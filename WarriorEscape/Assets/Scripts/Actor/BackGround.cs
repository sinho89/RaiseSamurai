using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : StaticActor
{
    public Dictionary<int, MoveBackground> _moveLayers = new Dictionary<int, MoveBackground>();
    protected override void Init()
    {
        base.Init();

        SetMoveLayers();
    }

    private void SetMoveLayers()
    {
        int i = 0;

        MoveBackground[] moveLayers = GetComponentsInChildren<MoveBackground>();

        foreach (MoveBackground child in moveLayers)
        {
            _moveLayers.Add(i, child);
            i++;
        }
    }

    public void MoveBackgroundSwitch(bool Flag)
    {
        foreach(KeyValuePair<int, MoveBackground> child in _moveLayers)
        {
            child.Value._isMoving = Flag;
        }
    }
    protected override void Update()
    {
        base.Update();
    }

    public override void Clear()
    {

    }
}
