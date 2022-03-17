using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndComplete : MonoBehaviour
{
    public ParticleSystem particle;
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
    public void ParticleMethod()
    {
        particle.Play();
    }
}
