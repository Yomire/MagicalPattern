using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixCol : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Health-1")
        {
            audioSource.PlayOneShot(HitSound);
        }
        if (trcol.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(HitSound);
        }
        if (trcol.gameObject.tag == "Boss")
        {
            audioSource.PlayOneShot(HitSound);
        }
    }
}
