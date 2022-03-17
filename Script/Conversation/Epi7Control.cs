using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
public class Epi7Control : MonoBehaviour
{
    public Animator MonaAnim, Epi7Anim, WitchAnim, CamAnim;
    public apPortrait StrayApPortrait;
    public ParticleSystem PortalPar, BPPar;
    void Start()
    {
        StrayApPortrait.Initialize();
        StrayApPortrait.Play("StandAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        MonaAnim.SetBool("IdleBool", true);
        MonaAnim.SetBool("WalkBool", false);
        Epi7Anim.SetBool("3AniBool", false);
        Epi7Anim.SetBool("4AniBool", false);
        WitchAnim.SetBool("PointingBool", false);
        WitchAnim.SetBool("IdleBool", true);
        CamAnim.SetBool("CamAni1Bool", true);
        CamAnim.SetBool("CamAni2Bool", false);
        CamAnim.SetBool("CamAni3Bool", false);
    }

    public void RunAni()
    {
        StrayApPortrait.Play("StrayRun", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void MonaWalk()
    {
        MonaAnim.SetBool("IdleBool", false);
        MonaAnim.SetBool("WalkBool", true);
    }
    public void MonaIdle()
    {
        MonaAnim.SetBool("IdleBool", true);
        MonaAnim.SetBool("WalkBool", false);
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
    public void CamAni1()
    {
        CamAnim.SetBool("CamAni1Bool", true);
        CamAnim.SetBool("CamAni2Bool", false);
        CamAnim.SetBool("CamAni3Bool", false);
    }
    public void CamAni2()
    {
        CamAnim.SetBool("CamAni1Bool", false);
        CamAnim.SetBool("CamAni2Bool", true);
        CamAnim.SetBool("CamAni3Bool", false);
    }
    public void CamAni3()
    {
        CamAnim.SetBool("CamAni1Bool", false);
        CamAnim.SetBool("CamAni2Bool", false);
        CamAnim.SetBool("CamAni3Bool", true);
    }
    public void Epi7Anim3Ani()
    {
        Epi7Anim.SetBool("3AniBool", true);
        Epi7Anim.SetBool("4AniBool", false);
    }
    public void Epi7Anim4Ani()
    {
        Epi7Anim.SetBool("3AniBool", false);
        Epi7Anim.SetBool("4AniBool", true);
    }
    public void PParPlay()
    {
        PortalPar.Play();
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
