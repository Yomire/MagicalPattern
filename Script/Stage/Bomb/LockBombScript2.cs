using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBombScript2 : MonoBehaviour
{
    public Animator ani;
    public AudioClip DisableClip;
    public AudioSource SEASource;
    public Rigidbody2D rb;
    void OnEnable()
    {
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * 5;
        if (this.transform.localPosition.x <= -12)
        {
            this.gameObject.SetActive(false);
        }        
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AttackSPB" || trcol.gameObject.tag == "LockBombOn")
        {
            ani.SetBool("On", true);
            LevelGenerateScript.instance.DisableCountMethod();
        }
    }
    public void SEMethod()
    {
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
}
