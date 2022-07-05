using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChoiceSkill : UI_Popup
{
    GameObject _choiceContent = null;
    Dictionary<int, SkillSubItem> _skills = new Dictionary<int, SkillSubItem>();

    enum ChoiceContentObject
    {
        ChoiceSkillContent,
    }

    public void OnEnable()
    {
        if (_choiceContent == null)
            return;

        Time.timeScale = 0f;

        _skills.Clear();

        foreach (Transform child in _choiceContent.transform)
            Managers.Resource.Destroy(child.gameObject);

        int randomSkill = 0;

        for (int i = 0; i < Managers.Actor.GetPlayerChoiceCount(); i++)
        {
            if (Managers.Data.SKills.Count <= i)
                break;

            SkillSubItem skill = Managers.UI.MakeSubItem<SkillSubItem>(_choiceContent.transform);

            while (true)
            {
                randomSkill = Random.Range(Managers.Data.SKills.Keys.First(), Managers.Data.SKills.Keys.Last() + 1);
                SkillSubItem skillCheck = null;
                Skills skillDataCheck = null;

                if (Managers.Actor.GetPlayerChoiceCount() <= 1 && Managers.Data.SKills[randomSkill].SkillId == Defines.SKILL_SACRIFICE)
                    continue;

                if (!_skills.TryGetValue(randomSkill, out skillCheck) && 
                    Managers.Data.SKills.TryGetValue(randomSkill, out skillDataCheck))
                    break;
            }

            _skills.Add(randomSkill, skill);
        }

        SetSkillChoiceUI();
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Time.timeScale = 0f;

        BindObject(typeof(ChoiceContentObject));

        _choiceContent = GetObject((int)ChoiceContentObject.ChoiceSkillContent);

        foreach (Transform child in _choiceContent.transform)
            Managers.Resource.Destroy(child.gameObject);

        int randomSkill = 0;

        for (int i = 0; i < Managers.Actor.GetPlayerChoiceCount(); i++)
        {
            if (Managers.Data.SKills.Count <= i)
                break;

            SkillSubItem skill = Managers.UI.MakeSubItem<SkillSubItem>(_choiceContent.transform);

            while (true)
            {
                randomSkill = Random.Range(Managers.Data.SKills.Keys.First(), Managers.Data.SKills.Keys.Last()+1);
                SkillSubItem skillCheck = null;
                Skills skillDataCheck = null;
                if (!_skills.TryGetValue(randomSkill, out skillCheck) && Managers.Data.SKills.TryGetValue(randomSkill, out skillDataCheck))
                    break;
            }

            _skills.Add(randomSkill, skill);
        }

        SetSkillChoiceUI();

        return true;

    }

    private void SetSkillChoiceUI()
    {
        foreach (KeyValuePair<int, SkillSubItem> skill in _skills)
        {
            Skills skilldata = null;
            if (Managers.Data.SKills.TryGetValue(skill.Key, out skilldata))
                skill.Value.SetSkillInfo(skilldata);
        }
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();

        foreach (Transform child in _choiceContent.transform)
            Managers.Resource.Destroy(child.gameObject);
    }
}
