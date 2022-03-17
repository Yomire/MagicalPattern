using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PawnScript : MonoBehaviour
{
    public float StartPosX, StartPosY, MoveX, EndPosX, StabMoveX, StabEndPosX, KickMoveX, KickMoveY, ScrollMoveX;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, DParObj, NameObj,
        StabPosLeft, StabPosRight, DisableParObj, FOPObj, LukeKickPos, CrackObj, CrackPosObj, CoffinObj1, CoffinObj2;
    public SpriteRenderer HP1Sprite;
    public string Flag, FlagHP, PauseFlag, LanceFlag;
    public AudioSource HPASLoop, SEASource, SEASource2, SEASource3;
    public AudioClip DisableClip, StabClip, KickClip;
    public Animator HPAni, PawnAni, NameAni;
    public ParticleSystem DisablePar, StabPar, LKickPar;
    public int HPCount, scoreValue, AttackNumber, AnimCount;
    private ScoreManager sm;
    public PlayableDirector FOPTL;
    public Collider2D LKickCol1, LKickCol2;
    void Awake()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void PawnEnable()
    {
        HPCount = 6;
        this.transform.position = new Vector3(StartPosX, StartPosY, 0);
        HPObj.SetActive(true);
        HPAni.SetBool("PargeBool", false);
        NameObj.SetActive(true);
        NameAni.SetBool("NameEndBool", false);
        Flag = "Start";
        FlagHP = "Null";
        PauseFlag = "Off";
        LanceFlag = "Null";
        PawnAni.SetBool("RunPromotionBool", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseFlag == "Off")
        {
            if (Flag == "Start")
            {
                this.transform.Translate(MoveX, 0, 0);
            }
            if (this.transform.localPosition.x >= EndPosX)
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
                        HPASLoop.Stop();
                        if (HPCount == 6)
                        {
                            HPCount--;
                            Flag = "Null";
                            /*
                            cam.backgroundColor = new Color32(80, 0, 0, 255);
                            tilemap1.color = new Color32(140, 0, 70, 255);
                            tilemap2.color = new Color32(115, 0, 60, 255);
                            BackLightBottom.color = new Color32(255, 0, 128, 255);
                            BackLightTop.color = new Color32(160, 0, 70, 255);
                            BGSprite1.color = new Color32(115, 0, 60, 255);
                            BGSprite2.color = new Color32(115, 0, 60, 255);
                            */
                        }
                        /*
                        if (HPCount == 4 || HPCount == 3 || HPCount == 2 || HPCount == 1 || HPCount == 0)
                        {

                            AniLoopCount = 0;
                        }
                        */
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
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 0)
                {
                    if (Flag != "End")
                    {
                        ScreenShakeController.instance.StartShake(.5f, .5f);
                        DParObj.transform.position = this.transform.position;
                        DisablePar.Play();
                        SEASource3.clip = DisableClip;
                        SEASource3.Play();
                        Flag = "End";
                        HP1.SetActive(false);
                        HPB1.SetActive(true);
                        //AniLoopCount = 0;
                        HPAni.SetBool("PargeBool", true);
                        NameAni.SetBool("NameEndBool", true);
                        Invoke("DisableMethod", 0.01f);
                        sm.AddScore(scoreValue);
                    }
                }
            }
            if (Flag == "QueenStabLeft")
            {
                this.transform.Translate(StabMoveX, 0, 0);
                if (this.transform.localPosition.x <= -StabEndPosX || this.transform.localPosition.x >= StabEndPosX)
                {
                    DisableParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    SEASource3.clip = DisableClip;
                    SEASource3.Play();
                    //SEASource2.clip = DisableClip;
                    //SEASource2.Play();
                    Invoke("ResetPos", 0.1f);
                }
            }
            if (Flag == "LukeKick")
            {
                this.transform.Translate(KickMoveX, KickMoveY, 0);
                if (this.transform.localPosition.y <= StartPosY)
                {
                    Flag = "Scroll";
                    Vector3 CPos = CrackPosObj.transform.position;
                    CrackObj.transform.position = new Vector2(CPos.x, -3);
                    CrackObj.SetActive(true);
                    LKickPar.Stop();
                    LKickCol1.enabled = false;
                    LKickCol2.enabled = true;
                    ScreenShakeController.instance.StartShake(.2f, .4f);
                    SEASource.clip = KickClip;
                    SEASource.Play();
                }
            }
            if (Flag == "Scroll")
            {
                this.transform.Translate(ScrollMoveX, 0, 0);
                if (this.transform.localPosition.x <= -StabEndPosX || this.transform.localPosition.x >= StabEndPosX)
                {
                    DisableParObj.transform.position = this.transform.position;
                    DisablePar.Play();
                    SEASource3.clip = DisableClip;
                    SEASource3.Play();
                    //SEASource2.clip = DisableClip;
                    //SEASource2.Play();
                    Invoke("ResetPos", 0.1f);
                }
            }
            if(LanceFlag == "FOPMoveX")
            {
                FOPObj.transform.Translate(ScrollMoveX, 0, 0);
                if (FOPObj.transform.localPosition.x <= 0)
                {
                    LanceFlag = "Null";
                }
            }
        }            
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
    public void ResetPos()
    {
        Flag = "Null";
        this.transform.position = new Vector3(10, 10, 0);
        AttackNumber = 0;
        AnimCount = 0;
        StabPar.Stop();
        PawnAni.SetBool("Shot2Bool", false);
        //rb.velocity = Vector3.zero;
        DisableParObj.transform.localScale = new Vector3(1, 1, 1);
        LKickCol1.enabled = false;
        LKickCol2.enabled = false;
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
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 4)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 3)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 2)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 1)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                }
                if(Flag == "Bishop")
                {
                    AnimCount++;
                    if(AnimCount >= 2)
                    {
                        Flag = "Bishop2";
                        CoffinObj1.SetActive(true);
                        AnimCount = 0;
                    }
                }
                if (Flag == "Bishop2")
                {
                    AnimCount++;
                    if (AnimCount >= 2)
                    {
                        CoffinObj2.SetActive(true);
                        Flag = "Bishop3";
                        AnimCount = 0;
                    }
                }
                if(Flag == "Bishop3")
                {
                    AnimCount++;
                    if(AnimCount >= 5)
                    {
                        AnimEndMethod();
                    }
                }
            }
        }
    }
    public void AttackMethod()
    {
        if (AttackNumber == 1 || AttackNumber == 14)
        {
            if (LanceFlag == "Null")
            {
                Flag = "QueenStabLeft";
                transform.localScale = new Vector3(1, 1, 1);
                PawnAni.Play("PawnRunAni", 0, 0.0f);
                PawnAni.SetBool("RunPromotionBool", true);
                Vector3 SPL = StabPosLeft.transform.position;
                this.transform.position = new Vector2(SPL.x, StartPosY);
                DisableParObj.transform.position = new Vector2(SPL.x, StartPosY);
                DisablePar.Play();
                SEASource3.clip = DisableClip;
                SEASource3.Play();
                StabPar.Stop();
            }
            if (LanceFlag != "Null")
            {
                Flag = "Null";
            }
        }
        if (AttackNumber == 2 || AttackNumber == 13)
        {
            if (LanceFlag == "Null")
            {
                this.transform.position = new Vector2(-6, 1.5f);
                Flag = "KnightShot";
                PawnAni.Play("PawnKnightShotAni", 0, 0.0f);
                DisableParObj.transform.position = new Vector2(-6, 1.5f);
                DisablePar.Play();
                SEASource3.clip = DisableClip;
                SEASource3.Play();
                DisableParObj.transform.localScale = new Vector3(2, 2, 2);
                StabPar.Stop();
            }
            if (LanceFlag != "Null")
            {
                Flag = "Null";
            }
        }
        if (AttackNumber == 3 || AttackNumber == 12)
        {
            if (LanceFlag == "Null")
            {
                this.transform.position = LukeKickPos.transform.position;
                Flag = "LukeKick";
                PawnAni.Play("PawnLukeKickAni", 0, 0.0f);
                DisableParObj.transform.position = LukeKickPos.transform.position;
                DisablePar.Play();
                SEASource3.clip = DisableClip;
                SEASource3.Play();
                DisableParObj.transform.localScale = new Vector3(3, 3, 3);
                LKickCol1.enabled = true;
                LKickCol2.enabled = false;
                LKickPar.Play();
                StabPar.Stop();
            }
            if (LanceFlag != "Null")
            {
                Flag = "Null";
            }
        }
        if (AttackNumber == 4 || AttackNumber == 11)
        {
            if (LanceFlag == "Null")
            {
                if (CoffinObj1.activeSelf)
                {
                    this.transform.position = new Vector2(7, 2);
                    Flag = "Bishop";
                    PawnAni.Play("PawnBishopAni", 0, 0.0f);
                    DisableParObj.transform.position = new Vector2(7, 2);
                    DisablePar.Play();
                    DisableParObj.transform.localScale = new Vector3(1, 1, 1);
                    SEASource3.clip = DisableClip;
                    SEASource3.Play();
                    StabPar.Stop();
                }
                if(CoffinObj1.activeSelf == false)
                {
                    Flag = "Null";
                }
            }
            if (LanceFlag != "Null")
            {
                Flag = "Null";
            }
        }
        if (AttackNumber == 6 || AttackNumber == 7 || AttackNumber == 8 || AttackNumber == 5)
        {
            Flag = "Null";
        }
    }
    public void AnimEndMethod()
    {
        //Flag = "Null";
        DisableParObj.transform.position = this.transform.position;
        DisablePar.Play();
        SEASource3.clip = DisableClip;
        SEASource3.Play();
        Invoke("ResetPos", 0.01f);
    }
    public void QueenAniMethod()
    {
        PawnAni.Play("PawnQueenAni", 0, 0.0f);
        DisablePar.Play();
        SEASource3.clip = DisableClip;
        SEASource3.Play();
        StabPar.Play();
        SEASource.clip = StabClip;
        SEASource.Play();
        Debug.Log(SEASource.clip);
    }
    public void FOPMethod()
    {
        FOPObj.transform.position = new Vector3(9, -4, 0);
        FOPTL.Play();
        ScreenShakeController.instance.StartShake(.2f, .4f);
        LanceFlag = "FOPMoveX";
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
            PawnAni.enabled = false;
            //rb.velocity = Vector3.zero;
        }
        if (col.gameObject.tag == "Attack")
        {
            if (FlagHP != "HPSet")
            {
                if (HP1Sprite.size.x >= 1.28)
                {
                    HP1Sprite.size -= new Vector2(0.3f, 0.0f);
                    ScreenShakeController.instance.StartShake(.1f, .2f);
                    //SEASource2.clip = DamageClip;
                    //SEASource2.Play();
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
                    //SEASource2.clip = DamageClip;
                    //SEASource2.Play();
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
            PawnAni.enabled = true;
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
                    //SEASource2.clip = DamageClip;
                    //SEASource2.Play();
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
                    //SEASource2.clip = DamageClip;
                    //SEASource2.Play();
                }
            }
        }
    }
}
