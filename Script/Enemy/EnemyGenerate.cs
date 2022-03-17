using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public float span = 3f;
    public float spanHigh = 3f;
    public float spanLow = 3f;
    public float High = 3f;
    public float Low = 0f;
    public float PosXHigh = 20f;
    public float PosXLow = 20f;
    public float ScaleHigh = 1f;
    public float ScaleLow = 1f;
    public float RotationHigh = 0;
    public float RotationLow = 0;
    private float currentTime = 0f;
    public GameObject GroundPrefab;
    public string flag = "Bat";

    public void Update()
    {
        currentTime += Time.deltaTime;
        if(flag == "Bat")
        {
            if (currentTime > span)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
            {
                //Debug.LogFormat("{0}秒経過", span);
                currentTime = 0f;
                BatCreate();
                span = Random.Range(spanLow, spanHigh);
            }
        }
        if (flag == "RotateBlade")
        {
            if (currentTime > span)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
            {
                //Debug.LogFormat("{0}秒経過", span);
                currentTime = 0f;
                RotateBladeCreate();
                span = Random.Range(spanLow, spanHigh);
            }
        }
        if (flag == "Step")
        {
            if (currentTime > span)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
            {
                //Debug.LogFormat("{0}秒経過", span);
                currentTime = 0f;
                StepGenerate();
            }
        }
    }

    public void BatCreate()
    {
        GameObject obj = ObjectPooler11.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
        obj.transform.localScale = Vector3.one * Random.Range(ScaleLow, ScaleHigh);
    }

    public void RotateBladeCreate()
    {
        GameObject obj = ObjectPooler18.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
        obj.transform.localScale = Vector3.one * Random.Range(ScaleLow, ScaleHigh);
    }

    public void StepGenerate()
    {
        GameObject obj = ObjectPooler19.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
}