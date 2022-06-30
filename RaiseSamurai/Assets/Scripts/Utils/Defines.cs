using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines
{
    public const int SKILL_DATA_FRONT_COUNT = 1000;
    public const int SKILL_DATA_MAX_COUNT = 1012;
    public enum Scenes
    {
        Unknown,
        Title,
        Game,
    }

    public enum Actors
    {
        Unknown,
        BackGround,
        Player,
        Monster,
        Effect,
    }

    public enum ActorStates
    {
        Move = 0,
        Attack1,
        Attack2,
        Death,
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

    public enum SkillTypes
    {
        Normal,
        Fire,
        Water,
        Wind,
        Thunder,
        Poison
    }

    public enum ComponentType
    {
        Unknown,
        Button,
        Image,
        Sprite,
        Text,
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
