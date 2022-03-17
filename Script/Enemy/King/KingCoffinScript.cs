using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCoffinScript : MonoBehaviour
{
    public float MoveY, EndPosY, ScrollSpeedX, EndPosX, LayerChangePosY;
    public int StartRender, HPCount, MaxHP;
    public string Flag, CrossFlag, PauseFlag;
    public SpriteRenderer SRend1, SRend2, SRend3, SRend4, SRend5;
    public GameObject LaserColObj;
    public Rigidbody2D rb;
    public Animator KCAnim;
    public ParticleSystem LaserPar;
    public Collider2D DamageCol;
    public AudioClip LandingClip, DisableClip, LaserClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            PauseFlag = "On";
            Flag = "Start";
            SRend1.sortingOrder = StartRender;
            SRend2.sortingOrder = StartRender;
            SRend3.sortingOrder = StartRender;
            SRend4.sortingOrder = StartRender;
            SRend5.sortingOrder = StartRender;
            HPCount = MaxHP;
            KCAnim.SetBool("CloseBool", false);
            LaserColObj.SetActive(false);
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
            if (Flag == "Move")
            {
                ScreenShakeController.instance.StartShake(.1f, .2f);
                Flag = "Scroll";
                DamageCol.enabled = false;
                SEASource.clip = LandingClip;
                SEASource.Play();
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
        if (this.transform.localPosition.y <= LayerChangePosY)
        {
            SRend1.sortingOrder = 0;
            SRend2.sortingOrder = 0;
            SRend3.sortingOrder = 0;
            SRend4.sortingOrder = 0;
            SRend5.sortingOrder = 0;
        }
        if(Flag == "Shake")
        {
            ScreenShakeController.instance.StartShake(.05f, .1f);
        }
    }
    public void MoveMethod()
    {
        Flag = "Move";        
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
        if (HPCount <= 0)
        {
            sm.AddScore(scoreValue);
            DisableMethod();
            CoinMethodCentor();
            SEASource.clip = DisableClip;
            SEASource.Play();
        }
    }
    public void HPMinusMethodSP()
    {
        HPCount -= 2;
        if (HPCount <= 0)
        {
            sm.AddScore(scoreValue);
            DisableMethod();
            CoinMethodCentor();
            SEASource.clip = DisableClip;
            SEASource.Play();
        }
    }

    public void LaserShotMethod()
    {
        LaserPar.Play();
        LaserColObj.SetActive(true);
        Flag = "Shake";
        SEASource.clip = LaserClip;
        SEASource.Play();
    }
    public void LaserEndMethod()
    {
        KCAnim.SetBool("CloseBool", true);
        Flag = "Null";
    }
}
