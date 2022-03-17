﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TutorialMona1 : MonoBehaviour
{
    public apPortrait MonaApPortrait;
    void OnEnable()
    {
        MonaApPortrait.Initialize();
        MonaApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void InvertFX()
    {
        MonaApPortrait.Play("InvertAniB", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
}
