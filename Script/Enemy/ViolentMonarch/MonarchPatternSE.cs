using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonarchPatternSE : MonoBehaviour
{
    public AudioSource SEASource;
    public AudioClip SEClip;
    public void SEMethod()
    {
        SEASource.clip = SEClip;
        SEASource.Play();
    }
}
