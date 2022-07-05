using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines
{
    public const float MAX_STAGE_TIME = 300;

    public const int SKILL_ATTACK_POWER  = 1000; // 괴력 [일반] - 공격력 20 영구 증가
    public const int SKILL_ATTACK_SPEED  = 1001; // 분노 [일반] - 공격속도 20% 영구 증가
    public const int SKILL_MAX_HP_UP     = 1002; // 불굴 [일반] - 최대체력 100 영구 증가
    public const int SKILL_LUCKY_UP      = 1003; // 행운 [일반] - 스킬 선택지 +1 영구 증가
    public const int SKILL_EARTH_QUAKE   = 1004; // 지진 [전설] - 기본공격이 범위공격으로 변경됨 ( 공격력 절반 영구 감소 )
    public const int SKILL_CRAZY         = 1005; // 광분 [전설] - 공격속도 100% 영구 증가 ( 최대 체력 절반 영구 감소 ) 
    public const int SKILL_POWER_WALL    = 1006; // 철벽 [희귀] - 최대체력 200% 영구 증가 ( 공격 속도 절반 영구 감소 )
    public const int SKILL_SACRIFICE     = 1007; // 희생 [희귀] - 스킬 선택지 -1 영구 감소 ( 공격력 100 증가 )
    public const int SKILL_HEAL          = 1008; // 치유 [희귀] - 30초간 1초에 한번씩 최대 체력의 5% 회복
    public const int SKILL_POISON_ATTACK = 1009; // 맹독지대 [전설] - 30초간 1초에 한번씩 전체 적들의 최대 체력의 10% 공격


    public enum Scenes
    {
        Unknown = 0,
        Title,
        Game,
    }

    public enum Actors
    {
        Unknown = 0,
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
        Players = 0,
        Monsters,
        Bullets,
        UIs,
        Effects,
        Systems,
    }

    public enum SkillTypes
    {
        Normal = 0,
        Red,
        Blue,
        Green
    }

    public enum SpecialTypes
    {
        Default = 0,
        EarthQuake,
        Crazy,
        PowerWall,
        Heal,
        PoisonAttack,
    }

    public enum ComponentType
    {
        Unknown = 0,
        Button,
        Image,
        Sprite,
        Text,
    }

    public enum ResourcsGroupType
    {
        Prefabs = 0,
        Sprites,
    }
    public enum Sounds
    {
        Bgm = 0,
        Effect,
        MaxCount,
    }

    public enum UIEvents
    {
        Click = 0,
        ClickUp,
        ClickDown,
        BeginDrag,
        Drag,
    }
}
