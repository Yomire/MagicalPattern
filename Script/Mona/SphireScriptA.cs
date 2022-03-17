using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphireScriptA : MonoBehaviour
{
    public ParticleSystem DisablePar, IdlePar;
    public GameObject MonaObj;
    public AudioSource audioSource;

    public void OnParticleSystemStopped()
    {
        if (MonaObj.activeInHierarchy)
        {
            Invoke("MonaFalse", 0.05f);
        }
        if (!MonaObj.activeInHierarchy)
        {
            Invoke("MonaActive", 0.05f);
        }
        //MonaObj.enabled = !MonaObj.enabled;
        DisablePar.Play();
        audioSource.Play();
    }
    public void MonaFalse()
    {
        IdlePar.Play();
        MonaObj.SetActive(false);
    }
    public void MonaActive()
    {
        IdlePar.Stop();
        MonaObj.SetActive(true);
    }
}
