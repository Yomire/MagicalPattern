using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GTHButton : MonoBehaviour
{
    bool isCalledOnce = false;
    public Image fillImage;
    public string Flag, TransitinoFlag;
    public AudioSource SESource;
    public AudioClip EnterSound;
    public Animator PanelAnim;
    public GameObject GTHObj;
    private void Awake()
    {
        fillImage.fillAmount = 0;
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
            if (TransitinoFlag == "NoHome")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    PanelAnim.SetBool("GTHCloseBool", true);
                    PanelAnim.SetBool("GTHOpenBool", false);
                    Invoke("DisableMethod", 1f);
                    Invoke("FillReset", 0.5f);
                }
            }
            if (TransitinoFlag == "YesHome")
            {
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    SESource.clip = EnterSound;
                    SESource.Play();
                    FadeManager.Instance.LoadScene("HomeVer3", 1f);
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
    public void DisableMethod()
    {
        GTHObj.SetActive(false);
    }
}
