using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class MeowBackScript : MonoBehaviour
{
    public apPortrait StrayApPortrait;
    public string flag = "Idle";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Idle")
        {
            StrayApPortrait.Play("BackMeowAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            StrayApPortrait.StopLayer(2);
            StrayApPortrait.StopLayer(3);
        }
        if (flag == "Speak")
        {
            StrayApPortrait.Play("BackMeowAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            StrayApPortrait.Play("BackMeowMouse", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            StrayApPortrait.StopLayer(3);
        }
        if (flag == "Cry")
        {
            StrayApPortrait.Play("BackMeowAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            StrayApPortrait.Play("BackMeowMouse", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            StrayApPortrait.Play("BackMeowTear", 3, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
    }
}
