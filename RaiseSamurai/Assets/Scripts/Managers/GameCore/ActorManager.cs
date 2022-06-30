using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class ActorManager
{
    GameObject _player = null;
    BackGround _backGround = null;
    DynamicActor _playerBehavior = null;

    static long _monsterID = 0;

    Dictionary<long, GameObject> _monsters = new Dictionary<long, GameObject>();
    Dictionary<long, GameObject> _targetMonsters = new Dictionary<long, GameObject>();

    private int _playerSkillChoiceCount = 3;

    public Action<int> OnSpawnEvent;
    public int _playerKillCount = 0;
    public bool _isGameOver = false;

    public GameObject GetPlayer() { return _player; }
    public BackGround GetBackGround() { return _backGround; }
    public SpawningPool SpawningPool { get; set; }

    public void SetPlayerSkill(Skills skill)
    {
        _playerBehavior.SkillSetInfo(skill);
        Time.timeScale = 1f;
    }

    public void SetChoiceCount(int Lucky)
    {
        int choiceCount = Lucky / 10;
        _playerSkillChoiceCount += choiceCount;
    }

    public int GetFieldMonsterCount() { return _monsters.Count(); }
    public int GetMaxMonsterCount() { return SpawningPool.GetMaxMonsterCount(); }
    public int GetPlayerChoiceCount() { return _playerSkillChoiceCount; }

    public Defines.Actors GetActorsType(GameObject go)
    {
        BaseActor ac = go.GetComponent<BaseActor>();
        if (ac == null)
            return Defines.Actors.Unknown;

        return ac.ActType;
    }

    public float GetHpValue(GameObject go)
    {
        DynamicActor ac = go.GetComponent<DynamicActor>();
        if (ac == null)
            return -1;
        return (float)ac.Hp / (float)ac.MaxHp;
    }

    public float GetMpValue(GameObject go)
    {
        DynamicActor ac = go.GetComponent<DynamicActor>();
        if (ac == null)
            return -1;
        return (float)ac.Mp / (float)ac.MaxMp;
    }

    public float GetExpValue(GameObject go)
    {
        DynamicActor ac = go.GetComponent<DynamicActor>();
        if (ac == null)
            return -1;
        return ac.Exp / ac.MaxExp;
    }

    public float GetMcntValue()
    {
        return (float)SpawningPool.GetMonsterCount() / 100f;
    }

    public int GetTargetListCount()
    {
        return _targetMonsters.Count;
    }

    public bool IsEmptyPlayerTarget()
    {
        if (_targetMonsters.Count > 0)
            return false;
        return true;
    }

    public bool IsMonsterAliveCheck(GameObject go)
    {
        DynamicActor daMonster = go.GetOrAddComponent<DynamicActor>();
        if (daMonster.Hp > 0)
            return true;
        return false;
    }

    public void AttackTarget(Defines.Actors type, int attack)
    {
        if(type == Defines.Actors.Player)
        {
            if (IsEmptyPlayerTarget())
                return;
            foreach (var target in _targetMonsters.ToList())
            {
                DynamicActor daMonster = target.Value.GetOrAddComponent<DynamicActor>();
                if(daMonster.Hp > 0)
                {
                    daMonster.Hit(attack);
                    if(!_playerBehavior.GetSplash())
                        break;
                }
            }

            if(_playerBehavior.GetSplash())
                Managers.UI.MakeWorldUI<TiamatEffect>(_player.transform, "TiamatEffect");
        }
        else if(type == Defines.Actors.Monster)
        {
            _player.GetOrAddComponent<DynamicActor>().Hit(attack);

        }
    }

    public void InTargetDictionary(GameObject go)
    {
        if (!IsMonsterAliveCheck(go))
            return;

        _targetMonsters.Add(go.GetComponent<MonsterController>()._uniqueID, go);
    }
    public void OutTargetDictionary(GameObject go)
    {
        foreach (var item in _targetMonsters.ToList()) // ToList()
        {
            if (item.Key == go.GetComponent<MonsterController>()._uniqueID)
            {
                _targetMonsters.Remove(item.Key);
                ++_playerKillCount;
                _playerBehavior.Exp += 10;
                break;
            }
        }
    }

    public GameObject Spawn(Defines.Actors type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Defines.Actors.BackGround:
                _backGround = go.GetComponent<BackGround>();
                break;
            case Defines.Actors.Player:
                _player = go;
                _playerBehavior = go.GetComponent<DynamicActor>();
                break;

            case Defines.Actors.Monster:
                {
                    _monsterID++;
                    _monsters.Add(_monsterID, go);
                    go.GetComponent<MonsterController>()._uniqueID = _monsterID;
                    if(OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(1);
                }
                break;
        }

        return go;
    }
    public void Despawn(GameObject go)
    {
        Defines.Actors type = GetActorsType(go);

        switch (type)
        {
            case Defines.Actors.BackGround:
                {
                    if (_backGround != null)
                        _backGround = null;
                }
                break;
            case Defines.Actors.Player:
                {
                    if (_player == go)
                        _player = null;
                    if(_playerBehavior != null)
                        _playerBehavior = null;
                }
                break;
            case Defines.Actors.Monster:
                {
                    if (_monsters.ContainsKey(_monsterID))
                    {
                        _monsters.Remove(_monsterID);
                        if (OnSpawnEvent != null)
                            OnSpawnEvent.Invoke(-1);
                    }

                }
                break;
        }

        Managers.Resource.Destroy(go);
    }
    public void Clear()
    {
        _targetMonsters.Clear();

        foreach (var m in _monsters.ToList()) // ToList()
        {
            _monsters.Remove(m.Key);
            Managers.Resource.Destroy(m.Value);
        }

        _monsterID = 0;
    }
}
