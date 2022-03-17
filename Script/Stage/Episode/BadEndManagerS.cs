using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndManagerS : MonoBehaviour
{
    public Animator ani;
    public GameObject DEffectObj;

    public void DeathAniMethod()
    {
        DEffectObj.SetActive(true);
        ani.Play("EmbraceAni2", 0, 0.0f);
        ScreenShakeController.instance.StartShake(.4f, .4f);
    }
}
