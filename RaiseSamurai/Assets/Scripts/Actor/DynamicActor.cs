using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicActor : BaseActor
{
    public Defines.ActorStates ActorStateType { get; protected set; } = Defines.ActorStates.Move;
    public Animator Actoranim { get; protected set; }

    protected WorldHPBar _hpBar = null;
    protected int _attackType = 0;
    protected bool _isMove = true;
    protected bool _isAttack = false;
    protected bool _isDeath = false;

    protected bool _isSplash = false;

    public float MoveSpeed { get; protected set; } = 1.0f;
    public int MaxHp { get; protected set; } = 100;
    public int Hp { get; protected set; } = 100;
    public int MaxMp { get; protected set; } = 50;
    public int Mp { get; protected set; } = 50;
    public int Attack { get; protected set; } = 10;
    public float AttackSpeed { get; protected set; } = 1.0f;
    public int Level { get; protected set; } = 1;
    public int MaxExp { get; protected set; } = 100;
    public int Lucky { get; protected set; } = 5;
    public int Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;

            int level = Level;
            while (true)
            {
                if (_exp < MaxExp)
                    break;
                level++;
                _exp -= MaxExp;
            }

            if (level != Level)
            {
                Managers.UI.MakeWorldUI<LevelUpEffect>(this.gameObject.transform, "LevelUpEffect");
                Level = level;
                Hp = MaxHp;
            }
        }
    }

    protected int _exp = 0;

    public bool GetSplash()
    {
        return _isSplash;
    }

    public void SkillSetInfo(Skills skill)
    {
        MaxHp += skill.MaxHp;
        Attack += skill.Attack;
        AttackSpeed += skill.AttackSpeed * 0.01f;
        Lucky += skill.Lucky;

        if (skill.Splash > 0 || _isSplash == true)
            _isSplash = true;
        else
            _isSplash = false;

        Managers.Actor.SetChoiceCount(Lucky);
    }

    public virtual void OnEnable()
    {
        Hp = MaxHp;
        Mp = MaxMp;
        ActorStateType = Defines.ActorStates.Move;
    }

    public virtual void Hit(int attack)
    {
        if(Hp > 0)
        {
            Hp -= attack;
            Managers.UI.MakeWorldUI<WorldDmg>(this.gameObject.transform, "WorldDmg").Damage = attack;
        }
    }

    protected override void Init()
    {
        base.Init();

        Actoranim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        AnimStateUpdate();
        HpBarCheck();
    }
    protected virtual void AnimStateUpdate()
    {   
        switch (ActorStateType)
        {
            case Defines.ActorStates.Move:
                _isMove = true;
                _isAttack = false;
                _isDeath = false;
                _attackType = 0;
                Actoranim.speed = 1.0f;
                break;

            case Defines.ActorStates.Attack1:
                _isMove = false;
                _isAttack = true;
                _isDeath = false;
                _attackType = 1;
                Actoranim.speed = AttackSpeed;
                break;

            case Defines.ActorStates.Attack2:
                _isMove = false;
                _isAttack = true;
                _isDeath = false;
                _attackType = 2;
                Actoranim.speed = AttackSpeed;
                break;

            case Defines.ActorStates.Death:
                _isMove = false;
                _isAttack = false;
                _isDeath = true;
                _attackType = 0;
                Actoranim.speed = 0.25f;
                break;

        }

        Actoranim.SetBool("IsMove", _isMove);
        Actoranim.SetBool("IsAttack", _isAttack);
        Actoranim.SetBool("IsDeath", _isDeath);
        Actoranim.SetInteger("AttackType", _attackType);
    }

    protected virtual void HpBarCheck()
    {
    }

    protected virtual void OnAttack()
    {
        Managers.Actor.AttackTarget(ActType, Attack);
    }
    protected virtual void OnDeath()
    {

    }
    public override void Clear()
    {

    }
}
