using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEColScript : MonoBehaviour
{
    public AudioClip SEColClip;
    public AudioSource SEASource;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground2" || col.gameObject.tag == "Health-1" || col.gameObject.tag == "Health-1B" || col.gameObject.tag == "Health-3")
        {
            SEASource.PlayOneShot(SEColClip);
            //Debug.Log("test");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground2" || col.gameObject.tag == "Health-1" || col.gameObject.tag == "Health-1B" || col.gameObject.tag == "Health-3")
        {
            //Debug.Log("test2");
            SEASource.PlayOneShot(SEColClip);
        }
    }
}
