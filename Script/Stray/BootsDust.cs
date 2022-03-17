using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsDust : MonoBehaviour
{
    public ParticleSystem RunDust;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            RunDust.Play();
        }
        if (col.gameObject.tag == "AnyPause")
        {
            RunDust.playbackSpeed = 0;
        }
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            RunDust.Stop();
        }
        if (col.gameObject.tag == "AnyPause")
        {
            RunDust.playbackSpeed = 1;
        }
    }
}
