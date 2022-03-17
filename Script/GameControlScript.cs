using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControlScript : MonoBehaviour
{
    public GameObject sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7 , sphere8, sphere9, gameOver, 
        PlayerObj, ContinuePanelObj, ContinuePos1, ContinuePos2, ContinuePos3, ContinuePos4, ContinuePos5, ContinuePos6, ContinuePos7, ContinuePos8, ContinuePos9, ContinuePos10,
        ContinuePos11, ContinuePos12, ContinuePos13, ContinuePos14, ContinuePos15, ContinuePos16, ContinuePos17, ContinuePos18, ContinuePos19, ContinuePos20, ContinuePos21;
    public static int health;
    public Animator PanelAnim;
    public string Flag, SkyFlag, TutorialFlag;
    bool isCalledOnce = false;
    public Pause PauseS;
    public Player PlayerS;
    public AudioSource SESource;
    public ScoreManager ScoreManagerS;
    public AdsLoadScript ALS;
    public LockPattern LPS;
    void Start()
    {
        health = 9;
        sphere1.gameObject.SetActive(true);
        sphere2.gameObject.SetActive(true);
        sphere3.gameObject.SetActive(true);
        sphere4.gameObject.SetActive(true);
        sphere5.gameObject.SetActive(true);
        sphere6.gameObject.SetActive(true);
        sphere7.gameObject.SetActive(true);
        sphere8.gameObject.SetActive(true);
        sphere9.gameObject.SetActive(true);
        Flag = "Continue";
        SkyFlag = "Ground";
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 9)
            health = 9;

        switch (health)
        {
            case 9:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(true);
                sphere6.gameObject.SetActive(true);
                sphere7.gameObject.SetActive(true);
                sphere8.gameObject.SetActive(true);
                sphere9.gameObject.SetActive(true);
                break;
            case 8:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(true);
                sphere6.gameObject.SetActive(true);
                sphere7.gameObject.SetActive(true);
                sphere8.gameObject.SetActive(true);
                sphere9.gameObject.SetActive(false);
                break;
            case 7:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(true);
                sphere6.gameObject.SetActive(true);
                sphere7.gameObject.SetActive(true);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 6:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(true);
                sphere6.gameObject.SetActive(true);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 5:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(true);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 4:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(true);
                sphere5.gameObject.SetActive(false);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 3:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(true);
                sphere4.gameObject.SetActive(false);
                sphere5.gameObject.SetActive(false);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 2:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(true);
                sphere3.gameObject.SetActive(false);
                sphere4.gameObject.SetActive(false);
                sphere5.gameObject.SetActive(false);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 1:
                sphere1.gameObject.SetActive(true);
                sphere2.gameObject.SetActive(false);
                sphere3.gameObject.SetActive(false);
                sphere4.gameObject.SetActive(false);
                sphere5.gameObject.SetActive(false);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
            case 0:
                sphere1.gameObject.SetActive(false);
                sphere2.gameObject.SetActive(false);
                sphere3.gameObject.SetActive(false);
                sphere4.gameObject.SetActive(false);
                sphere5.gameObject.SetActive(false);
                sphere6.gameObject.SetActive(false);
                sphere7.gameObject.SetActive(false);
                sphere8.gameObject.SetActive(false);
                sphere9.gameObject.SetActive(false);
                break;
        }

        if(health <= 0)
        {
            if(Flag == "Continue")
            {
                if (!isCalledOnce)
                {
                    if(TutorialFlag != "On")
                    {
                        ScoreManagerS.ResultMethod();
                        PlayerObj.SetActive(false);
                        ContinuePanelObj.SetActive(true);
                        isCalledOnce = true;
                        PanelAnim.SetBool("ContinueBool", true);
                        PanelAnim.SetBool("GetExpBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        Invoke("PauseMethod", 0.01f);
                        SESource.Pause();
                        //ScoreManagerS.ScoreSaveMethod();
                        ContinuePos1.SetActive(true);
                        ContinuePos2.SetActive(true);
                        ContinuePos3.SetActive(true);
                        ContinuePos4.SetActive(true);
                        ContinuePos5.SetActive(true);
                        ContinuePos6.SetActive(true);
                        ContinuePos7.SetActive(true);
                        ContinuePos8.SetActive(true);
                        ContinuePos9.SetActive(true);
                        ContinuePos10.SetActive(true);
                        ContinuePos11.SetActive(true);
                        ContinuePos12.SetActive(true);
                        ContinuePos13.SetActive(true);
                        ContinuePos14.SetActive(true);
                        ContinuePos15.SetActive(true);
                        ContinuePos16.SetActive(true);
                        ContinuePos17.SetActive(true);
                        ContinuePos18.SetActive(true);
                        ContinuePos19.SetActive(true);
                        ContinuePos20.SetActive(true);
                        ContinuePos21.SetActive(true);
                    }
                    if (TutorialFlag == "On")
                    {
                        FadeManager.Instance.LoadScene("HomeVer3", 0.5f);
                    }
                }
            }
            if (Flag == "GetExp")
            {
                if (!isCalledOnce)
                {
                    ScoreManagerS.ResultMethod();
                    PlayerObj.SetActive(false);
                    ContinuePanelObj.SetActive(true);
                    isCalledOnce = true;
                    PanelAnim.SetBool("ContinueBool", false);
                    PanelAnim.SetBool("GetExpEndBool", false);
                    PanelAnim.SetBool("GetExpBool", true);
                    PanelAnim.SetBool("GetExpEpiBool", false);
                    Invoke("PauseMethod", 0.01f);
                    SESource.Pause();
                    //ScoreManagerS.ScoreSaveMethod();
                }
            }
        }
    }
    public void NextFlagMethod()
    {
        isCalledOnce = false;
        Flag = "GetExp";
    }
    public void Episode8PanelActive()
    {
        if (Flag == "Continue")
        {
            ScoreManagerS.ResultMethod();
            PlayerObj.SetActive(false);
            ContinuePanelObj.SetActive(true);
            isCalledOnce = true;
            PanelAnim.SetBool("ContinueBool", true);
            PanelAnim.SetBool("GetExpBool", false);
            PanelAnim.SetBool("GetExpEndBool", false);
            PanelAnim.SetBool("GetExpEpiBool", false);
            Invoke("PauseMethod", 0.01f);
            SESource.Pause();
            //ScoreManagerS.ScoreSaveMethod();
            ContinuePos1.SetActive(true);
            ContinuePos2.SetActive(true);
            ContinuePos3.SetActive(true);
            ContinuePos4.SetActive(true);
            ContinuePos5.SetActive(true);
            ContinuePos6.SetActive(true);
            ContinuePos7.SetActive(true);
            ContinuePos8.SetActive(true);
            ContinuePos9.SetActive(true);
            ContinuePos10.SetActive(true);
            ContinuePos11.SetActive(true);
            ContinuePos12.SetActive(true);
            ContinuePos13.SetActive(true);
            ContinuePos14.SetActive(true);
            ContinuePos15.SetActive(true);
            ContinuePos16.SetActive(true);
            ContinuePos17.SetActive(true);
            ContinuePos18.SetActive(true);
            ContinuePos19.SetActive(true);
            ContinuePos20.SetActive(true);
            ContinuePos21.SetActive(true);
        }
        if (Flag == "GetExp")
        {
            ScoreManagerS.ResultMethod();
            PlayerObj.SetActive(false);
            ContinuePanelObj.SetActive(true);
            isCalledOnce = true;
            PanelAnim.SetBool("ContinueBool", false);
            PanelAnim.SetBool("GetExpEndBool", false);
            PanelAnim.SetBool("GetExpBool", true);
            PanelAnim.SetBool("GetExpEpiBool", false);
            Invoke("PauseMethod", 0.01f);
            SESource.Pause();
            //ScoreManagerS.ScoreSaveMethod();
        }
    }
    public void ContinueMethod()
    {
        //NextFlagMethod();
        PlayerObj.SetActive(true);
        PauseS.PauseOffMethod();
        health = 9;
        PlayerS.ContinueEnable();
        SESource.UnPause();
        ALS.AdsReLoad();
        if (SkyFlag == "Sky")
        {
            Invoke("ButterFlyMethod", 0.05f);
        }
        if (ContinuePos1.activeSelf)
        {
            PlayerObj.transform.position = ContinuePos1.transform.position;
        }
        if (ContinuePos1.activeSelf == false)
        {            
            if (ContinuePos2.activeSelf)
            {
                PlayerObj.transform.position = ContinuePos2.transform.position;
            }
            if (ContinuePos2.activeSelf == false)
            {
                if (ContinuePos3.activeSelf)
                {
                    PlayerObj.transform.position = ContinuePos3.transform.position;
                }
                if (ContinuePos3.activeSelf == false)
                {
                    if (ContinuePos4.activeSelf)
                    {
                        PlayerObj.transform.position = ContinuePos4.transform.position;
                    }
                    if (ContinuePos4.activeSelf == false)
                    {
                        if (ContinuePos5.activeSelf)
                        {
                            PlayerObj.transform.position = ContinuePos5.transform.position;
                        }
                        if (ContinuePos5.activeSelf == false)
                        {
                            if (ContinuePos6.activeSelf)
                            {
                                PlayerObj.transform.position = ContinuePos6.transform.position;
                            }
                            if (ContinuePos6.activeSelf == false)
                            {
                                if (ContinuePos7.activeSelf)
                                {
                                    PlayerObj.transform.position = ContinuePos7.transform.position;
                                }
                                if (ContinuePos7.activeSelf == false)
                                {
                                    if (ContinuePos8.activeSelf)
                                    {
                                        PlayerObj.transform.position = ContinuePos8.transform.position;
                                    }
                                    if (ContinuePos8.activeSelf == false)
                                    {
                                        if (ContinuePos9.activeSelf)
                                        {
                                            PlayerObj.transform.position = ContinuePos9.transform.position;
                                        }
                                        if (ContinuePos9.activeSelf == false)
                                        {
                                            if (ContinuePos10.activeSelf)
                                            {
                                                PlayerObj.transform.position = ContinuePos10.transform.position;
                                            }
                                            if (ContinuePos10.activeSelf == false)
                                            {
                                                if (ContinuePos11.activeSelf)
                                                {
                                                    PlayerObj.transform.position = ContinuePos11.transform.position;
                                                }
                                                if (ContinuePos11.activeSelf == false)
                                                {
                                                    if (ContinuePos12.activeSelf)
                                                    {
                                                        PlayerObj.transform.position = ContinuePos12.transform.position;
                                                    }
                                                    if (ContinuePos12.activeSelf == false)
                                                    {
                                                        if (ContinuePos13.activeSelf)
                                                        {
                                                            PlayerObj.transform.position = ContinuePos13.transform.position;
                                                        }
                                                        if (ContinuePos13.activeSelf == false)
                                                        {
                                                            if (ContinuePos14.activeSelf)
                                                            {
                                                                PlayerObj.transform.position = ContinuePos14.transform.position;
                                                            }
                                                            if (ContinuePos14.activeSelf == false)
                                                            {
                                                                if (ContinuePos15.activeSelf)
                                                                {
                                                                    PlayerObj.transform.position = ContinuePos15.transform.position;
                                                                }
                                                                if (ContinuePos15.activeSelf == false)
                                                                {
                                                                    if (ContinuePos16.activeSelf)
                                                                    {
                                                                        PlayerObj.transform.position = ContinuePos16.transform.position;
                                                                    }
                                                                    if (ContinuePos16.activeSelf == false)
                                                                    {
                                                                        if (ContinuePos17.activeSelf)
                                                                        {
                                                                            PlayerObj.transform.position = ContinuePos17.transform.position;
                                                                        }
                                                                        if (ContinuePos17.activeSelf == false)
                                                                        {
                                                                            if (ContinuePos18.activeSelf)
                                                                            {
                                                                                PlayerObj.transform.position = ContinuePos18.transform.position;
                                                                            }
                                                                            if (ContinuePos18.activeSelf == false)
                                                                            {
                                                                                if (ContinuePos19.activeSelf)
                                                                                {
                                                                                    PlayerObj.transform.position = ContinuePos19.transform.position;
                                                                                }
                                                                                if (ContinuePos19.activeSelf == false)
                                                                                {
                                                                                    if (ContinuePos20.activeSelf)
                                                                                    {
                                                                                        PlayerObj.transform.position = ContinuePos20.transform.position;
                                                                                    }
                                                                                    if (ContinuePos20.activeSelf == false)
                                                                                    {
                                                                                        if (ContinuePos21.activeSelf)
                                                                                        {
                                                                                            PlayerObj.transform.position = ContinuePos21.transform.position;
                                                                                        }
                                                                                        if (ContinuePos21.activeSelf == false)
                                                                                        {
                                                                                            PlayerObj.transform.position = ContinuePos1.transform.position;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void PauseMethod()
    {
        PauseS.PauseOnMethod();
    }
    public void SkyMethod()
    {
        SkyFlag = "Sky";
    }
    public void GroundMethod()
    {
        SkyFlag = "Ground";
    }
    public void ButterFlyMethod()
    {
        LPS.ButterflyPattern();
    }
}
