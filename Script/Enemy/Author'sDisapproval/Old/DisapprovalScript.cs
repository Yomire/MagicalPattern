using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class DisapprovalScript : MonoBehaviour
{
    public apPortrait DisapprovalApPortrait;
    public string flag = "Idle", flagHP = "false", LockFlag = "Off";
    public GameObject HPHolder, HP2, HP3, HP4, SandObj1, SandObj2A, SandObj2B, SandObj3A, SandObj3B, SandObj4A, SandObj4B, KeyActObj, CompleteObj;
    public int AttackNumber = 0, HPCount = 0, NumberStopper = 0, SandRanDom = 0;
    public LockBlockGenerate LockGeneScript, LockGeneScriptUp;
    public Animator DAni;
    public SpriteRenderer HP1Sprite;
    bool isCalledOnce = false;
    public Player PScript;
    public BlackFeedScript BlackObj;

    // Start is called before the first frame update
    void Start()
    {
        HPCount = 10;
        Invoke("HPConutStart", 4.0f);
        //DisapprovalApPortrait.Initialize();
        DAni.SetBool("AttackBool", false);
        DAni.SetBool("Attack2Bool", false);
        DAni.SetBool("IdleBool", false);
        DAni.SetBool("WallGeneUpBool", false);
        DAni.SetBool("UpAndSideBool", false); 
        DAni.SetLayerWeight(1, 0f);
        flag = "Idle";
        flagHP = "HP1Set";
    }
    void HPConutStart()
    {
        HPCount = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        if (flag == "Idle")
        {
            DAni.SetBool("AttackBool", false);
            DAni.SetBool("IdleBool", true);
            DAni.SetBool("Attack2Bool", false);
            DAni.SetBool("WallGeneUpBool", false);
            DAni.SetBool("UpAndSideBool", false);
            //DisapprovalApPortrait.Play("Idle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }

        if (AttackNumber == 1 || AttackNumber == 2 || AttackNumber == 3 || AttackNumber == 4)
        {
            flag = "Attack";
            DAni.SetBool("AttackBool", true);
            //AttackMethodFX();
            //AttackNumber = 0;
            //DisapprovalApPortrait.Play("WallAct", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);            
            //Invoke("FlagReset", 5.0f);
        }
        if(AttackNumber == 5)
        {
            flag = "Attack";
            //AttackNumber = 0;
            DAni.SetBool("Attack2Bool", true);
            /*SandMethodA();
            Invoke("SandMethodB", 1.0f);
            Invoke("SandMethodD", 2.0f);*/
        }
        if (AttackNumber == 6)
        {
            flag = "Attack";
            //AttackNumber = 0;
            DAni.SetBool("Attack2Bool", true);
            /*SandMethodD();
            Invoke("SandMethodC", 1.0f);
            Invoke("SandMethodB", 2.0f);*/
        }
        if (AttackNumber == 11 || AttackNumber == 12 || AttackNumber == 13)
        {
            flag = "Attack";
            //AttackNumber = 0;
            DAni.SetBool("WallGeneUpBool", true);
            /*SandMethodD();
            Invoke("SandMethodC", 1.0f);
            Invoke("SandMethodB", 2.0f);*/
        }
        if (AttackNumber == 14 || AttackNumber == 15 || AttackNumber == 16)
        {
            flag = "Attack";
            //AttackNumber = 0;
            DAni.SetBool("UpAndSideBool", true);
            /*SandMethodD();
            Invoke("SandMethodC", 1.0f);
            Invoke("SandMethodB", 2.0f);*/
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
        if (HPCount == 3)
        {
            //RageAni.SetBool("CentorAniBool", false);
            HP4.SetActive(false);            
        }
        if (HPCount == 4)
        {
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                HPHolder.SetActive(false);
                DisableMethod();
                CompleteMethod();
                Invoke("FeedOutMethod", 1.0f);
            }
            DAni.Play("DisableAni", 0, 0.0f);
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
    /*public void BarriarChange()
    {
        Invoke("LockMethod", 6.0f);
    }*/
    public void LockMethod()
    {
        LockFlag = PScript.flagLock;
        if(LockFlag == "On")
        {
            PScript.LockMethodOff();
        }
        if (LockFlag == "Off")
        {
            PScript.LockMethodOn();
        }
        DAni.SetLayerWeight(1, 1f);        
        Invoke("ApLayerResetMethod", 0.5f);
    }
    public void LockPatternActive()
    {
        KeyActObj.SetActive(true);
    }
    public void LockPatternFalse()
    {
        KeyActObj.SetActive(false);
    }
    public void AttackMethod()
    {
        //Debug.Log("test");
        LockGeneScript.GenerateMethod();
    }
    public void Attack2Method()
    {
        //Debug.Log("test");
        LockGeneScriptUp.GenerateMethod();
    }
    public void FlagReset()
    {
        flag = "Idle";
    }
    public void RandomMethod()
    {
        if (HPCount == 0)
        {
            if (NumberStopper == 0)
            {
                //Debug.Log("test");
                AttackNumber = Random.Range(1, 10);
            }
        }
        if (HPCount == 1)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 13);
            }
        }
        if (HPCount == 2)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(4, 17);
            }
        }
        if (HPCount == 3)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(4, 17);
            }
        }
    }
    public void ANumberReset()
    {
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
                HP1Sprite.size -= new Vector2(2.0f, 0.0f);
                Shake();
            }
            if (trcol.gameObject.tag == "AttackSP")
            {
                //RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                //Invoke("ApResetMethod", 0.5f);
                HP1Sprite.size -= new Vector2(5.0f, 0.0f);
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
                HP1Sprite.size -= new Vector2(0.5f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .05f);
                Invoke("LockMethod", 6.0f);
            }
        }
    }
    public void ApLayerResetMethod()
    {
        DAni.SetLayerWeight(1, 0f);
    }
    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    public void SandMethodA()
    {
        SandObj1.SetActive(true);
    }
    public void SandMethodB()
    {
        SandRanDom = Random.Range(1, 2);
        if(SandRanDom == 1)
        {
            SandObj2A.SetActive(true);
        }
        if (SandRanDom == 2)
        {
            SandObj2B.SetActive(true);
        }
    }
    public void SandMethodC()
    {
        SandRanDom = Random.Range(1, 2);
        if (SandRanDom == 1)
        {
            SandObj3A.SetActive(true);
        }
        if (SandRanDom == 2)
        {
            SandObj3B.SetActive(true);
        }
    }
    public void SandMethodD()
    {
        SandRanDom = Random.Range(1, 2);
        if (SandRanDom == 1)
        {
            SandObj4A.SetActive(true);
        }
        if (SandRanDom == 2)
        {
            SandObj4B.SetActive(true);
        }
    }
    public void DisableMethod()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

        Shake();
    }
    public void CompleteMethod()
    {
        CompleteObj.SetActive(true);
    }
    public void FeedOutMethod()
    {
        BlackObj.Completeflag();
    }
}
