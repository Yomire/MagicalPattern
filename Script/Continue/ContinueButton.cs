using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System.IO;
public class ContinueButton : MonoBehaviour
{
    public Image fillImage;
    public string Flag, TransitinoFlag, EpiFlag, MonarchFlag;
    public AudioSource SESource;
    public AudioClip EnterSound;
    bool isCalledOnce = false;
    public Animator PanelAnim;
    public GameControlScript GameConS;
    public ScoreManager ScoreManagerS;
    public GameObject AdsFailedObj, AdsObj;
    public AdsLoadScript ALS;
    public SnsShareScript SnsS;
    public Info1 info;
    private void Awake()
    {
        fillImage.fillAmount = 0;
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        if(AdsObj != null)
        {
            if (info.RemoveAdsFlag == "On")
            {
                AdsObj.SetActive(false);
            }
        }        
    }

    void Update()
    {
        if (Flag == "Minus")
        {
            fillImage.fillAmount -= 0.1f;
        }
        if (Flag == "Puls")
        {
            fillImage.fillAmount += 0.1f;
        }
        if (fillImage.fillAmount == 1f)
        {
            Flag = "Transition";
            if (TransitinoFlag == "NoContinue")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    PanelAnim.SetBool("GetExpBool", true);
                    PanelAnim.SetBool("ContinueBool", false);
                    //Debug.Log("test1");
                }
            }
            if(TransitinoFlag == "YesContinue")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    //SESource.PlayOneShot(EnterSound);
                    
                    if (info.RemoveAdsFlag != "On")
                    {
                        ALS.ShowReawrd();
                        ALS.FlagContinue();
                    }
                    if (info.RemoveAdsFlag == "On")
                    {
                        ALS.ContinueMethod();
                    }
                }
            }
            if (TransitinoFlag == "YesExpDouble")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    
                    //ScoreManagerS.ScoreSaveMethod();
                    //SnsS.CaptchaScreen();
                    if (info.RemoveAdsFlag != "On")
                    {
                        ALS.ShowReawrd();
                        ALS.FlagExpDouble();
                    }
                    if (info.RemoveAdsFlag == "On")
                    {
                        ALS.ExpDoubleMethod();
                    }
                }
            }
            if (TransitinoFlag == "NoExpDouble")
            {
                if (!isCalledOnce)
                {                    
                    if(EpiFlag != "On")
                    {
                        ScoreManagerS.ScoreSaveMethod();
                        isCalledOnce = true;
                        SESource.clip = EnterSound;
                        SESource.Play();
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpBool", false);
                        PanelAnim.SetBool("GetExpEndBool", true);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                    }
                    if (EpiFlag == "On")
                    {
                        ScoreManagerS.ScoreSaveMethod();
                        isCalledOnce = true;
                        SESource.clip = EnterSound;
                        SESource.Play();
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", true);
                    }
                    //ScoreManagerS.FlagChangeGetExp();
                    //SnsS.CaptchaScreen();
                }
            }
            if(TransitinoFlag == "SNS")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    //SnsS.ShareMethod();
                    SnsS.CaptchaScreen();
                    Invoke("FillReset", 1.0f);
                }
            }
            if (TransitinoFlag == "Home")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("HomeVer3", 1f);                    
                }
            }
            if (TransitinoFlag == "Episode1")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode1Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode2")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode2Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode3")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode3Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode4")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode4Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode5")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode5Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode6")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode6Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode7")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode7Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode8")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("Episode8Conversation", 1f);
                }
            }
            if (TransitinoFlag == "Episode9")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    if(MonarchFlag != "On")
                    {
                        FadeManager.Instance.LoadScene("Episode9ConversationBad", 1f);
                    }
                    if (MonarchFlag == "On")
                    {
                        FadeManager.Instance.LoadScene("Episode9ConversationGood", 1f);
                    }
                }
            }
            if (TransitinoFlag == "Ending")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("LastEnding", 1f);
                }
            }
        }
    }
    public void FillPuls()
    {
        Flag = "Puls";
    }
    public void FillMinus()
    {
        if (Flag != "Transition")
        {
            Flag = "Minus";
            isCalledOnce = false;
        }
    }
    public void FillReset()
    {
        fillImage.fillAmount = 0;
        Flag = "Minus";
        isCalledOnce = false;
    }
    public void EpiFlagMethod()
    {
        EpiFlag = "On";
    }
    public void MonaFlag()
    {
        MonarchFlag = "On";
        //Debug.Log(MonarchFlag);
    }
}
