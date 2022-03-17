using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendHand : MonoBehaviour
{
    public Animator HAni;
    public Player PScript;

    // Start is called before the first frame update
    void OnEnable()
    {
        HAni.SetBool("ExtendBool", true);
        HAni.SetBool("UnExtendBool", false);
        HAni.SetLayerWeight(1, 1f);
        Invoke("UnExtendMethod", 10.0f);
    }

    public void ExtendMethod()
    {
        HAni.SetLayerWeight(1, 1f);
        HAni.SetBool("UnExtendBool", false);
        HAni.SetBool("ExtendBool", true);
    }
    public void UnExtendMethod()
    {
        HAni.SetLayerWeight(1, 1f);
        HAni.SetBool("ExtendBool", false);
        HAni.SetBool("UnExtendBool", true);
    }
    
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
    public void DisableFX()
    {
        PScript.Disable();
        Invoke("Disable", 0.1f);        
    }
}
