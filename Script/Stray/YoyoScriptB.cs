using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScriptB : MonoBehaviour
{
    private Animator YoyoAni;
    // Start is called before the first frame update
    void OnEnable()
    {
        YoyoAni = GetComponent<Animator>();
        YoyoAni.Play("Roop", 0, 0.0f);
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
