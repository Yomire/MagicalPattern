using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakuseiScript : MonoBehaviour
{
    public string Flag = "Null", FlagHP, FlagBigBang;
    public GameObject CircleGearPos, HP1, HP2, HP3, HP4, HP5, HP6, HP7, GearsHolder, CircleSignObj, HPB1, HPB2, HPB3, HPB4, HPB5, HPB6, HPB7, BigBangObj, 
        BigGearStartObjLeft, BigGearStartObjRight, BigGearLeft, 
        GearPosTop, GearPosBottom, GearPosLeft, GearPosRight, GearTop, GearBottom, GearLeft, GearRight, PlayerObj, GearPosTop2, GearPosBottom2, GearPosLeft2, GearPosRight2, 
        ObstacleGear, GearRush1, GearRush2, GearRush3, GearRush4, GearRush5, GearRush6, GearRush7, GearRush8, GearRush9, GearRush10, GearRush11, GearRush12, GearRush13, GearRush14, 
        HugeGearHolder, HugeGearPos, HPObj, NameObj;
    public Animator WAni1, WAni2, WAni3, HPAni, NameAni;
    public ParticleSystem Sparkle1, Sparkle2, ParticleGear1, ParticleGear2, ParticleGear3, ParticleGear4, ParticleGear5, ParticleGear6, ParticleGear7, ParticleGear8, DustParticle1, DustParticle2, 
        BurnPar1, BurnPar2, BurnPar3, BurnPar4, BurnPar5, BurnPar6, BurnPar7, BurnPar8, BurnPar9, FallPar1, FallPar2, FallPar3, HugeFalseParLeft, HugeFalseParRight;
    public SpriteRenderer HP1Sprite;
    public int AttackNumber = 0, HPCount = 0, NumberStopper = 0, BurnNumber = 0;
    public float EndPos_X = -20, StartPos_Y = 12, EndPos_Y = 0, BurnPos_X = -5, MoveH = 1, MoveV = -1, DestroyPos_Y = -20;
    public GsHScript GsHS;
    public GearEnemy BigGearObj, RightGear, LeftGear, UpGear, LowerGear, ObstacleScript, 
        RushScript1, RushScript2, RushScript3, RushScript4, RushScript5, RushScript6, RushScript7, RushScript8, RushScript9, RushScript10, RushScript11, RushScript12, RushScript13, RushScript14, 
        HugeGearLeftScript, HugeGearRightScript;
    public HGHScript HGHS;
    public AudioSource HPASLoop, SEASourceLoop, SEASource;
    public AudioClip GearClip, BurnClip;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void WakuseiEnable()
    {
        HPObj.SetActive(true);
        this.transform.position = new Vector3(0, StartPos_Y, 20);
        //this.transform.Translate(0, StartPos_Y, 0);
        HPCount = 8;
        HPAni.SetBool("DissociationBool", false);
        ParticleGear1.Play();
        DustParticle1.Play();
        Flag = "Fall";
        WAniSpeed2();
        //Flag = "HPSet";
        FlagHP = "Null";
        FallPar1.Stop();
        FallPar2.Stop();
        FallPar3.Stop();
        FlagBigBang = "Null";
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

    // Update is called once per frame
    void Update()
    {
        if (Flag == "Fall")
        {
            this.transform.Translate(0, MoveV, 0);
            NumberStopper = 1;
        }
        if (this.transform.localPosition.y <= EndPos_Y)
        {
            Flag = "Stop";
            //NumberStopper = 0;
            if (HP1.activeSelf)
            {
                if(HP1Sprite.size.x <= 1.28)
                {
                    if(FlagHP == "Null")
                    {
                        if(HPCount >= 0)
                        {
                            //FlagHP = "HPSet";
                            HPCount--;
                        }
                        if (HPCount >= 1)
                        {
                            FlagHP = "HPSet";
                            //HPCount--;
                        }
                    }
                }
            }
        }   
        if(FlagHP == "HPSet")
        {
            HP1Sprite.size += new Vector2(0.1f, 0.0f);
            WAniSpeed5();
            if (HPASLoop.isPlaying == false)
            {
                HPASLoop.Play();
            }
            if (HP1Sprite.size.x >= 15)
            {
                FlagHP = "Null";
                NumberStopper = 0;
                WAniSpeed2();
                HPASLoop.Stop();
            }
        }
        if(HPCount <= 0)
        {
            this.transform.Translate(MoveH, -0.01f, 0);
        }
    }
    public void WAniEventMethod()
    {
        if (Flag == "Stop")
        {
            this.transform.Translate(0, 0, 0);
        }
        if(HPCount >= 1)
        {
            if (GearsHolder.activeSelf == false && BigGearLeft.activeSelf == false && CircleSignObj.activeSelf == false && HugeGearHolder.activeSelf == false)
            {
                if (AttackNumber == 5)
                {
                    CircleSignObj.SetActive(true);
                    Invoke("CircleGearAttack", 2.0f);
                }
                /*if (AttackNumber == 3 || AttackNumber == 4)
                {
                    CircleSignObj.SetActive(true);
                    Invoke("CircleGearAttackRight", 2.0f);
                }*/
                if (AttackNumber == 6 || AttackNumber == 7)
                {
                    BigGearStartObjLeft.transform.position = this.gameObject.transform.position;
                    BigGearStartObjLeft.SetActive(true);
                    BigGearLeft.SetActive(true);
                    BigGearObj.OEMethod();
                }
                if (AttackNumber == 11 || AttackNumber == 12 || AttackNumber == 15 || AttackNumber == 16)
                {
                    if (HugeGearHolder.activeSelf == false)
                    {
                        HugeGearHolder.transform.position = HugeGearPos.transform.position;
                        HugeGearLeftScript.OEMethod();
                        HugeGearRightScript.OEMethod();
                        BigGearStartObjLeft.SetActive(true);
                        BigGearStartObjLeft.transform.position = this.gameObject.transform.position;
                        BigGearStartObjRight.SetActive(true);
                        BigGearStartObjRight.transform.position = this.gameObject.transform.position;
                        HugeGearHolder.SetActive(true);
                        HGHS.OEMethod();
                    }
                }
            }
            if (GearsHolder.activeSelf == false && CircleSignObj.activeSelf == false && HugeGearHolder.activeSelf == false)
            {                  
                if (AttackNumber == 1)
                {
                    if (GearTop.activeSelf == false)
                    {
                        GearPosSetTop();
                    }
                }
                if (AttackNumber == 2)
                {
                    if (GearBottom.activeSelf == false)
                    {
                        GearPosSetBottom();
                    }                         
                }
                if (AttackNumber == 3)
                {
                    if (GearLeft.activeSelf == false)
                    {
                        GearPosSetLeft();
                    }                      
                }
                if (AttackNumber == 4)
                {
                    if (GearRight.activeSelf == false)
                    {
                        GearPosSetRight();
                    }                        
                }
                if (AttackNumber == 8 || AttackNumber == 9)
                {
                    if (ObstacleGear.activeSelf == false)
                    {
                        ObstacleMethod();
                    }
                }
                if (AttackNumber == 10 || AttackNumber == 13 || AttackNumber == 14)
                {
                    if (GearRush1.activeSelf == false && GearRush2.activeSelf == false && GearRush3.activeSelf == false && GearRush4.activeSelf == false && GearRush5.activeSelf == false && GearRush6.activeSelf == false && GearRush7.activeSelf == false && GearRush8.activeSelf == false && GearRush9.activeSelf == false && GearRush10.activeSelf == false && GearRush11.activeSelf == false && GearRush12.activeSelf == false && GearRush13.activeSelf == false && GearRush14.activeSelf == false)
                    {
                        GearRush1.SetActive(true);
                        RushScript1.OEMethod();
                        GearRush2.SetActive(true);
                        RushScript2.OEMethod();
                        GearRush3.SetActive(true);
                        RushScript3.OEMethod();
                        GearRush4.SetActive(true);
                        RushScript4.OEMethod();
                        GearRush5.SetActive(true);
                        RushScript5.OEMethod();
                        GearRush6.SetActive(true);
                        RushScript6.OEMethod();
                        GearRush7.SetActive(true);
                        RushScript7.OEMethod();
                        GearRush8.SetActive(true);
                        RushScript8.OEMethod();
                        GearRush9.SetActive(true);
                        RushScript9.OEMethod();
                        GearRush10.SetActive(true);
                        RushScript10.OEMethod();
                        GearRush11.SetActive(true);
                        RushScript11.OEMethod();
                        GearRush12.SetActive(true);
                        RushScript12.OEMethod();
                        GearRush13.SetActive(true);
                        RushScript13.OEMethod();
                        GearRush14.SetActive(true);
                        RushScript14.OEMethod();
                    }
                }
            }
        }        
        if (HPCount == 6)
        {
            HP7.SetActive(false);
            HPB7.SetActive(true);
            ParticleGear2.Play();
        }
        if (HPCount == 5)
        {
            HP6.SetActive(false);
            HPB6.SetActive(true);
            ParticleGear3.Play();
        }
        if (HPCount == 4)
        {
            HP5.SetActive(false);
            HPB5.SetActive(true);
            ParticleGear4.Play();
        }
        if (HPCount == 3)
        {
            HP4.SetActive(false);
            HPB4.SetActive(true);
            DustParticle2.Play();
            ParticleGear5.Play();
        }
        if (HPCount == 2)
        {
            HP3.SetActive(false);
            HPB3.SetActive(true);
            ParticleGear6.Play();
        }
        if (HPCount == 1)
        {
            HP2.SetActive(false);
            HPB2.SetActive(true);
            ParticleGear7.Play();
            ParticleGear8.Play();
            //Debug.Log("test");
        }
        if (HPCount <= 0)
        {
            HP1.SetActive(false);
            HPB1.SetActive(true);
            HPAni.SetBool("DissociationBool", true);
            NameAni.SetBool("NameEndBool", true);
            FallPar1.Play();
            FallPar2.Play();
            FallPar3.Play();
            if(FlagBigBang == "Null")
            {
                BigBangObj.SetActive(true);
                FlagBigBang = "BigBang";
            }
            ParticleGear1.Stop();
            ParticleGear2.Stop();
            ParticleGear3.Stop();
            ParticleGear4.Stop();
            ParticleGear5.Stop();
            ParticleGear6.Stop();
            ParticleGear7.Stop();
            ParticleGear8.Stop();
            DustParticle1.Stop();
            DustParticle2.Stop();
            if (HugeGearHolder.activeSelf)
            {
                HugeGearHolder.SetActive(false);
                HugeFalseParLeft.Play();
                HugeFalseParRight.Play();
            }
        }
        if (this.transform.localPosition.y <= DestroyPos_Y)
        {
            sm.AddScore(scoreValue);
            this.gameObject.SetActive(false);
        }
    }
    public void WAniRandomMethod()
    {
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 7)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 6);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 6)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 8);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 5)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 10);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 4)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 11);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 3)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 12);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 2)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 15);
                }
            }
        }
        if (GearsHolder.activeSelf == false || CircleSignObj.activeSelf == false)
        {
            if (HPCount == 1)
            {
                if (NumberStopper == 0)
                {
                    AttackNumber = Random.Range(1, 17);
                }
            }
        }
    }
    public void WAniSpeed2()
    {
        WAni1.SetFloat("1LAniSpeed", 2f);
        WAni2.SetFloat("2LAniSpeed", 2f);
        WAni3.SetFloat("3LAniSpeed", 2f);
        Sparkle1.Stop();
        Sparkle2.Stop();
        SEASourceLoop.Stop();
        SEASourceLoop.pitch = 1;
    }
    public void WAniSpeed5()
    {
        WAni1.SetFloat("1LAniSpeed", 5f);
        WAni2.SetFloat("2LAniSpeed", 5f);
        WAni3.SetFloat("3LAniSpeed", 5f);
        Sparkle1.Play();
        Sparkle2.Play();
        SEASourceLoop.clip = GearClip;
        SEASourceLoop.Play();
        SEASourceLoop.pitch = 3;
    }
    public void DamageMethod()
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
    public void DamageMethodSP()
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
    public void DamageMethodSP2()
    {
        if (FlagHP != "HPSet")
        {
            if (HP1Sprite.size.x >= 1.28)
            {
                HP1Sprite.size -= new Vector2(2.5f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .2f);
            }
        }                     
    }
    public void ObstacleMethod()
    {
        ObstacleGear.SetActive(true);
        ObstacleScript.OEMethod();
    }

    public void CircleGearAttack()
    {
        GearsHolder.SetActive(true);
        GearsHolder.transform.position = CircleGearPos.transform.position;
        //Invoke("GsHSMethodLeft", Random.Range(5, 10));
        Invoke("OEMCall", 0.1f);
    }
    /*public void CircleGearAttackRight()
    {
        GearsHolder.SetActive(true);
        GearsHolder.transform.position = CircleGearPos.transform.position;
        //Invoke("GsHSMethodRight", Random.Range(5, 10));
        Invoke("OEMCall", 0.1f);
    }*/

    public void GearPosSetTop()
    {
        Vector3 PlayerPos = PlayerObj.transform.position;
        GearPosTop.transform.position = new Vector2(PlayerPos.x, 7);
        Invoke("GearDengerTop", 0.1f);
        Invoke("GearAttackTop", 0.1f);
    }
    public void GearPosSetBottom()
    {
        Vector3 PlayerPos = PlayerObj.transform.position;
        GearPosBottom.transform.position = new Vector2(PlayerPos.x, -7);
        Invoke("GearDengerBottom", 0.1f);
        Invoke("GearAttackBottom", 0.1f);
    }
    public void GearPosSetLeft()
    {
        Vector3 PlayerPos = PlayerObj.transform.position;
        GearPosLeft.transform.position = new Vector2(-12, PlayerPos.y);
        Invoke("GearDengerLeft", 0.1f);
        Invoke("GearAttackLeft", 0.1f);
    }
    public void GearPosSetRight()
    {
        Vector3 PlayerPos = PlayerObj.transform.position;
        GearPosRight.transform.position = new Vector2(12, PlayerPos.y);
        Invoke("GearDengerRight", 0.1f);
        Invoke("GearAttackRight", 0.1f);
    }
    public void GearDengerTop()
    {
        //Debug.Log("top");
        GameObject obj5 = ObjectPooler5.current.GetPooledObject();
        if (obj5 == null) return;
        obj5.transform.position = GearPosTop.transform.position;
        obj5.transform.rotation = GearPosTop.transform.rotation;
        obj5.SetActive(true);
    }
    public void GearDengerBottom()
    {
        GameObject obj5 = ObjectPooler5.current.GetPooledObject();
        if (obj5 == null) return;
        obj5.transform.position = GearPosBottom.transform.position;
        obj5.transform.rotation = GearPosBottom.transform.rotation;
        obj5.SetActive(true);
    }
    public void GearDengerLeft()
    {
        GameObject obj5 = ObjectPooler5.current.GetPooledObject();
        if (obj5 == null) return;
        obj5.transform.position = GearPosLeft.transform.position;
        obj5.transform.rotation = GearPosLeft.transform.rotation;
        obj5.SetActive(true);
    }
    public void GearDengerRight()
    {
        GameObject obj5 = ObjectPooler5.current.GetPooledObject();
        if (obj5 == null) return;
        obj5.transform.position = GearPosRight.transform.position;
        obj5.transform.rotation = GearPosRight.transform.rotation;
        obj5.SetActive(true);
    }
    public void GearAttackTop()
    {
        GearTop.SetActive(true);
        GearTop.transform.position = GearPosTop2.transform.position;
        UpGear.OEMethod();
    }
    public void GearAttackBottom()
    {
        GearBottom.SetActive(true);
        LowerGear.OEMethod();
        GearBottom.transform.position = GearPosBottom2.transform.position;
    }
    public void GearAttackLeft()
    {
        GearLeft.SetActive(true);
        LeftGear.OEMethod();
        GearLeft.transform.position = GearPosLeft2.transform.position;
    }
    public void GearAttackRight()
    {
        GearRight.SetActive(true);
        RightGear.OEMethod();
        GearRight.transform.position = GearPosRight2.transform.position;
    }

    /*public void GsHSMethodLeft()
    {
        GsHS.MoveMethodLeft();
    }*/
    /*public void GsHSMethodRight()
    {
        GsHS.MoveMethodRight();
    }*/
    public void OEMCall()
    {
        GsHS.OEMethod();
    }
    public void BurnMethod()
    {
        if(HPCount <= 0)
        {
            BurnNumber = Random.Range(1, 9);
            if (BurnNumber == 1)
            {
                BurnPar1.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 2)
            {
                BurnPar2.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 3)
            {
                BurnPar3.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 4)
            {
                BurnPar4.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 5)
            {
                BurnPar5.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 6)
            {
                BurnPar6.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 7)
            {
                BurnPar7.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 8)
            {
                BurnPar8.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
            if (BurnNumber == 9)
            {
                BurnPar9.Play();
                SEASource.clip = BurnClip;
                SEASource.Play();
                ScreenShakeController.instance.StartShake(.2f, .4f);
            }
        }        
    }
}
