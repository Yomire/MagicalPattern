using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Playables;

public class KnightScript : MonoBehaviour
{
    public Animator BodyAnim, RightArmAnim, LeftArmAnim, HPAni, NameAni;
    public string Flag, FlagHP, ColorFlag, CheckmateFlag;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop, BGSprite1, BGSprite2;
    public AudioClip HPSound, SwingClip, ThrowClip, DisableClip;
    public AudioSource HPASLoop, SEASource;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    public Collider2D LanceCol;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount, LanceCount;
    public GameObject LanceObj, HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, DParObj,
        LanceFallPos, FOPObj, NameObj;
    public PlayableDirector FOPTL;
    public byte ColorR;
    public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveX, EndPosX, BackMoveX, JumpMoveX, JumpMoveY, FallMoveX, FallMoveY, FOPMoveX;
    public ParticleSystem DisablePar;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void KnightEnable()
    {
        HPObj.SetActive(true);
        HPCount = 6;
        ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        LeftArmAnim.SetBool("SwingUpAfterBool", false);
        RightArmAnim.SetBool("SwingUpBool", false);
        RightArmAnim.SetBool("SwingUpAfterBool", false);
        RightArmAnim.SetBool("LanceCatchBool", false);
        BodyAnim.SetBool("JumpBool", false);
        BodyAnim.SetBool("JumpLoopBool", false);
        BodyAnim.SetBool("ShotReadyBool", false);
        BodyAnim.SetBool("LanceShotAfterBool", false);
        RightArmAnim.SetBool("LanceShotAfterNullBool", false);
        RightArmAnim.SetBool("LanceShotAfterBool", false);
        FOPTL.Stop();
        AniLoopCount = 0;
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
    }
    public void HPResetMethod()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Flag == "Start")
        {
            this.transform.Translate(MoveX, 0, 0);
        }
        if (this.transform.localPosition.x >= EndPosX)
        {
            if(Flag == "Start")
            {
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
        if(FlagHP == "HPSet")
        {
            if (HP1.activeSelf)
            {
                HP1Sprite.size += new Vector2(0.1f, 0.0f);
                if (HPASLoop.isPlaying == false)
                {
                    HPASLoop.Play();
                }
                if (HP1Sprite.size.x >= 15)
                {
                    FlagHP = "Null";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    //Flag = "NumberChoice";
                    if (HPCount == 6)
                    {
                        HPCount--;
                        Flag = "NumberChoice";
                        if(CheckmateFlag != "On")
                        {
                            cam.backgroundColor = new Color32(80, 0, 0, 255);
                            tilemap1.color = new Color32(140, 0, 70, 255);
                            tilemap2.color = new Color32(115, 0, 60, 255);
                            BackLightBottom.color = new Color32(255, 0, 128, 255);
                            BackLightTop.color = new Color32(160, 0, 70, 255);
                            BGSprite1.color = new Color32(115, 0, 60, 255);
                            BGSprite2.color = new Color32(115, 0, 60, 255);
                        }                        
                    }
                    if (HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        
                        AniLoopCount = 0;
                    }
                }
            }
        }
        if (HP1Sprite.size.x <= 1.28)
        {
            if (HPCount == 5)
            {
                if (FlagHP != "HPSet")
                {
                    HP6.SetActive(false);
                    HPB6.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCount == 4)
            {
                if (FlagHP != "HPSet")
                {
                    HP5.SetActive(false);
                    HPB5.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCount == 3)
            {
                if (FlagHP != "HPSet")
                {
                    HP4.SetActive(false);
                    HPB4.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCount == 2)
            {
                if (FlagHP != "HPSet")
                {
                    HP3.SetActive(false);
                    HPB3.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCount == 1)
            {
                if (FlagHP != "HPSet")
                {
                    HP2.SetActive(false);
                    HPB2.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCount == 0)
            {
                if (Flag != "End")
                {
                    ScreenShakeController.instance.StartShake(.35f, .5f);
                    DParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    HPAni.SetBool("PargeBool", true);
                    NameAni.SetBool("NameEndBool", true);
                    Invoke("KDisableMethod", 0.01f);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    sm.AddScore(scoreValue);
                }
            }
        }

        if(Flag == "SwingUpReady")
        {
            this.transform.Translate(MoveX, 0, 0);
        }
        if (this.transform.localPosition.x >= 6)
        {
            if(Flag == "SwingUpReady")
            {
                Flag = "BackMove";
            }
        }
        if(Flag == "BackMove")
        {
            this.transform.Translate(BackMoveX, 0, 0);
        }
        if(this.transform.localPosition.x <= EndPosX)
        {
            if(Flag == "BackMove")
            {
                Flag = "NumberChoice";
                this.transform.position = new Vector3(EndPosX, StartPos_Y, 0);
                LeftArmAnim.SetBool("SwingUpAfterBool", true);
                RightArmAnim.SetBool("SwingUpBool", true);
                RightArmAnim.SetBool("SwingUpAfterBool", true);
                BodyAnim.SetBool("JumpBool", false);
                BodyAnim.SetBool("JumpLoopBool", false);
                BodyAnim.SetBool("ShotReadyBool", false);
                BodyAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", false);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", false);
            }
            if (Flag == "LanceAfterBack")
            {
                this.transform.position = new Vector3(EndPosX, StartPos_Y, 0);
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                BodyAnim.SetBool("JumpBool", false);
                BodyAnim.SetBool("JumpLoopBool", false);
                BodyAnim.SetBool("ShotReadyBool", false);
                BodyAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", true);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", true);
            }
        }

        if (Flag == "4ConsecutiveJump1A")
        {
            if(this.transform.localPosition.y <= 2.5f)
            {
                this.transform.Translate(JumpMoveX, JumpMoveY, 0);
            }
            if (this.transform.localPosition.y >= 2.5f)
            {
                Flag = "4ConsecutiveJump1B";
            }
        }
        if(Flag == "4ConsecutiveJump1B")
        {
            if (this.transform.localPosition.y >= -1.7f)
            {
                this.transform.Translate(FallMoveX, FallMoveY, 0);
            }
            if (this.transform.localPosition.y <= -1.7f)
            {
                Flag = "4ConsecutiveJumpReady2";
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        if (Flag == "4ConsecutiveJump2A")
        {
            if (this.transform.localPosition.y <= 2.5f)
            {
                this.transform.Translate(JumpMoveX, JumpMoveY, 0);
            }
            if (this.transform.localPosition.y >= 2.5f)
            {
                Flag = "4ConsecutiveJump2B";
            }
        }
        if (Flag == "4ConsecutiveJump2B")
        {
            if (this.transform.localPosition.y >= -1.7f)
            {
                this.transform.Translate(FallMoveX, FallMoveY, 0);
            }
            if (this.transform.localPosition.y <= -1.7f)
            {
                Flag = "4ConsecutiveJumpReady3";
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        if (Flag == "4ConsecutiveJump3A")
        {
            if (this.transform.localPosition.y <= 2.5f)
            {
                this.transform.Translate(JumpMoveX, JumpMoveY, 0);
            }
            if (this.transform.localPosition.y >= 2.5f)
            {
                Flag = "4ConsecutiveJump3B";
            }
        }
        if (Flag == "4ConsecutiveJump3B")
        {
            if (this.transform.localPosition.y >= -1.7f)
            {
                this.transform.Translate(FallMoveX, FallMoveY, 0);
            }
            if (this.transform.localPosition.y <= -1.7f)
            {
                Flag = "4ConsecutiveJumpReady4";
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        if (Flag == "4ConsecutiveJump4A")
        {
            if (this.transform.localPosition.y <= 2.5f)
            {
                this.transform.Translate(-JumpMoveX, JumpMoveY, 0);
            }
            if (this.transform.localPosition.y >= 2.5f)
            {
                Flag = "4ConsecutiveJump4B";
            }
        }
        if (Flag == "4ConsecutiveJump4B")
        {
            if (this.transform.localPosition.y >= -1.7f)
            {
                this.transform.Translate(-FallMoveX, FallMoveY, 0);
            }
            if (this.transform.localPosition.y <= -1.7f)
            {
                Flag = "JumpStop";
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }

        if (Flag == "LanceShotJump")
        {
            if (this.transform.localPosition.y <= 1.5f)
            {
                this.transform.Translate(0.05f, JumpMoveY, 0);
            }
            if (this.transform.localPosition.y >= 1.5f)
            {
                Flag = "LanceShot";
                RightArmAnim.Play("LanceShotReadyRightArmAni", 0, 0.0f);                
            }
        }
        /*
        if(Flag == "LanceShot")
        {
            RightArmAnim.SetBool("LanceShotAfterBool", false);
        }
        */
        if (Flag == "LanceBurn")
        {
            //transform.Translate(-speed, 0, 0);
            //FOPrb.velocity = Vector2.left * FOPMoveX;
            FOPObj.transform.Translate(FOPMoveX, 0, 0);
        }
        if (FOPObj.transform.localPosition.x <= 0)
        {
            if (Flag == "LanceBurn")
            {
                Flag = "LanceShotAfter";
                //FOPTL.Stop();
                RightArmAnim.SetBool("LanceShotAfterBool", true);
                BodyAnim.SetBool("LanceShotAfterBool", true);
            }
        }
        if(Flag == "LanceShotAfterFall")
        {
            if (this.transform.localPosition.y >= -1.7f)
            {
                this.transform.Translate(0, FallMoveY, 0);
            }
            if (this.transform.localPosition.y <= -1.7f)
            {
                Flag = "LanceAfterBack";
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        if(Flag == "LanceAfterBack")
        {
            if (this.transform.localPosition.x >= EndPosX)
            {
                this.transform.Translate(BackMoveX, 0, 0);
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
                    HP1Sprite.size -= new Vector2(0.2f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
        if (Flag == "SwingUpReady")
        {
            LanceCount++;
            if (LanceCount >= 5)
            {
                Flag = "BackMove";
                RightArmAnim.SetBool("SwingUpAfterBool", true);
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
                    HP1Sprite.size -= new Vector2(0.2f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
        if (Flag == "SwingUpReady")
        {
            LanceCount++;
            if (LanceCount >= 5)
            {
                Flag = "BackMove";
                RightArmAnim.SetBool("SwingUpAfterBool", true);
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
        if (Flag == "SwingUpReady")
        {
            LanceCount++;
            if (LanceCount >= 5)
            {
                Flag = "BackMove";
                RightArmAnim.SetBool("SwingUpAfterBool", true);
            }
        }
    }
    public void KDisableMethod()
    {
        this.gameObject.SetActive(false);
        if (CheckmateFlag != "On")
        {
            cam.backgroundColor = new Color32(0, 0, 0, 0);
            tilemap1.color = new Color32(0, 70, 80, 255);
            tilemap2.color = new Color32(26, 195, 252, 255);
            BackLightBottom.color = new Color32(26, 195, 252, 255);
            BackLightTop.color = new Color32(10, 0, 160, 255);
            BGSprite1.color = new Color32(255, 180, 250, 255);
            BGSprite2.color = new Color32(255, 180, 250, 255);
        }            
    }
    public void KAniRandomMethod()
    {
        if (HPCount == 6)
        {
            AttackNumber = Random.Range(1, 4);
        }
        if (HPCount == 5)
        {
            AttackNumber = Random.Range(1, 6);
        }
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(1, 7);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 8);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(1, 12);
        }
        if (HPCount == 1)
        {
            AttackNumber = Random.Range(1, 10);
        }
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(1, 9);
        }
        if (Flag == "LanceAfterBack")
        {
            Flag = "NumberChoice";
        }
    }
    public void KAniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 5)
            {
                LanceCount = 0;
                AniLoopCount = 0;
                Flag = "SwingUpReady";
                RightArmAnim.Play("SwingUpReadyRightArmAni", 0, 0.0f);
                LeftArmAnim.Play("SwingUpReadyLeftArmAni", 0, 0.0f);
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", false);
                BodyAnim.SetBool("JumpBool", false);
                BodyAnim.SetBool("JumpLoopBool", false);
                BodyAnim.SetBool("ShotReadyBool", false);
                BodyAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", false);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
            }
            if (AttackNumber == 2 || AttackNumber == 6)
            {
                LanceCount = 0;
                AniLoopCount = 0;
                Flag = "LanceThrow";
                RightArmAnim.Play("LanceThrowReadyRightArmAni", 0, 0.0f);
                LeftArmAnim.Play("LanceThrowReadyLeftArmAni", 0, 0.0f);
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", false);
                BodyAnim.SetBool("JumpBool", false);
                BodyAnim.SetBool("JumpLoopBool", false);
                BodyAnim.SetBool("ShotReadyBool", false);
                BodyAnim.SetBool("LanceShotAfterBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", false);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
                AniLoopCount = 0;
            }
            if (AttackNumber == 3 || AttackNumber == 7)
            {
                LanceCount = 0;
                AniLoopCount = 0;
                Flag = "4ConsecutiveJumpReady";
                //RightArmAnim.Play("", 0, 0.0f);
                //LeftArmAnim.Play("", 0, 0.0f);
                BodyAnim.SetBool("JumpBool", true);
                BodyAnim.SetBool("JumpLoopBool", true);
                BodyAnim.SetBool("ShotReadyBool", false);
                BodyAnim.SetBool("LanceShotAfterBool", false);
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", false);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
                AniLoopCount = 0;
            }
            if (AttackNumber == 4 || AttackNumber == 8)
            {
                LanceCount = 0;
                AniLoopCount = 0;
                Flag = "LanceShotReady";
                //RightArmAnim.Play("", 0, 0.0f);
                //LeftArmAnim.Play("", 0, 0.0f);
                BodyAnim.SetBool("JumpBool", true);
                BodyAnim.SetBool("JumpLoopBool", false);
                BodyAnim.SetBool("ShotReadyBool", true);
                BodyAnim.SetBool("LanceShotAfterBool", false);                
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", false);
                RightArmAnim.SetBool("LanceShotAfterNullBool", false);
                RightArmAnim.SetBool("LanceShotAfterBool", false);
                AniLoopCount = 0;
            }
        }
    }
    public void SwingUpMethod()
    {
        if(Flag == "SwingUpReady")
        {
            LeftArmAnim.SetBool("SwingUpAfterBool", true);
            RightArmAnim.SetBool("SwingUpBool", true);
            //Invoke("MoveStopMethod", 1.0f);
        }
    }
    /*
    public void MoveStopMethod()
    {
        Flag = "MoveStop";
    }
    */
    public void SwingUpLoopCount()
    {
        AniLoopCount++;
        if(AniLoopCount >= 5)
        {
            RightArmAnim.SetBool("SwingUpAfterBool", true);
            Flag = "BackMove";
        }
    }

    public void LanceCountMethod()
    {        
        if(Flag == "SwingUpReady")
        {
            LanceCount++;
            if (LanceCount >= 5)
            {
                Flag = "BackMove";
                RightArmAnim.SetBool("SwingUpAfterBool", true);
            }
        }
    }

    public void LanceFallMethod()
    {
        if(Flag == "LanceThrow")
        {
            AniLoopCount++;

            GameObject obj43 = ObjectPooler43.current.GetPooledObject();
            if (obj43 == null) return;
            obj43.transform.position = LanceFallPos.transform.position;
            obj43.SetActive(true);

            if(AniLoopCount >= 5)
            {
                Flag = "NumberChoice";
                LeftArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("SwingUpBool", false);
                RightArmAnim.SetBool("SwingUpAfterBool", false);
                RightArmAnim.SetBool("LanceCatchBool", true);
            }
        }        
    }

    public void JumpMethod()
    {
        if(Flag == "4ConsecutiveJumpReady")
        {
            Flag = "4ConsecutiveJump1A";
        }
        if (Flag == "4ConsecutiveJumpReady2")
        {
            Flag = "4ConsecutiveJump2A";
        }
        if (Flag == "4ConsecutiveJumpReady3")
        {
            Flag = "4ConsecutiveJump3A";
        }
        if (Flag == "4ConsecutiveJumpReady4")
        {
            Flag = "4ConsecutiveJump4A";
        }
        if (Flag == "LanceShotReady")
        {
            Flag = "LanceShotJump";
        }
    }
    public void FallBodyMethod()
    {
        //Debug.Log("tst");
        if(Flag == "4ConsecutiveJump4A" || Flag == "4ConsecutiveJump4B" || Flag == "JumpStop")
        {
            BodyAnim.SetBool("JumpBool", false);            
        }

        if(Flag == "LanceShotAfter")
        {
            Flag = "LanceShotAfterFall";
            BodyAnim.SetBool("JumpBool", false);
        }
    }
    public void RunBodyMethod()
    {
        if (Flag == "JumpStop")
        {
            Flag = "BackMove";
        }
    }

    public void LanceShotEvent()
    {
        if(Flag == "LanceShot")
        {
            FOPObj.transform.position = new Vector3(9, -4, 0);
            FOPTL.Play();
            Flag = "LanceBurn";
            ScreenShakeController.instance.StartShake(.2f, .4f);
        }
    }
    public void SwingSEMethod()
    {
        SEASource.clip = SwingClip;
        SEASource.Play();
    }
    public void ThrowSEMethod()
    {
        SEASource.clip = ThrowClip;
        SEASource.Play();
    }
}
