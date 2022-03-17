using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
public class Epi8Control : MonoBehaviour
{
    public Animator Epi8Anim, WitchAnim;
    public apPortrait StrayApPortrait;
    public ParticleSystem BPPar;
    void Start()
    {
        StrayApPortrait.Initialize();
        StrayApPortrait.Play("ShortnessOfBreath", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        Epi8Anim.SetBool("2AniBool", false);
        WitchAnim.SetBool("PointingBool", false);
        WitchAnim.SetBool("IdleBool", true);
    }
    public void SOBAni()
    {
        StrayApPortrait.Play("ShortnessOfBreath", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void SOBtoMoveAni()
    {
        StrayApPortrait.Play("SOBtoMove", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void WitchIdle()
    {
        WitchAnim.SetBool("PointingBool", false);
        WitchAnim.SetBool("IdleBool", true);
    }
    public void WitchPointing()
    {
        WitchAnim.SetBool("PointingBool", true);
        WitchAnim.SetBool("IdleBool", false);
    }
    public void Epi8Anim2Ani()
    {
        Epi8Anim.SetBool("2AniBool", true);
    }
    public void BPParPlay()
    {
        BPPar.Play();
    }
    public void BPParStop()
    {
        BPPar.Stop();
    }
}
