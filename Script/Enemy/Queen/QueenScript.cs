using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class QueenScript : MonoBehaviour
{
    public Animator QAnim, HPAni, QBSetAnim, NameAni;
    public float StartPos_X, StartPos_Y, MoveH, MoveV, EndPos_Y, BladeStabDiagonalMoveX, DiagonalStabEndPosY, DiagonalStabRotaZ, FallStabMoveY, DestroyPos_Y, BladeSetMoveX;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HP7, DSFParObj, DSFParPos, DiagonalStabPos, FSFParObj, PlayerPos,
        BPSet1Pos, BladeSetObj1, SwingPosRight, SwingPosLeft, BladeSetObj2,
        BladeFeatherParPos1, BladeFeatherParPos2, BladeFeatherParPos3, BladeFeatherParPos4, BladeFeatherParObj1, BladeFeatherParObj2, BladeFeatherParObj3, BladeFeatherParObj4, QFeatherParObj,
        FallBlade1, FallBlade2, FallBlade3, FallBlade4/*, FallBladeFParObj1, FallBladeFParObj2, FallBladeFParObj3, FallBladeFParObj4*/, 
        HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7, DisableFParObj, QBPortalSetObj, NameObj;
    public string Flag, FlagHP, SEFlag;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop, BGSprite1, BGSprite2;
    public AudioClip HPSound, StabClip, FeatherClip, SwingClip, DisableClip, LandClip;
    public AudioSource HPASLoop, SEASource, SEASource2;
    public Collider2D QueenCol, StabCol, StabFallCol;
    public ParticleSystem StabPar, StabFeatherPar, StabFallPar, StabFallFeatherPar, BSEnableFPar, RushPar, BladeSetFPar, BladeFeatherPar1, BladeFeatherPar2, BladeFeatherPar3, BladeFeatherPar4, QFeatherPar/*,
        FallBladeFPar1, FallBladeFPar2, FallBladeFPar3, FallBladeFPar4*/, DisableFPar, StageParLeft, StageParRight;
    public Rigidbody2D rb;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void QueenEnabled()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
        HPObj.SetActive(true);
        QAnim.SetBool("LeaveBool", false);
        QAnim.SetBool("BladeAttackStartBool", false);
        QAnim.SetBool("BladeSamonStartBool", false);
        if(QBPortalSetObj.activeSelf)
        {
            QBSetAnim.SetBool("CloseBool", true);
        }        
        //BladeHolderAni2.SetBool("Ani2Bool", false);
        //QAnim.SetBool("ChargeBool", true);
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        Flag = "Fall";
        HPAni.SetBool("PargeBool", false);
        HPCount = 7;
        FlagHP = "Null";
        QueenCol.enabled = true;
        StabCol.enabled = false;
        StabFallCol.enabled = false;
        StabPar.Stop();
        StabFallPar.Stop();
        BladeSetObj2.SetActive(false);
        NameObj.SetActive(true);
        NameAni.SetBool("NameEndBool", false);
        HP1.SetActive(true);
        HPB1.SetActive(false);
        HP2.SetActive(true);
        HPB2.SetActive(false);
        HP3.SetActive(true);
        HPB3.SetActive(false);
        HP4.SetActive(true);
        HPB4.SetActive(false);
        HP5.SetActive(true);
        HPB5.SetActive(false);
        HP6.SetActive(true);
        HPB6.SetActive(false);
        HP7.SetActive(true);
        HPB7.SetActive(false);
        SEFlag = "Off";
    }
    public void QHPResetMethod()
    {
        if (Flag != "End")
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            HPObj.SetActive(true);
            QAnim.SetBool("LeaveBool", false);
            QAnim.SetBool("BladeAttackStartBool", false);
            QAnim.SetBool("BladeSamonStartBool", false);
            if (QBPortalSetObj.activeSelf)
            {
                QBSetAnim.SetBool("CloseBool", true);
            }
            //BladeHolderAni2.SetBool("Ani2Bool", false);
            //QAnim.SetBool("ChargeBool", true);
            this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
            Flag = "Fall";
            HPAni.SetBool("PargeBool", false);
            //HPCount = 7;
            //FlagHP = "Null";
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabFallCol.enabled = false;
            StabPar.Stop();
            StabFallPar.Stop();
            BladeSetObj2.SetActive(false);
            SEFlag = "Off";
        }            
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Flag == "Fall")
        {
            this.transform.Translate(0, MoveV, 0);
            NumberStopper = 1;
        }
        if (this.transform.localPosition.y <= EndPos_Y)
        {
            if(Flag == "Fall")
            {
                Flag = "Stop";
                ScreenShakeController.instance.StartShake(.1f, .2f);
                cam.backgroundColor = new Color32(80, 0, 0, 255);
                tilemap1.color = new Color32(140, 0, 70, 255);
                tilemap2.color = new Color32(115, 0, 60, 255);
                BackLightBottom.color = new Color32(255, 0, 128, 255);
                BackLightTop.color = new Color32(160, 0, 70, 255);
                BGSprite1.color = new Color32(115, 0, 60, 255);
                BGSprite2.color = new Color32(115, 0, 60, 255);
                StageParLeft.startColor = new Color32(45, 0, 25, 255);
                StageParRight.startColor = new Color32(45, 0, 25, 255);
                QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                SEASource2.clip = LandClip;
                SEASource2.Play();
                //NumberStopper = 0;
                if (HP1.activeSelf)
                {
                    if (HP1Sprite.size.x <= 1.28)
                    {
                        if (FlagHP == "Null")
                        {
                            FlagHP = "HPSet";
                            /*if (HPCount >= 0)
                            {
                                HPCount--;
                            }*/
                        }
                    }
                }
            }
            if (Flag == "BladeSamonStart")
            {
                Flag = "BladeSamon";
                ScreenShakeController.instance.StartShake(.1f, .2f);
                SEASource.clip = LandClip;
                SEASource.Play();
            }
            if (Flag == "BladeSwing1Start")
            {
                Flag = "BladeSwing1";
                ScreenShakeController.instance.StartShake(.1f, .2f);
                //BladeSetEnableMethod();
            }
        }
        if (FlagHP == "HPSet")
        {
            if (HP1.activeSelf)
            {
                HP1Sprite.size += new Vector2(0.1f, 0.0f);
                //WAniSpeed5();
                if (HPASLoop.isPlaying == false)
                {
                    HPASLoop.Play();
                }                    
                //Debug.Log("audio");
                if (HP1Sprite.size.x >= 15)
                {
                    FlagHP = "Null";
                    NumberStopper = 0;
                    //WAniSpeed2();
                    HPASLoop.Stop();
                    QAnim.SetBool("LeaveBool", true);
                    //Flag = "Leave";
                    QueenCol.enabled = false;

                    if (HPCount == 7)
                    {
                        HPCount--;
                    }
                }
            }                
        }
        if(Flag == "DiagonalStab")
        {
            StabPar.Play();
            QAnim.Play("BladeStabAni", 0, 0.0f);
            this.transform.Translate(BladeStabDiagonalMoveX, 0, 0);
            //rb.velocity = new Vector2(BladeStabDiagonalMoveX, 0);
            if (SEFlag == "Off")
            {
                SEASource.clip = StabClip;
                SEASource.Play();
                SEFlag = "On";
            }
        }
        if (this.transform.localPosition.y <= DiagonalStabEndPosY)
        {
            if(Flag == "DiagonalStab")
            {
                Vector3 DSPP = DSFParPos.transform.position;
                DSFParObj.transform.position = new Vector2(DSPP.x, -3.98f);
                StabFeatherPar.Play();
                //DSFParObj.transform.position = DSFParPos.transform.position;
                //DSFParObj.transform.rotation = DSFParPos.transform.rotation;
                //PositionReset();
                Invoke("PositionReset", 0.01f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
                SEASource.clip = FeatherClip;
                SEASource.Play();
                SEASource2.clip = LandClip;
                SEASource2.Play();
                GameObject obj12 = ObjectPooler12.current.GetPooledObject();
                if (obj12 == null) return;
                obj12.transform.position = DSFParObj.transform.position;
                obj12.SetActive(true);

                GameObject obj41 = ObjectPooler41.current.GetPooledObject();
                if (obj41 == null) return;
                obj41.transform.position = DSFParObj.transform.position;
                obj41.SetActive(true);

                GameObject obj42 = ObjectPooler42.current.GetPooledObject();
                if (obj42 == null) return;
                obj42.transform.position = DSFParObj.transform.position;
                obj42.SetActive(true);
            }
            if (Flag == "FallStab")
            {
                Vector3 DSPP = DSFParPos.transform.position;
                FSFParObj.transform.position = new Vector2(DSPP.x, -3.98f);
                StabFallFeatherPar.Play();
                //DSFParObj.transform.position = DSFParPos.transform.position;
                //DSFParObj.transform.rotation = DSFParPos.transform.rotation;
                //PositionReset();
                Invoke("PositionReset", 0.01f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
                SEASource.clip = FeatherClip;
                SEASource.Play();
                SEASource2.clip = LandClip;
                SEASource2.Play();
                GameObject obj12 = ObjectPooler12.current.GetPooledObject();
                if (obj12 == null) return;
                obj12.transform.position = FSFParObj.transform.position;
                obj12.SetActive(true);

                GameObject obj41 = ObjectPooler41.current.GetPooledObject();
                if (obj41 == null) return;
                obj41.transform.position = FSFParObj.transform.position;
                obj41.SetActive(true);

                GameObject obj42 = ObjectPooler42.current.GetPooledObject();
                if (obj42 == null) return;
                obj42.transform.position = FSFParObj.transform.position;
                obj42.SetActive(true);
            }
            if (Flag == "Fall5sGo")
            {
                Vector3 DSPP = DSFParPos.transform.position;
                FSFParObj.transform.position = new Vector2(DSPP.x, -3.98f);
                StabFallFeatherPar.Play();
                //DSFParObj.transform.position = DSFParPos.transform.position;
                //DSFParObj.transform.rotation = DSFParPos.transform.rotation;
                //PositionReset();
                Invoke("PositionReset", 0.01f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
                SEASource.clip = FeatherClip;
                SEASource.Play();
                SEASource2.clip = LandClip;
                SEASource2.Play();
                GameObject obj12 = ObjectPooler12.current.GetPooledObject();
                if (obj12 == null) return;
                obj12.transform.position = FSFParObj.transform.position;
                obj12.SetActive(true);

                GameObject obj41 = ObjectPooler41.current.GetPooledObject();
                if (obj41 == null) return;
                obj41.transform.position = FSFParObj.transform.position;
                obj41.SetActive(true);

                GameObject obj42 = ObjectPooler42.current.GetPooledObject();
                if (obj42 == null) return;
                obj42.transform.position = FSFParObj.transform.position;
                obj42.SetActive(true);
            }
        }
        if(Flag == "FallStab")
        {
            StabFallPar.Play();
            QAnim.Play("WingCloseBladeFallAni", 0, 0.0f);
            this.transform.Translate(0, FallStabMoveY, 0);
            if(SEFlag == "Off")
            {
                SEASource.clip = StabClip;
                SEASource.Play();
                SEFlag = "On";
            }
        }
        if(Flag == "BladeStab")
        {
            StabPar.Play();
            this.transform.Translate(BladeStabDiagonalMoveX, 0, 0);
            if (SEFlag == "Off")
            {
                SEASource.clip = StabClip;
                SEASource.Play();
                SEFlag = "On";
            }
        }
        if (this.transform.localPosition.x <= -12)
        {
            if (Flag == "BladeStab")
            {
                Invoke("PositionReset", 0.01f);
            }
        }
        if (Flag == "BladeSamonStart")
        {
            this.transform.Translate(0, MoveV, 0);
            //NumberStopper = 1;
        }
        if (Flag == "BladeSwing1Start")
        {
            this.transform.Translate(0, MoveV, 0);
            //NumberStopper = 1;
        }
        if(Flag == "BladeSwingRight" || Flag == "BladeSwingLeft")
        {
            this.transform.Translate(0, MoveV, 0);
            BladeSetObj2.SetActive(true);
        }
        if (this.transform.localPosition.y <= 1.945f)
        {
            if(Flag == "BladeSwingRight")
            {
                Flag = "BladeSwingRightStop";
            }
            if (Flag == "BladeSwingLeft")
            {
                Flag = "BladeSwingLeftStop";
            }
        }
        if(Flag == "Fall5sGo")
        {
            StabFallPar.Play();
            QAnim.Play("WingCloseBladeFallAni", 0, 0.0f);
            this.transform.Translate(0, FallStabMoveY, 0);
            /*FallBlade1.transform.Translate(0, -FallStabMoveY, 0);
            FallBlade2.transform.Translate(0, -FallStabMoveY, 0);
            FallBlade3.transform.Translate(0, -FallStabMoveY, 0);
            FallBlade4.transform.Translate(0, -FallStabMoveY, 0);
            */
        }
        /*if (FallBlade1.transform.localPosition.y <= -1.3)
        {
            Vector3 FBPP = FallBlade1.transform.position;
            FallBladeFParObj1.transform.position = new Vector2(FBPP.x, -1.3f);
            FallBladeFPar1.Play();
            Invoke("FallBlade1PosReset", 0.01f);
            ScreenShakeController.instance.StartShake(.1f, .2f);
        }
        if (FallBlade2.transform.localPosition.y <= -1.3)
        {
            Vector3 FBPP = FallBlade2.transform.position;
            FallBladeFParObj2.transform.position = new Vector2(FBPP.x, -1.3f);
            FallBladeFPar1.Play();
            Invoke("FallBlade2PosReset", 0.01f);
            ScreenShakeController.instance.StartShake(.1f, .2f);
        }
        if (FallBlade3.transform.localPosition.y <= -1.3)
        {
            Vector3 FBPP = FallBlade3.transform.position;
            FallBladeFParObj3.transform.position = new Vector2(FBPP.x, -1.3f);
            FallBladeFPar3.Play();
            Invoke("FallBlade3PosReset", 0.01f);
            ScreenShakeController.instance.StartShake(.1f, .2f);
        }
        if (FallBlade4.transform.localPosition.y <= -1.3)
        {
            Vector3 FBPP = FallBlade4.transform.position;
            FallBladeFParObj4.transform.position = new Vector2(FBPP.x, -1.3f);
            FallBladeFPar4.Play();
            Invoke("FallBlade4PosReset", 0.01f);
            ScreenShakeController.instance.StartShake(.1f, .2f);
        }*/
        if (HP1Sprite.size.x <= 1.28)
        {
            if(HPCount == 6)
            {
                if (FlagHP != "HPSet")
                {
                    HP7.SetActive(false);
                    HPB7.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);                    
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 5)
            {
                if (FlagHP != "HPSet")
                {
                    HP6.SetActive(false);
                    HPB6.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 4)
            {
                if (FlagHP != "HPSet")
                {
                    HP5.SetActive(false);
                    HPB5.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 3)
            {
                if (FlagHP != "HPSet")
                {
                    HP4.SetActive(false);
                    HPB4.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 2)
            {
                if (FlagHP != "HPSet")
                {
                    HP3.SetActive(false);
                    HPB3.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 1)
            {
                if (FlagHP != "HPSet")
                {
                    HP2.SetActive(false);
                    HPB2.SetActive(true);

                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 0)
            {
                if (Flag != "End")
                {
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    QAnim.Play("DeathAni", 0, 0.0f);
                    //this.gameObject.transform.position = QDPosObj.transform.position;
                    //this.transform.Translate(0, 0.1f, 0);
                    if (QBPortalSetObj.activeSelf)
                    {
                        QBSetAnim.SetBool("CloseBool", true);
                    }
                }
            }
        }
        if(Flag == "BladeSetMove")
        {
            if (QBPortalSetObj.transform.localPosition.x >= -8.5)
            {
                QBPortalSetObj.transform.Translate(BladeSetMoveX, 0, 0);
            }
        }
    }
    public void PositionReset()
    {
        SEFlag = "Off";
        AniLoopCount = 0;
        //Debug.Log("tst");
        if (Flag != "BladeSwing1Action" && Flag != "BladeSwingLeftStart" && Flag != "Fall5s")
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
            this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabFallCol.enabled = false;
            Flag = "NumberChoice";
            StabPar.Stop();
            StabFallPar.Stop();
            NumberStopper = 0;
            QAnim.SetBool("LeaveBool", false);
            QAnim.SetBool("BladeSamonStartBool", false);
            QAnim.SetBool("BladeAttackStartBool", false);
            //BladeHolderAni2.SetBool("Ani2Bool", false);
            BladeSetObj2.SetActive(false);
        }
        if (Flag == "BladeSwing1Action")
        {
            //Debug.Log("test");
            Vector3 SPR = SwingPosRight.transform.position;
            this.transform.position = new Vector2(SPR.x, StartPos_Y);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabFallCol.enabled = false;
            Flag = "BladeSwingRight";
            QAnim.Play("BladeSwingDownStartAni", 0, 0.0f);
            BladeSetObj2.SetActive(true);
        }
        if (Flag == "BladeSwingLeftStart")
        {
            transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            Vector3 SPL = SwingPosLeft.transform.position;
            this.transform.position = new Vector2(SPL.x, StartPos_Y);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabFallCol.enabled = false;
            Flag = "BladeSwingLeft";
            QAnim.Play("BladeSwingDownStartAni", 0, 0.0f);
            BladeSetObj2.SetActive(false);
        }
        if (Flag == "Fall5s")
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            this.transform.position = new Vector2(0, StartPos_Y);
            StabFallCol.enabled = true;
            Flag = "Fall5sGo";
            FallBlade1.SetActive(true);
            FallBlade2.SetActive(true);
            FallBlade3.SetActive(true);
            FallBlade4.SetActive(true);
            BladeSetObj2.SetActive(false);
        }
    }
    public void QAniRandomMethod()
    {
        if (HPCount == 7)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 10);
            }
        }
        if (HPCount == 6)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 11);
            }
        }
        if (HPCount == 5)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 12);
            }
        }
        if (HPCount == 4)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(5, 13);
            }
        }
        if (HPCount == 3)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 12);
            }
        }
        if (HPCount == 2)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(5, 16);
            }
        }
        if (HPCount == 1 || HPCount == 0)
        {
            if (NumberStopper == 0)
            {
                AttackNumber = Random.Range(1, 16);
            }
        }
    }
    public void QAniEventMethod()
    {
        /*
        if (HPCount != 0)
        {
            if(Flag == "Stop")
            {
                if (AttackNumber == 1 || AttackNumber == 2 || AttackNumber == 5 || AttackNumber == 6)
                {
                    Flag = "DiagonalStab";
                    this.transform.rotation = Quaternion.Euler(0, 0, DiagonalStabRotaZ);
                    Vector3 DSP = DiagonalStabPos.transform.position;
                    this.transform.position = new Vector2(DSP.x, StartPos_Y);
                    StabCol.enabled = true;
                }
                if (AttackNumber == 3 || AttackNumber == 4 || AttackNumber == 7 || AttackNumber == 8)
                {
                    Flag = "FallStab";
                    Vector3 FSP = PlayerPos.transform.position;
                    this.transform.position = new Vector2(FSP.x, StartPos_Y);
                    StabFallCol.enabled = true;
                }
                if(AttackNumber == 9 || AttackNumber == 10 || AttackNumber == 14 || AttackNumber == 15)
                {
                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                    Flag = "BladeSamonStart";
                    NumberStopper = 0;
                    QAnim.SetBool("BladeSamonStartBool", true);
                    QAnim.SetBool("LeaveBool", false);
                }
                if (AttackNumber == 11 || AttackNumber == 12 || AttackNumber == 13)
                {
                    Flag = "BladeSwing1Start";
                    QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                }
            }            
        }
        */
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 2 || AttackNumber == 5 || AttackNumber == 6)
            {
                Flag = "DiagonalStab";
                this.transform.rotation = Quaternion.Euler(0, 0, DiagonalStabRotaZ);
                Vector3 DSP = DiagonalStabPos.transform.position;
                this.transform.position = new Vector2(DSP.x, StartPos_Y);
                StabCol.enabled = true;
            }
            if (AttackNumber == 3 || AttackNumber == 4 || AttackNumber == 7 || AttackNumber == 8)
            {
                Flag = "FallStab";
                Vector3 FSP = PlayerPos.transform.position;
                this.transform.position = new Vector2(FSP.x, StartPos_Y);
                StabFallCol.enabled = true;
            }
            if (AttackNumber == 9 || AttackNumber == 10 || AttackNumber == 14 || AttackNumber == 15)
            {
                QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                Flag = "BladeSamonStart";
                NumberStopper = 0;
                QAnim.SetBool("BladeSamonStartBool", true);
                QAnim.SetBool("LeaveBool", false);
            }
            if (AttackNumber == 11 || AttackNumber == 12 || AttackNumber == 13)
            {
                Flag = "BladeSwing1Start";
                QAnim.Play("QueenVisitAniLand", 0, 0.0f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.1f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(1.0f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.1f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(1.0f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "AttackSPB")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.5f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
    }
    public void BPSetSamonMethod()
    {
        if (Flag == "BladeSamon")
        {
            if (QBPortalSetObj.activeSelf == false)
            {
                QBPortalSetObj.transform.position = BPSet1Pos.transform.position;
                QBPortalSetObj.SetActive(true);
                Flag = "BladeSetMove";
                QBSetAnim.SetBool("CloseBool", false);
            }
        }
        if(Flag == "BladeSetMove")
        {
            if (QBPortalSetObj.transform.localPosition.x <= -8.5)
            {
                if (QBPortalSetObj.activeSelf)
                {
                    QBSetAnim.SetBool("CloseBool", true);
                }
                QAnim.SetBool("BladeAttackStartBool", true);
                Flag = "BladeStabReady";
            }
        }

        /*
        if(Flag == "BladeSamon")
        {
            if (NumberStopper == 0)
            {
                if (BPSet1.activeSelf == false)
                {
                    BPSet1.SetActive(true);
                    BPSet1.transform.position = BPSet1Pos.transform.position;
                    //NumberStopper++;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 1)
            {
                if (BPSet1.activeSelf)
                {
                    BPSet2.SetActive(true);
                    BPSet2.transform.position = BPSet2Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 2)
            {
                if (BPSet2.activeSelf)
                {
                    BPSet3.SetActive(true);
                    BPSet3.transform.position = BPSet3Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 3)
            {
                if (BPSet3.activeSelf)
                {
                    BPSet4.SetActive(true);
                    BPSet4.transform.position = BPSet4Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 4)
            {
                if (BPSet4.activeSelf)
                {
                    BPSet5.SetActive(true);
                    BPSet5.transform.position = BPSet5Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 5)
            {
                if (BPSet5.activeSelf)
                {
                    BPSet6.SetActive(true);
                    BPSet6.transform.position = BPSet6Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 6)
            {
                if (BPSet6.activeSelf)
                {
                    BPSet7.SetActive(true);
                    BPSet7.transform.position = BPSet7Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 7)
            {
                if (BPSet7.activeSelf)
                {
                    BPSet8.SetActive(true);
                    BPSet8.transform.position = BPSet8Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 8)
            {
                if (BPSet8.activeSelf)
                {
                    BPSet9.SetActive(true);
                    BPSet9.transform.position = BPSet9Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 9)
            {
                if (BPSet9.activeSelf)
                {
                    BPSet10.SetActive(true);
                    BPSet10.transform.position = BPSet10Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 10)
            {
                if (BPSet10.activeSelf)
                {
                    BPSet11.SetActive(true);
                    BPSet11.transform.position = BPSet11Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 11)
            {
                if (BPSet11.activeSelf)
                {
                    BPSet12.SetActive(true);
                    BPSet12.transform.position = BPSet12Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 12)
            {
                if (BPSet12.activeSelf)
                {
                    BPSet13.SetActive(true);
                    BPSet13.transform.position = BPSet13Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 13)
            {
                if (BPSet13.activeSelf)
                {
                    BPSet14.SetActive(true);
                    BPSet14.transform.position = BPSet14Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 14)
            {
                if (BPSet14.activeSelf)
                {
                    BPSet15.SetActive(true);
                    BPSet15.transform.position = BPSet15Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 15)
            {
                if (BPSet15.activeSelf)
                {
                    BPSet16.SetActive(true);
                    BPSet16.transform.position = BPSet16Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 16)
            {
                if (BPSet16.activeSelf)
                {
                    BPSet17.SetActive(true);
                    BPSet17.transform.position = BPSet17Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 17)
            {
                if (BPSet17.activeSelf)
                {
                    BPSet18.SetActive(true);
                    BPSet18.transform.position = BPSet18Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 18)
            {
                if (BPSet18.activeSelf)
                {
                    BPSet19.SetActive(true);
                    BPSet19.transform.position = BPSet19Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 19)
            {
                if (BPSet19.activeSelf)
                {
                    BPSet20.SetActive(true);
                    BPSet20.transform.position = BPSet20Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 20)
            {
                if (BPSet20.activeSelf)
                {
                    BPSet21.SetActive(true);
                    BPSet21.transform.position = BPSet21Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 21)
            {
                if (BPSet21.activeSelf)
                {
                    BPSet22.SetActive(true);
                    BPSet22.transform.position = BPSet22Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 22)
            {
                if (BPSet22.activeSelf)
                {
                    BPSet23.SetActive(true);
                    BPSet23.transform.position = BPSet23Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 23)
            {
                if (BPSet23.activeSelf)
                {
                    BPSet24.SetActive(true);
                    BPSet24.transform.position = BPSet24Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 24)
            {
                if (BPSet24.activeSelf)
                {
                    BPSet25.SetActive(true);
                    BPSet25.transform.position = BPSet25Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 25)
            {
                if (BPSet25.activeSelf)
                {
                    BPSet26.SetActive(true);
                    BPSet26.transform.position = BPSet26Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 26)
            {
                if (BPSet26.activeSelf)
                {
                    BPSet27.SetActive(true);
                    BPSet27.transform.position = BPSet27Pos.transform.position;
                    Invoke("NumberStopperMethod", 0.01f);
                }
            }
            if (NumberStopper == 27)
            {
                if (BPSet27.activeSelf)
                {
                    Invoke("NumberStopperMethod", 0.01f);
                    QAnim.SetBool("BladeAttackStartBool", true);
                    Flag = "BladeStabReady";
                }
            }
        }        
        */
    }
    public void NumberStopperMethod()
    {
        NumberStopper++;
    }
    public void FlagChangeStab()
    {
        if(Flag == "BladeStabReady")
        {
            Flag = "BladeStab";
            StabCol.enabled = true;
            RushPar.Play();
        }
    }
    public void BSEnableFParMethod()
    {
        BSEnableFPar.Play();
        SEASource.clip = FeatherClip;
        SEASource.Play();
    }
    public void BladeSetAniMethod()
    {
        //↓アニメーション不自然
        //BladeHolderAni2.SetBool("Ani2Bool", true);
    }
    public void BladeSetEnableMethod()
    {
        if(Flag == "BladeSwing1")
        {
            BladeSetObj1.SetActive(true);
            BladeSetObj1.transform.position = this.transform.position;
            NumberStopper++;
            //QAnim.SetBool("LeaveBool", true);
            BladeSetFPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
        }
    }
    public void BladePurgeLeave()
    {
        //Debug.Log("test");
        QAnim.SetBool("LeaveBool", true);
        Flag = "BladeSwing1Action";
    }
    public void SwingEndLoopEvent()
    {
        if(Flag == "BladeSwingRightStop")
        {
            AniLoopCount++;
            if (AniLoopCount == 5)
            {
                SEASource.clip = FeatherClip;
                SEASource.Play();
                Flag = "BladeSwingLeftStart";
                BladeFeatherParObj1.transform.position = BladeFeatherParPos1.transform.position;
                BladeFeatherParObj1.transform.rotation = BladeFeatherParPos1.transform.rotation;
                BladeFeatherPar1.Play();
                BladeFeatherParObj2.transform.position = BladeFeatherParPos2.transform.position;
                BladeFeatherParObj2.transform.rotation = BladeFeatherParPos2.transform.rotation;
                BladeFeatherPar2.Play();
                BladeFeatherParObj3.transform.position = BladeFeatherParPos3.transform.position;
                BladeFeatherParObj3.transform.rotation = BladeFeatherParPos3.transform.rotation;
                BladeFeatherPar3.Play();
                BladeFeatherParObj4.transform.position = BladeFeatherParPos4.transform.position;
                BladeFeatherParObj4.transform.rotation = BladeFeatherParPos4.transform.rotation;
                BladeFeatherPar4.Play();
                /*BladeFeatherParObj5.transform.position = BladeFeatherParPos5.transform.position;
                BladeFeatherParObj5.transform.rotation = BladeFeatherParPos5.transform.rotation;
                BladeFeatherPar5.Play();*/
                QFeatherParObj.transform.position = this.transform.position;
                QFeatherParObj.transform.rotation = this.transform.rotation;
                QFeatherPar.Play();
                //↓アニメーション不自然
                //BladeHolderAni2.SetBool("Ani2Bool", false);
                Invoke("PositionReset", 0.01f);
            }
        }
        if (Flag == "BladeSwingLeftStop")
        {
            AniLoopCount++;
            if (AniLoopCount == 5)
            {
                SEASource.clip = FeatherClip;
                SEASource.Play();
                Flag = "Fall5s";
                BladeFeatherParObj1.transform.position = BladeFeatherParPos1.transform.position;
                BladeFeatherParObj1.transform.rotation = BladeFeatherParPos1.transform.rotation;
                BladeFeatherPar1.Play();
                BladeFeatherParObj2.transform.position = BladeFeatherParPos2.transform.position;
                BladeFeatherParObj2.transform.rotation = BladeFeatherParPos2.transform.rotation;
                BladeFeatherPar2.Play();
                BladeFeatherParObj3.transform.position = BladeFeatherParPos3.transform.position;
                BladeFeatherParObj3.transform.rotation = BladeFeatherParPos3.transform.rotation;
                BladeFeatherPar3.Play();
                BladeFeatherParObj4.transform.position = BladeFeatherParPos4.transform.position;
                BladeFeatherParObj4.transform.rotation = BladeFeatherParPos4.transform.rotation;
                BladeFeatherPar4.Play();
                /*BladeFeatherParObj5.transform.position = BladeFeatherParPos5.transform.position;
                BladeFeatherParObj5.transform.rotation = BladeFeatherParPos5.transform.rotation;
                BladeFeatherPar5.Play();*/
                QFeatherParObj.transform.position = this.transform.position;
                QFeatherParObj.transform.rotation = this.transform.rotation;
                QFeatherPar.Play();
                //↓アニメーション不自然
                //BladeHolderAni2.SetBool("Ani2Bool", false);
                Invoke("PositionReset", 0.01f);
            }
        }
    }
    /*public void FallBlade1PosReset()
    {
        FallBlade1.transform.position = new Vector2(-4, 9);
        FallBlade1.SetActive(false);
    }
    public void FallBlade2PosReset()
    {
        FallBlade2.transform.position = new Vector2(-8, 9);
        FallBlade2.SetActive(false);
    }
    public void FallBlade3PosReset()
    {
        FallBlade3.transform.position = new Vector2(4, 9);
        FallBlade3.SetActive(false);
    }
    public void FallBlade4PosReset()
    {
        FallBlade4.transform.position = new Vector2(8, 9);
        FallBlade4.SetActive(false);
    }*/
    public void DisableEvent()
    {
        if (AniLoopCount == 1)
        {
            ScreenShakeController.instance.StartShake(.4f, .5f);
            this.transform.Translate(0, 1, 0);
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabFallCol.enabled = false;
            StabPar.Stop();
            StabFallPar.Stop();
            BladeSetObj2.SetActive(false);
        }
        if (AniLoopCount != 10)
        {
            AniLoopCount++;
            this.transform.Translate(0, -0.02f, 0);
        }
        if (AniLoopCount == 10)
        {
            DisableFParObj.transform.position = this.transform.position;
            DisableFPar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Invoke("DisableMethod", 0.01f);
            sm.AddScore(scoreValue);
            if (QBPortalSetObj.activeSelf)
            {
                QBSetAnim.SetBool("CloseBool", true);
            }
        }
    }
    public void DisableMethod()
    {
        NameAni.SetBool("NameEndBool", true);
        HPAni.SetBool("PargeBool", true);
        this.gameObject.SetActive(false);
        ScreenShakeController.instance.StartShake(.5f, .6f);
        cam.backgroundColor = new Color32(0, 0, 0, 255);
        tilemap1.color = new Color32(0, 70, 79, 255);
        tilemap2.color = new Color32(26, 195, 252, 255);
        BackLightBottom.color = new Color32(26, 195, 252, 255);
        BackLightTop.color = new Color32(10, 0, 160, 255);
        BGSprite1.color = new Color32(255, 180, 250, 255);
        BGSprite2.color = new Color32(255, 180, 250, 255);
        StageParLeft.startColor = new Color32(102, 139, 255, 255);
        StageParRight.startColor = new Color32(102, 139, 255, 255);
    }
    public void SwingSEMethod()
    {
        SEASource.clip = SwingClip;
        SEASource.Play();
    }
}
