using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KingSkyScript : MonoBehaviour
{
    public Animator HPAni, KAni, NameAni;
    public string Flag, FlagHP, ColorFlag;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop, BGSprite1, BGSprite2;
    public AudioClip HPSound, LaserClip, DisableClip;
    public AudioSource HPASLoop, SEASource;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    public Collider2D CoffinDamageCol;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount, CoffinHPCount, CoffinDisableCount = 2;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HP7, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7,
        CoffinObj, CoffinRidePos, MoveParObj, CrossPos1, CrossPos2, CrossPos3, CrossPos4, CrossPos5,
        KPortal1, KPortal2, KPortal3, KPortal4, KPortal5, KPortal6, KPortalPos1, KPortalPos2, KPortalPos3, KPortalPos4, KPortalPos5, KPortalPos6, KPortalPos7, KPortalPos8, PSamonPos,
        ChaserPortalPos, KingCoffinLeftObj, KingCoffinRightObj, KCPosLeft, KCPosRight, LaserColObj, LukeCoffinObj, 
        ASCoffinObj, ASCPos, CRCoffinObj, CoinCoffinObj, NameObj;
    //public PlayableDirector FOPTL;
    public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveY, EndPosY, CoffinFallX, CoffinFallY, FallEndPosY, CoffinScrollX, CoffinScrollEndY, CoffinFallEndPosY;
    public ParticleSystem DisablePar, MovePar, LaserPar, StageParLeft, StageParRight;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void KingEnabledOnSky()
    {
        HPObj.SetActive(true);
        HPCount = 7;
        CoffinHPCount = 0;
        ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        KAni.SetBool("CoffinOpenBool", false);
        //FOPTL.Stop();
        //CoffinObj.SetActive(false);
        LaserColObj.SetActive(false);
        LukeCoffinObj.SetActive(false);
        ASCoffinObj.SetActive(false);
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
    }
    public void HPResetMethod()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Flag == "Start")
        {
            this.transform.Translate(0, MoveY, 0);
        }
        if (this.transform.localPosition.y <= EndPosY)
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
        }
        if (FlagHP == "HPSet")
        {
            if (HP1.activeSelf)
            {
                HP1Sprite.size += new Vector2(0.1f, 0.0f);
                HPASLoop.Play();
                if (HP1Sprite.size.x >= 15)
                {
                    FlagHP = "Null";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    if (HPCount == 7)
                    {
                        HPCount--;
                        Flag = "NumberChoice";

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
                    if (HPCount == 6 || HPCount == 5 || HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        //Flag = "NumberChoice";
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
                    //QFParObj2.transform.position = this.transform.position;
                    //QFeatherPar2.Play();
                    //QAnim.Play("IdleFlyLoopAni", 0, 0.0f);
                    FlagHP = "HPSet";
                    HPCount--;
                    Invoke("TeleportMethod", 0.01f);
                }
            }
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
                    Invoke("TeleportMethod", 0.01f);
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
                    Invoke("TeleportMethod", 0.01f);
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
                    Invoke("TeleportMethod", 0.01f);
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
                    Invoke("TeleportMethod", 0.01f);
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
                    //Invoke("TeleportMethod", 0.01f);
                }
            }
            if (HPCount == 0)
            {
                if (Flag != "End")
                {
                    MoveParObj.transform.position = this.transform.position;
                    MovePar.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    //HPAni.SetBool("PargeBool", true);
                    KAni.Play("KingDeathLoopAni", 0, 0.0f);
                    //Invoke("DisableMethod", 0.01f);
                    LukeCoffinObj.SetActive(false);
                    LaserColObj.SetActive(false);
                }
            }
        }

        if (Flag == "CoffinFall")
        {
            this.transform.Translate(CoffinFallX, CoffinFallY, 0);
            if (this.transform.localPosition.y <= FallEndPosY)
            {
                Flag = "CoffinScroll";
                ScreenShakeController.instance.StartShake(.2f, .25f);
                CoffinDamageCol.enabled = false;
                KAni.SetBool("CoffinOpenBool", true);
            }
        }
        if (Flag == "CoffinScroll")
        {
            this.transform.Translate(CoffinScrollX, 0, 0);
            if (this.transform.localPosition.y <= CoffinScrollEndY)
            {
                TeleportMethod();
            }
        }

        if(Flag == "LaserReady")
        {
            this.transform.Translate(0, CoffinFallY, 0);
            if (this.transform.localPosition.y <= CoffinFallEndPosY)
            {
                Flag = "Laser";
            }
        }
        if(Flag == "LaserEndFall")
        {
            this.transform.Translate(0, CoffinFallY, 0);
            if (this.transform.localPosition.y <= CoffinScrollEndY)
            {
                TeleportMethod();
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
    public void DamageMethod()
    {
        if (FlagHP != "HPSet")
        {
            if (HP1Sprite.size.x >= 1.28)
            {
                HP1Sprite.size -= new Vector2(0.2f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        /*
        if (CoffinObj.activeSelf)
        {
            CoffinHPCount--;
            if (CoffinHPCount == CoffinDisableCount)
            {
                CoinMethodCentor();
                CoinMethodLeft();
                CoinMethodRight();
                TeleportMethod();
            }
        }
        */
    }
    public void DamageMethodSP()
    {
        if (FlagHP != "HPSet")
        {
            if (HP1Sprite.size.x >= 1.28)
            {
                HP1Sprite.size -= new Vector2(3.0f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }
        /*
        if (CoffinObj.activeSelf)
        {
            CoffinHPCount -= 2;
            if (CoffinHPCount == CoffinDisableCount)
            {
                CoinMethodCentor();
                CoinMethodLeft();
                CoinMethodRight();
                TeleportMethod();
            }
        }
        */
    }
    public void PositionReset()
    {
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        Flag = "NumberChoice";
        //CoffinObj.SetActive(false);
        KAni.Play("KingIdleSkyAni", 0, 0.0f);
        //Debug.Log("tes2");
    }
    public void TeleportMethod()
    {
        //Debug.Log("tes1");
        //DParObj.transform.position = this.transform.position;
        //DisablePar.Play();
        GameObject obj = ObjectPooler50.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

        Invoke("PositionReset", 0.01f);
        LukeCoffinObj.SetActive(false);
        LaserColObj.SetActive(false);
    }
    public void AniRandomMethod()
    {
        if (HPCount == 6)
        {
            AttackNumber = Random.Range(1, 5);
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
            AttackNumber = Random.Range(1, 13);
        }
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(1, 13);
        }
    }
    public void AniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 5 || AttackNumber == 6)
            {
                if (CRCoffinObj.activeSelf == false)
                {
                    AniLoopCount = 0;
                    Flag = "LanceSamonStart";
                    MoveParObj.transform.position = this.transform.position;
                    MovePar.Play();
                    Invoke("LanceSamonStartMethod", 0.01f);
                    KAni.SetBool("CoffinOpenBool", false);
                }                    
            }
            if (AttackNumber == 4 || AttackNumber == 7)
            {
                AniLoopCount = 0;
                Flag = "LaserStart";
                MoveParObj.transform.position = this.transform.position;
                MovePar.Play();
                Invoke("LaserStart", 0.01f);
                KAni.SetBool("CoffinOpenBool", false);
                LukeCoffinObj.SetActive(false);
                LaserColObj.SetActive(false);
            }
            /*
            if (AttackNumber == 3 || AttackNumber == 8)
            {
                if(ASCoffinObj.activeSelf == false)
                {
                    ASCoffinObj.transform.position = ASCPos.transform.position; //回避が難しすぎるので却下。
                    ASCoffinObj.SetActive(true);
                }                
            }
            */
            if (AttackNumber == 2 || AttackNumber == 9)
            {
                if (CRCoffinObj.activeSelf == false)
                {
                    CRCoffinObj.transform.position = KPortalPos1.transform.position;
                    CRCoffinObj.SetActive(true);
                }
            }
            if (AttackNumber == 1 || AttackNumber == 10)
            {
                if (CoinCoffinObj.activeSelf == false)
                {
                    CoinCoffinObj.transform.position = KPortalPos1.transform.position;
                    CoinCoffinObj.SetActive(true);
                }
            }
        }
    }
    public void CoffinRideStart()
    {
        Flag = "CoffinFall";
        this.transform.position = CoffinRidePos.transform.position;
        KAni.Play("KingCoffinRideAni", 0, 0.0f);
        //CoffinObj.SetActive(true);
        CoffinDamageCol.enabled = true;
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
    public void CoinMethodLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void ShotGunMethod1()
    {
        GameObject obj = ObjectPooler47.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CrossPos1.transform.position;
        obj.transform.rotation = CrossPos1.transform.rotation;
        obj.SetActive(true);
    }
    public void ShotGunMethod2()
    {
        GameObject obj = ObjectPooler47.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CrossPos2.transform.position;
        obj.transform.rotation = CrossPos2.transform.rotation;
        obj.SetActive(true);
    }
    public void ShotGunMethod3()
    {
        GameObject obj = ObjectPooler47.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CrossPos3.transform.position;
        obj.transform.rotation = CrossPos3.transform.rotation;
        obj.SetActive(true);
    }
    public void ShotGunMethod4()
    {
        GameObject obj = ObjectPooler47.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CrossPos4.transform.position;
        obj.transform.rotation = CrossPos4.transform.rotation;
        obj.SetActive(true);
    }
    public void ShotGunMethod5()
    {
        GameObject obj = ObjectPooler47.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CrossPos5.transform.position;
        obj.transform.rotation = CrossPos5.transform.rotation;
        obj.SetActive(true);
    }
    public void ShotGunEvent()
    {
        ShotGunMethod1();
        ShotGunMethod2();
        ShotGunMethod3();
        ShotGunMethod4();
        ShotGunMethod5();
    }

    public void KPortalStart()
    {
        Flag = "KPortalSamon";
        this.transform.position = PSamonPos.transform.position;
        KAni.Play("KingSamonLanceLoopAni", 0, 0.0f);
        //DParObj.transform.position = this.transform.position;
        //DisablePar.Play();
        GameObject obj = ObjectPooler50.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void KPortalMethod()
    {
        AniLoopCount++;
        if (AniLoopCount == 1)
        {
            KPortal1.transform.position = KPortalPos1.transform.position;
            KPortal1.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal1.SetActive(true);
        }
        if (AniLoopCount == 2)
        {
            KPortal2.transform.position = KPortalPos2.transform.position;
            KPortal2.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal2.SetActive(true);
        }
        if (AniLoopCount == 3)
        {
            KPortal3.transform.position = KPortalPos3.transform.position;
            KPortal3.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal3.SetActive(true);
        }
        if (AniLoopCount == 4)
        {
            KPortal4.transform.position = KPortalPos4.transform.position;
            KPortal4.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal4.SetActive(true);
        }
        if (AniLoopCount == 5)
        {
            KPortal5.transform.position = KPortalPos5.transform.position;
            KPortal5.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal5.SetActive(true);
        }
        if (AniLoopCount == 6)
        {
            KPortal6.transform.position = KPortalPos6.transform.position;
            KPortal6.transform.rotation = Quaternion.Euler(0, 0, 45);
            KPortal6.SetActive(true);
        }
        if (AniLoopCount >= 10)
        {
            TeleportMethod();
        }
    }

    public void ChaserPortalStart()
    {
        Flag = "ChaserPortalSamon";
        this.transform.position = new Vector3(StartPos_X, EndPosY, 0);
        KAni.Play("KingSamonReadyAni", 0, 0.0f);
        //DParObj.transform.position = this.transform.position;
        //DisablePar.Play();
        GameObject obj = ObjectPooler50.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void ChaserPortalMethod()
    {
        AniLoopCount++;
        if (AniLoopCount == 1)
        {
            KPortal1.transform.position = ChaserPortalPos.transform.position;
            KPortal1.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal1.SetActive(true);
        }
        if (AniLoopCount == 2)
        {
            KPortal2.transform.position = ChaserPortalPos.transform.position;
            KPortal2.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal2.SetActive(true);
        }
        if (AniLoopCount == 3)
        {
            KPortal3.transform.position = ChaserPortalPos.transform.position;
            KPortal3.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal3.SetActive(true);
        }
        if (AniLoopCount == 4)
        {
            KPortal4.transform.position = ChaserPortalPos.transform.position;
            KPortal4.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal4.SetActive(true);
        }
        if (AniLoopCount == 5)
        {
            KPortal5.transform.position = ChaserPortalPos.transform.position;
            KPortal5.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal5.SetActive(true);
        }
        if (AniLoopCount == 6)
        {
            KPortal6.transform.position = ChaserPortalPos.transform.position;
            KPortal6.transform.rotation = Quaternion.Euler(0, 0, 0);
            KPortal6.SetActive(true);
        }
        if (AniLoopCount >= 10)
        {
            TeleportMethod();
        }
    }

    public void LukeCoffinStart()
    {
        Flag = "LCoffin";
        this.transform.position = new Vector3(StartPos_X, EndPosY, 0);
        KAni.Play("CoffinSamonReadyAni", 0, 0.0f);
        //DParObj.transform.position = this.transform.position;
        //DisablePar.Play();
        GameObject obj = ObjectPooler50.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void LukeCoffinMethodLeft()
    {
        KingCoffinLeftObj.transform.position = KCPosLeft.transform.position;
        KingCoffinLeftObj.SetActive(true);
    }
    public void LukeCoffinMethodRight()
    {
        KingCoffinRightObj.transform.position = KCPosRight.transform.position;
        KingCoffinRightObj.SetActive(true);
    }
    public void LukeCoffinLoopMethod()
    {
        AniLoopCount++;
        if (AniLoopCount >= 40)
        {
            TeleportMethod();
        }
    }

    public void LanceSamonMethod1()
    {
        KPortal1.transform.position = KPortalPos1.transform.position;
        KPortal1.transform.rotation = KPortalPos1.transform.rotation;
        KPortal1.SetActive(true);
        KPortal2.transform.position = KPortalPos5.transform.position;
        KPortal2.transform.rotation = KPortalPos5.transform.rotation;
        KPortal2.SetActive(true);
    }
    public void LanceSamonMethod2()
    {
        KPortal3.transform.position = KPortalPos2.transform.position;
        KPortal3.transform.rotation = KPortalPos2.transform.rotation;
        KPortal3.SetActive(true);
        KPortal4.transform.position = KPortalPos6.transform.position;
        KPortal4.transform.rotation = KPortalPos6.transform.rotation;
        KPortal4.SetActive(true);
    }
    public void LanceSamonMethod3()
    {
        KPortal5.transform.position = KPortalPos3.transform.position;
        KPortal5.transform.rotation = KPortalPos3.transform.rotation;
        KPortal5.SetActive(true);
        KPortal6.transform.position = KPortalPos7.transform.position;
        KPortal6.transform.rotation = KPortalPos7.transform.rotation;
        KPortal6.SetActive(true);
    }
    public void LanceSamonMethod4()
    {
        KPortal1.transform.position = KPortalPos4.transform.position;
        KPortal1.transform.rotation = KPortalPos4.transform.rotation;
        KPortal1.SetActive(true);
        KPortal2.transform.position = KPortalPos8.transform.position;
        KPortal2.transform.rotation = KPortalPos8.transform.rotation;
        KPortal2.SetActive(true);
    }
    public void LanceSamonStartMethod()
    {
        Flag = "LanceSamon";
        KAni.Play("KingSamonLanceSkyLoopAni", 0, 0.0f);
        this.transform.position = new Vector3(StartPos_X, EndPosY, 0);
    }

    public void SamonAniMethod()
    {
        if(Flag == "LanceSamon")
        {
            AniLoopCount++;
            if(AniLoopCount == 2)
            {
                LanceSamonMethod1();
            }
            if (AniLoopCount == 4)
            {
                LanceSamonMethod2();
            }
            if (AniLoopCount == 6)
            {
                LanceSamonMethod3();
            }
            if (AniLoopCount == 8)
            {
                LanceSamonMethod4();
                TeleportMethod();
            }
        }
    }

    public void LaserStart()
    {
        Flag = "LaserReady";
        KAni.Play("LukeCoffinRideReadySkyAni", 0, 0.0f);
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        LukeCoffinObj.SetActive(true);
    }
    public void LaserMethod()
    {
        LaserPar.Play();
        LaserColObj.SetActive(true);
        SEASource.clip = LaserClip;
        SEASource.Play();
    }
    public void LaserEndMethod()
    {
        Flag = "LaserEndFall";
    }

    public void DisableEvent()
    {
        if (AniLoopCount == 1)
        {
            ScreenShakeController.instance.StartShake(.4f, .5f);
            this.transform.Translate(0, 0.1f, 0);
        }
        if (AniLoopCount != 10)
        {
            AniLoopCount++;
            this.transform.Translate(0, -0.02f, 0);
        }
        if (AniLoopCount >= 10)
        {
            //DParObj.transform.position = this.transform.position;
            //DisablePar.Play();
            GameObject obj = ObjectPooler50.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            SEASource.clip = DisableClip;
            SEASource.Play();
            Invoke("DisableMethod", 0.01f);
            sm.AddScore(scoreValue);
        }
    }
    public void DisableMethod()
    {
        NameAni.SetBool("NameEndBool", true);
        HPAni.SetBool("PargeBool", true);
        this.gameObject.SetActive(false);
        ScreenShakeController.instance.StartShake(.5f, .6f);
        cam.backgroundColor = new Color32(0, 0, 0, 0);
        tilemap1.color = new Color32(0, 70, 80, 255);
        tilemap2.color = new Color32(26, 195, 252, 255);
        BackLightBottom.color = new Color32(26, 195, 252, 255);
        BackLightTop.color = new Color32(10, 0, 160, 255);
        BGSprite1.color = new Color32(255, 180, 250, 255);
        BGSprite2.color = new Color32(255, 180, 250, 255);
        StageParLeft.startColor = new Color32(102, 139, 255, 255);
        StageParRight.startColor = new Color32(102, 139, 255, 255);
    }
}
