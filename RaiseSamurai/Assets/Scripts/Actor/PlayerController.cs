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
    }
    protected override void Init()
    {
        base.Init();
        ActType = Defines.Actors.Player;
        MaxHp = 100;
        Hp = 100;
        Attack = 50;
        AttackSpeed = 3.0f;
    }
    protected override void Update()
    {
        base.Update();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    private void OnMoveStart()
    {
        Managers.UI.BackGroundLayersMoveSwitch(true);
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
