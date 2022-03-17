using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BishopScript : MonoBehaviour
{
    public Animator HPAni, BAnim, NameAni;
    public string Flag, FlagHP, ColorFlag, FlagRight, FlagLeft;
    public SpriteRenderer HP1Sprite, BackLightBottom, BackLightTop;
    public AudioClip HPSound, DisableClip;
    public AudioSource HPASLoop, SEASource;
    public Camera cam;
    public Tilemap tilemap1, tilemap2;
    //public Collider2D LanceCol;
    public int HPCount, AttackNumber, AttackNumberB, AniLoopCountRight, AniLoopCountLeft;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, DParObj, 
        CoffinSGRight, CoffinSGLeft, CoffinCRRight, CoffinCRLeft, CoffinASRight, CoffinASLeft, CoffinPRight, CoffinPLeft, CoffinBHRight, CoffinBHLeft, 
        CoffinPosRight, CoffinPosLeft, NameObj;
    //public PlayableDirector FOPTL;
    public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveY, EndPosY;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;

    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void BishopEnable()
    {
        HPObj.SetActive(true);
        HPCount = 6;
        ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        FlagRight = "Null";
        FlagLeft = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        BAnim.SetBool("MagicReadyBool", false);
        BAnim.SetBool("IdleReady", true);
        //FOPTL.Stop();
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
                        BAnim.SetBool("MagicReadyBool", true);
                        BAnim.SetBool("IdleReady", false);
                        FlagLeft = "NumberChoice";
                        FlagRight = "NumberChoice";
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
                    GameObject obj = ObjectPooler50.current.GetPooledObject();
                    if (obj == null) return;
                    obj.transform.position = this.transform.position;
                    obj.SetActive(true);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    Flag = "End";
                    HP1.SetActive(false);
                    HPB1.SetActive(true);
                    //QAnim.Play("DeathAni", 0, 0.0f);
                    AniLoopCountRight = 0;
                    AniLoopCountLeft = 0;
                    HPAni.SetBool("PargeBool", true);
                    NameAni.SetBool("NameEndBool", true);
                    Invoke("DisableMethod", 0.01f);
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
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }

    public void AniRandomMethod()
    {
        if (HPCount == 6)
        {
            AttackNumber = Random.Range(1, 11);
            AttackNumberB = Random.Range(1, 11);
        }
        if (HPCount == 5)
        {
            AttackNumber = Random.Range(1, 12);
            AttackNumberB = Random.Range(1, 12);
        }
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(5, 13);
            AttackNumberB = Random.Range(5, 13);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 12);
            AttackNumberB = Random.Range(1, 12);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(5, 17);
            AttackNumberB = Random.Range(5, 17);
        }
        if (HPCount == 1 || HPCount == 0)
        {
            AttackNumber = Random.Range(1, 17);
            AttackNumberB = Random.Range(1, 17);
        }
    }
    public void AniEventMethod()
    {
        if (FlagRight == "NumberChoice")
        {
            if (AttackNumber == 1 || AttackNumber == 2 || AttackNumber == 5 || AttackNumber == 6)
            {
                FlagRight = "ShotGun";
                //BAnim.SetBool("MagicReadyBool", true);
                //BAnim.SetBool("IdleReady", false);
                //Flag = "Magic";
                AniLoopCountRight = 0;
            }
            if (AttackNumber == 3 || AttackNumber == 4 || AttackNumber == 7 || AttackNumber == 8)
            {
                FlagRight = "CrossRain";
                //BAnim.SetBool("MagicReadyBool", true);
                //BAnim.SetBool("IdleReady", false);
                Flag = "Magic";
                AniLoopCountRight = 0;
            }
            if (AttackNumber == 9 || AttackNumber == 10 || AttackNumber == 14 || AttackNumber == 15)
            {
                FlagRight = "ArmSpin";
                Flag = "Magic";
                AniLoopCountRight = 0;
            }
            if (AttackNumber == 11 || AttackNumber == 12 || AttackNumber == 13)
            {
                FlagRight = "BoonHummer";
                Flag = "Magic";
                AniLoopCountRight = 0;
            }
            if (AttackNumber == 14 || AttackNumber == 15 || AttackNumber == 16)
            {
                FlagRight = "Punch";
                Flag = "Magic";
                AniLoopCountRight = 0;
            }
        }
    }
    public void AniEventMethodB()
    {
        if (FlagLeft == "NumberChoice")
        {
            if (AttackNumberB == 1 || AttackNumberB == 2 || AttackNumberB == 5 || AttackNumberB == 6)
            {
                FlagLeft = "ShotGun";
                //BAnim.SetBool("MagicReadyBool", true);
                //BAnim.SetBool("IdleReady", false);
                //Flag = "Magic";
                AniLoopCountLeft = 0;
            }
            if (AttackNumberB == 3 || AttackNumberB == 4 || AttackNumberB == 7 || AttackNumberB == 8)
            {
                FlagLeft = "CrossRain";
                //BAnim.SetBool("MagicReadyBool", true);
                //BAnim.SetBool("IdleReady", false);
                //Flag = "Magic";
                AniLoopCountLeft = 0;
            }
            if (AttackNumberB == 9 || AttackNumberB == 10 || AttackNumberB == 14 || AttackNumberB == 15)
            {
                FlagLeft = "ArmSpin";
                //Flag = "Magic";
                AniLoopCountLeft = 0;
            }
            if (AttackNumberB == 11 || AttackNumberB == 12 || AttackNumberB == 13)
            {
                FlagLeft = "BoonHummer";
                //Flag = "Magic";
                AniLoopCountLeft = 0;
            }
            if (AttackNumberB == 14 || AttackNumberB == 15 || AttackNumberB == 16)
            {
                FlagLeft = "Punch";
                //Flag = "Magic";
                AniLoopCountLeft = 0;
            }
        }
    }

    public void BishopEventRight()
    {
        AniLoopCountRight++;
        
        if(FlagRight == "ShotGun")
        {
            if(AniLoopCountRight <= 1)
            {
                if (CoffinSGRight.activeSelf == false)
                {
                    CoffinSGRight.transform.rotation = CoffinPosRight.transform.rotation;
                    CoffinSGRight.transform.position = CoffinPosRight.transform.position;
                    CoffinSGRight.SetActive(true);
                }
            }            
            if(AniLoopCountRight == 30)
            {
                AniEventMethod();
                FlagRight = "NumberChoice";
            }
        }
        if (FlagRight == "CrossRain")
        {
            if (AniLoopCountRight <= 1)
            {
                if (CoffinCRRight.activeSelf == false)
                {
                    CoffinCRRight.transform.rotation = CoffinPosRight.transform.rotation;
                    CoffinCRRight.transform.position = CoffinPosRight.transform.position;
                    CoffinCRRight.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagRight = "NumberChoice";
            }
        }
        if (FlagRight == "ArmSpin")
        {
            if (AniLoopCountRight <= 1)
            {
                if (CoffinASRight.activeSelf == false)
                {
                    CoffinASRight.transform.rotation = CoffinPosRight.transform.rotation;
                    CoffinASRight.transform.position = CoffinPosRight.transform.position;
                    CoffinASRight.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagRight = "NumberChoice";
            }
        }
        if (FlagRight == "BoonHummer")
        {
            if (AniLoopCountRight <= 1)
            {
                if (CoffinBHRight.activeSelf == false)
                {
                    CoffinBHRight.transform.rotation = CoffinPosRight.transform.rotation;
                    CoffinBHRight.transform.position = CoffinPosRight.transform.position;
                    CoffinBHRight.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 50)
            {
                AniEventMethod();
                FlagRight = "NumberChoice";
            }
        }
        if (FlagRight == "Punch")
        {
            if (AniLoopCountRight <= 1)
            {
                if (CoffinPRight.activeSelf == false)
                {
                    CoffinPRight.transform.rotation = CoffinPosRight.transform.rotation;
                    CoffinPRight.transform.position = CoffinPosRight.transform.position;
                    CoffinPRight.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagRight = "NumberChoice";
            }
        }
    }
    public void BishopEventLeft()
    {
        AniLoopCountLeft++;
        if (FlagLeft == "ShotGun")
        {
            if (AniLoopCountLeft <= 1)
            {
                if (CoffinSGLeft.activeSelf == false)
                {
                    CoffinSGLeft.transform.rotation = CoffinPosLeft.transform.rotation;
                    CoffinSGLeft.transform.position = CoffinPosLeft.transform.position;
                    CoffinSGLeft.SetActive(true);
                }
            }                
            if(AniLoopCountLeft == 30)
            {
                AniEventMethodB();
                FlagLeft = "NumberChoice";
            }
        }
        if (FlagLeft == "CrossRain")
        {
            if (AniLoopCountLeft <= 1)
            {
                if (CoffinCRLeft.activeSelf == false)
                {
                    CoffinCRLeft.transform.rotation = CoffinPosLeft.transform.rotation;
                    CoffinCRLeft.transform.position = CoffinPosLeft.transform.position;
                    CoffinCRLeft.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagLeft = "NumberChoice";
            }
        }
        if (FlagLeft == "ArmSpin")
        {
            if (AniLoopCountLeft <= 1)
            {
                if (CoffinASLeft.activeSelf == false)
                {
                    CoffinASLeft.transform.rotation = CoffinPosLeft.transform.rotation;
                    CoffinASLeft.transform.position = CoffinPosLeft.transform.position;
                    CoffinASLeft.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagLeft = "NumberChoice";
            }
        }
        if (FlagLeft == "BoonHummer")
        {
            if (AniLoopCountLeft <= 1)
            {
                if (CoffinASLeft.activeSelf == false)
                {
                    CoffinASLeft.transform.rotation = CoffinPosLeft.transform.rotation;
                    CoffinASLeft.transform.position = CoffinPosLeft.transform.position;
                    CoffinASLeft.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 50)
            {
                AniEventMethod();
                FlagLeft = "NumberChoice";
            }
        }
        if (FlagLeft == "Punch")
        {
            if (AniLoopCountLeft <= 1)
            {
                if (CoffinPLeft.activeSelf == false)
                {
                    CoffinPLeft.transform.rotation = CoffinPosLeft.transform.rotation;
                    CoffinPLeft.transform.position = CoffinPosLeft.transform.position;
                    CoffinPLeft.SetActive(true);
                }
            }                
            if (AniLoopCountRight == 40)
            {
                AniEventMethod();
                FlagLeft = "NumberChoice";
            }
        }
    }
}
