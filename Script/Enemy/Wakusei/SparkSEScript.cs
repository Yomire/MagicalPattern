using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSEScript : MonoBehaviour
{
    public int Count;
    public AudioClip SparkClip;
    public AudioSource SEASoursLoop;
    public void PlusMethd()
    {
        Count++;
        if(Count >= 1)
        {
            SEASoursLoop.Play();
        }
    }

    // Update is called once per frame
    public void MinusMethod()
    {
        Count--;
        if(Count <= 0)
        {
            SEASoursLoop.Stop();
        }
    }
}
