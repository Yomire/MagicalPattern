using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBlockGenerate : MonoBehaviour
{
    public float High = 4f;
    public float Low = -3f;
    public float PosXHigh = 20f;
    public float PosXLow = 20f;
    public float ScaleHigh = 1f;
    public float ScaleLow = 1f;
    public int LockBlockGenerateNumber = 0;
    public string flag = "Side";

    // Update is called once per frame
    public void GenerateMethod()
    {
        if(flag == "Side")
        {
            LockBlockGenerateNumber = Random.Range(0, 3);
            if (LockBlockGenerateNumber == 1)
            {
                LockBlock1Generate();
            }
            if (LockBlockGenerateNumber == 2)
            {
                LockBlock2Generate();
            }
        }
        if (flag == "Up")
        {
            LockBlockGenerateNumber = Random.Range(0, 3);
            if (LockBlockGenerateNumber == 1)
            {
                LockBlock1UpGenerate();
            }
            if (LockBlockGenerateNumber == 2)
            {
                LockBlock2UpGenerate();
            }
        }
    }

    public void LockBlock1Generate()
    {
        GameObject obj = ObjectPooler23.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        obj.SetActive(true);
    }
    public void LockBlock2Generate()
    {
        GameObject obj = ObjectPooler24.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        obj.SetActive(true);
    }
    public void LockBlock1UpGenerate()
    {
        GameObject obj = ObjectPooler23.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.rotation = this.gameObject.transform.rotation;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        obj.SetActive(true);
    }
    public void LockBlock2UpGenerate()
    {
        GameObject obj = ObjectPooler24.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.rotation = this.gameObject.transform.rotation;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        obj.SetActive(true);
    }
}
