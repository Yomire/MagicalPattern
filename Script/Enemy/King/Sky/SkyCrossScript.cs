using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCrossScript : MonoBehaviour
{
    public float MoveY, EndPosYBottom;
    public AudioClip EnableClip;
    public AudioSource SEASource;
    public string LandFlag = "On";
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        if(LandFlag == "On")
        {
            SEASource.clip = EnableClip;
            SEASource.Play();
            LandFlag = "Off";
        }
    }
    void Update()
    {
        this.transform.Translate(0, MoveY, 0);

        if (this.transform.localPosition.y <= EndPosYBottom)
        {
            DisableMethod();
        }
    }
    public void DisableMethod()
    {
        LandFlag = "On";
        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB" || col.gameObject.tag == "Shield")
        {
            sm.AddScore(scoreValue);
            DisableMethod();
            CoinMethodCentor();
        }
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
}
