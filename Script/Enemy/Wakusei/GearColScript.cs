using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearColScript : MonoBehaviour
{
    public WakuseiScript WS;
    public ParticleSystem GearPar;
    public int HPCount;
    public GameObject CoinPos1, CoinPos2, CoinPos3;
    public AudioClip DisableClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            HPCount++;
            if(HPCount >= 3)
            {
                sm.AddScore(scoreValue);
                this.gameObject.SetActive(false);
                GearPar.Play();
                ScreenShakeController.instance.StartShake(.3f, .2f);
                WS.DamageMethodSP();
                SEASource.clip = DisableClip;
                SEASource.Play();
                CoinMethodCentorCentor();
                CoinMethodCentorLeft();
                CoinMethodCentorRight();
                CoinMethodRightCentor();
                CoinMethodRightLeft();
                CoinMethodRightRight();
                CoinMethodLeftCentor();
                CoinMethodLeftLeft();
                CoinMethodLeftRight();
            }
        }
        if (trcol.gameObject.tag == "EnemyFalse")
        {
            this.gameObject.SetActive(false);            
        }
        if (trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            this.gameObject.SetActive(false);
            GearPar.Play();
            ScreenShakeController.instance.StartShake(.3f, .2f);
            WS.DamageMethodSP();
            SEASource.clip = DisableClip;
            SEASource.Play();
            CoinMethodCentorCentor();
            CoinMethodCentorLeft();
            CoinMethodCentorRight();
            CoinMethodRightCentor();
            CoinMethodRightLeft();
            CoinMethodRightRight();
            CoinMethodLeftCentor();
            CoinMethodLeftLeft();
            CoinMethodLeftRight();
        }
    }
    public void HPReset()
    {
        HPCount = 0;
    }
    public void CoinMethodCentorCentor()
    {
        GameObject obj20 = ObjectPooler20.current.GetPooledObject();
        if (obj20 == null) return;
        obj20.transform.position = CoinPos1.transform.position;
        //obj20.transform.rotation = ShotPosRight.transform.rotation;
        obj20.SetActive(true);
    }
    public void CoinMethodCentorLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos1.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodCentorRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos1.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightCentor()
    {
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftCentor()
    {
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
}
