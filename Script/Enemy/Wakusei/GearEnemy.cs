using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearEnemy : MonoBehaviour
{
    public float SpeedX = 0.0f, SpeedY = 0.0f;
    //public float DestroyTime = 7.0f;
    //public float RotateZ = 1.0f;
    public Rigidbody2D rb;
    public string flag = "Null", FlagScale, PauseFlag;
    //public GameObject Sparkle;
    public int HPCount, StartHP;
    public GameObject CoinPos1, CoinPos2, CoinPos3, StartPos;
    public WakuseiScript WS;
    public ParticleSystem DisablePar1, DisablePar2, DisablePar3;
    public float EndPos_y, StartPos_y, StartPos_x;
    public AudioSource SEASourceLoop, SEASource;
    public AudioClip GearClip, DisableClip;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (PauseFlag == "Off")
        {
            if(FlagScale == "Big")
            {
                PauseFlag = "On";
                if (SEASourceLoop != null)
                {
                    SEASourceLoop.clip = GearClip;
                    SEASourceLoop.pitch = 3;
                    SEASourceLoop.Play();
                }                    
            }            
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(SpeedX, SpeedY);
        if (flag == "GearRush-")
        {
            if (this.transform.localPosition.y <= EndPos_y)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "GearRush+")
        {
            if (this.transform.localPosition.y >= EndPos_y)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if(HPCount >= 0)
        {
            if(trcol.gameObject.tag == "Shield")
            {
                if(flag == "Mini" || flag == "GearRush-" || flag == "GearRush+")
                {
                    WS.DamageMethod();
                    //ScreenShakeController.instance.StartShake(.3f, .2f);
                    CoinMethodCentorCentorNormal();
                    CoinMethodCentorLeft();
                    CoinMethodCentorRight();
                    DisablePar1.transform.position = CoinPos1.transform.position;
                    DisablePar1.Play();
                    this.gameObject.SetActive(false);
                    sm.AddScore(scoreValue);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    PauseFlag = "Off";
                }
            }
            if (trcol.gameObject.tag == "Attack")
            {
                ScreenShakeController.instance.StartShake(.05f, .05f);
                HPCount--;
                if (flag == "Huge")
                {
                    WS.DamageMethod();
                }
                if (HPCount <= 0)
                {
                    if(flag == "Big" || flag == "Huge")
                    {
                        WS.DamageMethodSP2();
                        ScreenShakeController.instance.StartShake(.3f, .2f);
                        CoinMethodCentorCentor();
                        CoinMethodCentorLeft();
                        CoinMethodCentorRight();
                        CoinMethodRightCentor();
                        CoinMethodRightLeft();
                        CoinMethodRightRight();
                        CoinMethodLeftCentor();
                        CoinMethodLeftLeft();
                        CoinMethodLeftRight();
                        if(SEASourceLoop != null)
                        {
                            SEASourceLoop.Stop();
                            SEASourceLoop.pitch = 1;
                        }                        
                        if (DisablePar1 != null)
                        {
                            DisablePar1.transform.position = CoinPos1.transform.position;
                            DisablePar1.Play();
                        }
                        if (DisablePar2 != null)
                        {
                            DisablePar2.transform.position = CoinPos2.transform.position;
                            DisablePar2.Play();
                        }
                        if (DisablePar3 != null)
                        {
                            DisablePar3.transform.position = CoinPos3.transform.position;
                            DisablePar3.Play();
                        }
                    }
                    if (flag == "Mini" || flag == "GearRush-" || flag == "GearRush+")
                    {
                        WS.DamageMethod();
                        //ScreenShakeController.instance.StartShake(.3f, .2f);
                        CoinMethodCentorCentorNormal();
                        CoinMethodCentorLeft();
                        CoinMethodCentorRight();
                        DisablePar1.transform.position = CoinPos1.transform.position;
                        DisablePar1.Play();
                    }
                    this.gameObject.SetActive(false);
                    sm.AddScore(scoreValue);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    PauseFlag = "Off";
                }
            }
            if (trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
            {
                ScreenShakeController.instance.StartShake(.1f, .1f);
                HPCount -= 2;
                if (flag == "Huge")
                {
                    WS.DamageMethod();
                }
                if (HPCount <= 0)
                {
                    if (flag == "Big" || flag == "Huge")
                    {
                        WS.DamageMethodSP2();
                        ScreenShakeController.instance.StartShake(.3f, .2f);
                        CoinMethodCentorCentor();
                        CoinMethodCentorLeft();
                        CoinMethodCentorRight();
                        CoinMethodRightCentor();
                        CoinMethodRightLeft();
                        CoinMethodRightRight();
                        CoinMethodLeftCentor();
                        CoinMethodLeftLeft();
                        CoinMethodLeftRight();
                        if (SEASourceLoop != null)
                        {
                            SEASourceLoop.Stop();
                            SEASourceLoop.pitch = 1;
                        }                            
                        if (DisablePar1 != null)
                        {
                            DisablePar1.transform.position = CoinPos1.transform.position;
                            DisablePar1.Play();
                        }
                        if (DisablePar2 != null)
                        {
                            DisablePar2.transform.position = CoinPos2.transform.position;
                            DisablePar2.Play();
                        }
                        if (DisablePar3 != null)
                        {
                            DisablePar3.transform.position = CoinPos3.transform.position;
                            DisablePar3.Play();
                        }
                    }
                    if (flag == "Mini" || flag == "GearRush-" || flag == "GearRush+")
                    {
                        WS.DamageMethod();
                        //ScreenShakeController.instance.StartShake(.3f, .2f);
                        CoinMethodCentorCentorNormal();
                        CoinMethodCentorLeft();
                        CoinMethodCentorRight();
                        DisablePar1.transform.position = CoinPos1.transform.position;
                        DisablePar1.Play();
                    }
                    this.gameObject.SetActive(false);
                    sm.AddScore(scoreValue);
                    SEASource.clip = DisableClip;
                    SEASource.Play();
                    PauseFlag = "Off";
                }
            }
        }
        if (flag == "Big")
        {
            if (trcol.gameObject.tag == "EnemyFalse")
            {
                this.gameObject.SetActive(false);
            }
        }            
        if(flag == "Mini")
        {
            if (trcol.gameObject.tag == "EnemyFalse2")
            {
                this.gameObject.SetActive(false);
            }
        }
        if (trcol.gameObject.tag == "AttackSPB")
        {
            HPCount = 0;
            WS.DamageMethodSP2();
            ScreenShakeController.instance.StartShake(.1f, .1f);
            if (HPCount <= 0)
            {
                if (flag == "Big" || flag == "Huge")
                {
                    WS.DamageMethodSP2();
                    ScreenShakeController.instance.StartShake(.3f, .2f);
                    CoinMethodCentorCentor();
                    CoinMethodCentorLeft();
                    CoinMethodCentorRight();
                    CoinMethodRightCentor();
                    CoinMethodRightLeft();
                    CoinMethodRightRight();
                    CoinMethodLeftCentor();
                    CoinMethodLeftLeft();
                    CoinMethodLeftRight();
                    if (SEASourceLoop != null)
                    {
                        SEASourceLoop.Stop();
                        SEASourceLoop.pitch = 1;
                    }                        
                    if (DisablePar1 != null)
                    {
                        DisablePar1.transform.position = CoinPos1.transform.position;
                        DisablePar1.Play();
                    }
                    if (DisablePar2 != null)
                    {
                        DisablePar2.transform.position = CoinPos2.transform.position;
                        DisablePar2.Play();
                    }
                    if (DisablePar3 != null)
                    {
                        DisablePar3.transform.position = CoinPos3.transform.position;
                        DisablePar3.Play();
                    }
                }
                if (flag == "Mini" || flag == "GearRush-" || flag == "GearRush+")
                {
                    WS.DamageMethod();
                    //ScreenShakeController.instance.StartShake(.3f, .2f);
                    CoinMethodCentorCentorNormal();
                    CoinMethodCentorLeft();
                    CoinMethodCentorRight();
                    DisablePar1.transform.position = CoinPos1.transform.position;
                    DisablePar1.Play();
                }
                this.gameObject.SetActive(false);
                sm.AddScore(scoreValue);
                SEASource.clip = DisableClip;
                SEASource.Play();
                PauseFlag = "Off";
            }
        }
    }
    public void OEMethod()
    {
        HPCount = StartHP;
        flag = FlagScale;
        if(StartPos != null)
        {
            this.gameObject.transform.position = StartPos.transform.position;
        }
        if(flag == "GearRush-" || flag == "GearRush+")
        {
            this.gameObject.transform.position = new Vector2(StartPos_x, StartPos_y);
        }
    }

    public void CoinMethodCentorCentorNormal()
    {
        GameObject obj20 = ObjectPooler12.current.GetPooledObject();
        if (obj20 == null) return;
        obj20.transform.position = CoinPos1.transform.position;
        //obj20.transform.rotation = ShotPosRight.transform.rotation;
        obj20.SetActive(true);
    }
    public void CoinMethodCentorCentor()
    {
        GameObject obj20 = ObjectPooler20.current.GetPooledObject();
        if (obj20 == null) return;
        obj20.transform.position = CoinPos1.transform.position;
        //obj20.transform.rotation = ShotPosRight.transform.rotation;
        obj20.SetActive(true);
    }
    public void CoinMethodCentorLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos1.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodCentorRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos1.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightCentor()
    {
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRightRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos2.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftCentor()
    {
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodLeftRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinPos3.transform.position;
        obj.SetActive(true);
    }
}
