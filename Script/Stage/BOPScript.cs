using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOPScript : MonoBehaviour
{
    public GameObject GTHPanelObj, PSVObj;
    public Animator GTHAnim, PSVAnim;
    public string Flag;
    public AudioSource SESource;
    public AudioClip EnterSound;
    void Start()
    {
        Flag = "PSVOn";
        GTHAnim.SetBool("GTHCloseBool", false);
        GTHAnim.SetBool("GTHOpenBool", true);

        PSVAnim.SetBool("OpenBool", true);
        PSVAnim.SetBool("CloseBool", false);
    }

    public void GTHOpenMethod()
    {
        GTHPanelObj.SetActive(true);
        GTHAnim.SetBool("GTHCloseBool", false);
        GTHAnim.SetBool("GTHOpenBool", true);
        SESource.clip = EnterSound;
        SESource.Play();
    }
    public void PSVOpenMethod()
    {
        if(Flag == "PSVOn")
        {
            Invoke("PSVFlagChenge", 0.5f);
            PSVObj.SetActive(true);
            PSVAnim.SetBool("CloseBool", false);
            PSVAnim.SetBool("OpenBool", true);
            SESource.clip = EnterSound;
            SESource.Play();
        }
        if (Flag == "PSVOff")
        {
            //Debug.Log("PSVOff");
            PSVAnim.SetBool("CloseBool", true);
            PSVAnim.SetBool("OpenBool", false);
            Invoke("PSVDisable", 1f);
            SESource.clip = EnterSound;
            SESource.Play();
        }
    }
    public void PSVDisable()
    {
        Flag = "PSVOn";
        PSVObj.SetActive(false);
    }
    public void PSVFlagChenge()
    {
        Flag = "PSVOff";
    }
}
