using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverSationManager : MonoBehaviour
{
    public Endless EndlessS;
    public Animator ani;
    public MonaEpisode1Ver2 MonaS;
    public string EpisodeFlag;
    void Start()
    {
        if(EpisodeFlag != "Null")
        {
            ani.SetBool("2AniBool", false);
        }        
        if(EpisodeFlag == "Episode4")
        {
            ani.SetBool("3AniBool", false);
        }        
    }
    public void GroundStop()
    {
        EndlessS.enabled = false;
    }
    public void GroundMove()
    {
        EndlessS.enabled = true;
    }
    public void NextAniMethod()
    {
        ani.SetBool("2AniBool", true);
        MonaS.WalkFlag();
    }
    public void MonaIdleMethod()
    {
        MonaS.IdleFlag();
    }
    public void NextAni2Method()
    {
        ani.SetBool("2AniBool", true);
    }
    public void NextAni3Method()
    {
        ani.SetBool("2AniBool", false);
        ani.SetBool("3AniBool", true);
    }
}
