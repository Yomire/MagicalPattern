using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate2 : MonoBehaviour
{
    public float span = 3f;
    public float High = 3f, High2 = 3f;
    public float Low = 0f, Low2 = 0f;
    public float PosXHigh = 20f;
    public float PosXLow = 20f;
    private float currentTime = 0f;
    public int Number;

    public void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
        {
            //Debug.LogFormat("{0}秒経過", span);
            currentTime = 0f;            
            Number = Random.Range(1, 2);
            if(Number == 1)
            {
                CreateGroundUp();
            }
            if (Number == 2)
            {
                CreateGroundDown();
            }
        }

        
        //GameObject clone = Instantiate(GroundPrefab, transform.position, transform.rotation);
    }

    void CreateGroundUp()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
    }
    void CreateGroundDown()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low2, High2));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
    }
}
