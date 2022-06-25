using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActorManager
{
    GameObject _player = null;
    DynamicActor _playerBehavior = null;

    static long _monsterID = 0;

    Dictionary<long, GameObject> _monsters = new Dictionary<long, GameObject>();
    Dictionary<long, GameObject> _targetMonsters = new Dictionary<long, GameObject>();


    public Action<int> OnSpawnEvent;

    public GameObject GetPlayer() { return _player; }
    public SpawningPool SpawningPool { get; set; }
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
        return ac.Hp / ac.MaxHp;
    }

    public float GetMpValue(GameObject go)
    {
        DynamicActor ac = go.GetComponent<DynamicActor>();
        if (ac == null)
            return -1;
        return ac.Mp / ac.MaxMp;
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
                    //break;
                }
            }
        }
        else if(type == Defines.Actors.Monster)
        {
            //_player.GetOrAddComponent<DynamicActor>().Hit(attack);
        }
    }

    public void InTargetDictionary(GameObject go)
    {
        if (!IsMonsterAliveCheck(go))
            return;

        long dicKey = Utils.GetDictionayFindKeyByValue(_monsters, go);
        _targetMonsters.Add(dicKey, go);
        Debug.Log(dicKey);
    }
    public void OutTargetDictionary(GameObject go)
    {
        long dicKey = Utils.GetDictionayFindKeyByValue(_targetMonsters, go);
        foreach (var item in _targetMonsters.ToList()) // ToList()
        {
            if (item.Key == dicKey)
            {
                _targetMonsters.Remove(item.Key);
                break;
            }
        }
    }

    public GameObject Spawn(Defines.Actors type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Defines.Actors.Player:
                _player = go;
                _playerBehavior = go.GetComponent<DynamicActor>();
                break;

            case Defines.Actors.Monster:
                {
                    _monsterID++;
                    _monsters.Add(_monsterID, go);
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
            case Defines.Actors.Player:
                {
                    if (_player == go)
                        _player = null;
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

    }
}
