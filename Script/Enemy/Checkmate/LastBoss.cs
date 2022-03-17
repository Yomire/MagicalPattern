using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoss : MonoBehaviour
{
    public Animator CMAnim, HPAnim, KNameAni, QNameAni, BladeSetAnim;
    public GameObject HPObj, HP1, HP2, HP3, HP4, HP5, HP6, HP7, HP8, HP9, HP10, HP11, HP12, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7, HPB8, HPB9, HPB10, HPB11, HPB12, 
        KNameObj, QNameObj, KingObj, QueenObj, DParObjQ, KPortalObj1, KPortalObj2, KPortalObj3, KPortalObj4, KPortalObj5, KPortalObj6, 
        QStabPosRightUp, QStabPosLeftUp, KPortalPosTop, QBladeLeftUp, QBladeRightUp, BladeHolderObj, LaserObj, BladeSetObj, LastBladeObj, CoinCoffinObj;
    public SpriteRenderer HP1Sprite;
    public string Flag, FlagHP, PauseFlag, StabFlag;
    public ParticleSystem DisableParQ, StabPar, LBPar;
    private ScoreManager sm;
    public int HPCount, scoreValue, AttackNumber, AnimCount;
    public float KResetPosX, KResetPosY, QResetPosX, QResetPosY, StabMoveY, BladeSetMoveX, LBSizeX, LBSizeY;
    public AudioSource HPASLoop, SEASource, SEASource2, SEASource3;
    public AudioClip DisableClip, DisableClipK, StabClip, SwingClip;
    public Collider2D LastBladeCol;
    public LastBladeS LBS;
    void Awake()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void KingQueenEnable()
    {
        HPCount = 12;
        HPObj.SetActive(true);
        HPAnim.SetBool("DisableBool", false);
        KNameObj.SetActive(true);
        KNameAni.SetBool("NameEndBool", false);
        QNameObj.SetActive(true);
        QNameAni.SetBool("NameEndBool", false);
        Flag = "Start";
        FlagHP = "Null";
        PauseFlag = "Off";
    }
    public void HP1SetMethod()
    {
        ScreenShakeController.instance.StartShake(.2f, .4f);
        Flag = "Stop";
        FlagHP = "HPSet";
    }
    void Update()
    {
        if(PauseFlag == "Off")
        {
            if (FlagHP == "HPSet")
            {
                if (HP12.activeSelf)
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
                        if (HPCount == 12)
                        {
                            HPCount--;
                            KingDParMethod();
                            DParObjQ.transform.position = QueenObj.transform.position;
                            DisableParQ.Play();
                            SEASource.clip = DisableClip;
                            SEASource.Play();
                            Invoke("ResetPos", 0.1f);
                        }
                    }
                }
            }
            if (HP1Sprite.size.x <= 1.28)
            {
                if (HPCount == 11)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP1.SetActive(false);
                        HPB1.SetActive(true);
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 10)
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
                if (HPCount == 9)
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
                if (HPCount == 8)
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
                if (HPCount == 7)
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
                if (HPCount == 6)
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
                if (HPCount == 5)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP7.SetActive(false);
                        HPB7.SetActive(true);
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 4)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP8.SetActive(false);
                        HPB8.SetActive(true);
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 3)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP9.SetActive(false);
                        HPB9.SetActive(true);
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 2)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP10.SetActive(false);
                        HPB10.SetActive(true);
                        FlagHP = "HPSet";
                        HPCount--;
                        Invoke("HPResetMethod", 0.01f);
                    }
                }
                if (HPCount == 1)
                {
                    if (FlagHP != "HPSet")
                    {
                        HP11.SetActive(false);
                        HPB11.SetActive(true);
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
                        KingDParMethod();
                        DParObjQ.transform.position = QueenObj.transform.position;
                        DisableParQ.Play();
                        SEASource.clip = DisableClip;
                        SEASource.Play();
                        //SEASource3.clip = DisableClip;
                        //SEASource3.Play();
                        Flag = "End";
                        HP12.SetActive(false);
                        HPB12.SetActive(true);
                        //AniLoopCount = 0;
                        HPAnim.SetBool("PargeBool", true);
                        KNameAni.SetBool("NameEndBool", true);
                        QNameAni.SetBool("NameEndBool", true);
                        //Invoke("DisableMethod", 0.01f);                        
                        CMAnim.Play("DeathAni", 0, 0.0f);
                    }
                }
            }
            if (StabFlag == "OnLeft")
            {
                QBladeLeftUp.transform.Translate(0, StabMoveY, 0);
                if (QBladeLeftUp.transform.localPosition.y <= -3f)
                {
                    ScreenShakeController.instance.StartShake(.2f, .4f);
                    DParObjQ.transform.position = QBladeLeftUp.transform.position;
                    DisableParQ.Play();
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    //QueenObj.transform.position = new Vector2(9, 9);
                    StabFlag = "Off";
                    QBladeLeftUp.SetActive(false);
                }
            }
            if (StabFlag == "OnRight")
            {
                QBladeRightUp.transform.Translate(0, StabMoveY, 0);
                if (QBladeRightUp.transform.localPosition.y <= -3f)
                {
                    ScreenShakeController.instance.StartShake(.2f, .4f);
                    DParObjQ.transform.position = QBladeRightUp.transform.position;
                    DisableParQ.Play();
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    //QueenObj.transform.position = new Vector2(9, 9);
                    StabFlag = "Off";
                    QBladeRightUp.SetActive(false);
                }
            }
            if (Flag == "LaserAndBlade")
            {
                BladeSetObj.transform.Translate(-BladeSetMoveX, 0, 0);
                if (BladeSetObj.transform.localPosition.x <= -6)
                {
                    Flag = "LaserAndBladeEnd";
                    BladeSetAnim.SetBool("CloseBool", true);
                }
            }
        }        
    }
    public void ResetPos()
    {
        CMAnim.Play("ResetPosAni", 0, 0.0f);
        QueenObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        Flag = "Null";
        AttackNumber = 0;
        StabPar.Stop();
        AnimCount = 0;
        LBPar.Stop();
        LastBladeCol.enabled = false;
        LBS.LBSEnable();
    }
    public void AnimEndMethod()
    {
        KingDParMethod();
        DParObjQ.transform.position = QueenObj.transform.position;
        DisableParQ.Play();
        QueenObj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        Invoke("ResetPos", 0.1f);
        //Debug.Log("test");
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void DisableMethod()
    {
        KingDParMethod();
        DParObjQ.transform.position = QueenObj.transform.position;
        DisableParQ.Play();
        this.gameObject.SetActive(false);
        sm.AddScore(scoreValue);
        ScreenShakeController.instance.StartShake(.5f, .5f);
        HPAnim.SetBool("DisableBool", true);
        SEASource.clip = DisableClip;
        SEASource.Play();
    }
    public void KingDParMethod()
    {
        GameObject obj = ObjectPooler50.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = KingObj.transform.position;
        //obj.transform.rotation = CrossPos5.transform.rotation;
        obj.SetActive(true);
        SEASource2.clip = DisableClipK;
        SEASource2.Play();
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
                    if (HPCount == 12)
                    {
                        AttackNumber = Random.Range(1, 3);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 11)
                    {
                        AttackNumber = Random.Range(1, 3);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 10)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 9)
                    {
                        AttackNumber = Random.Range(1, 5);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 8)
                    {
                        AttackNumber = Random.Range(1, 7);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 7)
                    {
                        AttackNumber = Random.Range(1, 7);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 6)
                    {
                        AttackNumber = Random.Range(1, 4);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 5)
                    {
                        AttackNumber = Random.Range(1, 12);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 4)
                    {
                        AttackNumber = Random.Range(1, 12);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 3)
                    {
                        AttackNumber = Random.Range(1, 8);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 2)
                    {
                        AttackNumber = Random.Range(1, 8);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                    if (HPCount == 1)
                    {
                        AttackNumber = Random.Range(1, 8);
                        Flag = "Attack";
                        Invoke("AttackMethod", 0.1f);
                    }
                }
                if(Flag == "BladeAndLance")
                {
                    AnimCount++;
                    if(AnimCount == 1)
                    {
                        KPortalObj1.transform.position = KPortalPosTop.transform.position;
                        KPortalObj1.SetActive(true);
                    }
                    if (AnimCount == 2)
                    {
                        QBladeLeftUp.SetActive(true);
                        QBladeLeftUp.transform.position = QStabPosLeftUp.transform.position;
                        //QueenObj.transform.rotation = Quaternion.Euler(0, 0, 45);
                        //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        StabFlag = "OnLeft";
                    }
                    if (AnimCount == 3)
                    {
                        KPortalObj2.transform.position = KPortalPosTop.transform.position;
                        KPortalObj2.SetActive(true);
                    }
                    if (AnimCount == 4)
                    {
                        QBladeRightUp.SetActive(true);
                        QBladeRightUp.transform.position = QStabPosRightUp.transform.position;
                        //QueenObj.transform.rotation = Quaternion.Euler(0, 0, 45);
                        //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        StabFlag = "OnRight";
                    }
                    if (AnimCount == 5)
                    {
                        KPortalObj3.transform.position = KPortalPosTop.transform.position;
                        KPortalObj3.SetActive(true);
                    }
                    if (AnimCount == 6)
                    {
                        QBladeLeftUp.SetActive(true);
                        QBladeLeftUp.transform.position = QStabPosLeftUp.transform.position;
                        //QueenObj.transform.rotation = Quaternion.Euler(0, 0, 45);
                        //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        StabFlag = "OnLeft";
                    }
                    if (AnimCount == 7)
                    {
                        KPortalObj4.transform.position = KPortalPosTop.transform.position;
                        KPortalObj4.SetActive(true);
                    }
                    if (AnimCount == 8)
                    {
                        QBladeRightUp.SetActive(true);
                        QBladeRightUp.transform.position = QStabPosRightUp.transform.position;
                        //QueenObj.transform.rotation = Quaternion.Euler(0, 0, 45);
                        //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        StabFlag = "OnRight";
                    }
                    if (AnimCount == 9)
                    {
                        KPortalObj5.transform.position = KPortalPosTop.transform.position;
                        KPortalObj5.SetActive(true);
                    }
                    if (AnimCount == 10)
                    {
                        QBladeLeftUp.SetActive(true);
                        QBladeLeftUp.transform.position = QStabPosLeftUp.transform.position;
                        //QueenObj.transform.rotation = Quaternion.Euler(0, 0, 45);
                        //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        StabFlag = "OnLeft";
                    }
                    if (AnimCount == 11)
                    {
                        KPortalObj6.transform.position = KPortalPosTop.transform.position;
                        KPortalObj6.SetActive(true);                        
                    }
                    if (AnimCount == 12)
                    {
                        AnimEndMethod();
                    }
                }
                if(Flag == "LaserAndBladeEnd")
                {
                    if(LaserObj.activeSelf == false && BladeSetObj.activeSelf == false)
                    {
                        AnimEndMethod();
                        //Debug.Log("test");
                    }
                }
                if(Flag == "LastBlade")
                {
                    AnimCount++;
                    if(AnimCount >= 7)
                    {
                        Flag = "LastBladeSwing";
                        KingDParMethod();
                        Invoke("LBSwingAni", 0.1f);
                    }
                }
            }
        }
    }
    public void AttackMethod()
    {
        if (AttackNumber == 1 || AttackNumber == 3)
        {
            Flag = "QueenSamon";
            CMAnim.Play("QueenSamonAni", 0, 0.0f);
            StabPar.Play();
        }
        if (AttackNumber == 2 || AttackNumber == 4)
        {
            Flag = "BladeAndLance";
            CMAnim.Play("BladeAndLanceAni", 0, 0.0f);
            //StabPar.Play();
            //QueenObj.transform.position = new Vector2(9, 9);
            //QueenObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            DParObjQ.transform.position = QueenObj.transform.position;
            DisableParQ.Play();
            SEASource.clip = DisableClip;
            SEASource.Play();
            KingObj.transform.position = new Vector2(8, 2);
            KingDParMethod();
            BladeHolderObj.SetActive(true);
        }
        if (AttackNumber == 5 || AttackNumber == 7)
        {
            Flag = "LaserAndBlade";
            CMAnim.Play("LaserAndBladeAni", 0, 0.0f);
            KingDParMethod();
            DParObjQ.transform.position = QueenObj.transform.position;
            DisableParQ.Play();
            SEASource.clip = DisableClip;
            SEASource.Play();
            LaserObj.SetActive(true);
            BladeSetObj.transform.position = new Vector2(7, 2.3f);
            BladeSetObj.SetActive(true);
            BladeSetAnim.SetBool("CloseBool", false);
        }
        if (AttackNumber == 6 || AttackNumber == 8)
        {
            Flag = "LastBlade";
            CMAnim.Play("LastBladeAni", 0, 0.0f);
            LastBladeObj.transform.localScale = new Vector3(0.1f, 0.4f, 1);
            LBSizeX = 0;
            LBSizeY = 0;
            LastBladeCol.enabled = true;
            LBPar.Play();
            CoinCoffinObj.transform.position = new Vector2(7, 5);
            CoinCoffinObj.SetActive(true);
            AnimCount = 0;
        }
        if (AttackNumber == 9 || AttackNumber == 10 || AttackNumber == 11 || AttackNumber == 12)
        {
            Flag = "Null";
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
            CMAnim.enabled = false;
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
        if (col.gameObject.tag == "Coin")
        {
            if(Flag == "LastBlade")
            {
                Debug.Log("col");
                LBSizeX += 0.03f;
                LBSizeY += 0.03f;
                LastBladeObj.transform.localScale = new Vector3(0.1f + LBSizeX, 0.4f + LBSizeY, 1);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
            CMAnim.enabled = true;
        }
    }
    public void LBSwingAni()
    {
        CMAnim.Play("LastBladeSwingAni", 0, 0.0f);
    }
    /*
    public void DeathMethod()
    {        
        KingDParMethod();
        DParObjQ.transform.position = QueenObj.transform.position;
        DisableParQ.Play();
        this.gameObject.SetActive(false);
    }
    */
    public void StabSE()
    {
        SEASource.clip = StabClip;
        SEASource.Play();
    }
    public void SwingSE()
    {
        SEASource.clip = SwingClip;
        SEASource.Play();
    }
}
