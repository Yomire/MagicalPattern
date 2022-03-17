using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableAni : MonoBehaviour
{
    private Animator ani;
    public float DisableDelay = 20.0f;
    CrackReturn Crackscript;
    public Animator VisibleAni;
    public GameObject VisibleCol;

    private void OnEnable()
    {
        ani = GetComponent<Animator>();
        ani.Play("Start", 0, 0.0f);
        Invoke("Disable", DisableDelay);
        Crackscript = GameObject.Find("Crack").GetComponent<CrackReturn>();

        //VisibleAni = this.transform.Find("Visible").GetComponent<Animator>();
    }

    void Disable()
    {
        Crackscript.PosReset();
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void VisibleScaleUp()
    {
        VisibleAni.Play("BigVisible", 0, 0.0f);
        VisibleCol.gameObject.SetActive(false);
    }
}
