using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureScript : MonoBehaviour
{
    public string flag = "Idle", flagHP = "false", flagBlade = "false";
    public GameObject HPHolder, HP2, HP3, HP4, CompleteObj, Player,
        EH1, EH2, EH3, EyeRight, EyeLeft;
    public int AttackNumber = 0, HPCount = 0, NumberStopper = 0;
    public Animator FAni;
    public SpriteRenderer HP1Sprite;
    bool isCalledOnce = false;
    public BlackFeedScript BlackObj;
    public Collider2D BladeCollider, BeakCol, PanelCol;
    //private Rigidbody2D rb;
    public ParticleSystem GatlingP, SporeP, SparkleP, SparkleP2;

    void Start()
    {
        NumberStopper = 1;
        Invoke("ANumberReset", 6.0f);
        //DisapprovalApPortrait.Initialize();
        FAni.SetBool("LeftAttackBool", false);
        //FAni.SetBool("DownBladeBool", false);
        FAni.SetBool("IdleBool", false);
        FAni.SetBool("DownAttackBool", false);
        FAni.SetBool("DownAttack2Bool", false);
        FAni.SetBool("FailureFallBool", false);
        FAni.SetBool("ExtendAttackBool", false); 
        //FAni.SetBool("UpAndSideBool", false);
        FAni.SetLayerWeight(1, 0f);
        FAni.SetLayerWeight(2, 0f);
        flag = "Idle";
        flagHP = "HP1Set";
        BladeCollider.enabled = false;
        BladeFlagFalse();
        Invoke("BladeFlagTrue", 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == "Idle")
        {
            FAni.SetBool("LeftAttackBool", false);
            //FAni.SetBool("DownBladeBool", false);
            FAni.SetBool("IdleBool", true);
            FAni.SetBool("DownAttackBool", false);
            FAni.SetBool("DownAttack2Bool", false);
            FAni.SetBool("ExtendAttackBool", false);
            //this.transform.Translate(0, 0, 0);
        }
        if (AttackNumber == 2)
        {
            flag = "Attack";
            FAni.SetBool("DownAttackBool", true);
            //NumberStopper = 1;            
        }
        if (AttackNumber == 3)
        {
            flag = "Attack";
            FAni.SetBool("DownAttack2Bool", true);
            //NumberStopper = 1;            
        }
        if (AttackNumber == 4)
        {
            flag = "Attack";
            //NumberStopper = 1;
            FAni.SetBool("LeftAttackBool", true);
        }
        if (AttackNumber == 7 || AttackNumber == 6)
        {
            flag = "Attack";
            FAni.SetBool("FailureFallBool", true);
        }
        if (AttackNumber == 9 || AttackNumber == 8)
        {
            flag = "Attack";
            FAni.SetBool("ExtendAttackBool", true);
            /*ExtendHandMethod();
            Invoke("ExtendHandMethod2", 0.5f);
            Invoke("ExtendHandMethod3", 1.0f);
            Invoke("ExtendHandMethod", 1.5f);
            Invoke("ExtendHandMethod2", 2.0f);
            Invoke("ExtendHandMethod3", 2.5f);*/
        }

        if (flagHP == "Idle")
        {
            if (HPHolder != null)
            {
                if (HP1Sprite.size.x <= 1.28)
                {
                    flagHP = "HP1Set";
                    HPCount++;
                }
            }
        }
        if (HPCount == 1)
        {
            HP2.SetActive(false);
        }
        if (HPCount == 2)
        {
            HP3.SetActive(false);
        }
        /*if (HPCount == 3)
        {
            //RageAni.SetBool("CentorAniBool", false);
            HP4.SetActive(false);
        }*/
        if (HPCount == 3)
        {
            if (!isCalledOnce)
            {
                SparkleStopMethod();
                GatlingStopMethod();
                SporeStopMethod();
                isCalledOnce = true;
                HPHolder.SetActive(false);
                EyeRight.SetActive(false);
                EyeLeft.SetActive(false);
                DisableMethod();
                CompleteMethod();
                Invoke("FeedOutMethod", 1.0f);
            }
            FAni.Play("Disable", 0, 0.0f);
        }
        if (flagHP == "HP1Set")
        {
            HP1Sprite.size += new Vector2(0.05f, 0.0f);
            if (HP1Sprite.size.x >= 15)
            {
                flagHP = "Idle";
            }
        }
    }
    public void RandomMethod()
    {
        if (HPCount == 0)
        {
            if (NumberStopper == 0)
            {
                //Debug.Log("test");
                AttackNumber = Random.Range(1, 6);
            }
        }
        if (HPCount == 1)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 8);
            }
        }
        if (HPCount == 2)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 11);
            }
        }
        /*if (HPCount == 3)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 5);
            }
        }*/
    }
    public void FlagReset()
    {
        flag = "Idle";
        ANumberReset();
        FAni.SetBool("LeftAttackBool", false);
        //FAni.SetBool("DownBladeBool", false);
        FAni.SetBool("IdleBool", true);
        FAni.SetBool("DownAttackBool", false);
        FAni.SetBool("DownAttack2Bool", false);
        FAni.SetBool("ExtendAttackBool", false);
        FAni.SetBool("FailureFallBool", false);
    }
    public void ANumberReset()
    {
        //Debug.Log("test");
        NumberStopper = 0;
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (flagHP == "Idle")
        {
            if (trcol.gameObject.tag == "Attack")
            {
                //RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                //Invoke("ApResetMethod", 0.5f);
                HP1Sprite.size -= new Vector2(0.05f, 0.0f);
                Shake();
            }
        }
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (flagHP == "Idle")
        {
            if (trcol.gameObject.tag == "Attack")
            {
                //RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                //Invoke("ApResetMethod", 0.5f);
                HP1Sprite.size -= new Vector2(0.05f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .05f);
            }
        }
    }
    public void DamageMethod()
    {
        if (flagHP == "Idle")
        {
            HP1Sprite.size -= new Vector2(0.5f, 0.0f);
            Shake();
        }
    }
    public void Damage2Method()
    {
        if (flagHP == "Idle")
        {
            HP1Sprite.size -= new Vector2(0.05f, 0.0f);
            ScreenShakeController.instance.StartShake(.1f, .05f);
        }
    }
    public void BladeCol()
    {
        BladeCollider.enabled = true;
    }
    public void BladeColFalse()
    {
        BladeCollider.enabled = false;
    }
    public void CompleteMethod()
    {
        CompleteObj.SetActive(true);
    }
    public void FeedOutMethod()
    {
        BlackObj.Completeflag();
    }
    public void DisableMethod()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

        Shake();
    }
    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    public void GatlingMethod()
    {
        GatlingP.Play();
    }
    public void GatlingStopMethod()
    {
        GatlingP.Stop();
    }
    public void SporeMethod()
    {
        SporeP.Play();
    }
    public void SporeStopMethod()
    {
        //Debug.Log("test");
        SporeP.Stop();
    }
    public void BladeMethod()
    {
        if(flagBlade == "true")
        {
            FAni.SetLayerWeight(1, 1f);
            FAni.Play("DownBlade", 1, 0.0f);
        }
        //Invoke("BladeFalseMethod", 3.0f);
    }
    public void BladeFalseMethod()
    {
        //Debug.Log("test");
        FAni.SetLayerWeight(1, 0f);
    }
    public void BladeFlagTrue()
    {
        flagBlade = "true";
    }
    public void BladeFlagFalse()
    {
        flagBlade = "false";
    }
    public void SparkleMethod()
    {
        SparkleP.Play();
        SparkleP2.Play();
        BeakCol.enabled = true;
        PanelCol.enabled = true; 
    }
    public void SparkleStopMethod()
    {
        PanelCol.enabled = false;
        BeakCol.enabled = false;
        SparkleP.Stop();
        SparkleP2.Stop();
    }
    public void ExtendHandMethod()
    {
        if (EH1.activeSelf == false)
        {
            EH1.SetActive(true);
        }
    }
    public void ExtendHandMethod2()
    {
        if (EH2.activeSelf == false)
        {
            EH2.SetActive(true);
        }
    }
    public void ExtendHandMethod3()
    {
        if (EH3.activeSelf == false)
        {
            EH3.SetActive(true);
        }
    }
}
