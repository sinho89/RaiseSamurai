using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseActor : MonoBehaviour
{
    public Defines.Actors ActType { get; private set; } = Defines.Actors.Unknown;
}
