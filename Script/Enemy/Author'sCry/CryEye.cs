using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryEye : MonoBehaviour
{
    //public ACryScript ACS;
    public ACScript ACSc;
    public GameObject DamageObj;
    public Renderer DamageRend;

    void OnEnable()
    {
        //DamageObj.SetActive(false);
        DamageRend.enabled = false;
    }

    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            /*
            DamageObj.SetActive(true);
            Invoke("DamageEnd", 0.1f);
            ACS.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            */
            Invoke("DamageEnd", 0.2f);
            ACSc.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            DamageRend.enabled = true;
        }
        if (trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
        {
            Invoke("DamageEnd", 0.2f);
            ACSc.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            DamageRend.enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            /*
            DamageObj.SetActive(true);
            Invoke("DamageEnd", 0.1f);
            ACS.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            */
            Invoke("DamageEnd", 0.2f);
            ACSc.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            DamageRend.enabled = true;
        }
        if (trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
        {
            Invoke("DamageEnd", 0.2f);
            ACSc.DamageMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            DamageRend.enabled = true;
        }
    }

    public void DamageEnd()
    {
        DamageRend.enabled = false;
    }
}
