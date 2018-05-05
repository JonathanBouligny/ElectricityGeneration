using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallController : MonoBehaviour {

    public bool on;
    public Component[] waterFallParticles;
    public int level;

    void Start()
    {
        level = 0;
        waterFallParticles = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            switch(level)
            {
                case 0:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                            part.Stop();
                    }
                    break;
                case 1:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                        if(part.CompareTag("Level1WaterFall"))
                        {
                            part.Play();
                        }
                        else
                        {
                            part.Stop();
                        }
                    }
                        
                break;
                case 2:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                        if (part.CompareTag("Level1WaterFall") || part.CompareTag("Level2WaterFall"))
                        {
                            part.Play();
                        }
                        else
                        {
                            part.Stop();
                        }
                    }
                    break;
                case 3:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                        if (part.CompareTag("Level1WaterFall") || part.CompareTag("Level2WaterFall") || part.CompareTag("Level3WaterFall"))
                        {
                            part.Play();
                        }
                        else
                        {
                            part.Stop();
                        }
                    }
                    break;
                case 4:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                        if (part.CompareTag("Level1WaterFall") || part.CompareTag("Level2WaterFall") || part.CompareTag("Level3WaterFall") || part.CompareTag("Level4WaterFall"))
                        {
                            part.Play();
                        }
                        else
                        {
                            part.Stop();
                        }
                    }
                    break;
                case 5:
                    foreach (ParticleSystem part in waterFallParticles)
                    {
                            part.Play();
                    }
                    break;
            }

        }
        else
        {
            foreach (ParticleSystem part in waterFallParticles)
                part.Stop();
        }
    }
}
