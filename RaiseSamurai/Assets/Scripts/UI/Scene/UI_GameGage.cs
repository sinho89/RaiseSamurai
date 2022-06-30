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

    enum GageText
    {
        MCNT_Title,
    }

    private Slider[] _gagesArray = new Slider[(int)(Gages.MCNT_Bar) +1];

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindSlider(typeof(Gages));
        BindText(typeof(GageText));

        for(int i = 0; i < (int)(Gages.MCNT_Bar) +1; i++)
            _gagesArray[i] = GetSlider(i);

        return true;
    }

    private void Update()
    {
        _gagesArray[(int)Gages.HP_Bar].value = Managers.Actor.GetHpValue(transform.parent.gameObject);
        _gagesArray[(int)Gages.MP_Bar].value = Managers.Actor.GetMpValue(transform.parent.gameObject);
        _gagesArray[(int)Gages.EXP_Bar].value = Managers.Actor.GetExpValue(transform.parent.gameObject);

        int monsterCount = Managers.Actor.GetFieldMonsterCount();
        int monsterMaxCount = Managers.Actor.GetMaxMonsterCount();

        GetText((int)GageText.MCNT_Title).text = $"현재 몬스터 수 : {monsterCount}/{monsterMaxCount}";

        if (monsterCount >= monsterMaxCount / 3 * 2)
            GetText((int)GageText.MCNT_Title).color = new Color(1f, 0f, 0f);
        else if (monsterCount >= monsterMaxCount / 3 * 1)
            GetText((int)GageText.MCNT_Title).color = new Color(1f, 1f, 0f);
        else if (monsterCount >= monsterMaxCount / 3 * 0)
            GetText((int)GageText.MCNT_Title).color = new Color(0f, 1f, 0f);
    }
}
