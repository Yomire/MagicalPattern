using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonaEpisode1Ver2 : MonoBehaviour
{
    //public apPortrait MonaApPortrait;
    public Animator ani;
    public float span = 1f;
    public string Flag;
    void Awake()
    {
        //MonaApPortrait.Initialize();
        //MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        Flag = "IdleRight";
        ani.SetBool("IdleBool", true);
        ani.SetBool("WalkBool", false);
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(span);
            if(Flag == "IdleRight")
            {
                transform.localScale = new Vector3(-0.21f, 0.21f, 1);
                Invoke("IdleLeftFlag", 0.1f);
            }
            if (Flag == "IdleLeft")
            {
                transform.localScale = new Vector3(0.21f, 0.21f, 1);
                Invoke("IdleRightFlag", 0.1f);
            }
        }
    }
    public void IdleLeftFlag()
    {
        Flag = "IdleLeft";
    }
    public void IdleRightFlag()
    {
        Flag = "IdleRight";
    }
    public void WalkFlag()
    {
        transform.localScale = new Vector3(0.21f, 0.21f, 1);
        Flag = "Walk";
        //MonaApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        ani.SetBool("IdleBool", false);
        ani.SetBool("WalkBool", true);
    }
    public void WalkFlag2()
    {
        transform.localScale = new Vector3(-0.21f, 0.21f, 1);
        Flag = "Walk";
        ani.SetBool("IdleBool", false);
        ani.SetBool("WalkBool", true);
        //MonaApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void IdleFlag()
    {
        transform.localScale = new Vector3(0.21f, 0.21f, 1);
        Flag = "Idle";
        ani.SetBool("IdleBool", true);
        ani.SetBool("WalkBool", false);
        //MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void IdleFlag2()
    {
        transform.localScale = new Vector3(-0.21f, 0.21f, 1);
        Flag = "Idle";
        ani.SetBool("IdleBool", true);
        ani.SetBool("WalkBool", false);
        //MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
}
