﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    public string TargetTag;
    public float Speed = 0.5f;
        
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, TargetTag);
        Invoke("SCFalse", 0.01f);
    }
    void SCFalse()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nearObj != null)
        {
            //経過時間を取得
            searchTime += Time.deltaTime;

            if (searchTime >= 1.0f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, TargetTag);

                //経過時間を初期化
                searchTime = 0;
            }

            //対象の位置の方向を向く
            if(nearObj != null)
            {
                transform.LookAt(nearObj.transform);
            }            

            //自分自身の位置から相対的に移動する
            transform.Translate(Vector3.forward * Speed);
        }        
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
