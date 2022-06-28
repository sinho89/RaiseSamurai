using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DynamicActor
{
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Hit(int attack)
    {
        base.Hit(attack);

        if (Hp <= 0)
        {
            Hp = 0;
            if (ActorStateType != Defines.ActorStates.Death)
            {
                ActorStateType = Defines.ActorStates.Death;
                Managers.Sound.Play("BGM/GameOverBgm", Defines.Sounds.Bgm);
            }
        }
    }

    protected override void Init()
    {
        base.Init();
        ActType = Defines.Actors.Player;
        MaxHp = 50;
        Hp = 50;
        Attack = 50;
        AttackSpeed = 2.0f;

        if(Managers.Scene.CurrentScene.SceneType == Defines.Scenes.Game)
            _hpBar = Managers.UI.MakeWorldUI<WorldHPBar>(this.gameObject.transform, "WorldHpBar");
    }
    protected override void Update()
    {
        if (Managers.Actor._isGameOver) return;
        base.Update();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Managers.Actor._isGameOver) return;
        Managers.Actor.InTargetDictionary(collision.gameObject);
        Managers.UI.BackGroundLayersMoveSwitch(false);
        ActorStateType = Utils.GetRandAttackType(2);
    }

    protected override void OnAttack()
    {
        base.OnAttack();
    }

    protected override void OnDeath()
    {

    }

    private void OnGameOver()
    {
        Actoranim.speed = 0f;
        Managers.Actor._isGameOver = true;
        //Managers.Scene._MovingScene = Defines.Scenes.Title;
        //Managers.Scene._isSceneChange = true;
    }

    private void OnMoveStart()
    {
        Managers.UI.BackGroundLayersMoveSwitch(true);
    }
    private void OnAttackStart()
    {
        Managers.Sound.Play("Effect/PlayerAttack", Defines.Sounds.Effect);
    }

    private void OnAttackFinish()
    {
        if (Managers.Actor.GetTargetListCount() <= 0)
        {
            Managers.UI.BackGroundLayersMoveSwitch(true);
            ActorStateType = Defines.ActorStates.Move;
        }

    }

    public override void Clear()
    {

    }
}
