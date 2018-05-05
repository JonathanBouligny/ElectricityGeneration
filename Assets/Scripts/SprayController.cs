using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour {

    public bool on;
    public Component[] sprayParticleGenerator;

    void Start()
    {
        sprayParticleGenerator = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
		if(on)
        {
            foreach (ParticleSystem part in sprayParticleGenerator)
                part.Play();
        }
        else
        {
            foreach (ParticleSystem part in sprayParticleGenerator)
                part.Stop();
        }
	}
}
