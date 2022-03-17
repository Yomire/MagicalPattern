using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class QSkyScript : MonoBehaviour
{
    public Camera cam;
    //public float ;
    public string ColorFlag, Flag, FlagHP, SEFlag;
    public byte ColorR;
    public float StartPos_X, StartPos_Y, MoveV, EndPos_Y, RightTopQPosY, RightBottomQPosY, BladeShotMoveY, StabEndPosTop, StabEndPosBottom, StabEndPosRight, StabEndPosLeft;
    public Animator QAnim, HPAni, BPSLAnim, NameAni;
    public GameObject QBPortalSetObj, HP1, HP2, HP3, HP4, HP5, HP6, HP7, BladeSetObj1, HPObj, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7,
        SkyBladeObjTop, SkyBladeObjBottom, SkyBladeObjRight, SkyBladeObjLeft, SkyBladePosTop, SkyBladePosBottom, SkyBladePosRight, SkyBladePosLeft, SkyBladePosRightTop, SkyBladePosRightBottom, SkyBladePosLeftTop, SkyBladePosLeftBottom,
        PlayerNearPosRight, PlayerNearPosLeft, QFParObj, QFParObj2, BPSLPos, BPSLObj, LPBObj1, LPBObj2, LPBObj3, LPBObj4, LPBObj5, RightTopQPos, RightBottomQPos, 
        BladeSandPosFirstTop, BladeSandPosFirstBottom, BladeSandPosSecondTop, BladeSandPosSecondBottom, BladeSandPosThirdTop, BladeSandPosThirdBottom, BladeSandPosForthTop, BladeSandPosForthBottom, NameObj;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop, BGSprite1, BGSprite2;
    public AudioSource HPLoopAudioSource, SEASource, SEASource2;
    public AudioClip FeatherClip, StabClip, SwingClip, DisableClip;
    public Collider2D QueenCol, StabCol;
    public ParticleSystem BladeSetFPar, StabPar, QFeatherPar, QFeatherPar2, StabParLeft, StageParLeft, StageParRight;
    public LongPortalBlade LPBScript1, LPBScript2, LPBScript3, LPBScript4, LPBScript5;
    public Tilemap tilemap1, tilemap2;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void QueenEnabledOnSky()
    {
        HPObj.SetActive(true);
        HPCount = 7;
        ColorFlag = "FeedChange";
        Flag = "Fall";
        FlagHP = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
        HPAni.SetBool("PargeBool", false);
        /*
        if (QBPortalSetObj.activeSelf)
        {
            QBSetAnim.SetBool("CloseBool", true);
        }
        */
        QAnim.SetBool("SwingStartBool", false);
        QAnim.SetBool("BladeShotEndBool", false);
        QueenCol.enabled = true;
        StabCol.enabled = false;
        //StabFallCol.enabled = false;
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
            QAnim.SetBool("SwingStartBool", false);
            QAnim.SetBool("BladeShotEndBool", false);
            /*
            if (QBPortalSetObj.activeSelf)
            {
                QBSetAnim.SetBool("CloseBool", true);
            }
            */
            //BladeHolderAni2.SetBool("Ani2Bool", false);
            //QAnim.SetBool("ChargeBool", true);
            this.transform.position = new Vector3(StartPos_X, EndPos_Y, 0);
            QFParObj.transform.position = this.transform.position;
            QFeatherPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Flag = "Null";
            FlagHP = "HPSet";
            HPAni.SetBool("PargeBool", false);
            //HPCount = 7;
            //FlagHP = "Null";
            QueenCol.enabled = true;
            StabCol.enabled = false;
            //StabFallCol.enabled = false;
            StabPar.Stop();
            StabParLeft.Stop();
            //StabFallPar.Stop();
            //BladeSetObj2.SetActive(false);
            LPBScript1.DisableMethod();
            LPBScript2.DisableMethod();
            LPBScript3.DisableMethod();
            LPBScript4.DisableMethod();
            LPBScript5.DisableMethod();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(ColorFlag == "FeedChange")
        {
            if(ColorR <= 80)
            {
                ColorR++;
                cam.backgroundColor = new Color32(ColorR, 0, 0, 255);
            }            
        }
        if (Flag == "Fall")
        {
            this.transform.Translate(0, MoveV, 0);
            NumberStopper = 1;
        }
        if (this.transform.localPosition.y <= EndPos_Y)
        {
            if (Flag == "Fall")
            {
                if (HP1.activeSelf)
                {
                    //Debug.Log("test3");
                    if (HP1Sprite.size.x <= 1.28)
                    {
                        //Debug.Log("test4");
                        if (FlagHP == "Null")
                        {
                            //Debug.Log("test5");
                            Flag = "Stop";
                            FlagHP = "HPSet";
                        }
                    }
                }
            }
        }
        if (FlagHP == "HPSet")
        {
            if (HP1.activeSelf)
            {
                HP1Sprite.size += new Vector2(0.1f, 0.0f);
                //WAniSpeed5();
                HPLoopAudioSource.Play();
                //Debug.Log("audio");
                if (HP1Sprite.size.x >= 15)
                {
                    FlagHP = "Null";
                    NumberStopper = 0;
                    //WAniSpeed2();
                    HPLoopAudioSource.Stop();
                    //QAnim.SetBool("LeaveBool", true);
                    //Flag = "Leave";
                    //QueenCol.enabled = false;
                    
                    if (HPCount == 7)
                    {
                        HPCount--;
                        BladeSetObj1.transform.position = this.transform.position;
                        BladeSetObj1.SetActive(true);
                        BladeSetFPar.Play();
                        SEASource.clip = FeatherClip;
                        SEASource.Play();
                        //Flag = "CrossBlade";
                        cam.backgroundColor = new Color32(80, 0, 0, 255);
                        tilemap1.color = new Color32(140, 0, 70, 255);
                        tilemap2.color = new Color32(115, 0, 60, 255);
                        BackLightBottom.color = new Color32(255, 0, 128, 255);
                        BackLightTop.color = new Color32(160, 0, 70, 255);
                        BGSprite1.color = new Color32(115, 0, 60, 255);
                        BGSprite2.color = new Color32(115, 0, 60, 255);
                        StageParLeft.startColor = new Color32(45, 0, 25, 255);
                        StageParRight.startColor = new Color32(45, 0, 25, 255);
                    }
                    if (HPCount == 5 || HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        //HPCount--;
                        Flag = "NumberChoice";
                    }
                }
            }
        }
        if (Flag == "PortalBladeShotLoop")
        {
            this.transform.Translate(0, BladeShotMoveY, 0);
            BPSLObj.transform.Translate(BladeShotMoveY, 0, 0);
        }
        if (Flag == "PortalBladeShotLoopUp")
        {
            this.transform.Translate(0, -BladeShotMoveY, 0);
            BPSLObj.transform.Translate(-BladeShotMoveY, 0, 0);
        }
        if (Flag == "StabAttackRight")
        {
            StabPar.Play();
            this.transform.Translate(-0.3f, 0, 0);
            StabCol.enabled = true;
            if(SEFlag == "Off")
            {
                SEASource.clip = StabClip;
                SEASource.Play();
                SEFlag = "On";
            }
        }
        if (Flag == "StabAttackLeft")
        {
            //Debug.Log("left");
            StabParLeft.Play();
            this.transform.Translate(0.3f, 0, 0);
            StabCol.enabled = true;
            if (SEFlag == "Off")
            {
                SEASource.clip = StabClip;
                SEASource.Play();
                SEFlag = "On";
            }
        }

        if (HP1Sprite.size.x <= 1.28)
        {
            if (HPCount == 6)
            {
                if (FlagHP != "HPSet")
                {
                    HP7.SetActive(false);
                    HPB7.SetActive(true);
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
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
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
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
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
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
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
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
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
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
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("QHPResetMethod", 0.01f);
                }
            }
            if (HPCount == 0)
            {
                if (Flag != "End")
                {
                    QFParObj2.transform.position = this.transform.position;
                    QFeatherPar2.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    //this.gameObject.transform.position = QDPosObj.transform.position;
                    //this.transform.Translate(0, 0.1f, 0);
                    /*
                    if (QBPortalSetObj.activeSelf)
                    {
                        QBSetAnim.SetBool("CloseBool", true);
                    }
                    */
                    LPBScript1.DisableMethod();
                    LPBScript2.DisableMethod();
                    LPBScript3.DisableMethod();
                    LPBScript4.DisableMethod();
                    LPBScript5.DisableMethod();

                }
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
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(3.0f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(3.0f, 0.0f);
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
    }
    public void QAniRandomMethod()
    {
        if (HPCount == 6)
        {
            AttackNumber = Random.Range(7, 17);
        }
        if (HPCount == 5)
        {
            AttackNumber = Random.Range(1, 19);
        }
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(1, 27);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 29);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(7, 29);
        }
        if (HPCount == 1)
        {
            AttackNumber = Random.Range(1, 32);
        }
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(1, 32);
        }
    }
    public void PositionReset()
    {
        AniLoopCount = 0;
        //Debug.Log("tst");
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
        QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        QueenCol.enabled = true;
        StabCol.enabled = false;
        //StabFallCol.enabled = false;
        Flag = "NumberChoice";
        StabPar.Stop();
        StabParLeft.Stop();
        //StabFallPar.Stop();
        NumberStopper = 0;
        QAnim.SetBool("SwingStartBool", false);
        QAnim.SetBool("BladeShotEndBool", false);
        SEFlag = "Off";
    }
    public void PositionResetEvent()
    {
        QFParObj.transform.position = this.transform.position;
        QFeatherPar.Play();
        SEASource.clip = FeatherClip;
        SEASource.Play();
        Invoke("PositionReset", 0.01f);
    }
    public void QAniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 7 || AttackNumber == 17)
            {
                if(BPSLObj.activeSelf == false)
                {
                    Flag = "PortalBladeShotStartTop";
                    this.transform.position = RightTopQPos.transform.position;
                    QFParObj.transform.position = RightTopQPos.transform.position;
                    QFeatherPar.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("BladeShotStartAni", 0, 0.0f);
                    BPSLObj.SetActive(true);
                    BPSLObj.transform.position = BPSLPos.transform.position;
                    BPSLAnim.Play("BPSAni1", 0, 0.0f);
                    NumberStopper++;
                }                
            }
            if (AttackNumber == 8 || AttackNumber == 18)
            {
                if (BPSLObj.activeSelf == false)
                {
                    Flag = "PortalBladeShotStartBottom";
                    this.transform.position = RightBottomQPos.transform.position;
                    QFParObj.transform.position = this.transform.position;
                    QFeatherPar.Play();
                    SEASource.clip = FeatherClip;
                    SEASource.Play();
                    QAnim.Play("BladeShotStartAni", 0, 0.0f);
                    BPSLObj.SetActive(true);
                    BPSLObj.transform.position = BPSLPos.transform.position;
                    BPSLAnim.Play("BPSAni1", 0, 0.0f);
                    NumberStopper++;
                }                    
            }
            if (AttackNumber == 1 || AttackNumber == 27)
            {
                QBSTopSamon();
                QBSBottomSamon();
            }
            if (AttackNumber == 2 || AttackNumber == 28)
            {
                QBSRightSamon();
                QBSLeftSamon();
            }
            if (AttackNumber == 3 || AttackNumber == 29)
            {
                QBSRightTopSamon();
                QBSLeftBottomSamon();
            }
            if (AttackNumber == 4 || AttackNumber == 30)
            {
                QBSLeftTopSamon();
                QBSRightBottomSamon();
            }
            if (AttackNumber == 5 || AttackNumber == 31)
            {
                Flag = "SwingDown1";
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
            }
            if (AttackNumber == 6 || AttackNumber == 32)
            {
                Flag = "SwingDown1Left";
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            }
            if (AttackNumber == 9 || AttackNumber == 19)
            {
                Flag = "RightBladeSand";
                this.transform.position = SkyBladePosRight.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
                //QAnim.Play("BladeShotStartAni", 0, 0.0f);
            }
            if (AttackNumber == 10 || AttackNumber == 20)
            {
                Flag = "LeftBladeSand";
                this.transform.position = SkyBladePosLeft.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);
                //QAnim.Play("BladeShotStartAni", 0, 0.0f);
            }
            if (AttackNumber == 11 || AttackNumber == 21)
            {
                Flag = "TopBladeSand";
                this.transform.position = SkyBladePosTop.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
                //QAnim.Play("BladeShotStartAni", 0, 0.0f);
            }
            if (AttackNumber == 12 || AttackNumber == 22)
            {
                Flag = "BottomBladeSand";
                this.transform.position = SkyBladePosBottom.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);
                //QAnim.Play("BladeShotStartAni", 0, 0.0f);
            }            
            if (AttackNumber == 13 || AttackNumber == 23)
            {
                Flag = "RightTopBladeSand";
                this.transform.position = SkyBladePosRightTop.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 45);
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
            }
            if (AttackNumber == 14 || AttackNumber == 24)
            {
                Flag = "LeftBottomBladeSand";
                this.transform.position = SkyBladePosLeftBottom.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, 45);
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            }
            if (AttackNumber == 15 || AttackNumber == 25)
            {
                Flag = "RightBottomBladeSand";
                this.transform.position = SkyBladePosRightBottom.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, -45);
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
            }
            if (AttackNumber == 16 || AttackNumber == 26)
            {
                Flag = "LeftTopBladeSand";
                this.transform.position = SkyBladePosLeftTop.transform.position;
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
                QAnim.Play("BladeShotStartAni", 0, 0.0f);
                this.transform.rotation = Quaternion.Euler(0, 0, -45);
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            }
        }
        if(Flag == "SwingDown1")
        {
            QFParObj.transform.position = this.transform.position;
            QFeatherPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Invoke("NearThePlayer", 0.01f);
        }
        if (Flag == "SwingDown1Left")
        {
            QFParObj.transform.position = this.transform.position;
            QFeatherPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Invoke("NearThePlayerLeft", 0.01f);
        }
        if (Flag == "CrossBlade")
        {
            //Debug.Log("test2");
            CrossBladeStab();
        }
    }

    public void QBSetObjEndMethod()
    {
        //Debug.Log("tst1");
        if (HPCount == 6)
        {
            //Debug.Log("tst1");
            Flag = "CrossBlade";
        }
        
    }

    public void ShotAniEvent()
    {
        if (Flag == "PortalBladeShotStartTop")
        {
            Flag = "PortalBladeShotLoop";
        }
        if(Flag == "PortalBladeShotLoop")
        {
            if (this.transform.localPosition.y <= RightBottomQPosY)
            {
                Flag = "PortalBladeShotEndTop";
                if (LPBObj1.activeSelf)
                {
                    LPBScript1.DisableMethod();
                }
                if (LPBObj2.activeSelf)
                {
                    LPBScript2.DisableMethod();
                }
                if (LPBObj3.activeSelf)
                {
                    LPBScript3.DisableMethod();
                }
                if (LPBObj4.activeSelf)
                {
                    LPBScript4.DisableMethod();
                }
                if (LPBObj5.activeSelf)
                {
                    LPBScript5.DisableMethod();
                }                
            }
        }
        if(Flag == "PortalBladeShotEndTop")
        {
            if (LPBObj1.activeSelf == false && LPBObj2.activeSelf == false && LPBObj3.activeSelf == false && LPBObj4.activeSelf == false && LPBObj5.activeSelf == false)
            {
                QAnim.SetBool("BladeShotEndBool", true);
                //Flag = "NumberChoice";
            }
        }
        if (Flag == "PortalBladeShotStartBottom")
        {
            Flag = "PortalBladeShotLoopUp";
        }
        if (Flag == "PortalBladeShotLoopUp")
        {
            if (this.transform.localPosition.y >= RightTopQPosY)
            {
                Flag = "PortalBladeShotEndTop";
                if (LPBObj1.activeSelf)
                {
                    LPBScript1.DisableMethod();
                }
                if (LPBObj2.activeSelf)
                {
                    LPBScript2.DisableMethod();
                }
                if (LPBObj3.activeSelf)
                {
                    LPBScript3.DisableMethod();
                }
                if (LPBObj4.activeSelf)
                {
                    LPBScript4.DisableMethod();
                }
                if (LPBObj5.activeSelf)
                {
                    LPBScript5.DisableMethod();
                }
            }
        }

        if (Flag == "RightBladeSand")
        {
            AniLoopCount++;
            if(AniLoopCount == 1)
            {
                QBSRightSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "LeftBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSRightSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "TopBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSTopSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSTopSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSTopSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSTopSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "BottomBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSTopSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSTopSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSTopSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSTopSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if(Flag == "RightTopBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSRightTopSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightTopSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightTopSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightTopSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "LeftBottomBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSRightTopSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightTopSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightTopSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightTopSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "RightBottomBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSRightBottomSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightBottomSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightBottomSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightBottomSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
        if (Flag == "LeftTopBladeSand")
        {
            AniLoopCount++;
            if (AniLoopCount == 1)
            {
                QBSRightBottomSandFirst();
            }
            if (AniLoopCount == 3)
            {
                QBSRightBottomSandSecond();
            }
            if (AniLoopCount == 6)
            {
                QBSRightBottomSandThird();
            }
            if (AniLoopCount == 9)
            {
                QBSRightBottomSandForth();
            }
            if (AniLoopCount >= 12)
            {
                QAnim.Play("BladeStabReadySkyAni", 0, 0.0f);
                QFParObj.transform.position = this.transform.position;
                QFeatherPar.Play();
                SEASource.clip = FeatherClip;
                SEASource.Play();
            }
        }
    }

    public void StabAttackGoEvent()
    {
        if(Flag == "RightBladeSand" || Flag == "TopBladeSand" || Flag == "RightTopBladeSand" || Flag == "RightBottomBladeSand")
        {
            Flag = "StabAttackRight";
        }
        if (Flag == "LeftBladeSand" || Flag == "BottomBladeSand" || Flag == "LeftBottomBladeSand" || Flag == "LeftTopBladeSand")
        {
            Flag = "StabAttackLeft";
        }

        if (this.transform.localPosition.y >= StabEndPosTop)
        {
            //Debug.Log("top");
            PositionReset();
        }
        if (this.transform.localPosition.y <= StabEndPosBottom)
        {
            //Debug.Log("bottom");
            PositionReset();
        }
        if (this.transform.localPosition.x >= StabEndPosRight)
        {
            //Debug.Log("right");
            PositionReset();
        }
        if (this.transform.localPosition.x <= StabEndPosLeft)
        {
            //Debug.Log("left");
            PositionReset();
        }
    }

    public void CrossBladeStab()
    {
        //Debug.Log("test3");
        NumberStopper++;
        if(NumberStopper == 1)
        {
            QBSRightTopSamon();
            QBSLeftBottomSamon();
        }
        if (NumberStopper == 2)
        {
            QBSRightBottomSamon();
            QBSLeftTopSamon();
        }
        if (NumberStopper == 3)
        {
            //AttackNumber = 5;
            //StabRight();
            Flag = "SwingDown1";
        }
    }

    public void SwingDownRightEvent()
    {
        AniLoopCount++;
        if(AniLoopCount >= 3)
        {
            QAnim.SetBool("SwingStartBool", true);
        }
        if (AniLoopCount >= 5)
        {
            QFParObj.transform.position = this.transform.position;
            QFeatherPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Invoke("PositionReset", 0.01f);
        }
    }
    public void NearThePlayer()
    {        
        this.transform.position = PlayerNearPosRight.transform.position;
        QAnim.Play("BSDStartLoopAni", 0, 0.0f);
        QFParObj2.transform.position = this.transform.position;
        QFeatherPar2.Play();
        SEASource.clip = FeatherClip;
        SEASource.Play();
    }
    public void NearThePlayerLeft()
    {
        this.transform.position = PlayerNearPosLeft.transform.position;
        QAnim.Play("BSDStartLoopAni", 0, 0.0f);
        QFParObj2.transform.position = this.transform.position;
        QFeatherPar2.Play();
        SEASource.clip = FeatherClip;
        SEASource.Play();
    }

    public void StabRight()
    {
        Flag = "StabAttackRight";
    }

    public void QBSTopSamon()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 180);
        SkyBladeObjTop.transform.position = SkyBladePosTop.transform.position;
        SkyBladeObjTop.SetActive(true);
    }
    public void QBSBottomSamon()
    {
        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 0);
        SkyBladeObjBottom.transform.position = SkyBladePosBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightSamon()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 90);
        SkyBladeObjRight.transform.position = SkyBladePosRight.transform.position;
        SkyBladeObjRight.SetActive(true);
    }
    public void QBSLeftSamon()
    {
        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, -90);
        SkyBladeObjLeft.transform.position = SkyBladePosLeft.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }

    public void QBSRightTopSamon()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 135);
        SkyBladeObjTop.transform.position = SkyBladePosRightTop.transform.position;
        SkyBladeObjTop.SetActive(true);
    }
    public void QBSRightBottomSamon()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 45);
        SkyBladeObjRight.transform.position = SkyBladePosRightBottom.transform.position;
        SkyBladeObjRight.SetActive(true);
    }
    public void QBSLeftTopSamon()
    {
        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, -135);
        SkyBladeObjLeft.transform.position = SkyBladePosLeftTop.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSLeftBottomSamon()
    {
        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, -45);
        SkyBladeObjBottom.transform.position = SkyBladePosLeftBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }

    public void QBSRightSandFirst()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 180);
        SkyBladeObjTop.transform.position = BladeSandPosFirstTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 0);
        SkyBladeObjBottom.transform.position = BladeSandPosFirstBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightSandSecond()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 180);
        SkyBladeObjRight.transform.position = BladeSandPosSecondTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
        SkyBladeObjLeft.transform.position = BladeSandPosSecondBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSRightSandThird()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 180);
        SkyBladeObjTop.transform.position = BladeSandPosThirdTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 0);
        SkyBladeObjBottom.transform.position = BladeSandPosThirdBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightSandForth()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 180);
        SkyBladeObjRight.transform.position = BladeSandPosForthTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
        SkyBladeObjLeft.transform.position = BladeSandPosForthBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }

    public void QBSTopSandFirst()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, -90);
        SkyBladeObjTop.transform.position = BladeSandPosFirstTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 90);
        SkyBladeObjBottom.transform.position = BladeSandPosFirstBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSTopSandSecond()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, -90);
        SkyBladeObjRight.transform.position = BladeSandPosSecondTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
        SkyBladeObjLeft.transform.position = BladeSandPosSecondBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSTopSandThird()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, -90);
        SkyBladeObjTop.transform.position = BladeSandPosThirdTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 90);
        SkyBladeObjBottom.transform.position = BladeSandPosThirdBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSTopSandForth()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, -90);
        SkyBladeObjRight.transform.position = BladeSandPosForthTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
        SkyBladeObjLeft.transform.position = BladeSandPosForthBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }

    public void QBSRightTopSandFirst()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 225);
        SkyBladeObjTop.transform.position = BladeSandPosFirstTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 45);
        SkyBladeObjBottom.transform.position = BladeSandPosFirstBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightTopSandSecond()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 225);
        SkyBladeObjRight.transform.position = BladeSandPosSecondTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 45);
        SkyBladeObjLeft.transform.position = BladeSandPosSecondBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSRightTopSandThird()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 225);
        SkyBladeObjTop.transform.position = BladeSandPosThirdTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 45);
        SkyBladeObjBottom.transform.position = BladeSandPosThirdBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightTopSandForth()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 225);
        SkyBladeObjRight.transform.position = BladeSandPosForthTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 45);
        SkyBladeObjLeft.transform.position = BladeSandPosForthBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSRightBottomSandFirst()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 135);
        SkyBladeObjTop.transform.position = BladeSandPosFirstTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 315);
        SkyBladeObjBottom.transform.position = BladeSandPosFirstBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightBottomSandSecond()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 135);
        SkyBladeObjRight.transform.position = BladeSandPosSecondTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 315);
        SkyBladeObjLeft.transform.position = BladeSandPosSecondBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }
    public void QBSRightBottomSandThird()
    {
        SkyBladeObjTop.transform.rotation = Quaternion.Euler(0, 0, 135);
        SkyBladeObjTop.transform.position = BladeSandPosThirdTop.transform.position;
        SkyBladeObjTop.SetActive(true);

        SkyBladeObjBottom.transform.rotation = Quaternion.Euler(0, 0, 315);
        SkyBladeObjBottom.transform.position = BladeSandPosThirdBottom.transform.position;
        SkyBladeObjBottom.SetActive(true);
    }
    public void QBSRightBottomSandForth()
    {
        SkyBladeObjRight.transform.rotation = Quaternion.Euler(0, 0, 135);
        SkyBladeObjRight.transform.position = BladeSandPosForthTop.transform.position;
        SkyBladeObjRight.SetActive(true);

        SkyBladeObjLeft.transform.rotation = Quaternion.Euler(0, 0, 315);
        SkyBladeObjLeft.transform.position = BladeSandPosForthBottom.transform.position;
        SkyBladeObjLeft.SetActive(true);
    }

    public void DisableEvent()
    {
        if (AniLoopCount == 1)
        {
            ScreenShakeController.instance.StartShake(.4f, .5f);
            this.transform.Translate(0, 1, 0);
            QueenCol.enabled = true;
            StabCol.enabled = false;
            StabPar.Stop();
            StabParLeft.Stop();
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            BPSLObj.SetActive(false);
            SEFlag = "Off";
        }
        if (AniLoopCount != 10)
        {
            AniLoopCount++;
            this.transform.Translate(0, -0.02f, 0);
        }
        if (AniLoopCount == 10)
        {
            QFParObj.transform.position = this.transform.position;
            QFeatherPar.Play();
            SEASource.clip = FeatherClip;
            SEASource.Play();
            Invoke("DisableMethod", 0.01f);
            sm.AddScore(scoreValue);
            SEASource2.clip = DisableClip;
            SEASource2.Play();
        }
    }
    public void DisableMethod()
    {
        NameAni.SetBool("NameEndBool", true);
        HPAni.SetBool("PargeBool", true);
        this.gameObject.SetActive(false);
        ScreenShakeController.instance.StartShake(.5f, .6f);
        cam.backgroundColor = new Color32(0, 0, 0, 0);
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
