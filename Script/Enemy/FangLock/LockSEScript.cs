using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSEScript : MonoBehaviour
{
    public AudioClip SEClip;
    public AudioSource SEASours;
    public string Flag;

    // Start is called before the first frame update
    void Start()
    {
        SEASours = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "LockSE")
        {
            if (Flag == "SEOn")
            {
                SEASours.clip = SEClip;
                SEASours.Play();
            }
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "LockSE")
        {
            if(Flag == "SEOn")
            {
                SEASours.clip = SEClip;
                SEASours.Play();
            }
        }
    }
    void OnBecameVisible()
    {
        //Debug.Log("test");
        Flag = "SEOn";
        //SEASours.mute = false;
    }
    void OnBecameInvisible()
    {
        //Debug.Log("test2");
        Flag = "SEOff";
        //SEASours.mute = true;
    }
}
