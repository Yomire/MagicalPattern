using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBPortalSE : MonoBehaviour
{
    public AudioClip BladeClip;
    public AudioSource SEASource;

    public void SEMethod()
    {
        SEASource.clip = BladeClip;
        SEASource.Play();
    }
}
