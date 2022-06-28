using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour
{
    private void OnEffectEnd()
    {
        Managers.UI.MakeWorldUI<WorldLevelUp>(transform.parent, "WorldLevelUp");
        Destroy(gameObject);
    }
}
