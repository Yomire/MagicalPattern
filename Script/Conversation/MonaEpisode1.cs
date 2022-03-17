using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
public class MonaEpisode1 : MonoBehaviour
{
    public apPortrait MonaApPortrait;
    public float span = 1f;
    public string Flag;
    void Awake()
    {
        MonaApPortrait.Initialize();
        MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        Flag = "IdleRight";
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(span);
            if(Flag == "IdleRight")
            {
                transform.localScale = new Vector3(-0.28f, 0.28f, 1);
                Invoke("IdleLeftFlag", 0.1f);
            }
            if (Flag == "IdleLeft")
            {
                transform.localScale = new Vector3(0.28f, 0.28f, 1);
                Invoke("IdleRightFlag", 0.1f);
            }
            /*
            if (Flag == "Walk")
            {
                transform.localScale = new Vector3(0.28f, 0.28f, 1);
                //Invoke("IdleRightFlag", 0.1f);
            }
            */
        }
    }
    public void IdleLeftFlag()
    {
        if (Flag == "IdleRight")
        {
            Flag = "IdleLeft";
        }            
    }
    public void IdleRightFlag()
    {
        if (Flag == "IdleLeft")
        {
            Flag = "IdleRight";
        }            
    }
    public void WalkFlag()
    {
        transform.localScale = new Vector3(0.28f, 0.28f, 1);
        Flag = "Walk";
        MonaApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void WalkFlag2()
    {
        transform.localScale = new Vector3(-0.28f, 0.28f, 1);
        Flag = "Walk";
        MonaApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void IdleFlag()
    {
        transform.localScale = new Vector3(0.28f, 0.28f, 1);
        Flag = "Idle";
        MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void IdleFlag2()
    {
        transform.localScale = new Vector3(-0.28f, 0.28f, 1);
        Flag = "Idle";
        MonaApPortrait.Play("IdleAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
}
