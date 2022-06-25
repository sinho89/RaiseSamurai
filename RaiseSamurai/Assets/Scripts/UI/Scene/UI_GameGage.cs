using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameGage : UI_Scene
{
    enum Gages
    {
        HP_Bar,
        MP_Bar,
        EXP_Bar,
        MCNT_Bar,
    }

    private Slider[] _gagesArray = new Slider[(int)(Gages.MCNT_Bar) +1];

    public override void Init()
    {
        BindSlider(typeof(Gages));

        for(int i = 0; i < (int)(Gages.MCNT_Bar) +1; i++)
            _gagesArray[i] = GetSlider(i);
    }

    private void Update()
    {
        _gagesArray[(int)Gages.HP_Bar].value = Managers.Actor.GetHpValue(transform.parent.gameObject);
        _gagesArray[(int)Gages.MP_Bar].value = Managers.Actor.GetMpValue(transform.parent.gameObject);
        _gagesArray[(int)Gages.EXP_Bar].value = Managers.Actor.GetExpValue(transform.parent.gameObject);
        _gagesArray[(int)Gages.MCNT_Bar].value = Managers.Actor.GetMcntValue();
    }
}
