using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefab : MonoBehaviour
{
    public GameObject EffectPrefabA;
    public SpriteRenderer E_SpriteRenderer;
    public float StartScaleX = 0.5f, StartScaleY = 1f;
    public float ScaleHigh = 1;
    public float ScaleLow = 0;
    public float RotationHigh = 0;
    public float RotationLow = 0;
    public float timer = 0.0f;
    public float Destroytime = -1.0f;
    public float Alpha = 1;
    public string flag = "Null", ShakeFlag = "shake";
    public float ShakeX = 0.3f, ShakeY = 0.2f;


    private void OnEnable()
    {
        //Debug.Log("test");
        timer = 0;
        EffectPrefabA.transform.localScale = new Vector3(StartScaleX, StartScaleY, 0);
        //E_SpriteRenderer.color = new Color(205, 255, 175, 255);
        
        if(ShakeFlag == "shake")
        {
            ScreenShakeController.instance.StartShake(ShakeX, ShakeY);
        }
        Invoke("Disable", Destroytime);
        /*if(flag == "Shake")
        {
            ShakeMethod();
        }*/
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        EffectPrefabA.transform.localScale += new Vector3(ScaleLow, ScaleHigh, 0);
        /*E_SpriteRenderer.color -= new Color(0, 0, 0, Alpha);
        if (E_SpriteRenderer.color.a <= 0)
        {
            EffectPrefabA.SetActive(false);
            //Destroy(this.gameObject);
        }*/
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void ShakeMethod()
    {
        ScreenShakeController.instance.StartShake(0f, 0f);
    }
}
