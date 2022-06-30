using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parsing Json

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}
public class DataManager
{
    public Dictionary<int, Data.Skills> SKills { get; private set; } = new Dictionary<int, Data.Skills>();
    public Dictionary<int, Data.PlayerStats> PlayerStats { get; private set; } = new Dictionary<int, Data.PlayerStats>();

    public void Init()
    {
        PlayerStats = LoadJson<Data.PlayerStatData, int, Data.PlayerStats>("PlayerStatData").MakeDict();
        SKills = LoadJson<Data.SkillData, int, Data.Skills>("SkillData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        //return JsonUtility.FromJson<Loader>(textAsset.text);
        return JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }
    public void Clear()
    {

    }
}
