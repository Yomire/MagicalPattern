using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLaserB : MonoBehaviour
{
    public GameObject LaserColObj;
    public Player PS;
    public MonaObjScript MOS;
    public void OnParticleSystemStopped()
    {
        MOS.MonaFalseFX();
        //Debug.Log("test");
        PS.MonaMove();
        PS.HeartConnectionEndFX();
        LaserColObj.SetActive(false);
    }
}
