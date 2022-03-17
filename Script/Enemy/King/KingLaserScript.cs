using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingLaserScript : MonoBehaviour
{
    public GameObject LaserColObj;
    public KingCoffinScript KS;
    public KingSkyScript KSkyS;
    //public ParticleSystem EndPar;
    public BPLaserS BPLS;
    public void OnParticleSystemStopped()
    {
        if(KS != null)
        {
            KS.LaserEndMethod();
            LaserColObj.SetActive(false);
            //EndPar.Play();
        }
        if (KSkyS != null)
        {
            KSkyS.LaserEndMethod();
            LaserColObj.SetActive(false);
            //EndPar.Play();
        }
        if (BPLS != null)
        {
            BPLS.LaserEndMethod();
            LaserColObj.SetActive(false);
            //EndPar.Play();
        }
    }
}
