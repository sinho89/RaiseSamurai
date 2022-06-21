using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines
{
    public enum Scenes
    {
        Unknown,
        Title,
        Game,
    }

    public enum Actors
    {
        Unknown,
        Player,
        Monster,
    }

    public enum ActorStates
    {
        Idle = 0,
        Move,
        Attack,
        Casting,
        Hit,
        Die,
    }

    public enum ObjectTypes
    {
        Players,
        Monsters,
        Bullets,
        UIs,
        Effects,
        Systems,
    }

    public enum ResourcsGroupType
    {
        Prefabs,
        Sprites,
    }
    public enum Sounds
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvents
    {
        Click,
        ClickUp,
        ClickDown,
        BeginDrag,
        Drag,
    }
}
