using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class EpisodeManager : MonoBehaviour
{
    public Info1 info;
    public AudioSource BGMASours;
    public float span = 3f, GPosXEnd, GroundMoveX;
    public string Flag, EpisodeFlag;
    //public int Number, DisableCount;
    public GameObject LevelObj, StartUIObj, EndUIObj, GroundObj, HintObj, ScorePanelObj;
    public LevelGenerateScript LGS;
    public ParticleSystem LevelPar;
    public Collider2D CompleteCol;
    public ADBossScript ADBS;
    public ACScript ACS;
    public ARageScriptVer2 ARS;
    public int Count;
    public Animator PanelAnim;
    public ContinueButton ConBS;
    public ScoreManager ScoreManagerS;
    public AdsLoadScript AdsLS;
    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        BGMASours.volume = info.BGMVolume;
        Flag = "Start";
        if (EpisodeFlag == "Episode6")
        {
            LevelObj.SetActive(true);
        }
    }
    void Update()
    {
        if (EpisodeFlag == "Episode6")
        {
            if (Count >= 3)
            {
                if (GroundObj.transform.localPosition.x >= GPosXEnd)
                {
                    GroundObj.transform.Translate(GroundMoveX, 0, 0);
                }
                if (GroundObj.transform.localPosition.x <= GPosXEnd)
                {
                    GroundObj.transform.position = new Vector3(30, 0, 0);
                    HintObj.SetActive(false);
                    EpisodeFlag = "Episode6B";
                }
            }                
        }            
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(span);
            if (Flag == "Start")
            {
                LevelPar.Play();
                StartUIObj.SetActive(true);                
                Invoke("LevelFlag", 0.1f);
                if (EpisodeFlag == "Episode1")
                {
                    LevelObj.SetActive(true);
                    LGS.LevelOnEnableTGGB();
                }
                if (EpisodeFlag == "Episode2")
                {
                    LevelObj.SetActive(true);
                    LGS.LevelOnEnableLock();
                }
                if (EpisodeFlag == "Episode3")
                {
                    LevelObj.SetActive(true);
                    ADBS.DisapprovalEnable();
                }
                if (EpisodeFlag == "Episode4")
                {
                    LevelObj.SetActive(true);
                    ACS.ACEnable();
                }
                if (EpisodeFlag == "Episode5")
                {
                    LevelObj.SetActive(true);
                    LGS.LevelOnEnableMix2();
                }
                if (EpisodeFlag == "Episode7")
                {
                    LevelObj.SetActive(true);
                    ARS.ARageEnable();
                }
                if (EpisodeFlag == "Episode8")
                {
                    LevelObj.SetActive(true);
                    LGS.LevelOnEnableMix3();
                }
            }
            if (EpisodeFlag == "Episode6")
            {
                //Debug.Log("tet");
                if (Count <= 9)
                {
                    Count += 1;
                }
                if (Count <= 1)
                {
                    HintObj.SetActive(true);
                }
                if (Count >= 3)
                {
                    LGS.LevelOnEnableSkyMix();
                }
            }
            if (LevelObj.activeSelf == false)
            {
                if (Flag == "Level")
                {
                    CompleteCol.enabled = true;
                    LevelPar.Play();
                    EndUIObj.SetActive(true);
                    Invoke("EndFlag", 0.1f);
                }
                else if(Flag == "End")
                {
                    if (EpisodeFlag == "Episode1")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode1Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode2")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode2Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode3")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode3Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode4")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode4Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode5")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode5Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode6B")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode6Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode7")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode7Conversation", 0.5f);
                    }
                    if (EpisodeFlag == "Episode8")
                    {
                        Invoke("CompleteFlag", 0.01f);
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        ScoreManagerS.ResultMethod();
                        //FadeManager.Instance.LoadScene("Episode7Conversation", 0.5f);
                    }
                    /*
                    if (EpisodeFlag == "Episode9")
                    {

                    }
                    */
                }
            }
        }
    }
    public void LevelFlag()
    {
        Flag = "Level";
    }
    public void EndFlag()
    {
        Flag = "End";
    }
    public void CompleteFlag()
    {
        Flag = "Complete";
    }
}
