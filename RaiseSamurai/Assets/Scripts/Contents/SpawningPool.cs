using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    int _monsterCount = 0;

    [SerializeField]
    int _maxMonsterCount = 0;

    [SerializeField]
    float _spawnTime = 1.0f;

    public void AddMonsterCount(int value) { _monsterCount += value; }
    public void SetMaxMonsterCount(int count) { _maxMonsterCount = count; }
    public void SetSpawnTime(float time) { _spawnTime = time; }
    public int GetMonsterCount()
    {
        return _monsterCount;
    }
    public int GetMaxMonsterCount()
    {
        return _maxMonsterCount;
    }
    void Start()
    {
        Managers.Actor.OnSpawnEvent -= AddMonsterCount;
        Managers.Actor.OnSpawnEvent += AddMonsterCount;

        StartCoroutine("MonsterSpawn");
    }

    IEnumerator MonsterSpawn()
    {
        while (_monsterCount < _maxMonsterCount)
        {
            if (Managers.Actor._isGameOver)
                break;
            yield return new WaitForSeconds(_spawnTime);
            GameObject obj = Managers.Actor.Spawn(Defines.Actors.Monster, "Monster/FlyingEye/FlyingEye");
            obj.transform.position = new Vector3(5.0f, 0.15f, 0.0f);
        }

        StopCoroutine("MonsterSpawn");
    }
}
