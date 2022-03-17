using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
public class Epi8Stray : MonoBehaviour
{
    public apPortrait StrayApPortrait;
    // Start is called before the first frame update
    void Start()
    {
        StrayApPortrait.Initialize();
    }

    public void StandFX()
    {
        StrayApPortrait.Play("StandAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
}
