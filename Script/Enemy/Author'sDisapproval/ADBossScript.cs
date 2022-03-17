using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADBossScript : MonoBehaviour
{
    public Animator ADAnim, HPAni, NameAni;
    public string Flag, FlagHP, LockFlag;
    public SpriteRenderer HP1Sprite;
    public AudioClip HPSound, DisableClip;
    public AudioSource HPASLoop, SEASource;
    //public Camera cam;
    //public Tilemap tilemap1, tilemap2;
    //public Collider2D LanceCol;
    public int HPCount, NumberStopper = 0, AttackNumber, AniLoopCount;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HPB1, HPB2, HPB3, HPB4, DParObj, BarriarObj, NameObj;
    //public PlayableDirector FOPTL;
    //public byte ColorR;
    //public Rigidbody2D FOPrb;
    public float StartPos_X, StartPos_Y, MoveY, EndPosY;
    public ParticleSystem DisablePar;
    public LockBlockGenerate LockGeneScript, LockGeneScriptUp;
    public Player PScript;
    public SEScript SESc;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void DisapprovalEnable()
    {
        BarriarObj.SetActive(true);
        HPObj.SetActive(true);
        HPCount = 4;
        //ColorFlag = "FeedChange";
        Flag = "Start";
        FlagHP = "Null";
        this.transform.position = new Vector3(StartPos_X, StartPos_Y, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.localScale = new Vector3(-1, 1, 1);
        HPAni.SetBool("PargeBool", false);
        ADAnim.SetBool("WallActReadyBool", false);
        ADAnim.SetBool("WallAct1Bool", false);
        ADAnim.SetBool("WallAct2Bool", false);
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
                    Flag = "NumberChoice";
                    FlagHP = "Null";
                    //NumberStopper = 0;
                    HPASLoop.Stop();
                    ADAnim.SetBool("WallActReadyBool", true);
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
                    AniLoopCount = 0;
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
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
        BarriarObj.SetActive(false);
        ScreenShakeController.instance.StartShake(.2f, .4f);
    }
    public void AniRandomMethod()
    {
        if (HPCount == 4)
        {
            AttackNumber = Random.Range(1, 14);
        }
        if (HPCount == 3)
        {
            AttackNumber = Random.Range(1, 10);
        }
        if (HPCount == 2)
        {
            AttackNumber = Random.Range(1, 15);
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
                ADAnim.SetBool("WallAct1Bool", false);
                ADAnim.SetBool("WallAct2Bool", true);
                Flag = "BlockRight";
            }
            if (AttackNumber == 3 || AttackNumber == 8)
            {
                ADAnim.SetBool("WallAct1Bool", true);
                ADAnim.SetBool("WallAct2Bool", false);
            }
            if (AttackNumber == 15 || AttackNumber == 20)
            {
                ADAnim.SetBool("WallAct1Bool", false);
                ADAnim.SetBool("WallAct2Bool", true);
                Flag = "BlockUp";
            }
        }
    }
    public void FlagResetMethod()
    {
        Flag = "NumberChoice";
        ADAnim.SetBool("WallAct1Bool", false);
        ADAnim.SetBool("WallAct2Bool", false);
    }

    public void AttackMethod()
    {
        if(Flag == "BlockRight")
        {
            //Debug.Log("side");
            LockGeneScript.GenerateMethod();
        }
        if (Flag == "BlockUp")
        {
            //Debug.Log("Up");
            LockGeneScriptUp.GenerateMethod();
        }
    }
    public void LockMethod()
    {
        if (PScript != null)
        {
            LockFlag = PScript.flagLock;
            if (LockFlag == "On")
            {
                PScript.LockMethodOff();
                SESc.SoundMethod9();
            }
            if (LockFlag == "Off")
            {
                PScript.LockMethodOn();
                SESc.SoundMethod9();
            }
            /*
            DAni.SetLayerWeight(1, 1f);
            Invoke("ApLayerResetMethod", 0.5f);
            */
        }
    }
    public void ScreenShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.1f, .2f);
    }
}
