using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines
{
    public const float MAX_STAGE_TIME = 300;

    public const int SKILL_ATTACK_POWER  = 1000; // ���� [�Ϲ�] - ���ݷ� 20 ���� ����
    public const int SKILL_ATTACK_SPEED  = 1001; // �г� [�Ϲ�] - ���ݼӵ� 20% ���� ����
    public const int SKILL_MAX_HP_UP     = 1002; // �ұ� [�Ϲ�] - �ִ�ü�� 100 ���� ����
    public const int SKILL_LUCKY_UP      = 1003; // ��� [�Ϲ�] - ��ų ������ +1 ���� ����
    public const int SKILL_EARTH_QUAKE   = 1004; // ���� [����] - �⺻������ ������������ ����� ( ���ݷ� ���� ���� ���� )
    public const int SKILL_CRAZY         = 1005; // ���� [����] - ���ݼӵ� 100% ���� ���� ( �ִ� ü�� ���� ���� ���� ) 
    public const int SKILL_POWER_WALL    = 1006; // ö�� [���] - �ִ�ü�� 200% ���� ���� ( ���� �ӵ� ���� ���� ���� )
    public const int SKILL_SACRIFICE     = 1007; // ��� [���] - ��ų ������ -1 ���� ���� ( ���ݷ� 100 ���� )
    public const int SKILL_HEAL          = 1008; // ġ�� [���] - 30�ʰ� 1�ʿ� �ѹ��� �ִ� ü���� 5% ȸ��
    public const int SKILL_POISON_ATTACK = 1009; // �͵����� [����] - 30�ʰ� 1�ʿ� �ѹ��� ��ü ������ �ִ� ü���� 10% ����


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
