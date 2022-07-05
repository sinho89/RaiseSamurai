using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeEffect : UI_Base
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

        return true;
    }
    private void Update()
    {
        if (!_particleSystem.IsAlive() && _particleSystem != null)
        {
            Destroy(gameObject);
        }
    }
}
