using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class ARageScript : MonoBehaviour
{
    public apPortrait RageApPortrait;
    public GameObject ThunderDrumA, ThunderDrumB, ThunderDrumC, ThunderDrumD, ThunderDrumE, ThunderDrumF, ThunderDrumG, ThunderDrumH, HPHolder, HP2, HP3, HP4,
        ChainLock1, ChainLock2, ChainLock3, ChainLock4, ChainLock5, ChainLock6, ChainLock7, ChainLock8, ChainLock9, 
        ThunderFallenDangerA, ThunderFallenDangerB, ThunderFallenDangerC, ThunderFallenDangerD, ThunderFallenDangerE, ThunderFallenDangerF, ThunderFallenDangerG, ThunderFallenDangerH, ThunderFallenDangerI,
        RageThunder, ChainObj, CompleteObj, NightObj, DeathPosA, DeathPosB, DeathPosC, DeathPosD, DeathPosE;       
    public ParticleSystem ThunderFallenA, ThunderFallenB, ThunderFallenC, ThunderFallenD, ThunderFallenE, ThunderFallenF, ThunderFallenG, ThunderFallenH, ThunderFallenI;
    public Animator RageAni, RageBackAni;
    public string flag = "Idle", flagHP = "false";
    public SpriteRenderer HP1Sprite;
    public int AttackNumber = 0, HPCount = 0, NumberStopper = 0, PatternNumber = 0;
    private Rigidbody2D rb;
    bool isCalledOnce = false;
    public BlackFeedScript BlackObj;

    void Start()
    {
        flagHP = "HP1Set";
        flag = "Stop";
        Invoke("flagIdleMethod", 10.0f);
        RageAni.SetBool("CentorAniBool", true);
        RageBackAni.SetBool("RageBackPurgeBool", false);
        RageBackAni.SetBool("RageBackIdleBool", false);
    }
    public void flagIdleMethod()
    {
        flag = "Idle";
    }
    // Update is called once per frame
    void Update()
    {
        RageApPortrait.Play("Author'sRageIdle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        if (flag == "Idle")
        {
            if (PatternNumber == 1)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock1.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 2)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock2.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 3)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock3.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 4)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock4.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 5)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock5.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 6)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock6.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 7)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock7.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 8)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock8.SetActive(true);
                PatternNumber = 0;
            }
            if (PatternNumber == 9)
            {
                ChainObj.SetActive(true);
                //Skullani.SetLayerWeight(3, 0.4f);
                ChainLock9.SetActive(true);
                PatternNumber = 0;
            }

            if (AttackNumber == 10)
            {
                AttackNumber = 0;
                ThunderDrumAllAttack();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 4.0f);
            }

            if (AttackNumber == 2)
            {
                AttackNumber = 0;
                ThunderAndDangerA();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 3)
            {
                AttackNumber = 0;
                ThunderAndDangerB();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 4)
            {
                AttackNumber = 0;
                ThunderAndDangerC();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 5)
            {
                AttackNumber = 0;
                ThunderAndDangerD();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 6)
            {
                AttackNumber = 0;
                ThunderAndDangerE();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 7)
            {
                AttackNumber = 0;
                ThunderAndDangerF();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 8)
            {
                AttackNumber = 0;
                ThunderAndDangerG();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 9)
            {
                AttackNumber = 0;
                ThunderAndDangerH();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 1)
            {
                AttackNumber = 0;
                ThunderAndDangerI();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 11)
            {
                AttackNumber = 0;
                ThunderAndDangerI();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerH", 0.2f);
                Invoke("ThunderAndDangerG", 0.4f);
                Invoke("ThunderAndDangerF", 0.6f);
                Invoke("ThunderAndDangerE", 0.8f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 12)
            {
                AttackNumber = 0;
                ThunderAndDangerA();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerB", 0.2f);
                Invoke("ThunderAndDangerC", 0.4f);
                Invoke("ThunderAndDangerD", 0.6f);
                Invoke("ThunderAndDangerE", 0.8f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 13)
            {
                RageBackAni.SetBool("RageBackIdleBool", false);
                RageBackAni.SetBool("RageBackPurgeBool", true);
                AttackNumber = 0;
                ThunderAndDangerA();
                ThunderAndDangerI();
                Invoke("ThunderAndDangerB", 0.2f);
                Invoke("ThunderAndDangerH", 0.2f);
                Invoke("ThunderAndDangerC", 0.4f);
                Invoke("ThunderAndDangerG", 0.4f);
                Invoke("ThunderAndDangerD", 0.6f);
                Invoke("ThunderAndDangerF", 0.6f);
                Invoke("ThunderAndDangerE", 1.2f);
                Invoke("ThunderAndDangerD", 1.4f);
                Invoke("ThunderAndDangerF", 1.4f);
                Invoke("ThunderAndDangerC", 1.6f);
                Invoke("ThunderAndDangerG", 1.6f);
                Invoke("ThunderAndDangerB", 1.8f);
                Invoke("ThunderAndDangerH", 1.8f);
                Invoke("ThunderDrumAllAttack", 2.2f);
                NumberStopper = 1;
                Invoke("ANumberReset", 5.0f);
                Invoke("RageThunderAttack", 2.5f);
                Invoke("RageBackReset", 6.0f); 
            }
            if (AttackNumber == 14)
            {
                AttackNumber = 0;
                ThunderAndDangerA();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerB", 0.2f);
                Invoke("ThunderAndDangerF", 0.4f);
                Invoke("ThunderAndDangerI", 0.6f);
                Invoke("ThunderAndDangerE", 0.8f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 15)
            {
                AttackNumber = 0;
                ThunderAndDangerF();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerA", 0.2f);
                Invoke("ThunderAndDangerC", 0.4f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 16)
            {
                AttackNumber = 0;
                ThunderAndDangerC();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerE", 0.2f);
                Invoke("ThunderAndDangerI", 0.4f);
                Invoke("ThunderAndDangerB", 0.6f);
                Invoke("ThunderAndDangerD", 0.8f);
                Invoke("ANumberReset", 0.5f);
            }
            if (AttackNumber == 17)
            {
                AttackNumber = 0;
                ThunderAndDangerG();
                NumberStopper = 1;
                //Invoke("AttackArmRightMethod", 2.0f);
                Invoke("ThunderAndDangerB", 0.2f);
                Invoke("ThunderAndDangerA", 0.4f);
                Invoke("ThunderAndDangerF", 0.6f);
                Invoke("ThunderAndDangerD", 0.8f);
                Invoke("ANumberReset", 0.5f);
            }
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
            RageAni.SetBool("CentorAniBool", false);
            HP4.SetActive(false);
            NightObj.SetActive(false);
        }
        if (HPCount == 4)
        {
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                HPHolder.SetActive(false);
                //Skullani.SetBool("TrueFinishBool", true);
                Invoke("CompleteMethod", 1.0f);
                Invoke("FeedOutMethod", 2.0f);
                RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                DeathMethodA();
                Invoke("DeathMethodC", 0.2f);
                Invoke("DeathMethodB", 0.4f);
                Invoke("DeathMethodE", 0.6f);
                Invoke("DeathMethodD", 0.8f);
                Invoke("DeathMethodA", 1.0f);
                Invoke("DeathMethodE", 1.2f);
                Invoke("DeathMethodB", 1.4f);
                Invoke("DeathMethodD", 1.6f);
                Invoke("DeathMethodC", 1.8f);
                Invoke("DeathMethodA", 2.0f);
                Invoke("DeathMethodC", 2.2f);
            }
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

    public void CompleteMethod()
    {
        CompleteObj.SetActive(true);
    }
    public void FeedOutMethod()
    {
        BlackObj.Completeflag();
    }

    public void RandomMethodFX()
    {
        if (HPCount == 0)
        {
            if (NumberStopper == 0)
            {
                PatternNumber = Random.Range(1, 100);
                AttackNumber = Random.Range(1, 10);
            }
        }
        if (HPCount == 1)
        {
            if (NumberStopper == 0)
            {
                PatternNumber = Random.Range(1, 100);
                AttackNumber = Random.Range(1, 12);
            }
        }
        if (HPCount == 2)
        {
            if (NumberStopper == 0)
            {
                PatternNumber = Random.Range(1, 100);
                AttackNumber = Random.Range(1, 17);
            }
        }
        if (HPCount == 3)
        {
            if (NumberStopper == 0)
            {
                PatternNumber = Random.Range(1, 100);
                AttackNumber = Random.Range(10, 17);
            }
        }
    }
    public void ANumberReset()
    {
        NumberStopper = 0;
    }
    public void RageBackReset()
    {
        RageBackAni.SetBool("RageBackIdleBool", true);
        RageBackAni.SetBool("RageBackPurgeBool", false);
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (flagHP == "Idle")
        {
            if (trcol.gameObject.tag == "Attack")
            {
                RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                Invoke("ApResetMethod", 0.5f);
                HP1Sprite.size -= new Vector2(0.5f, 0.0f);
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
                RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                Invoke("ApResetMethod", 0.5f);
                HP1Sprite.size -= new Vector2(0.005f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .05f);
            }
        }
    }
    /*void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            RageApPortrait.Play("RageDamage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            Invoke("ApResetMethod", 0.5f);
            HP1Sprite.size -= new Vector2(0.005f, 0.0f);
        }
    }*/

    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }

    void ApResetMethod()
    {
        RageApPortrait.StopLayer(2);
    }

    public void ThunderDrumAttackA()
    {
        ThunderDrumA.SetActive(true);
    }
    public void ThunderDrumAttackB()
    {
        ThunderDrumB.SetActive(true);
    }
    public void ThunderDrumAttackC()
    {
        ThunderDrumC.SetActive(true);
    }
    public void ThunderDrumAttackD()
    {
        ThunderDrumD.SetActive(true);
    }
    public void ThunderDrumAttackE()
    {
        ThunderDrumE.SetActive(true);
    }
    public void ThunderDrumAttackF()
    {
        ThunderDrumF.SetActive(true);
    }
    public void ThunderDrumAttackG()
    {
        ThunderDrumG.SetActive(true);
    }
    public void ThunderDrumAttackH()
    {
        ThunderDrumH.SetActive(true);
    }

    public void ThunderDrumAllAttack()
    {
        ThunderDrumAttackA();
        Invoke("ThunderDrumAttackB", 0.2f);
        Invoke("ThunderDrumAttackC", 0.4f);
        Invoke("ThunderDrumAttackD", 0.6f);
        Invoke("ThunderDrumAttackE", 0.8f);
        Invoke("ThunderDrumAttackF", 1.0f);
        Invoke("ThunderDrumAttackG", 1.2f);
        Invoke("ThunderDrumAttackH", 1.4f);
    }

    public void NightMethod()
    {
        NightObj.SetActive(false);
    }
    public void ThunderFallenAttackA()
    {
        ThunderFallenA.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackB()
    {
        ThunderFallenB.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackC()
    {
        ThunderFallenC.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackD()
    {
        ThunderFallenD.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackE()
    {
        ThunderFallenE.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackF()
    {
        ThunderFallenF.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackG()
    {
        ThunderFallenG.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackH()
    {
        ThunderFallenH.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }
    public void ThunderFallenAttackI()
    {
        ThunderFallenI.Play();
        NightObj.SetActive(true);
        Invoke("NightMethod", 0.1f);
    }

    public void ThunderAndDangerA()
    {
        //Debug.Log("test");
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerA.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackA", 1.0f);
    }
    public void ThunderAndDangerB()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerB.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackB", 1.0f);
    }
    public void ThunderAndDangerC()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerC.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackC", 1.0f);
    }
    public void ThunderAndDangerD()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerD.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackD", 1.0f);
    }
    public void ThunderAndDangerE()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerE.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackE", 1.0f);
    }
    public void ThunderAndDangerF()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerF.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackF", 1.0f);
    }
    public void ThunderAndDangerG()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerG.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackG", 1.0f);
    }
    public void ThunderAndDangerH()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerH.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackH", 1.0f);
    }
    public void ThunderAndDangerI()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = ThunderFallenDangerI.transform.position;
        obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
        obj.SetActive(true);

        Invoke("ThunderFallenAttackI", 1.0f);
    }
    public void RageThunderAttack()
    {
        RageThunder.SetActive(true);
    }

    public void DeathMethodA()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DeathPosA.transform.position;
        //obj.transform.rotation = DeathPosA.transform.rotation;
        obj.SetActive(true);
        Shake();
    }
    public void DeathMethodB()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DeathPosB.transform.position;
        //obj.transform.rotation = DeathPosA.transform.rotation;
        obj.SetActive(true);
        Shake();
    }
    public void DeathMethodC()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DeathPosC.transform.position;
        //obj.transform.rotation = DeathPosA.transform.rotation;
        obj.SetActive(true);
        Shake();
    }
    public void DeathMethodD()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DeathPosD.transform.position;
        //obj.transform.rotation = DeathPosA.transform.rotation;
        obj.SetActive(true);
        Shake();
    }
    public void DeathMethodE()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DeathPosE.transform.position;
        //obj.transform.rotation = DeathPosA.transform.rotation;
        obj.SetActive(true);
        Shake();
    }
}
