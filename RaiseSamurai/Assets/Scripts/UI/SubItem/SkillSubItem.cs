using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSubItem : UI_Base
{
    private TextMeshProUGUI _skillTitle = null;
    private TextMeshProUGUI _skillInfo = null;
    private GameObject _skillType = null;
    private Skills _skillData = null;
    enum SkillTexts
    {
        SkillTitle,
        SkillInfo,
    }
    enum SkillTypes
    {
        SkillType,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindText(typeof(SkillTexts));
        BindObject(typeof(SkillTypes));

        _skillTitle = GetText((int)SkillTexts.SkillTitle);
        _skillInfo = GetText((int)SkillTexts.SkillInfo);
        _skillType = GetObject((int)SkillTypes.SkillType);

        RefreshSkillInfo();

        return true;
    }

    public void SetSkillInfo(Skills skill)
    {
        _skillData = skill;
        RefreshSkillInfo();
    }

    public void OnClickSkill()
    {
        if (_skillData == null)
            return;

        Managers.Actor.SetPlayerSkill(_skillData);
        Managers.Data.SKills.Remove(_skillData.SkillId);
        Managers.UI.FindPopup<UI_ChoiceSkill>().ExitChoiceSkill();
    }

    public void RefreshSkillInfo()
    {
        if (_skillData == null)
            return;

        if (_init == false)
            return;


        GetText((int)SkillTexts.SkillTitle).text = _skillData.skillTitle;
        GetText((int)SkillTexts.SkillInfo).text = _skillData.skillInfo;

        switch (_skillData.skillType)
        {
            case Defines.SkillTypes.Normal:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_17");
                break;

            case Defines.SkillTypes.Fire:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_18");
                break;

            case Defines.SkillTypes.Water:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_08");
                break;

            case Defines.SkillTypes.Wind:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_10");
                break;

            case Defines.SkillTypes.Thunder:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_01");
                break;

            case Defines.SkillTypes.Poison:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/SpellBookPreface_13");
                break;
        }
    }
}
