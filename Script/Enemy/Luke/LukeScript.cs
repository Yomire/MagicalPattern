using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Playables;

public class LukeScript : MonoBehaviour
{
    public Animator HPAni, LukeAni, NameAni;
    public string Flag, FlagHP, ColorFlag;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop;
    public AudioClip HPSound, JetClip, HomingShotClip, LaserClip, CrackClip, DisableClip;
    public AudioSource HPASLoop, SEASource, SEASourceLoop, SEASource2;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    //public Collider2D LanceCol;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, DParObj, TargetObj, KickObj, KickPos, 
        CrackObj1, CrackObj2, CrackObj3, CrackObj4, CrackObj5, CrackObj6, CrackObj7, CrackObj8, CrackObj9, CrackObj10, CrackObj11, CrackObj12, CrackObj13, CrackObj14, CrackObj15, CrackObj16, CrackObj17, CrackObj18, CrackObj19, CrackObj20,
        CrackObjPos, LaserColObj, HomingPos, NameObj;
    //public PlayableDirector FOPTL;
    public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveX, EndPosX;
    public ParticleSystem DisablePar, TackleParRight, TackleParLeft, 
        JetPar1, JetPar2, JetPar3, JetPar4, JetPar5, JetPar6, JetPar7, JetPar8, JetPar9, JetPar10, LaserPar, KickPar, ShotPar, SparklePar, DustPar, LaserStartPar;
    public Collider2D LukeCol;
    public TrailRenderer EyeTrail;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void LukeEnable()
    {
        HPObj.SetActive(true);
        HPCount = 6;
        ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        this.transform.position = new Vector3(-17, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        //FOPTL.Stop();
        LukeAni.SetBool("KickStartBool", false);
        LukeAni.SetBool("DashBool", false);
        LukeAni.SetBool("DashStartBool", false);
        LukeAni.SetBool("IdleBool", true);
        LukeAni.SetBool("LaserBool", false);
        LukeAni.SetBool("LaserEndBool", false);
        LukeAni.SetBool("HomingBool", false);
        LukeAni.SetBool("HomingEndBool", false);
        LukeCol.enabled = true;
        JetPar1.Play();
        JetPar2.Play();
        JetPar3.Play();
        JetPar4.Play();
        JetPar5.Play();
        JetPar6.Play();
        JetPar7.Stop();
        JetPar8.Stop();
        JetPar9.Play();
        JetPar10.Play();
        SparklePar.Stop();
        DustPar.Stop();
        EyeTrail.enabled = true;
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
                    FlagHP = "Null";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    if (HPCount == 6)
                    {
                        HPCount--;
                        Flag = "NumberChoice";
                    }
                    if (HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        //Flag = "NumberChoice";
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

                    LukeAni.SetBool("HomingEndBool", true);
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

                    LukeAni.SetBool("HomingEndBool", true);
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

                    LukeAni.SetBool("HomingEndBool", true);
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

                    LukeAni.SetBool("HomingEndBool", true);
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

                    LukeAni.SetBool("HomingEndBool", true);
                }
            }
            if (HPCount == 0)
            {
                if (Flag != "End")
                {
                    DParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    HPAni.SetBool("PargeBool", true);
                    NameAni.SetBool("NameEndBool", true);
                    Invoke("LDisableMethod", 0.01f);
                    ScreenShakeController.instance.StartShake(.3f, .6f);
                    LukeAni.SetBool("HomingEndBool", true);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    sm.AddScore(scoreValue);
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
    }
    void OnTriggerStay2D(Collider2D col)
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
    }

    public void LIdleMethod()
    {
        Flag = "NumberChoice";
        LukeAni.Play("LukeStartAni", 0, 0.0f);
        LukeAni.SetBool("KickStartBool", false);
        LukeAni.SetBool("DashBool", false);
        LukeAni.SetBool("DashStartBool", false);
        LukeAni.SetBool("IdleBool", true);
        LukeAni.SetBool("LaserBool", false);
        LukeAni.SetBool("LaserEndBool", false);
        LukeAni.SetBool("HomingBool", false);
        LukeAni.SetBool("HomingEndBool", false);
        TackleParRight.Stop();
        TackleParLeft.Stop();
        LukeCol.enabled = true;
        JetPar1.Play();
        JetPar2.Play();
        JetPar3.Play();
        JetPar4.Play();
        JetPar5.Play();
        JetPar6.Play();
        JetPar7.Stop();
        JetPar8.Stop();
        JetPar9.Play();
        JetPar10.Play();
    }
    public void AniRandomMethod()
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
            AttackNumber = Random.Range(1, 10);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(1, 10);
        }
        if (HPCount == 1)
        {
            AttackNumber = Random.Range(3, 10);
        }
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(5, 13);
        }
        if (Flag == "LanceAfterBack")
        {
            Flag = "NumberChoice";
        }
    }
    public void AniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 3 || AttackNumber == 7)
            {
                LukeAni.SetBool("DashStartBool", true);
                LukeAni.SetBool("DashBool", true);
                AniLoopCount = 0;
                Flag = "Tackle";
                JetPar1.Play();
                JetPar2.Play();
                JetPar3.Play();
                JetPar4.Play();
                JetPar5.Play();
                JetPar6.Play();
                JetPar7.Stop();
                JetPar8.Stop();
                JetPar9.Stop();
                JetPar10.Stop();
            }
            if (AttackNumber == 2 || AttackNumber == 4 || AttackNumber == 8)
            {
                LukeAni.SetBool("DashStartBool", true);
                LukeAni.SetBool("DashBool", false);
                LukeAni.SetBool("KickStartBool", true);
                AniLoopCount = 0;
                Flag = "Kick";
                JetPar1.Play();
                JetPar2.Play();
                JetPar3.Play();
                JetPar4.Play();
                JetPar5.Play();
                JetPar6.Play();
                JetPar7.Stop();
                JetPar8.Stop();
                JetPar9.Stop();
                JetPar10.Stop();
            }
            if(AttackNumber == 9 || AttackNumber == 12)
            {
                LukeAni.SetBool("DashStartBool", true);
                LukeAni.SetBool("DashBool", false);
                LukeAni.SetBool("KickStartBool", true);
                LukeAni.SetBool("LaserBool", true);
                LukeAni.SetBool("LaserEndBool", false);
                AniLoopCount = 0;
                Flag = "Laser";
                JetPar1.Play();
                JetPar2.Play();
                JetPar3.Play();
                JetPar4.Play();
                JetPar5.Play();
                JetPar6.Play();
                JetPar7.Stop();
                JetPar8.Stop();
                JetPar9.Stop();
                JetPar10.Stop();
            }
            if (AttackNumber == 5 || AttackNumber == 10)
            {
                LukeAni.SetBool("DashStartBool", false);
                LukeAni.SetBool("DashBool", false);
                LukeAni.SetBool("KickStartBool", false);
                LukeAni.SetBool("LaserBool", false);
                LukeAni.SetBool("LaserEndBool", false);
                LukeAni.SetBool("HomingBool", true);
                LukeAni.SetBool("HomingEndBool", false);
                AniLoopCount = 0;
                Flag = "Homing";
                JetPar1.Stop();
                JetPar2.Stop();
                JetPar3.Stop();
                JetPar4.Stop();
                JetPar5.Stop();
                JetPar6.Stop();
                JetPar7.Stop();
                JetPar8.Stop();
                JetPar9.Play();
                JetPar10.Play();
            }
        }
    }
    public void HPStartSetMethod()
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
        JetPar1.Play();
        JetPar2.Play();
        JetPar3.Play();
        JetPar4.Play();
        JetPar5.Play();
        JetPar6.Play();
        JetPar7.Stop();
        JetPar8.Stop();
        JetPar9.Play();
        JetPar10.Play();
        //LukeAni.SetBool("HomingBool", false);
        LukeAni.SetBool("HomingEndBool", false);
    }

    public void LDisableMethod()
    {
        this.gameObject.SetActive(false);
    }

    public void LDashRightMethod()
    {
        TackleParRight.Play();
        TackleParLeft.Stop();
    }
    public void LDashLeftMethod()
    {
        TackleParLeft.Play();
        TackleParRight.Stop();
    }

    public void LKickStartMethod()
    {
        if(Flag == "Kick")
        {
            LukeAni.Play("LukeStartAni", 0, 0.0f);
            TargetObj.SetActive(false);
            LukeAni.SetBool("IdleBool", false);
            LukeCol.enabled = false;
            KickObj.transform.position = KickPos.transform.position;
            KickObj.SetActive(true);
        }   
        if(Flag == "Laser")
        {

        }
    }
    /*
    public void LKickEndMethod()
    {
        LukeAni.SetBool("IdleBool", true);
    }
    */
    public void EyeTrueMethod()
    {
        EyeTrail.enabled = true;
    }
    public void EyeFalseMethod()
    {
        EyeTrail.enabled = false;
    }
    public void JetFalseMethod()
    {
        JetPar1.Stop();
        JetPar2.Stop();
        JetPar3.Stop();
        JetPar4.Stop();
        JetPar5.Stop();
        JetPar6.Stop();
        JetPar7.Stop();
        JetPar8.Stop();
        JetPar9.Stop();
        JetPar10.Stop();
    }
    public void JetTrueMethod()
    {
        JetPar1.Play();
        JetPar2.Play();
        JetPar3.Play();
        JetPar4.Play();
        JetPar5.Play();
        JetPar6.Play();
        JetPar7.Play();
        JetPar8.Play();
        JetPar9.Play();
        JetPar10.Play();
    }

    public void LaserCrack()
    {
        SEASource2.clip = CrackClip;
        SEASource2.Play();
        AniLoopCount++;
        if (AniLoopCount == 0)
        {
            if (CrackObj1.activeSelf == false)
            {                
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj1.transform.position = new Vector2(COP.x, -3);
                CrackObj1.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }            
        }
        if (AniLoopCount == 1)
        {
            if (CrackObj2.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj2.transform.position = new Vector2(COP.x, -3);
                CrackObj2.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }                
        }
        if (AniLoopCount == 2)
        {
            if (CrackObj3.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj3.transform.position = new Vector2(COP.x, -3);
                CrackObj3.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }                
        }
        if (AniLoopCount == 3)
        {
            if (CrackObj4.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj4.transform.position = new Vector2(COP.x, -3);
                CrackObj4.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
                //AniLoopCount = 0;
            }            
        }
        if (AniLoopCount == 4)
        {
            if (CrackObj5.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj5.transform.position = new Vector2(COP.x, -3);
                CrackObj5.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 5)
        {
            if (CrackObj6.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj6.transform.position = new Vector2(COP.x, -3);
                CrackObj6.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 6)
        {
            if (CrackObj7.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj7.transform.position = new Vector2(COP.x, -3);
                CrackObj7.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 7)
        {
            if (CrackObj8.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj8.transform.position = new Vector2(COP.x, -3);
                CrackObj8.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 8)
        {
            if (CrackObj9.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj9.transform.position = new Vector2(COP.x, -3);
                CrackObj9.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 9)
        {
            if (CrackObj10.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj10.transform.position = new Vector2(COP.x, -3);
                CrackObj10.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 10)
        {
            if (CrackObj11.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj11.transform.position = new Vector2(COP.x, -3);
                CrackObj11.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
            if(Flag == "Laser")
            {
                LaserStartMethod();
                Flag = "LaserB";
            }            
        }
        if (AniLoopCount == 11)
        {
            //AniLoopCount = 0;
            if (CrackObj12.activeSelf == false)
            {
                //AniLoopCount++;
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj12.transform.position = new Vector2(COP.x, -3);
                CrackObj12.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);                
            }
        }
        if (AniLoopCount == 12)
        {
            if (CrackObj13.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj13.transform.position = new Vector2(COP.x, -3);
                CrackObj13.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 13)
        {
            if (CrackObj14.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj14.transform.position = new Vector2(COP.x, -3);
                CrackObj14.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 14)
        {
            if (CrackObj15.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj15.transform.position = new Vector2(COP.x, -3);
                CrackObj15.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 15)
        {
            if (CrackObj16.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj16.transform.position = new Vector2(COP.x, -3);
                CrackObj16.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 16)
        {
            if (CrackObj17.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj17.transform.position = new Vector2(COP.x, -3);
                CrackObj17.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 17)
        {
            if (CrackObj18.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj18.transform.position = new Vector2(COP.x, -3);
                CrackObj18.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount == 18)
        {
            if (CrackObj19.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj19.transform.position = new Vector2(COP.x, -3);
                CrackObj19.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
        if (AniLoopCount >= 19)
        {
            AniLoopCount = 0;
            if (CrackObj20.activeSelf == false)
            {
                Vector3 COP = CrackObjPos.transform.position;
                CrackObj20.transform.position = new Vector2(COP.x, -3);
                CrackObj20.SetActive(true);
                ScreenShakeController.instance.StartShake(.3f, .4f);
            }
        }
    }

    public void LaserEndMethod()
    {
        LukeAni.SetBool("LaserBool", false);
        LukeAni.SetBool("LaserEndBool", true);
    }
    public void LaserReadyMethod()
    {
        LaserStartPar.Play();
    }
    public void LaserStartMethod()
    {
        LaserStartPar.Stop();
        LaserColObj.SetActive(true);
        LaserPar.Play();
        LaserSEMethod();
    }

    public void KickParMethod()
    {
        KickPar.Play();
    }
    public void KickParFalseMethod()
    {
        KickPar.Stop();
    }

    public void HomingBulletMethod()
    {
        HomingShotSEMethod();
        AniLoopCount++;
        ShotPar.Play();
        GameObject obj = ObjectPooler45.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HomingPos.transform.position;
        obj.SetActive(true);
        if(AniLoopCount >= 10)
        {
            LukeAni.SetBool("HomingEndBool", true);
        }
    }
    public void HomingEnd()
    {
        Flag = "NumberChoice";
        LukeAni.SetBool("KickStartBool", false);
        LukeAni.SetBool("DashBool", false);
        LukeAni.SetBool("DashStartBool", false);
        LukeAni.SetBool("IdleBool", true);
        LukeAni.SetBool("LaserBool", false);
        LukeAni.SetBool("LaserEndBool", false);
        LukeAni.SetBool("HomingBool", false);
        LukeAni.SetBool("HomingEndBool", false);
        TackleParRight.Stop();
        TackleParLeft.Stop();
        LukeCol.enabled = true;
        JetPar1.Play();
        JetPar2.Play();
        JetPar3.Play();
        JetPar4.Play();
        JetPar5.Play();
        JetPar6.Play();
        JetPar7.Stop();
        JetPar8.Stop();
        JetPar9.Play();
        JetPar10.Play();
    }

    public void GroundParMethod()
    {
        SparklePar.Play();
        DustPar.Play();
    }
    public void GroundParStopMethod()
    {
        SparklePar.Stop();
        DustPar.Stop();
    }

    public void Jet78910()
    {
        JetPar1.Stop();
        JetPar2.Stop();
        JetPar3.Stop();
        JetPar4.Stop();
        JetPar5.Stop();
        JetPar6.Stop();
        JetPar7.Play();
        JetPar8.Play();
        JetPar9.Play();
        JetPar10.Play();
    }
    public void HomingShotSEMethod()
    {
        SEASource.clip = HomingShotClip;
        SEASource.Play();
    }
    public void LaserSEMethod()
    {
        SEASource.clip = LaserClip;
        SEASource.Play();
    }
    public void JetSEMethod()
    {
        SEASourceLoop.clip = JetClip;
        SEASourceLoop.Play();
        SEASourceLoop.volume = 1;
        SEASourceLoop.pitch = 3;
    }
    public void JetSEStopMethod()
    {
        SEASourceLoop.volume = 0.2f;
        SEASourceLoop.Stop();
        SEASourceLoop.pitch = 1;
    }
}
