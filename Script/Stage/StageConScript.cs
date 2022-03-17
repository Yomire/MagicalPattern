using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageConScript : MonoBehaviour
{
    public int EndCount = 0, EndCountMax = 100;
    public string flag = "A";
    public GameObject EnemyGenerater, EnemyGenerater2, EnemyGenerater3, EnemyGenerater4, EnemyGenerater5, EnemyGenerater6;
    public GameObject StartPos, StartPos2;
    private float currentTime = 0f, currentTime2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        EndCount = 0;
        Invoke("CountReset", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "A")
        {
            if (EndCount == 20)
            {
                if (EnemyGenerater2 != null)
                {
                    EnemyGenerater2.SetActive(true);
                }
            }
            if (EndCount == 30)
            {
                DestroyObjects();
                if (EnemyGenerater != null)
                {
                    EnemyGenerater.SetActive(false);
                }
                if (EnemyGenerater2 != null)
                {
                    EnemyGenerater2.SetActive(false);
                }
                flag = "B";
            }
            if (EndCount == 40)
            {
                DestroyObjects();
                EnemyGenerater3.SetActive(false);
                EnemyGenerater4.SetActive(false);
                EnemyGenerater5.SetActive(false);
                EnemyGenerater6.SetActive(false);
            }
        }
        if(flag == "B")
        {
            currentTime += Time.deltaTime;
            currentTime2 += Time.deltaTime;
            if (currentTime > 10)  //currentTime > Random.Range(spanLow, spanHigh)は、update中常に更新され、spanLowが叩き出されるため、ランダムの意味がない。
            {
                EnemyGenerater3.SetActive(true);
                EnemyGenerater4.SetActive(true);
            }
            if (currentTime > 3)
            {
                EnemyGenerater5.SetActive(false);
                EnemyGenerater6.SetActive(false);
            }
        }
    }

    public void CountMethod()
    {
        EndCount++;
    }

    public void DestroyObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Health-1");
        foreach(GameObject target in gameObjects)
        {
            target.SetActive(false);
        }
    }

    void CountReset()
    {
        EndCount = 0;
    }
}
