using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMCoinCoffinS : MonoBehaviour
{
    public float MoveY, EndPosY, ScrollSpeedX, EndPosX, DisablePosY;
    public int StartRender, AttackNumber, HPCount, MaxHP;
    public string Flag, CrossFlag, PauseFlag;
    public SpriteRenderer SRend1, SRend2, SRend3, SRend4, SRend5;
    public GameObject CrossPos1, CrossPos2, CrossPos3, CrossPos4, CrossPos5;
    public Rigidbody2D rb;
    public Collider2D DamageCol;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (PauseFlag == "Off")
        {
            PauseFlag = "On";
            if (Flag != "Sky" && Flag != "Coin")
            {
                Flag = "Start";
            }
            SRend1.sortingOrder = StartRender;
            SRend2.sortingOrder = StartRender;
            SRend3.sortingOrder = StartRender;
            SRend4.sortingOrder = StartRender;
            SRend5.sortingOrder = StartRender;
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
            if (Flag == "Move")
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
        if (this.transform.localPosition.y <= DisablePosY)
        {
            DisableMethod();
        }
        if (Flag == "Fall")
        {
            this.transform.Translate(0, MoveY, 0);
            DamageCol.enabled = true;
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
    }
    public void FallOnlyMethod()
    {
        Flag = "Fall";
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
    public void ShotGunMethod1()
    {
        if (CrossFlag == "7")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler46.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos1.transform.position;
                obj.transform.rotation = CrossPos1.transform.rotation;
                obj.SetActive(true);
            }
        }
        if (CrossFlag == "0")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler47.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos1.transform.position;
                obj.transform.rotation = CrossPos1.transform.rotation;
                obj.SetActive(true);
            }
        }

        if (Flag == "Sky")
        {
            GameObject obj = ObjectPooler49.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos1.transform.position;
            obj.transform.rotation = CrossPos1.transform.rotation;
            obj.SetActive(true);
        }
        if (Flag == "Coin")
        {
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos1.transform.position;
            obj.transform.rotation = CrossPos1.transform.rotation;
            obj.SetActive(true);
        }
    }
    public void ShotGunMethod2()
    {
        if (CrossFlag == "7")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler46.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos2.transform.position;
                obj.transform.rotation = CrossPos2.transform.rotation;
                obj.SetActive(true);
            }
        }
        if (CrossFlag == "0")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler47.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos2.transform.position;
                obj.transform.rotation = CrossPos2.transform.rotation;
                obj.SetActive(true);
            }
        }

        if (Flag == "Sky")
        {
            GameObject obj = ObjectPooler49.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos2.transform.position;
            obj.transform.rotation = CrossPos2.transform.rotation;
            obj.SetActive(true);
        }
        if (Flag == "Coin")
        {
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos2.transform.position;
            obj.transform.rotation = CrossPos2.transform.rotation;
            obj.SetActive(true);
        }
    }
    public void ShotGunMethod3()
    {
        if (CrossFlag == "7")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler46.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos3.transform.position;
                obj.transform.rotation = CrossPos3.transform.rotation;
                obj.SetActive(true);
            }
        }
        if (CrossFlag == "0")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler47.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos3.transform.position;
                obj.transform.rotation = CrossPos3.transform.rotation;
                obj.SetActive(true);
            }
        }

        if (Flag == "Sky")
        {
            GameObject obj = ObjectPooler49.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos3.transform.position;
            obj.transform.rotation = CrossPos3.transform.rotation;
            obj.SetActive(true);
        }
        if (Flag == "Coin")
        {
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos3.transform.position;
            obj.transform.rotation = CrossPos3.transform.rotation;
            obj.SetActive(true);
        }
    }
    public void ShotGunMethod4()
    {
        if (CrossFlag == "7")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler46.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos4.transform.position;
                obj.transform.rotation = CrossPos4.transform.rotation;
                obj.SetActive(true);
            }
        }
        if (CrossFlag == "0")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler47.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos4.transform.position;
                obj.transform.rotation = CrossPos4.transform.rotation;
                obj.SetActive(true);
            }
        }

        if (Flag == "Sky")
        {
            GameObject obj = ObjectPooler49.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos4.transform.position;
            obj.transform.rotation = CrossPos4.transform.rotation;
            obj.SetActive(true);
        }
        if (Flag == "Coin")
        {
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos4.transform.position;
            obj.transform.rotation = CrossPos4.transform.rotation;
            obj.SetActive(true);
        }
    }
    public void ShotGunMethod5()
    {
        if (CrossFlag == "7")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler46.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos5.transform.position;
                obj.transform.rotation = CrossPos5.transform.rotation;
                obj.SetActive(true);
            }
        }
        if (CrossFlag == "0")
        {
            if (Flag == "Start")
            {
                GameObject obj = ObjectPooler47.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = CrossPos5.transform.position;
                obj.transform.rotation = CrossPos5.transform.rotation;
                obj.SetActive(true);
            }
        }

        if (Flag == "Sky")
        {
            GameObject obj = ObjectPooler49.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos5.transform.position;
            obj.transform.rotation = CrossPos5.transform.rotation;
            obj.SetActive(true);
        }
        if (Flag == "Coin")
        {
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = CrossPos5.transform.position;
            obj.transform.rotation = CrossPos5.transform.rotation;
            obj.SetActive(true);
        }
    }
    public void ShotGunEvent()
    {
        AttackNumber = Random.Range(1, 6);
        if (AttackNumber == 1)
        {
            ShotGunMethod1();
        }
        if (AttackNumber == 2)
        {
            ShotGunMethod2();
        }
        if (AttackNumber == 3)
        {
            ShotGunMethod3();
        }
        if (AttackNumber == 4)
        {
            ShotGunMethod4();
        }
        if (AttackNumber >= 5)
        {
            ShotGunMethod5();
        }
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

    public void FlagChangeSky()
    {
        Flag = "Sky";
    }
    public void FlagChangeCoin()
    {
        Flag = "Coin";
    }
}
