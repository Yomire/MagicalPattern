using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class StrayConversation1 : MonoBehaviour
{
    public apPortrait StrayApPortrait;
    // Start is called before the first frame update
    void Start()
    {
        StrayApPortrait.Initialize();
        StrayApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }

    /*
    public void NextAni()
    {
        StrayApPortrait.Play("GetUpAniA", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void WakeAniFX()
    {
        StrayApPortrait.Play("GetUpAniB", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }*/
}
