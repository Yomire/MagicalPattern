using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnabledParticle : MonoBehaviour
{
    public ParticleSystem particle;
    public float DisableTime = 0.2f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        particle.Play();
        Invoke("Disable", DisableTime);
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
