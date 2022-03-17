using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPLaserS : MonoBehaviour
{
    public Animator BPLAnim;
    public ParticleSystem LaserPar;
    public AudioClip LaserClip;
    public AudioSource SEASource;
    public GameObject LaserColObj;
    void Start()
    {
        BPLAnim.SetBool("EndBool", false);
    }
    public void LaserEndMethod()
    {
        BPLAnim.SetBool("EndBool", true);
    }
    public void DisableMethod()
    {
        BPLAnim.SetBool("EndBool", false);
        this.gameObject.SetActive(false);
    }
    public void LaserShotMethod()
    {
        LaserPar.Play();
        LaserColObj.SetActive(true);
        //Flag = "Shake";
        SEASource.clip = LaserClip;
        SEASource.Play();
    }
}
