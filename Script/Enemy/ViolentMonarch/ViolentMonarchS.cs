using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ViolentMonarchS : MonoBehaviour
{
    public AdsLoadScript AdsLS;
    public float StartPosX, StartPosY, EndPosY, MoveY, StabMoveX, DiagonalStabRotaZ, FallStabRotaZ, StabEndPosY, EndPosX, speed;
    public GameObject EnableObj, HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HP7, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7, 
        MonarchObj, MonaObj, BulletObj, DisableParObj, DiagonalStabPos, FallStabPos, HunmmerPos, LeftStabPos, RightStabPos, 
        BladePObj, HammerPObj, ButterflyPObj, MagnetPObj, BulletPObj, ThunderPObj, BombPObj, BombObj, player, BulletPosObj, 
        ScorePanelObj, StartUIObj, CompleteUIObj;
    public string Flag, FlagHP, PauseFlag;
    public ParticleSystem DisablePar, StabPar, Thunder1Par, Thunder2Par, Thunder3Par, Thunder4Par, ButterflyPar1, ButterflyPar2, ButterflyPar3, ButterflyPar4, 
        StartPar;
    public SpriteRenderer HP1Sprite;
    public int HPCount, AttackNumber, AnimCount;
    public AudioSource HPASLoop;
    public Animator VMAnim, PanelAnim, HPAni;
    public ContinueButton ConBS, NextButtonS;
    public Vector2 prev;
    private Rigidbody2D rb;
    public MonarchBulletS MBS;
    public ScoreManager ScoreManagerS;
    public AudioSource BGMASours, SEASource, SEASource2, SEASource3;
    public AudioClip StabClip, HammerClip, BulletClip, DisableClip, LandClip;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    public Info1 info;
    void Awake()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        this.transform.position = new Vector3(StartPosX, StartPosY, 0);
        Flag = "Fall";
        HPCount = 7;
        player = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
        PauseFlag = "Off";
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        BGMASours.volume = info.BGMVolume;
    }
    void Move()
    {
        //ユーザの場所を特定
        Vector2 Predetor = player.transform.position;

        float x = Predetor.x;
        float y = Predetor.y;
        //追跡方向の決定
        Vector2 direction = new Vector2(0, y - transform.position.y).normalized;
        //ターゲット方向に力を加える
        rb.velocity = (direction * speed);
    }
    void FixedUpdate()
    {
        if(PauseFlag == "Off")
        {
            if (Flag == "Fall")
            {
                this.transform.Translate(0, MoveY, 0);
            }
            if (this.transform.localPosition.y <= EndPosY)
            {
                if (Flag == "Fall")
                {
                    Flag = "Stop";
                    FlagHP = "HPSet";
                    EnableObj.SetActive(false);
                    DisablePar.Play();
                    DisableParObj.transform.position = this.transform.position;
                    ShakeMethod();
                    StartUIObj.SetActive(true);
                    StartPar.Play();
                    SEASource2.clip = DisableClip;
                    SEASource2.Play();
                    SEASource3.clip = LandClip;
                    SEASource3.Play();
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
                        Flag = "Null";
                        FlagHP = "Null";
                        //WAniSpeed2();
                        HPASLoop.Stop();
                        DisablePar.Play();
                        SEASource2.clip = DisableClip;
                        SEASource2.Play();
                        Invoke("ResetPos", 0.1f);
                        if (HPCount == 7)
                        {
                            HPCount--;
                        }
                    }
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
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 5)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP6.SetActive(false);
                        HPB6.SetActive(true);
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 4)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP5.SetActive(false);
                        HPB5.SetActive(true);
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 3)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP4.SetActive(false);
                        HPB4.SetActive(true);
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 2)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP3.SetActive(false);
                        HPB3.SetActive(true);
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 1)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP2.SetActive(false);
                        HPB2.SetActive(true);
                        VMAnim.Play("LandAni", 0, 0.0f);
                        //QAnim.Play("QueenVisitAniLand", 0, 0.0f);
                        FlagHP = "HPSet";
                        HPCount--;
                        AnimEndMethod();
                        //Invoke("QHPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 0)
                {
                    if (Flag != "End" && Flag != "Complete")
                    {
                        AnimCount = 0;
                        ConBS.EpiFlagMethod();
                        AdsLS.EpiFlagOn();
                        Flag = "End";
                        HP1.SetActive(false);
                        HPB1.SetActive(true);
                        MonarchObj.SetActive(false);
                        MonaObj.SetActive(true);
                        DisableParObj.transform.position = this.transform.position;
                        DisablePar.Play();
                        SEASource2.clip = DisableClip;
                        SEASource2.Play();
                        Invoke("MonaDeathAnim", 0.1f);
                        if (BulletObj.activeSelf)
                        {
                            BulletObj.SetActive(false);
                        }
                    }
                }
            }
            if (Flag == "DiagonalStab" || Flag == "FallStab")
            {
                this.transform.Translate(StabMoveX, 0, 0);
                StabPar.Play();
                if (this.transform.localPosition.y <= EndPosY)
                {
                    DisableParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    SEASource2.clip = DisableClip;
                    SEASource2.Play();
                    Invoke("ResetPos", 0.1f);
                    ScreenShakeController.instance.StartShake(.2f, .4f);
                    GameObject obj12 = ObjectPooler12.current.GetPooledObject();
                    if (obj12 == null) return;
                    obj12.transform.position = this.transform.position;
                    obj12.SetActive(true);

                    GameObject obj41 = ObjectPooler41.current.GetPooledObject();
                    if (obj41 == null) return;
                    obj41.transform.position = this.transform.position;
                    obj41.SetActive(true);

                    GameObject obj42 = ObjectPooler42.current.GetPooledObject();
                    if (obj42 == null) return;
                    obj42.transform.position = this.transform.position;
                    obj42.SetActive(true);
                }
            }
            if (Flag == "LeftStab")
            {
                this.transform.Translate(StabMoveX, 0, 0);
                StabPar.Play();
                if (this.transform.localPosition.x <= -EndPosX || this.transform.localPosition.x >= EndPosX)
                {
                    DisableParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    SEASource2.clip = DisableClip;
                    SEASource2.Play();
                    Invoke("ResetPos", 0.1f);
                    //ScreenShakeController.instance.StartShake(.2f, .4f);
                }
            }
            if (Flag == "RightStab")
            {
                this.transform.Translate(-StabMoveX, 0, 0);
                StabPar.Play();
                if (this.transform.localPosition.x <= -EndPosX || this.transform.localPosition.x >= EndPosX)
                {
                    DisableParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    SEASource2.clip = DisableClip;
                    SEASource2.Play();
                    Invoke("ResetPos", 0.1f);
                    //ScreenShakeController.instance.StartShake(.2f, .4f);
                }
            }
            if (Flag == "Butterfly")
            {
                Move();
            }
        }        
    }
    public void MonaDeathAnim()
    {
        VMAnim.Play("MonaDeathAni", 0, 0.0f);
        HPAni.SetBool("PargeBool", true);
        this.transform.Translate(0, 2, 0);
        CompleteUIObj.SetActive(true);
        StartPar.Play();
        sm.AddScore(scoreValue);
    }
    public void ResetPos()
    {
        //FlagHP = "Null";
        Flag = "Null";
        this.transform.position = new Vector3(10, 10, 0);
        AttackNumber = 0;
        AnimCount = 0;
        StabPar.Stop();
        VMAnim.SetBool("Shot2Bool", false);
        ButterflyPar1.Stop();
        ButterflyPar2.Stop();
        ButterflyPar3.Stop();
        ButterflyPar4.Stop();
        rb.velocity = Vector3.zero;
        if (BulletObj.activeSelf)
        {
            BulletObj.SetActive(false);
        }
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (PauseFlag == "Off")
            {                
                if (Flag == "Null")
                {
                    if (HPCount == 7)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 6)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 5)
                    {
                        AttackNumber = Random.Range(1, 10);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 4)
                    {
                        AttackNumber = Random.Range(1, 15);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 3)
                    {
                        AttackNumber = Random.Range(1, 15);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 2)
                    {
                        AttackNumber = Random.Range(1, 20);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 1)
                    {
                        AttackNumber = Random.Range(1, 20);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                }
                if (Flag == "Bomb")
                {
                    AnimCount++;
                    if (AnimCount >= 1)
                    {
                        VMAnim.SetBool("Shot2Bool", true);
                        Flag = "Bomb2";
                    }
                }                
                /*
                if (Flag == "Thunder4")
                {
                    BombAnimMethod();
                }
                */
                if (Flag == "Bomb3")
                {
                    AnimCount++;
                    if (AnimCount >= 2)
                    {
                        AnimEndMethod();
                    }
                }
                if (Flag == "Butterfly")
                {
                    AnimCount++;
                    if (AnimCount >= 3)
                    {
                        Flag = "Magnet";
                        AnimCount = 0;
                        MagnetPObj.transform.position = this.transform.position;
                        MagnetPObj.SetActive(true);
                        rb.velocity = Vector3.zero;
                        BulletObj.transform.position = BulletPosObj.transform.position;
                        BulletObj.SetActive(true);
                    }
                }
                if (Flag == "Magnet")
                {
                    AnimCount++;
                    if (AnimCount >= 5)
                    {
                        Flag = "Bullet";
                        BulletPObj.transform.position = this.transform.position;
                        BulletPObj.SetActive(true);
                        VMAnim.SetBool("Shot2Bool", true);
                        MBS.ShotMethod();
                        AnimCount = 0;
                    }
                }
                if (Flag == "Bullet")
                {
                    AnimCount++;
                    if (AnimCount >= 3)
                    {
                        AnimEndMethod();
                    }
                }
                if (Flag == "Thunder")
                {
                    Invoke("ThunderFlag1", 0.1f);
                    //DisableParObj.transform.position = new Vector3(-6.75f, 4f, 0);
                    //DisablePar.Play();
                    ThunderPObj.transform.position = new Vector3(-6.75f, 4f, 0);
                    ThunderPObj.SetActive(true);
                    Thunder1Par.Play();
                    //Debug.Log("test");
                }
                if (Flag == "Thunder1")
                {
                    Invoke("ThunderFlag2", 0.1f);
                    //DisableParObj.transform.position = new Vector3(-6.75f, 4f, 0);
                    //DisablePar.Play();
                    ThunderPObj.transform.position = new Vector3(-2.25f, 4f, 0);
                    ThunderPObj.SetActive(true);
                    Thunder2Par.Play();
                    //Debug.Log("test");
                }
                if (Flag == "Thunder2")
                {
                    Invoke("ThunderFlag3", 0.1f);
                    //DisableParObj.transform.position = new Vector3(-6.75f, 4f, 0);
                    //DisablePar.Play();
                    ThunderPObj.transform.position = new Vector3(2.25f, 4f, 0);
                    ThunderPObj.SetActive(true);
                    Thunder3Par.Play();
                    //Debug.Log("test");
                }
                if (Flag == "Thunder3")
                {
                    //Invoke("ThunderFlag4", 0.1f);
                    //DisableParObj.transform.position = new Vector3(-6.75f, 4f, 0);
                    //DisablePar.Play();
                    ThunderPObj.transform.position = new Vector3(6.75f, 4f, 0);
                    ThunderPObj.SetActive(true);
                    Thunder4Par.Play();
                    BombAnimMethod();
                    //Debug.Log("test");
                }
                if(Flag == "End")
                {
                    AnimCount++;
                    if(AnimCount >= 3)
                    {
                        ScorePanelObj.SetActive(true);
                        PanelAnim.SetBool("GetExpBool", true);
                        PanelAnim.SetBool("ContinueBool", false);
                        PanelAnim.SetBool("GetExpEndBool", false);
                        PanelAnim.SetBool("GetExpEpiBool", false);
                        ScoreManagerS.ResultMethod();
                        Flag = "Complete";
                        //Debug.Log("test1");
                    }
                }
            }
        }
        /*
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            if(Flag == "Magnet")
            {
                CoinGenerateUp();
                CoinGenerateCentor();
                CoinGenerateDown();
                Debug.Log("test");
            }
        }
        */
    }
    public void AttackMethod()
    {
        if(AttackNumber == 1 || AttackNumber == 14)
        {
            Flag = "DiagonalStab";
            DisableParObj.transform.position = DiagonalStabPos.transform.position;
            //Invoke("DisableParMethod", 0.01f);
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            BladePObj.transform.position = DiagonalStabPos.transform.position;
            BladePObj.SetActive(true);
            this.transform.position = DiagonalStabPos.transform.position;
            this.transform.rotation = Quaternion.Euler(0, 0, DiagonalStabRotaZ);
            VMAnim.Play("BladeStabAni", 0, 0.0f);
            transform.localScale = new Vector3(-1, 1, 1);
            SEASource.clip = StabClip;
            SEASource.Play();
        }
        if (AttackNumber == 2 || AttackNumber == 13)
        {
            Flag = "FallStab";
            DisableParObj.transform.position = FallStabPos.transform.position;
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            //Invoke("DisableParMethod", 0.01f);
            BladePObj.transform.position = FallStabPos.transform.position;
            BladePObj.SetActive(true);
            this.transform.position = FallStabPos.transform.position;
            this.transform.rotation = Quaternion.Euler(0, 0, FallStabRotaZ);
            VMAnim.Play("BladeStabAni", 0, 0.0f);
            transform.localScale = new Vector3(-1, 1, 1);
            SEASource.clip = StabClip;
            SEASource.Play();
        }
        if (AttackNumber == 10)
        {
            Flag = "LeftStab";
            DisableParObj.transform.position = LeftStabPos.transform.position;
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            //Invoke("DisableParMethod", 0.01f);
            BladePObj.transform.position = LeftStabPos.transform.position;
            BladePObj.SetActive(true);
            this.transform.position = LeftStabPos.transform.position;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            VMAnim.Play("BladeStabAni", 0, 0.0f);
            transform.localScale = new Vector3(-1, 1, 1);
            SEASource.clip = StabClip;
            SEASource.Play();
        }
        if (AttackNumber == 11)
        {
            Flag = "RightStab";
            DisableParObj.transform.position = RightStabPos.transform.position;
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            //Invoke("DisableParMethod", 0.01f);
            BladePObj.transform.position = RightStabPos.transform.position;
            BladePObj.SetActive(true);
            this.transform.position = RightStabPos.transform.position;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            VMAnim.Play("BladeStabAni", 0, 0.0f);
            transform.localScale = new Vector3(1, 1, 1);
            SEASource.clip = StabClip;
            SEASource.Play();
        }
        if (AttackNumber == 5)
        {
            Flag = "Hammer";
            DisableParObj.transform.position = HunmmerPos.transform.position;
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            //Invoke("DisableParMethod", 0.01f);
            HammerPObj.transform.position = HunmmerPos.transform.position;
            HammerPObj.SetActive(true);
            Vector3 HPos = HunmmerPos.transform.position;
            this.transform.position = new Vector2(HPos.x, -2.28f);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            VMAnim.Play("HunmmerAni", 0, 0.0f);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (AttackNumber == 3 || AttackNumber == 12)
        {
            Flag = "Thunder";
            VMAnim.Play("LandAni", 0, 0.0f);
            /*
            //DisableParObj.transform.position = new Vector3(-6.75f, 4f, 0);
            //DisablePar.Play();
            ThunderPObj.transform.position = new Vector3(-6.75f, 4f, 0);
            ThunderPObj.SetActive(true);
            Thunder1Par.Play();
            */
        }
        if (AttackNumber == 15 || AttackNumber == 18)
        {
            Flag = "Butterfly";
            DisableParObj.transform.position = new Vector2(7f, 0);
            DisablePar.Play();
            SEASource2.clip = DisableClip;
            SEASource2.Play();
            //Invoke("DisableParMethod", 0.01f);
            ButterflyPObj.transform.position = new Vector2(7f, 0);
            ButterflyPObj.SetActive(true);
            this.transform.position = new Vector2(7f, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            VMAnim.Play("Shot1Ani", 0, 0.0f);
            transform.localScale = new Vector3(1, 1, 1);
            
            MBS.BulletEnable();
            ButterflyPar1.Play();
            ButterflyPar2.Play();
            ButterflyPar3.Play();
            ButterflyPar4.Play();
        }
        if (AttackNumber == 4 || AttackNumber == 6 || AttackNumber == 7 || AttackNumber == 8 || AttackNumber == 9 || AttackNumber == 16 || AttackNumber == 17 || AttackNumber == 19 || AttackNumber == 20)
        {
            Flag = "Null";
        }
    }
    public void AnimEndMethod()
    {
        DisableParObj.transform.position = this.transform.position;
        DisablePar.Play();
        SEASource2.clip = DisableClip;
        SEASource2.Play();
        Invoke("ResetPos", 0.01f);
    }
    public void ShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.2f, .4f);
    }
    public void ThunderFlag1()
    {
        Flag = "Thunder1";
    }
    public void ThunderFlag2()
    {
        Flag = "Thunder2";
    }
    public void ThunderFlag3()
    {
        Flag = "Thunder3";
    }
    public void ThunderFlag4()
    {
        Flag = "Thunder4";
    }
    public void BombAnimMethod()
    {
        Flag = "Bomb";
        DisableParObj.transform.position = new Vector3(6.75f, -2.83f, 0);
        DisablePar.Play();
        SEASource2.clip = DisableClip;
        SEASource2.Play();
        //Invoke("DisableParMethod", 0.01f);
        BombPObj.transform.position = new Vector3(6.75f, -2.83f, 0);
        BombPObj.SetActive(true);
        this.transform.position = new Vector3(6.75f, -2.83f, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        VMAnim.Play("BombLandPoseAni", 0, 0.0f);
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void BombMethod()
    {
        Flag = "Bomb3";
        BombObj.transform.position = new Vector3(6f, -3f, 0);
        BombObj.SetActive(true);
        VMAnim.SetBool("Shot2Bool", false);
        AnimCount = 0;
        ShakeMethod();
    }
    public void CoinGenerateUp()
    {
        if (Flag == "Magnet")
        {
            GameObject obj56 = ObjectPooler56.current.GetPooledObject();
            if (obj56 == null) return;
            obj56.SetActive(true);
            obj56.transform.position = new Vector3(9f, 7f, 0);
        }            
    }
    public void CoinGenerateCentor()
    {
        if (Flag == "Magnet")
        {
            GameObject obj56 = ObjectPooler56.current.GetPooledObject();
            if (obj56 == null) return;
            obj56.SetActive(true);
            obj56.transform.position = new Vector3(12f, 0, 0);
        }            
    }
    public void CoinGenerateDown()
    {
        if (Flag == "Magnet")
        {
            GameObject obj56 = ObjectPooler56.current.GetPooledObject();
            if (obj56 == null) return;
            obj56.SetActive(true);
            obj56.transform.position = new Vector3(9f, -7f, 0);
        }            
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
            VMAnim.enabled = false;
            rb.velocity = Vector3.zero;
        }
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.3f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(2.0f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
            VMAnim.enabled = true;
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
    public void PanelMethod()
    {        
        ScorePanelObj.SetActive(true);
        PanelAnim.SetBool("GetExpBool", true);
        PanelAnim.SetBool("ContinueBool", false);
        PanelAnim.SetBool("GetExpEndBool", false);
        PanelAnim.SetBool("GetExpEpiBool", false);
        ScoreManagerS.ResultMethod();
        ConBS.EpiFlagMethod();
        NextButtonS.MonaFlag();
        CompleteUIObj.SetActive(true);
        StartPar.Play();
    }
    public void HammerSE()
    {
        SEASource.clip = HammerClip;
        SEASource.Play();
    }
    public void BulletSE()
    {
        SEASource.clip = BulletClip;
        SEASource.Play();
    }
}
