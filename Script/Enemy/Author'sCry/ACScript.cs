using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ACScript : MonoBehaviour
{
    public Animator ACAnim, HPAni, HPAniEX, NameAni;
    public string Flag, FlagHP, ColorFlag;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop, HPEX1Sprite, BGSprite1, BGSprite2;
    public AudioClip HPSound, DisableClip;
    public AudioSource HPASLoop, SEASource;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    public Collider2D EXEyeCol;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount, HPCountEX;
    public GameObject HPObj, HP1, HP2, HP3, HPB1, HPB2, HPB3, DParObj, HPEXObj, HPEX1, HPEX2, HPEX3, HPEX4, HPEXB1, HPEXB2, HPEXB3, HPEXB4, ArmRight, ArmLeft, 
        RightEyeObj, LeftEyeObj, TargetObjEX, DeadArmObj1, DeadArmObj2, DeadParPos1, DeadParPos2, DeadParPos3, DeadParPos4, DeadParPos5, 
        AttackArmLeft, AttackArmRight, StepGenerateObjUp, StepGenerateObjDown, AttackEyeObjLeft, AttackEyeObjRight, AttackEyePosLeftUp, AttackEyePosLeft, AttackEyePosLeftDown,
        AttackEyePosRightUp, AttackEyePosRight, AttackEyePosRightDown, NailGeneArmLeft, NailGeneArmRight, DeadArm1, DeadArm2, NameObj;
    //public PlayableDirector FOPTL;
    public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveX, EndPosX;
    public ParticleSystem DisablePar;
    public CryArmScript CArmS1, CArmS2;
    public AudioClip SmileClip;
    public AudioSource SEASoursLoop;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void ACEnable()
    {
        SEASoursLoop.clip = SmileClip;
        SEASoursLoop.Play();
        SEASoursLoop.pitch = 2;
        HPObj.SetActive(true);
        HPEXObj.SetActive(false);
        HPCount = 3;
        HPCountEX = 4;
        ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        NameObj.SetActive(true);
        NameAni.SetBool("NameEndBool", false);
        if (HPAni != null)
        {
            HPAni.SetBool("PargeBool", false);
        }
        /*
        if (HPAniEX != null)
        {
            HPAniEX.SetBool("PargeBool", false);
        }
        */
        ACAnim.SetBool("MoveBool", false);
        ACAnim.SetBool("CenterBool", false);
        //FOPTL.Stop();
        HP1.SetActive(true);
        HPB1.SetActive(false);
        HP2.SetActive(true);
        HPB2.SetActive(false);
        HP3.SetActive(true);
        HPB3.SetActive(false);
        ArmRight.SetActive(true);
        ArmLeft.SetActive(true);
        DParObj.transform.position = this.transform.position;
        DisablePar.Play();
        EXEyeCol.enabled = false;
        RightEyeObj.SetActive(true);
        LeftEyeObj.SetActive(true);
        TargetObjEX.SetActive(false);
        AttackArmLeft.SetActive(false);
        AttackArmRight.SetActive(false);
        ACAnim.SetLayerWeight(1, 0f);
        ACAnim.SetLayerWeight(2, 0f);
        StepGenerateObjUp.SetActive(false);
        StepGenerateObjDown.SetActive(false);
        AttackEyeObjLeft.SetActive(false);
        AttackEyeObjRight.SetActive(false);
        NailGeneArmLeft.SetActive(false);
        NailGeneArmRight.SetActive(false);
        if (DeadArm1.activeSelf)
        {
            CArmS1.Disable();
        }
        if (DeadArm2.activeSelf)
        {
            CArmS2.Disable();
        }

        tilemap1.color = new Color32(100, 20, 64, 255);
        tilemap2.color = new Color32(200, 0, 80, 255);
        BackLightBottom.color = new Color32(200, 0, 80, 255);
        BackLightTop.color = new Color32(200, 0, 80, 255);
        BGSprite1.color = new Color32(255, 120, 155, 255);
        BGSprite2.color = new Color32(255, 120, 155, 255);
    }
    public void HPResetMethod()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Flag == "Start")
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
        if (FlagHP == "HPSet")
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
                    Flag = "NumberChoice";
                    //FlagHP = "DamageCan";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    if (HPCount == 3)
                    {
                        HPCount--;
                        ACAnim.SetBool("MoveBool", true);
                        SEASoursLoop.pitch = 1;
                        SEASoursLoop.Stop();
                    }
                    /*
                    if (HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        Flag = "NumberChoice";
                    }
                    */
                    if (HPCount >= 0)
                    {
                        FlagHP = "DamageCan";
                    }
                    /*
                    if (HPCountEX >= 0)
                    {
                        FlagHP = "Null";
                    }
                    */
                }
            }
        }
        if (HP1Sprite.size.x <= 1.28)
        {
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
                if (Flag != "EX")
                {
                    if (HPObj.activeSelf)
                    {
                        DParObj.transform.position = this.transform.position;
                        DisablePar.Play();
                        Flag = "EX";
                        HP1.SetActive(false);
                        HPB1.SetActive(true);
                        //QAnim.Play("DeathAni", 0, 0.0f);
                        AniLoopCount = 0;
                        HPAni.SetBool("PargeBool", true);
                        //Invoke("EXMethod", 0.01f);
                        ACAnim.Play("ACFirstDisAni", 0, 0.0f);
                        AttackArmLeft.SetActive(false);
                        AttackArmRight.SetActive(false);
                        ACAnim.SetLayerWeight(1, 0f);
                        ACAnim.SetLayerWeight(2, 0f);
                    }                    
                }
            }
        }

        if (FlagHP == "HPSetEX")
        {
            if (HPEX1.activeSelf)
            {
                HPEX1Sprite.size += new Vector2(0.1f, 0.0f);
                HPASLoop.Play();
                if (HPEX1Sprite.size.x >= 15)
                {
                    Flag = "NumberChoice";
                    //FlagHP = "DamageCan";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    if (HPCountEX == 4)
                    {
                        HPCountEX--;
                    }
                    if (HPCountEX >= 0)
                    {
                        FlagHP = "DamageCanEX";
                    }
                }
            }
        }
        if (HPEX1Sprite.size.x <= 1.28)
        {
            if (HPCountEX == 3)
            {
                if (FlagHP != "HPSetEX")
                {
                    HPEX4.SetActive(false);
                    HPEXB4.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSetEX";
                    HPCountEX--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCountEX == 2)
            {
                if (FlagHP != "HPSetEX")
                {
                    HPEX3.SetActive(false);
                    HPEXB3.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSetEX";
                    HPCountEX--;
                    Invoke("HPResetMethod", 0.01f);

                    StepGenerateObjUp.SetActive(false);
                    StepGenerateObjDown.SetActive(false);
                    AttackEyeObjLeft.SetActive(false);
                    AttackEyeObjRight.SetActive(false);
                }
            }
            if (HPCountEX == 1)
            {
                if (FlagHP != "HPSetEX")
                {
                    HPEX2.SetActive(false);
                    HPEXB2.SetActive(true);
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSetEX";
                    HPCountEX--;
                    Invoke("HPResetMethod", 0.01f);
                }
            }
            if (HPCountEX == 0)
            {
                if (Flag != "End")
                {
                    DParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    Flag = "End";
                    HPEX1.SetActive(false);
                    HPEXB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    ACAnim.Play("ACEXDisAni", 0, 0.0f);

                    tilemap1.color = new Color32(0, 70, 80, 255);
                    tilemap2.color = new Color32(26, 195, 252, 255);
                    BackLightBottom.color = new Color32(26, 195, 252, 255);
                    BackLightTop.color = new Color32(10, 0, 160, 255);
                    BGSprite1.color = new Color32(255, 180, 250, 255);
                    BGSprite2.color = new Color32(255, 180, 250, 255);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP == "DamageCan")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.2f, 0.0f);
                }
            }
            if (FlagHP == "DamageCan")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.2f, 0.0f);
                }
            }

            if (FlagHP == "DamageCanEX")
            {
                if (HPEX1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.2f, 0.0f);
                }
            }
            if (FlagHP == "DamageCanEX")
            {
                if (HPEX1Sprite.size.x >= 1.28)
                {
                    HPEX1Sprite.size -= new Vector2(0.2f, 0.0f);
                }
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (FlagHP == "DamageCan")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(1.0f, 0.0f);
                }
            }
            if (FlagHP == "DamageCanEX")
            {
                if (HPEX1Sprite.size.x >= 1.28)
                {
                    HPEX1Sprite.size -= new Vector2(1.0f, 0.0f);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP == "DamageCan")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(1.5f, 0.0f);
                }
            }
            if (FlagHP == "DamageCanEX")
            {
                if (HPEX1Sprite.size.x >= 1.28)
                {
                    HPEX1Sprite.size -= new Vector2(1.5f, 0.0f);
                }
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (FlagHP == "DamageCan")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(3.0f, 0.0f);
                }
            }
            if (FlagHP == "DamageCanEX")
            {
                if (HPEX1Sprite.size.x >= 1.28)
                {
                    HPEX1Sprite.size -= new Vector2(3.0f, 0.0f);
                }
            }
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
    public void HPSetEXMethod()
    {
        FlagHP = "HPSetEX";
        HPEXObj.SetActive(true);
        HPEX1.SetActive(true);
        HPEXB1.SetActive(false);
        HPEX2.SetActive(true);
        HPEXB2.SetActive(false);
        HPEX3.SetActive(true);
        HPEXB3.SetActive(false);
        HPEX4.SetActive(true);
        HPEXB4.SetActive(false);
        ArmRight.SetActive(false);
        ArmLeft.SetActive(false);
        RightEyeObj.SetActive(false);
        LeftEyeObj.SetActive(false);
        EXEyeCol.enabled = true;
        TargetObjEX.SetActive(true);

        StepGenerateObjUp.SetActive(true);
        StepGenerateObjDown.SetActive(true);
    }
    public void EXMethod()
    {     
        
        ACAnim.Play("ACFirstDisAni", 0, 0.0f);
        //FlagHP = "HPSetEX";
    }
    public void ScreenShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.2f, .4f);
    }

    public void DamageMethod()
    {
        if (FlagHP == "DamageCan")
        {
            if (HP1Sprite.size.x >= 1.28)
            {
                HP1Sprite.size -= new Vector2(1.5f, 0.0f);
            }
        }
        if (FlagHP == "DamageCanEX")
        {
            if (HPEX1Sprite.size.x >= 1.28)
            {
                HPEX1Sprite.size -= new Vector2(0.5f, 0.0f);
            }
        }
    }
    public void DamageSPMethod()
    {
        if (FlagHP == "DamageCan")
        {
            if (HP1Sprite.size.x >= 1.28)
            {
                HP1Sprite.size -= new Vector2(3.0f, 0.0f);
            }
        }
        if (FlagHP == "DamageCanEX")
        {
            if (HPEX1Sprite.size.x >= 1.28)
            {
                HPEX1Sprite.size -= new Vector2(2.0f, 0.0f);
            }
        }
    }

    public void EXDisableMethod()
    {
        DParObj.transform.position = this.transform.position;
        DisablePar.Play();
        Invoke("DisableMethod", 0.01f);
        HPAniEX.SetBool("PargeBool", true);
        NameAni.SetBool("NameEndBool", true);
        sm.AddScore(scoreValue);
    }

    public void DeadArmEnable1()
    {
        DeadArmObj1.SetActive(true);
    }
    public void DeadArmEnable2()
    {
        DeadArmObj2.SetActive(true);
    }
    public void DeadParMethod0()
    {
        ScreenShakeMethod();
        DParObj.transform.position = this.transform.position;
        DisablePar.Play();
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void DeadParMethod1()
    {
        /*
        ScreenShakeMethod();
        DeadParObj1.transform.position = DeadParPos1.transform.position;
        DeadPar1.Play();
        */
        SEASource.clip = DisableClip;
        SEASource.Play();
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = DeadParPos1.transform.position;
        obj14C.SetActive(true);
    }
    public void DeadParMethod2()
    {
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = DeadParPos2.transform.position;
        obj14C.SetActive(true);
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void DeadParMethod3()
    {
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = DeadParPos3.transform.position;
        obj14C.SetActive(true);
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void DeadParMethod4()
    {
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = DeadParPos4.transform.position;
        obj14C.SetActive(true);
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void DeadParMethod5()
    {
        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = DeadParPos5.transform.position;
        obj14C.SetActive(true);
        SEASource.clip = DisableClip;
        SEASource.Play();
    }

    public void AniRandomMethod()
    {
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(1, 4);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 4);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(1, 4);
        }
        if (HPCount == 1)
        {
            AttackNumber = Random.Range(1, 4);
        }
        /*
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(1, 4);
        }
        */
        /*
        if (HPCountEX == 4)
        {
            AttackNumber = Random.Range(5, 11);
        }
        */
        if (HPCountEX == 3)
        {
            AttackNumber = Random.Range(5, 11);
        }
        if (HPCountEX == 2)
        {
            AttackNumber = Random.Range(1, 11);
        }
        if (HPCountEX == 1)
        {
            AttackNumber = Random.Range(11, 16);
        }
        if (HPCountEX == 0)
        {
            AttackNumber = Random.Range(0, 0);
        }
    }
    public void AniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 12)
            {
                /*
                ADAnim.SetBool("WallAct1Bool", false);
                ADAnim.SetBool("WallAct2Bool", true);
                */
                if(AttackArmLeft.activeSelf == false && NailGeneArmLeft.activeSelf == false)
                {
                    Flag = "AttackArmLeft";
                    AttackArmLeft.SetActive(true);
                    ACAnim.SetLayerWeight(1, 1f);
                }
            }
            if (AttackNumber == 2 || AttackNumber == 13)
            {
                if (AttackArmRight.activeSelf == false && NailGeneArmRight.activeSelf == false)
                {
                    Flag = "AttackArmRight";
                    AttackArmRight.SetActive(true);
                    ACAnim.SetLayerWeight(2, 1f);
                }
            }
            if (AttackNumber == 5)
            {
                if(AttackEyeObjLeft.activeSelf == false)
                {
                    AttackEyeObjLeft.SetActive(true);
                    AttackEyeObjLeft.transform.position = AttackEyePosLeftUp.transform.position;
                }                
            }
            if (AttackNumber == 6)
            {
                if (AttackEyeObjLeft.activeSelf == false)
                {
                    AttackEyeObjLeft.SetActive(true);
                    AttackEyeObjLeft.transform.position = AttackEyePosLeft.transform.position;
                }
            }
            if (AttackNumber == 7)
            {
                if (AttackEyeObjLeft.activeSelf == false)
                {
                    AttackEyeObjLeft.SetActive(true);
                    AttackEyeObjLeft.transform.position = AttackEyePosLeftDown.transform.position;
                }
            }
            if (AttackNumber == 8)
            {
                if (AttackEyeObjRight.activeSelf == false)
                {
                    AttackEyeObjRight.SetActive(true);
                    AttackEyeObjRight.transform.position = AttackEyePosRightUp.transform.position;
                }
            }
            if (AttackNumber == 9)
            {
                if (AttackEyeObjRight.activeSelf == false)
                {
                    AttackEyeObjRight.SetActive(true);
                    AttackEyeObjRight.transform.position = AttackEyePosRight.transform.position;
                }
            }
            if (AttackNumber == 10)
            {
                if (AttackEyeObjRight.activeSelf == false)
                {
                    AttackEyeObjRight.SetActive(true);
                    AttackEyeObjRight.transform.position = AttackEyePosRightDown.transform.position;
                }
            }
            if (AttackNumber == 14)
            {
                if (NailGeneArmLeft.activeSelf == false && AttackArmLeft.activeSelf == false)
                {
                    NailGeneArmLeft.SetActive(true);
                    //AttackEyeObjRight.transform.position = AttackEyePosRightDown.transform.position;
                }
            }
            if (AttackNumber == 15)
            {
                if (NailGeneArmRight.activeSelf == false && AttackArmRight.activeSelf == false)
                {
                    NailGeneArmRight.SetActive(true);
                    //AttackEyeObjRight.transform.position = AttackEyePosRightDown.transform.position;
                }
            }
        }
    }
    public void FlagResetMethod()
    {
        if(AttackArmLeft.activeSelf == false)
        {
            ACAnim.SetLayerWeight(1, 0f);
            Flag = "NumberChoice";
        }
        if (AttackArmRight.activeSelf == false)
        {
            ACAnim.SetLayerWeight(2, 0f);
            Flag = "NumberChoice";
        }
    }
}
