using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActor : MonoBehaviour
{
    public Defines.Actors ActType { get; protected set; } = Defines.Actors.Unknown;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        
    }

    protected virtual void Update()
    {

    }
    public abstract void Clear();
}
