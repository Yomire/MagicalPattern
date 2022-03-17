using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class MonaObjScript : MonoBehaviour
{
    public apPortrait MonaApPortrait;
    public ParticleSystem HCPar, EnablePar;
    public GameObject LaserColObj;
    // Start is called before the first frame update
    void OnEnable()
    {
        MonaApPortrait.Initialize();
        MonaApPortrait.Play("HeartConnectionVer2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    // Update is called once per frame
    /*void Update()
    {
        MonaApPortrait.Initialize();
        MonaApPortrait.Play("HeartConnection", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }*/
    public void HeartConnectionFX()
    {
        HCPar.Play();
        LaserColObj.SetActive(true);
        MonaApPortrait.Play("HeartConnectionVer2B", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void MonaFalseFX()
    {
        MonaApPortrait.Play("False", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        EnablePar.Play();
        //this.gameObject.SetActive(false);
    }
    public void AnimPauseMethod()
    {
        MonaApPortrait.PauseAll();
    }
    public void AnimResumeMethod()
    {
        MonaApPortrait.ResumeAll();
    }
}
