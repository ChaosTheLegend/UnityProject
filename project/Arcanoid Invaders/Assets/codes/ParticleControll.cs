using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControll : MonoBehaviour {

    public ParticleSystem EngineParticleMain;
    public ParticleSystem EngineParticleHit;
    public ParticleSystem DeathParticle;
    public Transform[] engines;
    ParticleSystem[] activeparticles;
    public float ExplosionRad; 

    private void Start()
    {
        activeparticles = new ParticleSystem[engines.Length];
        for (int i = 0;i<engines.Length; i++)
        {
            activeparticles[i] = Instantiate(EngineParticleMain, engines[i].position, engines[i].rotation);
            activeparticles[i].transform.parent = engines[i];
        }
    }

    public void Hit(Transform HitPoint)
    {
        for (int i = 0; i < activeparticles.Length; i++)
        {
            if (activeparticles[i].transform.parent == HitPoint)
            {
                Destroy(activeparticles[i]);
                activeparticles[i] = Instantiate(EngineParticleHit, HitPoint.position, HitPoint.rotation);
                activeparticles[i].transform.parent = HitPoint;
            }
        }
    }
    public void death()
    {
        Destroy(Instantiate(DeathParticle, transform.position + Random.insideUnitSphere * ExplosionRad, transform.rotation).gameObject, 0.2f);
    }
    
}
