using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnOff : MonoBehaviour
{
    public string Flag;
    public ParticleSystem ParOnOff1, ParOnOff2, ParOnOff3, ParOnOff4, ParOnOff5, ParOnOff6, ParOnOff7;
    public AudioSource SEASourceLoop;
    public AudioClip GearClip;
    public SparkSEScript SSS;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if(Flag == "SparkleFlag")
        {
            if (trcol.gameObject.tag == "Sparkle")
            {
                if (ParOnOff1 != null)
                {
                    ParOnOff1.Play();
                    if(SSS != null)
                    {
                        SSS.PlusMethd();
                    }                    
                }
                if (ParOnOff2 != null)
                {
                    ParOnOff2.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
                if (ParOnOff3 != null)
                {
                    ParOnOff3.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
                if (ParOnOff4 != null)
                {
                    ParOnOff4.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
                if (ParOnOff5 != null)
                {
                    ParOnOff5.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
                if (ParOnOff6 != null)
                {
                    ParOnOff6.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
                if (ParOnOff7 != null)
                {
                    ParOnOff7.Play();
                    if (SSS != null)
                    {
                        SSS.PlusMethd();
                    }
                }
            }
        }                
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (Flag == "SparkleFlag")
        {
            if (trcol.gameObject.tag == "Sparkle")
            {
                if (ParOnOff1 != null)
                {
                    ParOnOff1.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff2 != null)
                {
                    ParOnOff2.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff3 != null)
                {
                    ParOnOff3.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff4 != null)
                {
                    ParOnOff4.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff5 != null)
                {
                    ParOnOff5.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff6 != null)
                {
                    ParOnOff6.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
                if (ParOnOff7 != null)
                {
                    ParOnOff7.Stop();
                    if (SSS != null)
                    {
                        SSS.MinusMethod();
                    }
                }
            }
        }            
    }
}
