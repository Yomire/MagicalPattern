using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyScript : MonoBehaviour
{
    public float EndPos_X = -19, SpeedX, Low = 0.01f, High = 1f, nowPosi, EndPos_X2 = 19;
    public AudioClip DisableClip;
    public AudioSource SEASource;
    //public int scoreValue;  // これが敵を倒すと得られる点数になる
    //private ScoreManager sm;
    void Start()
    {
        //sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        nowPosi = this.transform.position.y;
        SpeedX = Random.Range(Low, High);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.x >= EndPos_X)
        {
            this.transform.Translate(-SpeedX, 0, 0);
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / -3, 1f), transform.position.z);
        }
        if (this.transform.localPosition.x <= EndPos_X)
        {
            this.gameObject.SetActive(false);
        }
        if (this.transform.localPosition.x >= EndPos_X2)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack" || trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
        {
            ScreenShakeController.instance.StartShake(.2f, .1f);
            //LevelGenerateScript.instance.DisableCountMethod();
            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);
            SEASource.clip = DisableClip;
            SEASource.Play();
            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);
            Invoke("DisableMethod", 0.01f);
            //sm.AddScore(scoreValue);
        }
        if (trcol.gameObject.tag == "Stop")
        {
            SpeedZero();
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Stop")
        {
            SpeedX = Random.Range(Low, High);
        }
    }

    public void SpeedZero()
    {
        SpeedX = 0;
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
