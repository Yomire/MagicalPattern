using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigScript : MonoBehaviour
{
    public Animator SBAnim, CPAnim;
    public string Flag;
    public GameObject ConfigPanelObj;
    public AudioSource SESource;
    public AudioClip EnterSound;
    public EndlessScoreVer2 ESV2Script;
    void Start()
    {
        Flag = "ConfigClose";
        SBAnim.SetBool("BigBool", false);
        SBAnim.SetBool("MiniBool", false);
        CPAnim.SetBool("CloseBool", false);
    }

    public void ConfigButton()
    {
        ESV2Script.SaveMethod();
        if (Flag == "ConfigClose")
        {
            SESource.PlayOneShot(EnterSound);
            ConfigPanelObj.SetActive(true);
            SBAnim.SetBool("BigBool", true);
            SBAnim.SetBool("MiniBool", false);
            CPAnim.SetBool("CloseBool", false);
            Flag = "ConfigNull";
            Invoke("FlagChangeOpen", 1f);
        }
        if(Flag == "ConfigOpen")
        {
            SESource.PlayOneShot(EnterSound);
            SBAnim.SetBool("BigBool", false);
            SBAnim.SetBool("MiniBool", true);
            CPAnim.SetBool("CloseBool", true);
            Flag = "ConfigNull";
            Invoke("FlagChangeClose", 1f);
        }

    }
    public void FlagChangeOpen()
    {
        Flag = "ConfigOpen";
    }
    public void FlagChangeClose()
    {
        Flag = "ConfigClose";
    }
}
