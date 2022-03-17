using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleEnableScript : MonoBehaviour
{
    public GameObject SparkleObj;
    public AudioClip SparkClip;
    public AudioSource SEASoursLoop;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            SEASoursLoop.clip = SparkClip;
            SEASoursLoop.Play();
            SEASoursLoop.pitch = 3;
            SparkleObj.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            SEASoursLoop.Stop();
            SEASoursLoop.pitch = 1;
            SparkleObj.gameObject.SetActive(false);
        }
    }
}
