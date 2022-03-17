using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHCoffinScript : MonoBehaviour
{
    public float MoveY, EndPosY, ScrollSpeedX, EndPosX;
    public int StartRender, HPCount, MaxHP;
    public string Flag, PauseFlag;
    public SpriteRenderer SRend1, SRend2, SRend3, SRend4, SRend5;
    public GameObject CrossPos1, CrossPos2, CrossPos3, CrossPos4, CrossPos5, ArmObj;
    public Rigidbody2D rb;
    public ParticleSystem SparklePar;
    public Collider2D DamageCol;
    public AudioClip ColClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (PauseFlag == "Off")
        {            
            PauseFlag = "On";
            Flag = "Start";
            ArmObj.SetActive(true);
            SRend1.sortingOrder = StartRender;
            SRend2.sortingOrder = StartRender;
            SRend3.sortingOrder = StartRender;
            SRend4.sortingOrder = StartRender;
            SRend5.sortingOrder = StartRender;
            SparklePar.Stop();
            HPCount = MaxHP;
            DamageCol.enabled = false;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag == "Move")
        {
            this.transform.Translate(0, MoveY, 0);
            DamageCol.enabled = true;
        }
        if (this.transform.localPosition.y <= EndPosY)
        {
            if(Flag == "Move")
            {
                ScreenShakeController.instance.StartShake(.1f, .2f);
                Flag = "Scroll";
                DamageCol.enabled = false;
            }            
        }
        if (Flag == "Scroll")
        {
            rb.velocity = Vector2.left * ScrollSpeedX;
        }
        if (this.transform.localPosition.x <= EndPosX)
        {
            DisableMethod();
        }
    }
    public void MoveMethod()
    {
        Flag = "Move";
        SRend1.sortingOrder = 0;
        SRend2.sortingOrder = 0;
        SRend3.sortingOrder = 0;
        SRend4.sortingOrder = 0;
        SRend5.sortingOrder = 0;
        ArmObj.SetActive(false);
    }
    public void DisableMethod()
    {
        PauseFlag = "Off";
        this.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            HPMinusMethod();
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            HPMinusMethodSP();
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            HPMinusMethod();
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            HPMinusMethodSP();
        }
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
    public void HPMinusMethod()
    {
        HPCount--;
        ScreenShakeController.instance.StartShake(.1f, .2f);
        if (HPCount <= 0)
        {
            sm.AddScore(scoreValue);
            GameObject obj = ObjectPooler50.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            Invoke("DisableMethod", 0.01f);
            Invoke("CoinMethodCentor", 0.01f);
            Invoke("CoinMethodRight", 0.01f);
            Invoke("CoinMethodLeft", 0.01f);
        }
    }
    public void HPMinusMethodSP()
    {
        HPCount -= 2;
        ScreenShakeController.instance.StartShake(.1f, .2f);
        if (HPCount <= 0)
        {
            sm.AddScore(scoreValue);
            GameObject obj = ObjectPooler50.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            Invoke("DisableMethod", 0.01f);
            Invoke("CoinMethodCentor", 0.01f);
            Invoke("CoinMethodRight", 0.01f);
            Invoke("CoinMethodLeft", 0.01f);
        }
    }
    public void ScrShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.1f, .2f);
        SparklePar.Play();
    }
    public void SparkleEnd()
    {
        SparklePar.Stop();
    }
    public void SEMethod()
    {
        SEASource.clip = ColClip;
        SEASource.Play();
    }
}
