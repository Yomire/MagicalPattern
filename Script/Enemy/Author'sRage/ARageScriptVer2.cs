using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARageScriptVer2 : MonoBehaviour
{
    public Animator ARAnim, BackAnim, HPAni, NameAni;
    public string Flag, FlagHP, ColorFlag;
    public SpriteRenderer HP1Sprite, NightSprite;
    public AudioClip HPSound, DrumClip, PurgeClip, DisableClip;
    public AudioSource HPASLoop, SEASource;
    //public Camera cam;
    //public Tilemap tilemap1, tilemap2;
    //public Collider2D LanceCol;
    public int HPCount, AttackNumber, AniLoopCount;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HPB1, HPB2, HPB3, HPB4, DParObj, ClowdPosObj, ClowdObj1, ClowdObj2, ClowdObj3, ClowdObj4, ClowdObj5, ClowdObj6, ClowdObj7, ClowdObj8, 
        DrumThunderObj1, DrumThunderObj2, DrumThunderObj3, DrumThunderObj4, DrumThunderObj5, DrumThunderObj6, DrumThunderObj7, DrumThunderObj8, 
        FinalAttackObj, ThunderFallenDangerA, ThunderFallenDangerB, ThunderFallenDangerC, ThunderFallenDangerD, ThunderFallenDangerE, ThunderFallenDangerF, ThunderFallenDangerG, ThunderFallenDangerH, ThunderFallenDangerI, 
        NameObj;
    //public PlayableDirector FOPTL;
    //public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveY, EndPosY;
    public ParticleSystem DisablePar, ThunderPar1, ThunderPar2, ThunderPar3, ThunderPar4, ThunderPar5, ThunderPar6, ThunderPar7, ThunderPar8, ThunderPar9;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    public byte ColorNightA;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    // Start is called before the first frame update
    public void ARageEnable()
    {
        //BarriarObj.SetActive(true);
        HPObj.SetActive(true);
        HPCount = 4;
        //ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        ColorFlag = "FeedChange";
        this.transform.position = new Vector3(0, 12, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        ARAnim.SetBool("FullDrumBool", false);
        ARAnim.SetBool("RFABool", false);
        ARAnim.SetBool("RFAEndBool", false);
        ARAnim.SetBool("Drums1Bool", false);
        ARAnim.SetBool("Drums2Bool", false);
        ARAnim.SetLayerWeight(1, 0f);
        BackAnim.SetBool("RageBackIdleBool", true);
        BackAnim.SetBool("RageBackPurgeBool", false);
        ClowdPosObj.SetActive(true);
        ColorNightA = 0;
        DrumThunderObj1.SetActive(false);
        DrumThunderObj2.SetActive(false);
        DrumThunderObj3.SetActive(false);
        DrumThunderObj4.SetActive(false);
        DrumThunderObj5.SetActive(false);
        DrumThunderObj6.SetActive(false);
        DrumThunderObj7.SetActive(false);
        DrumThunderObj8.SetActive(false);
        FinalAttackObj.SetActive(false);
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
    }
    public void HPResetMethod()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (ColorFlag == "FeedChange")
        {
            if (ColorNightA <= 180)
            {
                ColorNightA++;
                NightSprite.color = new Color32(0, 0, 0, ColorNightA);
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
                    ARAnim.SetLayerWeight(1, 1f);
                    Flag = "NumberChoice";
                    FlagHP = "Null";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    //ADAnim.SetBool("WallActReadyBool", true);
                    if (HPCount == 4)
                    {
                        HPCount--;
                    }
                    /*
                    if (HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                    {
                        Flag = "NumberChoice";
                    }
                    */
                }
            }
        }
        if (HP1Sprite.size.x <= 1.28)
        {
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
                    DParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCount = 0;
                    HPAni.SetBool("PargeBool", true);
                    NameAni.SetBool("NameEndBool", true);
                    Invoke("DisableMethod", 0.01f);
                    ScreenShakeController.instance.StartShake(.2f, .4f);
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
                    HP1Sprite.size -= new Vector2(1.0f, 0.0f);
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
                    HP1Sprite.size -= new Vector2(0.5f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                }
            }
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
        NightSprite.color = new Color32(0, 0, 0, 0);
        ClowdPosObj.SetActive(false);
    }
    public void AniRandomMethod()
    {
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(1, 14);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 18);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(1, 20);
        }
        if (HPCount == 1)
        {
            AttackNumber = Random.Range(1, 21);
        }
        if (HPCount == 0)
        {
            AttackNumber = Random.Range(1, 21);
        }
    }
    public void AniEventMethod()
    {
        if (Flag == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 2)
            {
                //ADAnim.SetBool("WallAct1Bool", false);
                //ADAnim.SetBool("WallAct2Bool", true);
                //Flag = "Thunder";
                ARAnim.SetBool("Drums1Bool", true);

            }
            if (AttackNumber == 3 || AttackNumber == 4)
            {
                ARAnim.SetBool("Drums2Bool", true);
            }
            if (AttackNumber == 5 || AttackNumber == 6)
            {
                ARAnim.SetBool("FullDrumBool", true);
            }
            if (AttackNumber == 19 || AttackNumber == 20)
            {
                ARAnim.SetBool("RFABool", true);
                ARAnim.SetBool("RFAEndBool", false);
                BackAnim.SetBool("RageBackIdleBool", false);
                BackAnim.SetBool("RageBackPurgeBool", true);
                FinalAttackObj.SetActive(true);
                SEASource.clip = PurgeClip;
                SEASource.Play();
            }
            if(AttackNumber == 7)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerA.transform.position;
                obj.transform.rotation = ThunderFallenDangerA.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 8)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerB.transform.position;
                obj.transform.rotation = ThunderFallenDangerB.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 9)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerC.transform.position;
                obj.transform.rotation = ThunderFallenDangerC.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 10)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerD.transform.position;
                obj.transform.rotation = ThunderFallenDangerD.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 11)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerE.transform.position;
                obj.transform.rotation = ThunderFallenDangerE.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 12)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerF.transform.position;
                obj.transform.rotation = ThunderFallenDangerF.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 13)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerG.transform.position;
                obj.transform.rotation = ThunderFallenDangerG.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 14)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerH.transform.position;
                obj.transform.rotation = ThunderFallenDangerH.transform.rotation;
                obj.SetActive(true);
            }
            if (AttackNumber == 15)
            {
                GameObject obj = ObjectPooler5.current.GetPooledObject();
                if (obj == null) return;

                obj.transform.position = ThunderFallenDangerI.transform.position;
                obj.transform.rotation = ThunderFallenDangerI.transform.rotation;
                obj.SetActive(true);
            }
        }
    }
    public void FlagResetMethod()
    {
        Flag = "NumberChoice";
        //ADAnim.SetBool("WallAct1Bool", false);
        //ADAnim.SetBool("WallAct2Bool", false);
    }

    public void ClowdEnable1()
    {
        ClowdObj1.SetActive(true);
        ClowdObj1.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable2()
    {
        ClowdObj2.SetActive(true);
        ClowdObj2.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable3()
    {
        ClowdObj3.SetActive(true);
        ClowdObj3.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable4()
    {
        ClowdObj4.SetActive(true);
        ClowdObj4.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable5()
    {
        ClowdObj5.SetActive(true);
        ClowdObj5.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable6()
    {
        ClowdObj6.SetActive(true);
        ClowdObj6.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable7()
    {
        ClowdObj7.SetActive(true);
        ClowdObj7.transform.position = ClowdPosObj.transform.position;
    }
    public void ClowdEnable8()
    {
        ClowdObj8.SetActive(true);
        ClowdObj8.transform.position = ClowdPosObj.transform.position;
    }
    public void StartHPSet()
    {
        FlagHP = "HPSet";
    }
    public void FeedEnd()
    {
        ColorFlag = "FeedEnd";
    }

    public void DrumMethod1()
    {
        DrumThunderObj1.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod2()
    {
        DrumThunderObj2.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod3()
    {
        DrumThunderObj3.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod4()
    {
        DrumThunderObj4.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod5()
    {
        DrumThunderObj5.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod6()
    {
        DrumThunderObj6.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod7()
    {
        DrumThunderObj7.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }
    public void DrumMethod8()
    {
        DrumThunderObj8.SetActive(true);
        SEASource.clip = DrumClip;
        SEASource.Play();
    }

    public void AniReset()
    {
        ARAnim.SetBool("RFABool", false);
        ARAnim.SetBool("RFAEndBool", true);
        BackAnim.SetBool("RageBackIdleBool", true);
        BackAnim.SetBool("RageBackPurgeBool", false);
    }

    public void ThunderMethod()
    {
        if(AttackNumber == 7)
        {
            ThunderPar1.Play();
        }
        if (AttackNumber == 8)
        {
            ThunderPar2.Play();
        }
        if (AttackNumber == 9)
        {
            ThunderPar3.Play();
        }
        if (AttackNumber == 10)
        {
            ThunderPar4.Play();
        }
        if (AttackNumber == 11)
        {
            ThunderPar5.Play();
        }
        if (AttackNumber == 12)
        {
            ThunderPar6.Play();
        }
        if (AttackNumber == 13)
        {
            ThunderPar7.Play();
        }
        if (AttackNumber == 14)
        {
            ThunderPar8.Play();
        }
        if (AttackNumber == 15)
        {
            ThunderPar9.Play();
        }
    }
}
