using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMonaB : MonoBehaviour
{
    private Animator ani;
    public ParticleSystem EnablePar, IdlePar;
    //public GameObject MonaObj;
    //public AudioSource audioSource;
    public StrayConversation scriptStray;

    void OnEnable()
    {
        ani = GetComponent<Animator>();
    }
    public void MonaActive()
    {
        //IdlePar.Stop();
        EnablePar.Play();
        //audioSource.Play();
        //MonaObj.SetActive(true);
        StrayWake();
    }
    /* 
    public void FallAni()
    {
        ani.Play("ColliderIdle", 0, 0.0f);
    }
    */
    public void StrayWake()
    {
        scriptStray.NextAni();
    }
}
