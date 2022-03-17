using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    public float MoveY, EndPosY, ScrollSpeedX, EndPosX, LayerChangePosY, EndPosXRight, EndPosYUp;
    public string Flag, LandFlag = "On", PauseFlag = "Off";
    public Rigidbody2D rb;
    public SpriteRenderer SRend;
    public int LayerNumber;
    public AudioClip EnableClip, LandClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        if (PauseFlag == "Off")
        {
            sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            PauseFlag = "On";
            Flag = "Move";
            SRend.sortingOrder = LayerNumber;
            Invoke("EnableSEMethod", 0.01f);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag == "Move")
        {
            this.transform.Translate(0, MoveY, 0);
            if(LandFlag == "On")
            {
                LandFlag = "Off";                
            }
        }
        if(this.transform.localPosition.y <= EndPosY)
        {
            if (Flag == "Move")
            {
                ScreenShakeController.instance.StartShake(.1f, .2f);
                Flag = "Scroll";
                if (LandFlag == "Off")
                {
                    SEASource.clip = LandClip;
                    SEASource.Play();
                    LandFlag = "On";
                }                    
            }                
        }
        if (this.transform.localPosition.y <= LayerChangePosY)
        {
            SRend.sortingOrder = 0;
        }
        if (Flag == "Scroll")
        {
            rb.velocity = Vector2.left * ScrollSpeedX;
        }
        if(this.transform.localPosition.x <= EndPosX || this.transform.localPosition.x >= EndPosXRight || this.transform.localPosition.y >= EndPosYUp)
        {
            DisableMethod();
        }
    }
    public void DisableMethod()
    {
        PauseFlag = "Off";
        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB" || col.gameObject.tag == "Shield")
        {
            sm.AddScore(scoreValue);
            DisableMethod();
            CoinMethodCentor();
            ScreenShakeController.instance.StartShake(.1f, .2f);
        }        
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
    public void EnableSEMethod()
    {
        if (this.gameObject.activeSelf)
        {
            SEASource.clip = EnableClip;
            SEASource.Play();
        }            
    }
}
