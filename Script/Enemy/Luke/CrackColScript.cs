using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackColScript : MonoBehaviour
{
    public CrackScript CS;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            Invoke("DisableMethod", 0.01f);
        }            
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            Invoke("DisableMethod", 0.01f);
        }
    }

    public void DisableMethod()
    {
        CS.DisableMethod();
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
    public void CoinMethodLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
}
