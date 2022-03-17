using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    public Player PScript;
    public FifthCoinGene CoinScript;
    public AudioClip SEClip;
    public AudioSource SEASours;
    public string FlagSE = "On";

    public void OnParticleCollision(GameObject pcol)
    {
        if(pcol.gameObject.tag == "Player")
        {
            //Debug.Log("test");
            PScript.DamageMethod();
        }
        if(CoinScript != null)
        {
            if (pcol.gameObject.tag == "Ground")
            {
                Shake();
                CoinScript.CoinGene();
                
                if(FlagSE == "On")
                {
                    SEASours.clip = SEClip;
                    SEASours.Play();
                    FlagSE = "Off";
                }
            }
        }
    }

    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    public void OnParticleSystemStopped()
    {
        if (FlagSE == "Off")
        {
            SEASours.Stop();
            FlagSE = "On";
        }
    }
}
