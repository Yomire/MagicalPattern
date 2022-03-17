 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACryScript : MonoBehaviour
{
    public string flag = "Idle", flagHP = "false";
    public SpriteRenderer HP1Sprite, HP1BSprite;
    //public float nowPosi;
    public Animator Skullani;
    private float countTime = 0;
    public GameObject AttackArmLeft, AttackArmRight, StepGenerateUp, StepGenerateDown, LaserLeft, LaserRight, ThreeEyeAura, 
        HPHolder, HP2, HP3, HPHolderB, HP2B, HP3B, HP4B, CryEyeLeft, CryEyeRight, EyeAttackLeft, EyeAttackRight, 
        EyeAttackPosLeftUp, EyeAttackPosLeftCentor, EyeAttackPosLeftDown, EyeAttackPosRightUp, EyeAttackPosRightCentor, EyeAttackPosRightDown, 
        LaserEX, BeamEyeLeft, BeamEyeRight, BurnPosA, BurnPosB, BurnPosC, BurnPosD, BurnPosE, NailArmRight, NailArmLeft, ChainLock1, ChainLock2, ChainLock3, ChainLock4, ChainLock5, ChainLock6, ChainLock7, ChainLock8, ChainLock9, CompleteObj;
    public int AttackNumber = 0, HPCount = 0, NumberStopper = 0, PatternNumber = 0;
    public Collider2D ThirdCol;
    public CryEyeAttack EyeScript, EyeScriptB;
    public CryEyeSideBeam EyeBScriptA, EyeBScriptB;
    public BlackFeedScript BlackObj;
    bool isCalledOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        //Skullani = GetComponent<Animator>();
        //nowPosi = this.transform.position.x;
        flagHP = "HP1Set";
        flag = "Stop";
        Invoke("flagIdleMethod", 10.0f);
        //Skullani.Play("CryIdle", 0, 0.0f);
        Skullani.SetLayerWeight(1, 1f);
        Skullani.SetLayerWeight(2, 0f);
        Skullani.SetLayerWeight(3, 0f);
        Skullani.SetLayerWeight(4, 0f);
        Skullani.SetLayerWeight(5, 0f);
        Skullani.SetLayerWeight(6, 0f);
        Skullani.SetBool("EyeBeamBool", false);
        Skullani.SetBool("EyeBeamBool2", false);
        Skullani.SetBool("ThirdEyeAwakeBool", false);
        Skullani.SetBool("EyePurgeBool", false);
        Skullani.SetBool("EyeBeamThirdBool", false);
        Skullani.SetBool("TrueFinishBool", false); 
        ThreeEyeAura.SetActive(false);
        ThirdCol.enabled = false;
    }

    public void flagIdleMethod()
    {
        flag = "Idle";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //countTime -= Time.deltaTime;
        if (flag == "Idle")
        {
            if (PatternNumber == 1)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock1.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 2)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock2.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 3)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock3.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 4)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock4.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 5)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock5.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 6)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock6.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 7)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock7.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 8)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock8.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }
            if (PatternNumber == 9)
            {
                Skullani.SetLayerWeight(3, 0.4f);
                ChainLock9.SetActive(true);
                PatternNumber = 0;
                Invoke("CryCryReset", 0.5f);
            }

            if (AttackNumber == 1)
            {
                AttackNumber = 0;
                AttackArmLeftMethod();
                Invoke("AttackArmRightMethod", 2.0f);
            }
            if (AttackNumber == 2)
            {
                LaserEnabled();
                //Skullani.SetBool("EyeBeamBool", true);
                Invoke("EyeBeam", 0.01f);
                //AttackNumber = 0;
                //Invoke("AttackArmRightMethod", 2.0f);
            }
            if (AttackNumber == 3)
            {
                LaserEnabled();
                //Skullani.SetBool("EyeBeamBool", true);
                Invoke("EyeBeam2", 0.01f);
                //AttackNumber = 0;
                //Invoke("AttackArmRightMethod", 2.0f);
            }

            if (AttackNumber == 5)
            {
                AttackNumber = 0;
                EyeAttack();
                Invoke("EyeAttackF", 2.0f);
                //Invoke("ANumberReset", 4.0f);
            }
            if (AttackNumber == 6)
            {
                AttackNumber = 0;
                EyeAttackB();
                Invoke("EyeAttackF", 2.0f);
            }
            if (AttackNumber == 7)
            {
                AttackNumber = 0;
                EyeAttackC();
                Invoke("EyeAttackD", 1.0f);
            }
            if (AttackNumber == 8)
            {
                AttackNumber = 0;
                EyeAttackC();
                Invoke("EyeAttackE", 1.0f);
            }            
            if (AttackNumber == 9)
            {
                AttackNumber = 0;
                NumberStopper = 1;
                Invoke("ANumberReset", 6.0f);
                //EyeBeamA();
                Invoke("EyeBeamA", 2.0f);
                Invoke("EyeBeamF", 3.0f);
            }
            if (AttackNumber == 10)
            {
                AttackNumber = 0;
                NumberStopper = 1;
                Invoke("ANumberReset", 6.0f);
                //EyeBeamB();
                Invoke("EyeBeamB", 2.0f);
                Invoke("EyeBeamD", 3.0f);
            }
            if (AttackNumber == 11)
            {
                AttackNumber = 0;
                NumberStopper = 1;
                Invoke("ANumberReset", 6.0f);
                //EyeBeamF();
                Invoke("EyeBeamF", 2.0f);
                Invoke("EyeBeamB", 3.0f);
            }
            if (AttackNumber == 12)
            {
                AttackNumber = 0;
                NumberStopper = 1;
                Invoke("ANumberReset", 6.0f);
                //EyeBeamC();
                Invoke("EyeBeamC", 2.0f);
                Invoke("EyeBeamE", 3.0f);
            }

            if (AttackNumber == 13)
            {
                AttackNumber = 0;
                LaserEnabledEX();
                Invoke("EyeLaserEX", 0.01f);
            }
            if (AttackNumber == 14)
            {
                AttackNumber = 0;
                AttackArmLeftMethod();
                Invoke("AttackArmRightMethod", 0.5f);
            }
            if (AttackNumber == 15)
            {
                AttackNumber = 0;
                NailArmRight.SetActive(true);
            }
            if (AttackNumber == 16)
            {
                AttackNumber = 0;
                NailArmLeft.SetActive(true);
            }
            if (AttackNumber == 17)
            {
                AttackNumber = 0;
                NailArmRight.SetActive(true);
                NailArmLeft.SetActive(true);
            }
            //transform.position = new Vector3(nowPosi + Mathf.PingPong(Time.time / 3, 7.0f), transform.position.y, transform.position.z);
            //transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 3, 0.3f), transform.position.z);
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
            HP3.SetActive(false);
            //Skullani.SetBool("EyePurgeBool", true);
            ArmFree();
            Invoke("EyePurge", 0.01f);
            Invoke("ArmWithDraw", 2.5f);
            Invoke("StepCreateMethod", 2.0f);
            Skullani.SetLayerWeight(6, 1f);
        }
        if (HPCount == 2)
        {
            HP2.SetActive(false);
        }
        if (HPCount == 3)
        {
            StepDisabledMethod();
            if(EyeScript != null)
            {
                EyeScript.Destroy();
            }
            if (EyeScriptB != null)
            {
                EyeScriptB.Destroy();
            }
            if (EyeBScriptA != null)
            {
                EyeBScriptA.Destroy();
            }
            if (EyeBScriptB != null)
            {
                EyeBScriptB.Destroy();
            }
            HPHolder.SetActive(false);
            Skullani.SetLayerWeight(2, 0f);
            Skullani.SetLayerWeight(4, 1f);
            Skullani.SetLayerWeight(6, 1f);
            //Invoke("ArmFree", 2.0f);
            Skullani.SetBool("ThirdEyeAwakeBool", true);
        }
        if (flagHP == "HP1Set")
        {
            HP1Sprite.size += new Vector2(0.05f, 0.0f);
            if (HP1Sprite.size.x >= 15)
            {
                flagHP = "Idle";
            }
        }
        if (flagHP == "IdleB")
        {
            Skullani.SetLayerWeight(2, 1f);
            Skullani.SetLayerWeight(4, 0f);
            Skullani.SetLayerWeight(5, 1f);
            
            if (HPHolderB != null)
            {
                if (HP1BSprite.size.x <= 1.28)
                {
                    flagHP = "HPSetB";
                    HPCount++;                    
                }
            }
            if (EyeScript != null)
            {
                EyeScript.Destroy();
            }
            if (EyeScriptB != null)
            {
                EyeScriptB.Destroy();
            }
            if (EyeBScriptA != null)
            {
                EyeBScriptA.Destroy();
            }
            if (EyeBScriptB != null)
            {
                EyeBScriptB.Destroy();
            }
        }        
        if (HPCount == 4)
        {
            HP2B.SetActive(false);
        }
        if (HPCount == 5)
        {
            HP3B.SetActive(false);
        }
        if (HPCount == 6)
        {
            HP4B.SetActive(false);
        }
        if (HPCount == 7)
        {
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                HPHolderB.SetActive(false);
                Skullani.SetBool("TrueFinishBool", true);
                Invoke("CompleteMethod", 1.0f);
                Invoke("FeedOutMethod", 2.0f);
            }
        }
        if (flagHP == "HPSetB")
        {
            Skullani.SetLayerWeight(5, 1f);
            if (HPHolderB != null)
            {
                HP1BSprite.size += new Vector2(0.05f, 0.0f);
                if (HP1BSprite.size.x >= 15)
                {
                    flagHP = "IdleB";
                }
            }             
        }
    }
    public void CompleteMethod()
    {
        CompleteObj.SetActive(true);
    }
    public void FeedOutMethod()
    {
        BlackObj.Completeflag();
    }

    public void DamageMethod()
    {
        if (flagHP == "Idle")
        {
            HP1Sprite.size -= new Vector2(0.2f, 0.0f);
        }
        if (flagHP == "IdleB")
        {
            HP1BSprite.size -= new Vector2(0.2f, 0.0f);
        }
    }

    public void RandomAttackMethod()
    {
        AttackNumber = Random.Range(1, 4);
        PatternNumber = Random.Range(1, 100);
    }
    public void RandomAttackMethodB()
    {
        if (NumberStopper == 0)
        {
            PatternNumber = Random.Range(1, 100);
            AttackNumber = Random.Range(5, 12);
        }
    }
    public void RandomAttackMethodC()
    {
        PatternNumber = Random.Range(1, 100);
        AttackNumber = Random.Range(13, 17);
    }

    public void ANumberReset()
    {
        NumberStopper = 0;
    }

    public void LaserEnabled()
    {
        //Debug.Log("test");
        LaserLeft.SetActive(true);
        LaserRight.SetActive(true);
    }

    public void AttackArmLeftMethod()
    {
        AttackArmLeft.SetActive(true);
    }

    public void AttackArmRightMethod()
    {
        AttackArmRight.SetActive(true);
    }

    public void StepCreateMethod()
    {
        StepGenerateUp.SetActive(true);
        StepGenerateDown.SetActive(true);
    }

    public void StepDisabledMethod()
    {
        StepGenerateUp.SetActive(false);
        StepGenerateDown.SetActive(false);
    }

    public void CryCryReset()
    {
        Skullani.SetLayerWeight(3, 0f);
    }

    public void IdleAni()
    {
        Skullani.SetBool("EyeBeamBool", false);
        Skullani.SetBool("EyeBeamBool2", false);
        Skullani.Play("CryIdle", 0, 0.0f);
        LaserLeft.SetActive(false);
        LaserRight.SetActive(false);       
    }
    public void IdleAniThird()
    {
        Skullani.SetBool("EyeBeamThirdBool", false);
        Skullani.Play("Cry3rdEyeIdle", 0, 0.0f);
        LaserEX.SetActive(false);
    }

    public void EyeBeam()
    {
        AttackNumber = 0;
        Skullani.SetBool("EyeBeamBool", true);
        //Skullani.Play("CryEyeBeam", 0, 0.0f);
    }
    public void EyeBeam2()
    {
        AttackNumber = 0;
        Skullani.SetBool("EyeBeamBool2", true);
        //Skullani.Play("CryEyeBeam", 0, 0.0f);
    }

    public void AwakeThreeEye()
    {
        ThreeEyeAura.SetActive(true);
        ThirdCol.enabled = true;
        HPHolderB.SetActive(true);
        flagHP = "HPSetB";
    }

    public void CryEyeDisabled()
    {
        Destroy(CryEyeLeft);
        Destroy(CryEyeRight);
        //Debug.Log("test");
        //CryEyeLeft.SetActive(false);
        //CryEyeRight.SetActive(false);
    }

    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }

    public void ArmWithDraw()
    {
        Skullani.SetLayerWeight(1, 0f);
        Skullani.SetLayerWeight(2, 1f);
    }

    public void ArmFree()
    {
        Skullani.SetLayerWeight(1, 0f);
        Skullani.SetLayerWeight(2, 0f);
        Skullani.SetLayerWeight(3, 0f);
        Skullani.SetLayerWeight(4, 0f);
    }

    public void EyePurge()
    {
        Skullani.SetBool("EyePurgeBool", true);
    }

    public void EyeAttack()
    {
        if(EyeAttackLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftUp.transform.position;
            obj.transform.rotation = EyeAttackPosLeftUp.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActLeftUp", 1.0f);
        }
    }
    public void EyeAttackB()
    {
        if (EyeAttackLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftCentor.transform.position;
            obj.transform.rotation = EyeAttackPosLeftCentor.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActLeftCentor", 1.0f);
        }
    }
    public void EyeAttackC()
    {
        if (EyeAttackLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftDown.transform.position;
            obj.transform.rotation = EyeAttackPosLeftDown.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActLeftDown", 1.0f);
        }
    }
    public void EyeAttackD()
    {
        if(EyeAttackRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightUp.transform.position;
            obj.transform.rotation = EyeAttackPosRightUp.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActRightUp", 1.0f);
        }
    }
    public void EyeAttackE()
    {
        if (EyeAttackRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightCentor.transform.position;
            obj.transform.rotation = EyeAttackPosRightCentor.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActRightCentor", 1.0f);
        }
    }
    public void EyeAttackF()
    {
        if (EyeAttackRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightDown.transform.position;
            obj.transform.rotation = EyeAttackPosRightDown.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeAttackActRightDown", 1.0f);
        }
    }

    public void EyeAttackActLeftUp()
    {
        if (EyeAttackLeft != null)
        {
            EyeAttackLeft.SetActive(true);
            EyeAttackLeft.transform.position = EyeAttackPosLeftUp.transform.position;
        }
    }
    public void EyeAttackActLeftCentor()
    {
        if (EyeAttackLeft != null)
        {
            EyeAttackLeft.SetActive(true);
            EyeAttackLeft.transform.position = EyeAttackPosLeftCentor.transform.position;
        }
    }
    public void EyeAttackActLeftDown()
    {
        if (EyeAttackLeft != null)
        {
            EyeAttackLeft.SetActive(true);
            EyeAttackLeft.transform.position = EyeAttackPosLeftDown.transform.position;
        }
    }
    public void EyeAttackActRightUp()
    {
        if (EyeAttackRight != null)
        {
            EyeAttackRight.SetActive(true);
            EyeAttackRight.transform.position = EyeAttackPosRightUp.transform.position;
        }
    }
    public void EyeAttackActRightCentor()
    {
        if (EyeAttackRight != null)
        {
            EyeAttackRight.SetActive(true);
            EyeAttackRight.transform.position = EyeAttackPosRightCentor.transform.position;
        }
    }
    public void EyeAttackActRightDown()
    {
        if (EyeAttackRight != null)
        {
            EyeAttackRight.SetActive(true);
            EyeAttackRight.transform.position = EyeAttackPosRightDown.transform.position;
        }
    }

    public void ThirdEyeAwakeMethod()
    {
        Skullani.SetLayerWeight(5, 1f);
    }

    public void EyeLaserEX()
    {
        Skullani.SetBool("EyeBeamThirdBool", true);
    }
    public void LaserEnabledEX()
    {
        LaserEX.SetActive(true);
    }

    public void EyeBeamLeftUp()
    {
        if (BeamEyeLeft != null)
        {
            BeamEyeLeft.SetActive(true);
            BeamEyeLeft.transform.position = EyeAttackPosLeftUp.transform.position;
        }
    }
    public void EyeBeamLeftCentor()
    {
        if (BeamEyeLeft != null)
        {
            BeamEyeLeft.SetActive(true);
            BeamEyeLeft.transform.position = EyeAttackPosLeftCentor.transform.position;
        }
    }
    public void EyeBeamLeftDown()
    {
        if (BeamEyeLeft != null)
        {
            BeamEyeLeft.SetActive(true);
            BeamEyeLeft.transform.position = EyeAttackPosLeftDown.transform.position;
        }
    }
    public void EyeBeamRightUp()
    {
        if (BeamEyeRight != null)
        {
            BeamEyeRight.SetActive(true);
            BeamEyeRight.transform.position = EyeAttackPosRightUp.transform.position;
        }
    }
    public void EyeBeamRightCentor()
    {
        if (BeamEyeRight != null)
        {
            BeamEyeRight.SetActive(true);
            BeamEyeRight.transform.position = EyeAttackPosRightCentor.transform.position;
        }
    }
    public void EyeBeamRightDown()
    {
        if(BeamEyeRight != null)
        {
            BeamEyeRight.SetActive(true);
            BeamEyeRight.transform.position = EyeAttackPosRightDown.transform.position;
        }
    }
    public void EyeBeamA()
    {
        if(BeamEyeLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftUp.transform.position;
            obj.transform.rotation = EyeAttackPosLeftUp.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamLeftUp", 1.0f);
        }
    }
    public void EyeBeamB()
    {
        if (BeamEyeLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftCentor.transform.position;
            obj.transform.rotation = EyeAttackPosLeftCentor.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamLeftCentor", 1.0f);
        }
    }
    public void EyeBeamC()
    {
        if (BeamEyeLeft != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosLeftDown.transform.position;
            obj.transform.rotation = EyeAttackPosLeftDown.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamLeftDown", 1.0f);
        }
    }
    public void EyeBeamD()
    {
        if(BeamEyeRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightUp.transform.position;
            obj.transform.rotation = EyeAttackPosRightUp.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamRightUp", 1.0f);
        }
    }
    public void EyeBeamE()
    {
        if (BeamEyeRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightCentor.transform.position;
            obj.transform.rotation = EyeAttackPosRightCentor.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamRightCentor", 1.0f);
        }
    }
    public void EyeBeamF()
    {
        if (BeamEyeRight != null)
        {
            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EyeAttackPosRightDown.transform.position;
            obj.transform.rotation = EyeAttackPosRightDown.transform.rotation;
            obj.SetActive(true);

            Invoke("EyeBeamRightDown", 1.0f);
        }
    }

    public void BurnMethodA()
    {
        GameObject obj14A = ObjectPooler14.current.GetPooledObject();
        if (obj14A == null) return;
        obj14A.transform.position = BurnPosA.transform.position;
        obj14A.SetActive(true);

        Shake();
    }
    public void BurnMethodB()
    {
        GameObject obj14B = ObjectPooler14.current.GetPooledObject();
        if (obj14B == null) return;
        obj14B.transform.position = BurnPosB.transform.position;
        obj14B.SetActive(true);

        Shake();
    }
    public void BurnMethodC()
    {
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = BurnPosC.transform.position;
        obj14C.SetActive(true);

        Shake();
    }
    public void BurnMethodD()
    {
        GameObject obj14D = ObjectPooler14.current.GetPooledObject();
        if (obj14D == null) return;
        obj14D.transform.position = BurnPosD.transform.position;
        obj14D.SetActive(true);

        Shake();
    }
    public void BurnMethodE()
    {
        GameObject obj14E = ObjectPooler14.current.GetPooledObject();
        if (obj14E == null) return;
        obj14E.transform.position = BurnPosE.transform.position;
        obj14E.SetActive(true);

        Shake();
    }
}
