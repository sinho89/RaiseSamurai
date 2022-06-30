using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : UI_Base
{
    ParticleSystem _particleSystem;
    enum Particle
    {
        EffectParticle,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(Particle));

        _particleSystem = GetObject((int)Particle.EffectParticle).GetComponent<ParticleSystem>();
        Managers.UI.MakeWorldUI<WorldLevelUp>(transform.parent, "WorldLevelUp");

        return true;


    }
    private void Update()
    {
        if(!_particleSystem.IsAlive() && _particleSystem != null)
        {
            if (Managers.Data.SKills.Count > 0)
                Managers.UI.ShowPopupUI<UI_ChoiceSkill>("UI_ChoiceSkill");
            Destroy(gameObject);
        }
    }
}
