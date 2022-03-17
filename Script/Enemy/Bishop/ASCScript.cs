using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASCScript : MonoBehaviour
{
    public float MoveY, EndPosY, ScrollSpeedX, EndPosX;
    public int StartRender, HPCount, MaxHP;
    public string Flag, PauseFlag;
    //public SpriteRenderer SRend1, SRend2, SRend3, SRend4, SRend5;
    //public GameObject CrossPos1, CrossPos2, CrossPos3, CrossPos4, CrossPos5;
    public Rigidbody2D rb;
    public AudioClip ColClip;
    public AudioSource SEASource;
    public RotateMethod RMScript;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (PauseFlag == "Off")
        {
            PauseFlag = "On";            
            Flag = "Start";
            /*
            SRend1.sortingOrder = StartRender;
            SRend2.sortingOrder = StartRender;
            SRend3.sortingOrder = StartRender;
            SRend4.sortingOrder = StartRender;
            SRend5.sortingOrder = StartRender;
            */
            HPCount = MaxHP;
        }        
    }

    // Update is called once per frame
    void Update()
    {
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
        Flag = "Scroll";
    }
    public void DisableMethod()
    {
        if(RMScript != null)
        {
            RMScript.PauseFlagOffMethod();
        }        
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
            GameObject obj = ObjectPooler50.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            PauseFlag = "Off";
            DisableMethod();
            CoinMethodCentor();
            sm.AddScore(scoreValue);
        }
    }
    public void HPMinusMethodSP()
    {
        HPCount -= 2;
        ScreenShakeController.instance.StartShake(.1f, .2f);
        if (HPCount <= 0)
        {
            GameObject obj = ObjectPooler50.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            PauseFlag = "Off";
            DisableMethod();
            CoinMethodCentor();
            sm.AddScore(scoreValue);
        }
    }
    public void ScrShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.1f, .2f);
    }
    public void PunchSEMethod()
    {
        SEASource.clip = ColClip;
        SEASource.Play();
    }
}
