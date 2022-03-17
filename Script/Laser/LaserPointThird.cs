using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointThird : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;
    public LineRenderer Line;
    public float StartWidthScale = 1.0f;
    public float EndWidthScale = 1.0f;
    public float span = 3f;
    //public float Horizon = 1.0f;
    private float currentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0, StartPos.transform.position);
        Line.SetPosition(1, EndPos.transform.position);
        Line.startWidth = StartWidthScale;
        Line.endWidth = EndWidthScale;
        Line.SetColors(Color.yellow, Color.red);
        //第一引数には始点、第二引数には終点の色を渡します。

        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            //Debug.LogFormat("{0}秒経過", span);
            currentTime = 0f;
            CreateCol();
        }

        //EndPos.transform.Translate(Horizon, 0, 0);
    }

    void CreateCol()
    {
        GameObject obj = ObjectPooler21.current.GetPooledObject();
        if (obj == null) return;
        if(obj != null)
        {
            obj.transform.position = StartPos.position;
            obj.transform.rotation = StartPos.rotation;
            obj.SetActive(true);
            obj.transform.parent = StartPos.transform;
        }

    }
}
