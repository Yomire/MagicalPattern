using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class StrayConversation : MonoBehaviour
{
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        //StrayApPortrait.Initialize();
        //StrayApPortrait.Play("SleepAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }

    // Update is called once per frame
    public void NextAni()
    {
        Anim.Play("Epi0GetUpAni", 0, 0.0f);
        //StrayApPortrait.Play("GetUpAniA", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    /*
    public void WakeAniFX()
    {
        StrayApPortrait.Play("GetUpAniB", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    */
}
