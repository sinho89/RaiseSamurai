using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackGround : UI_Scene
{
    enum Layers
    {
        LAYER00, Layer_00_1, Layer_00_2,
        LAYER01, Layer_01_1, Layer_01_2,
        LAYER02, Layer_02_1, Layer_02_2,
        LAYER03, Layer_03_1, Layer_03_2,
        LAYER04, Layer_04_1, Layer_04_2,
        LAYER05, Layer_05_1, Layer_05_2,
        LAYER06, Layer_06_1, Layer_06_2,
        LAYER07, Layer_07_1, Layer_07_2,
        LAYER08, Layer_08_1, Layer_08_2,
        LAYER09, Layer_09_1, Layer_09_2,
    }

    public override void Init()
    {
        BindObject(typeof(Layers));

        for(int i = 0; i <= (int)(Layers.Layer_09_2); i++)
            if (i % 3 != 0)
                Managers.UI.BackGroundLayers.Add(GetObject(i).gameObject.GetOrAddComponent<MoveBackground>());
    }
}
