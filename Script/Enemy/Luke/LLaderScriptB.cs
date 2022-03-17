using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLaderScriptB : MonoBehaviour
{
    public GameObject LaserColObj;
    public LukeScript LS;
    public ParticleSystem EndPar;

    public void OnParticleSystemStopped()
    {
        LS.LaserEndMethod();
        LaserColObj.SetActive(false);
        EndPar.Play();
    }
}
