using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
using UnityEngine.SceneManagement;
public class StrayEpisode1 : MonoBehaviour
{
    public apPortrait StrayApPortrait;
    public string EpisodeFlag;
    public GameObject EffectPrefab;
    void Awake()
    {
        StrayApPortrait.Initialize();
    }
    void Start()
    {       
        if (EpisodeFlag == "Episode1")
        {
            StrayApPortrait.Play("ShortnessOfBreath", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
        if (EpisodeFlag == "Episode4")
        {
            StrayApPortrait.Play("StrayRun", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
        if (EpisodeFlag == "Episode4B")
        {
            StrayApPortrait.Play("SleepAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            //Debug.Log("tst");
        }
    }
    public void SOBAniMethod()
    {
        StrayApPortrait.Play("SOBtoMove", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void StandFX()
    {
        StrayApPortrait.Play("StandAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void WalkAniMethod()
    {
        StrayApPortrait.Play("WalkAni", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if(EpisodeFlag == "Episode4")
        {
            if (trcol.gameObject.tag == "Health-1")
            {
                Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
                Invoke("DisableMethod", 0.1f);
                Invoke("NextScene", 2f);
            }
        }        
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
    public void NextScene()
    {
        FadeManager.Instance.LoadScene("Episode4Conversation2", 0.5f);
    }
}
