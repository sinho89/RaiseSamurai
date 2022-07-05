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
        Managers.UI.FindPopup<UI_ChoiceSkill>().gameObject.SetActive(false);
    }

    public void RefreshSkillInfo()
    {
        if (_skillData == null)
            return;

        if (_init == false)
            return;


        GetText((int)SkillTexts.SkillTitle).text = _skillData.skillTitle;
        GetText((int)SkillTexts.SkillInfo).text = _skillData.skillInfo;

        switch(_skillData.SkillLevel)
        {
            case 1:
                GetText((int)SkillTexts.SkillTitle).color = new Color(1f, 1f, 1f);
                break;
            case 2:
                GetText((int)SkillTexts.SkillTitle).color = new Color(0f, 1f, 0f);
                break;
            case 3:
                GetText((int)SkillTexts.SkillTitle).color = new Color(0f, 0.8f, 1f);
                break;
            case 4:
                GetText((int)SkillTexts.SkillTitle).color = new Color(1f, 1f, 0f);
                break;
        }

        switch (_skillData.skillType)
        {
            case Defines.SkillTypes.Normal:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/Thief_Halting");
                break;

            case Defines.SkillTypes.Red:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/Flame_Original");
                break;

            case Defines.SkillTypes.Blue:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/Flame_Blue");
                break;

            case Defines.SkillTypes.Green:
                GetObject((int)SkillTypes.SkillType).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>("Sprites/UI/Flame_Green");
                break;
        }
    }
}
