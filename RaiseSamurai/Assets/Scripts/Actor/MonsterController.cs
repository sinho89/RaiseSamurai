using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : DynamicActor
{
    private bool _isTargeting = false;
    public long _uniqueID = 0;
    public override void OnEnable()
    {
        base.OnEnable();

        _isTargeting = false;
    }

    public override void Hit(int attack)
    {
        base.Hit(attack);

        if (Hp <= 0)
        {
            if (ActorStateType != Defines.ActorStates.Death)
            {
                ActorStateType = Defines.ActorStates.Death;
                Managers.Actor.OutTargetDictionary(this.gameObject);
                _isTargeting = false;
            }
        }
    }
    protected override void Init()
    {
        base.Init();

        ActType = Defines.Actors.Monster;
        MaxHp = 100;
        Hp = 100;
        Attack = 5;
        MoveSpeed = 1.3f;

        _hpBar = Managers.UI.MakeWorldUI<WorldHPBar>(this.gameObject.transform, "WorldHpBar");
    }
    protected override void Update()
    {
        if (Managers.Actor._isGameOver)
            ActorStateType = Defines.ActorStates.Move;

        base.Update();
        Move();
    }

    private void Move()
    {
        if ((ActorStateType == Defines.ActorStates.Move && _isTargeting == false) ||
            (ActorStateType == Defines.ActorStates.Death && Managers.Actor.IsEmptyPlayerTarget()) ||
            Managers.Actor._isGameOver)
        {
            /*_moveX = transform.position.x;
            _moveX -= MoveSpeed * Time.deltaTime;*/
            transform.Translate(new Vector3(-MoveSpeed * Time.deltaTime, 0, 0));

            if(transform.position.x < -10.0f)
                Managers.Actor.Despawn(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Managers.Actor._isGameOver) return;

        _isTargeting = true;
        ActorStateType = Utils.GetRandAttackType(2);
    }

    protected override void OnDeath()
    {
        Managers.Actor.Despawn(this.gameObject);
    }
    public override void Clear()
    {

    }
}
