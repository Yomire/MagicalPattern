using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
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

    public void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
        {
            //Debug.LogFormat("{0}秒経過", span);
            currentTime = 0f;
            CreateStep();
            span = Random.Range(spanLow, spanHigh);
        }

        
        //GameObject clone = Instantiate(GroundPrefab, transform.position, transform.rotation);
    }

    void CreateStep()
    {
        GameObject obj = ObjectPooler2.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
        obj.transform.localScale = Vector3.one * Random.Range(ScaleLow, ScaleHigh);
        obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
        //Instantiate(GroundPrefab, new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High)), GroundPrefab.transform.rotation);
        //GroundPrefab.transform.localScale = Vector3.one * Random.Range(ScaleLow, ScaleHigh);
        //GroundPrefab.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
    }
}
