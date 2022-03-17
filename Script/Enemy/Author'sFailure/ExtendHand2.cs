using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class ExtendHand2 : MonoBehaviour
{
    public apPortrait ExtendApPortrait;
    public string flag = "UnExtend";

    // Start is called before the first frame update
    void Update()
    {
        ExtendApPortrait.Play("Idle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }

    // Update is called once per frame
    /*void Update()
    {
        if(flag == "Extend")
        {
            ExtendApPortrait.Play("Idle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            ExtendApPortrait.Play("UnExtend", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
        if (flag == "UnExtend")
        {
            ExtendApPortrait.Play("Idle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            ExtendApPortrait.Play("Extend", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
    }
    public void ExtendMethod()
    {
        flag = "Extend";
    }
    public void UnExtendMethod()
    {
        flag = "UnExtend";
    }*/
}
