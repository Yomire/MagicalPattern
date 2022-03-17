using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{    
    private Rigidbody2D rb;
    private const int MaxRightJumpCount = 1;
    private int RightJumpCount = 0;
    private const int MaxLeftJumpCount = 1;
    private int LeftJumpCount = 0;
    private Animator ani;
    public Animator PhoenixAni;
    GenerateHandLeft script;
    public float jumpSpeed = 5;
    public float moveSpeed = 5, SliderSpeed = 5.0f, ScytheSpeed = 10.0f, ButterflySpeed = 200.0f, WindMoveX;
    public apPortrait StrayApPortrait;
    public string flag = "true", flagB = "false", flagLock = "Off", flagDirection = "Null", flagC = "Off", TimeFlag = "Off", /*flagBoomerang = "Off",*/ flagGround = "Off", 
        flagYoyoSliding = "Off", JoyColExitFlag = "On", HamerSlideFlag = "Plus", flagHC = "Off", flagButterfly = "Off", flagVector = "Off", flagY = "Off", 
        PauseFlag, ContinueFlag;
    public float AttackJumpMini = 1;
    public float AttackJumpMiniX = 1;
    public Collider2D ShieldCol, ScytheCol, HammerCol, CoinChangeCol, MagnetCol, HammerSoundCol, LockCol, HammerCol2, ScytheCutCol;
    //public Collider2D PlayerCol;
    //public Collider2D EffectCollider;
    public Camera camera;
    public GameObject EffectPrefab, ShotPosRight, ShotPosLeft, ChainObj, ChainLock1, ChainLock2, ChainLock3, ChainLock4, ChainLock5, ChainLock6, ChainLock7, ChainLock8, ChainLock9, KeyActObj,
        PhoenixObj, BombObj, ArrowPos, ArrowPosUp, ArrowPosDown, YoyoSTPObj, YoyoSTPObjB, YoyoStringObjB, TanglerObj, RightHandPos, ScytheParObj, ScytheSPParObj, ScytheSPObj, RevolvObj,
        ShotSliderPosRight, ShotSliderPosLeft, HeartObj, ThunderPosA, ThunderPosB, CoinActObj, MagnetActObj, MeteorPosA, MeteorPosB, MeteorPosC, MeteorPosD, MeteorPosE, StabColObj, StabColObjB, 
        MonaObj, ThunderObjUp, ThunderObjSide;
    public Image SPGage, SPGageB;
    public TrailRenderer BTrail;
    public ParticleSystem ShotParticleA, ShotParticleB, RunDust, ScytheSlash, ScytheSlashSP, HAParticle, HSParticle, ShotParticleSliderRight, ShotParticleSliderLeft, ChargeEndPar, BladeSlashPar;
    public LockScript ChainS1, ChainS2, ChainS3, ChainS4, ChainS5, ChainS6, ChainS7, ChainS8, ChainS9;
    public PhoenixScriptVerB PhSc;
    public BombScript BoSc;
    [SerializeField] private PlayerController joystick;
    private Vector2 dir = Vector2.zero;
    public PlayableDirector StabDirector, StabDirectorBack, ThunderDirectorUp, ThunderDirectorSide;
    private const int MaxRushCountRight = 1, MaxRushCountLeft = 1;
    public int RushCountRight = 0, RushCountLeft = 0, Count = 0;
    public AudioClip ShotSound, ShieldLSound;
    public AudioSource audioSource, audioLoop, CoinAudioSource;
    public MonaScript MScript;
    public SEScript SoundScript;
    public Text PatternName1, PatternName2, PatternName3;
    public GameControlScript GameConS;

    void Start()
    {
        Application.targetFrameRate = 30;
        flagLock = "Off";
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        script = GameObject.Find("AttackGenerate").GetComponent<GenerateHandLeft>();
        flag = "true";
        flagB = "false";
        PhoenixAni = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        PauseFlag = "Off";
    }
    public void OnDisable()
    {
        ShieldCol.enabled = true;
    }
    public void ContinueEnable()
    {
        StartCoroutine("Damage");
        flag = "Damage";
        SPGage.fillAmount = 1;
        SPGageB.fillAmount = 1;
        GameConS.NextFlagMethod();
        ContinueFlag = "Continue";
    }
    void FixedUpdate()
    {
        if(PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                //Debug.Log(flagB);
                //Vector2 myGravity = new Vector2(0, 0);
                if (flag == "Jump")
                {
                    //YoyoStringObj.SetActive(false);
                    //YoyoSTPObj.SetActive(false);
                    if (rb.velocity.y == 0)
                    {
                        if (flagC != "ScytheOn")
                        {
                            //ThunderSphirePar.Stop();
                            flag = "True";
                            ani.Play("ColliderIdle", 0, 0.0f);
                            StrayApPortrait.Play("StrayRun", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                            StrayApPortrait.StopLayer(2);
                            RightJumpCount = 0;
                            LeftJumpCount = 0;
                            rb.velocity = new Vector2(0.0f, 0.0f);
                            //BladeCollider2.enabled = false;
                            //BTrail.enabled = false;
                            //BladeSpinPar.Stop();
                            //Debug.Log("test");
                            //BladeSpinCol.enabled = false;
                            BladeSlashPar.Stop();
                        }
                        if (flagC == "ScytheOn")
                        {
                            StrayApPortrait.Play("RidingScytheStart", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                            Invoke("ScytheRide", 0.1f);
                            ani.Play("ColliderIdle", 0, 0.0f);
                            if (flagDirection == "Right")
                            {
                                rb.velocity = new Vector2(ScytheSpeed, 0.0f);
                            }
                            if (flagDirection == "Left")
                            {
                                rb.velocity = new Vector2(-ScytheSpeed, 0.0f);
                            }
                        }
                    }
                }

                if (flag == "Damage" && flagButterfly == "Off")
                {
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.Play("StrayDamage2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    //BladeCollider2.enabled = false;
                    //BTrail.enabled = false;
                    BladeSlashPar.Stop();
                    //BladeSpinCol.enabled = false;
                    Invoke("FlagMethod", 1.0f);
                }
                if (flag == "Damage2" && flagButterfly == "Off")
                {
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.Play("StrayDamage2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    //BladeCollider2.enabled = false;
                    //BTrail.enabled = false;
                    BladeSlashPar.Stop();
                }

                else if (flag == "Geki")
                {
                    StrayApPortrait.Play("StrayGeki1", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                else if (flag == "Geki2")
                {
                    rb.velocity = new Vector2(AttackJumpMiniX, AttackJumpMini);
                    //rb.gravityScale = 5;
                    //rb.AddForce(myGravity);
                    StrayApPortrait.Play("StrayGeki2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                else if (flag == "Geki3")
                {
                    rb.velocity = new Vector2(-AttackJumpMiniX, AttackJumpMini);
                    //rb.gravityScale = 5;
                    //rb.AddForce(myGravity);
                    StrayApPortrait.Play("StrayGeki3", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }

                if (rb.velocity.y < 0 || rb.velocity.y > 0)
                {
                    if (flag == "Jump")
                    {
                        //Debug.Log("test");
                        StrayApPortrait.Play("StrayRotation", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        //YoyoStringObj.SetActive(false);
                        //YoyoSTPObj.SetActive(false);
                        /*if (flagB == "BladeVisible")
                        {
                            BladeCollider2.enabled = true;
                            StrayApPortrait.Play("StrayBladeRotate", 2);
                            //BTrail.enabled = true;
                            //BladeSpinPar.Play();
                            BladeSpinCol.enabled = true;
                        }*/
                        /*if (flagThunder == "ThunderMode")
                        {
                            ThunderSphirePar.Play();
                        }*/
                    }

                    else if (flag == "Geki4")
                    {
                        rb.velocity = new Vector2(0.0f, AttackJumpMini);
                        //rb.gravityScale = 5;
                        //rb.AddForce(myGravity);
                        StrayApPortrait.Play("StrayGeki4", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        Invoke("FlagMethod", 0.1f);
                    }
                    /*else if (flag == "BladeStart")
                    {
                        //BTrail.enabled = false;
                        rb.velocity = new Vector2(100.0f, AttackJumpMini);
                        StrayApPortrait.Play("StrayBladeStart", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        Invoke("MoveMethod", 0.01f);
                    }*/
                    /*else if (flag == "Blade1")
                    {
                        rb.velocity = new Vector2(0.0f, 0.0f);
                        StrayApPortrait.Play("StrayBlade1", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        BladeSlashPar.Play();
                    }*/
                    else if (flag == "Birn")
                    {
                        StrayApPortrait.Play("BombThrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        Invoke("FlagMethod", 0.3f);
                    }
                    else if (flag == "BirnBackRight")
                    {
                        StrayApPortrait.Play("Exprodion", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        Invoke("FlagMethod", 0.2f);
                        Invoke("BirnBackRightMethod", 0.1f);
                    }
                    else if (flag == "BirnBackLeft")
                    {
                        transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                        StrayApPortrait.Play("Exprodion", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        Invoke("FlagMethod", 0.2f);
                        Invoke("BirnBackLeftMethod", 0.1f);
                    }
                    else if (flag == "ArrowShootRight")
                    {
                        rb.velocity = Vector3.zero;
                        transform.localScale = new Vector3(1.1f, 1.1f, 1);
                        StrayApPortrait.Play("Arrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        rb.gravityScale = 0;
                        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    }
                    else if (flag == "ArrowShootLeft")
                    {
                        rb.velocity = Vector3.zero;
                        transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                        StrayApPortrait.Play("Arrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.StopLayer(2);
                        rb.gravityScale = 0;
                        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    }
                    /*else if(flag == "ScytheJump")
                    {
                        StrayApPortrait.Play("ScytheRota Copy", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    }*/
                }

                if(flagButterfly != "On")
                {
                    if (rb.velocity.y == 0)
                    {
                        if (flag == "true")
                        {
                            //ThunderSphirePar.Stop();
                            ani.Play("ColliderIdle", 0, 0.0f);
                            StrayApPortrait.Play("StrayRun", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                            StrayApPortrait.StopLayer(2);
                            RightJumpCount = 0;
                            LeftJumpCount = 0;
                            rb.velocity = new Vector2(0.0f, 0.0f);
                            //BladeSpinPar.Stop();
                            //BladeSpinCol.enabled = false;
                            BladeSlashPar.Stop();
                            if (flagB == "BombReload")
                            {
                                StrayApPortrait.Play("BombReload", 2);
                                Invoke("BombReload", 0.1f);
                            }
                            if (flagB == "BombReloadB" || flagB == "BombShootLockOn")
                            {
                                StrayApPortrait.Play("BombReloadB", 2);
                            }
                        }
                        else if (flag == "false")
                        {
                            HSParticle.Stop();
                            rb.velocity = new Vector2(0.0f, 0.0f);
                            if (flagC != "ScytheOn")
                            {
                                ani.Play("ColliderSlider", 0, 0.0f);
                                //Debug.Log("Sliding");
                                StrayApPortrait.Play("StraySliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                //StrayApPortrait.StopLayer(2);
                                if (flagGround == "On")
                                {
                                    RunDust.Play();
                                }
                                if (flagYoyoSliding == "On")
                                {
                                    StrayApPortrait.Play("YoyoSliding", 2);
                                    YoyoStringObjB.SetActive(true);
                                    TanglerObj.SetActive(true);
                                }
                                YoyoSTPObj.SetActive(false);
                                YoyoSTPObjB.SetActive(false);
                                if (flagC == "ShotOn")
                                {
                                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                                    StrayApPortrait.Play("SliderShotLayer", 2);
                                }
                                if (flagDirection == "Null")
                                {
                                    flag = "true";
                                }
                            }
                        }
                        else if (flag == "SliderRight")
                        {
                            HSParticle.Stop();
                            rb.velocity = new Vector2(SliderSpeed, 0.0f);
                            if (flagC != "ScytheOn")
                            {
                                ani.Play("ColliderSlider", 0, 0.0f);
                                //Debug.Log("Sliding");
                                StrayApPortrait.Play("StraySliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                //StrayApPortrait.StopLayer(2);
                                if (flagGround == "On")
                                {
                                    RunDust.Play();
                                }
                                if (flagYoyoSliding == "On")
                                {
                                    StrayApPortrait.Play("YoyoSliding", 2);
                                }
                                YoyoSTPObj.SetActive(false);
                                YoyoSTPObjB.SetActive(false);
                                if (flagC == "ShotOn")
                                {
                                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                                    StrayApPortrait.Play("SliderShotLayer", 2);
                                }
                            }
                        }
                        else if (flag == "SliderLeft")
                        {
                            HSParticle.Stop();
                            rb.velocity = new Vector2(-SliderSpeed, 0.0f);
                            if (flagC != "ScytheOn")
                            {
                                ani.Play("ColliderSlider", 0, 0.0f);
                                //Debug.Log("Sliding");
                                StrayApPortrait.Play("StraySliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                StrayApPortrait.StopLayer(2);
                                if (flagGround == "On")
                                {
                                    RunDust.Play();
                                }
                                if (flagYoyoSliding == "On")
                                {
                                    StrayApPortrait.Play("YoyoSliding", 2);
                                }
                                YoyoSTPObj.SetActive(false);
                                YoyoSTPObjB.SetActive(false);
                                if (flagC == "ShotOn")
                                {
                                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                                    StrayApPortrait.Play("SliderShotLayer", 2);
                                }
                            }
                        }

                        else if (flag == "Birn")
                        {
                            StrayApPortrait.Play("BombThrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                            StrayApPortrait.StopLayer(2);
                            Invoke("FlagMethod", 0.3f);
                        }
                        else if (flag == "BirnBackRight")
                        {
                            StrayApPortrait.Play("Exprodion", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                            StrayApPortrait.StopLayer(2);
                            Invoke("FlagMethod", 0.2f);
                            Invoke("BirnBackRightMethod", 0.1f);
                        }
                        /*else if(flag == "ScytheJump")
                        {
                            flag = "Scythe";
                        }*/
                    }
                }                

                else if (flag == "BirnBackLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("Exprodion", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    Invoke("FlagMethod", 0.2f);
                    Invoke("BirnBackLeftMethod", 0.1f);
                }

                if (flag == "KeyAction")
                {
                    StrayApPortrait.Play("KeyAction", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    Invoke("FlagMethod", 0.5f);
                }

                if (flag == "Shield")
                {
                    if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
                    {
                        StrayApPortrait.Play("StrayShield", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        Invoke("ShieldExpand2", 0.1f);
                        ShieldCol.enabled = true;
                        //PlayerCol.enabled = false; 
                        SPGage.fillAmount -= 0.01f;
                        SPGageB.fillAmount -= 0.01f;
                    }
                }
                if (flag == "Shield2")
                {
                    if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
                    {
                        StrayApPortrait.Play("StrayShield2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        rb.gravityScale = 0;
                        rb.velocity = Vector3.zero;
                        SPGage.fillAmount -= 0.001f;
                        SPGageB.fillAmount -= 0.001f;
                        if (SPGage.fillAmount == 0 || SPGageB.fillAmount == 0)
                        {
                            FlagMethod();
                        }
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;

                    }
                }

                if (flag == "ShotRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    StrayApPortrait.Play("StrayShotRight", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                }
                if (flag == "ShotLeft")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    StrayApPortrait.Play("StrayShotLeft", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                }

                if (PhoenixObj.activeSelf)
                {
                    SPGage.fillAmount -= 0.001f;
                    SPGageB.fillAmount -= 0.001f;
                    if (SPGage.fillAmount == 0 || SPGageB.fillAmount == 0)
                    {
                        PhoenixMethod();
                    }
                }
                if (RevolvObj.activeSelf)
                {
                    SPGage.fillAmount -= 0.001f;
                    SPGageB.fillAmount -= 0.001f;
                    if (SPGage.fillAmount == 0 || SPGageB.fillAmount == 0)
                    {
                        RevolvingCutter();
                    }
                }
                if (flag == "true" || flag == "Jump" || flag == "false")
                {
                    BombObj.SetActive(false);
                }
                else if (flag == "ArrowShootRight")
                {
                    rb.velocity = Vector3.zero;
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("Arrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                    //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                else if (flag == "ArrowShootLeft")
                {
                    rb.velocity = Vector3.zero;
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("Arrow", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                    //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                if (TimeFlag == "TimeSlow")
                {
                    if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
                    {
                        //StrayApPortrait.Play("StrayShield2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                        StrayApPortrait.Play("TimeSlow", 3);
                        SPGage.fillAmount -= 0.001f;
                        SPGageB.fillAmount -= 0.001f;
                        if (SPGage.fillAmount == 0 || SPGageB.fillAmount == 0)
                        {
                            //Debug.Log("testD");
                            TimeFlagOff();
                        }
                        Time.timeScale = 0.5f;
                    }
                }
                if (TimeFlag == "Off")
                {
                    Time.timeScale = 1f;
                }
                if (flag == "BoomerangRight")
                {
                    StrayApPortrait.Play("Boomerang", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    Invoke("FlagMethod", 0.3f);
                    //rb.gravityScale = 0;
                    rb.velocity = new Vector2(0, AttackJumpMini);
                }
                if (flag == "BoomerangLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("Boomerang", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    Invoke("FlagMethod", 0.3f);
                    //rb.gravityScale = 0;
                    rb.velocity = new Vector2(0, AttackJumpMini);
                }
                if (flag == "Yoyo")
                {
                    StrayApPortrait.Play("YoyoTangler", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    //Invoke("FlagMethod", 1f);
                }
                if (flag == "YoyoRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("YoyoTangler", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);

                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    if (rb.velocity.y > 0 || rb.velocity.y < 0)
                    {
                        rb.velocity = new Vector2(10, 0);
                    }
                }
                if (flag == "YoyoLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("YoyoTangler", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);

                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    if (rb.velocity.y > 0 || rb.velocity.y < 0)
                    {
                        rb.velocity = new Vector2(-10, 0);
                    }
                }
                /*if (flag == "YoyoRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("YoyoAroundTheWorld", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    //Invoke("FlagMethod", 0.5f);
                }
                if (flag == "YoyoLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("YoyoAroundTheWorld", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    //Invoke("FlagMethod", 0.5f);
                }*/
                /*if (flag == "YoyoDown")
                {
                    StrayApPortrait.Play("YoyoSliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }*/
                /*if (flag != "Yoyo")
                {
                    YoyoStringObjB.SetActive(false);
                    TanglerObj.SetActive(false);
                }*/
                if (flag != "false" && flag != "SliderRight" && flag != "SliderLeft")
                {
                    RunDust.Stop();
                }
                if (flag != "Yoyo" && flagYoyoSliding != "On" && flag != "YoyoRight" && flag != "YoyoLeft")
                {
                    YoyoStringObjB.SetActive(false);
                    TanglerObj.SetActive(false);
                }
                /*if (flag != "YoyoRight" && flag != "YoyoLeft")
                {
                    YoyoSTPObj.SetActive(false);
                    YoyoSTPObjB.SetActive(false);
                }*/
                if (flagC == "YoyoOn")
                {
                    if (flagDirection == "Null")
                    {
                        flag = "Yoyo";
                    }
                    /*if (flagDirection == "Right")
                    {
                        flag = "YoyoRight";
                    }
                    if (flagDirection == "Left")
                    {
                        flag = "YoyoLeft";
                    }*/
                }

                if (flag == "Scythe")
                {
                    StrayApPortrait.Play("RidingScytheStart", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    Invoke("ScytheRide", 0.1f);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    if (flagDirection == "Right")
                    {
                        rb.velocity = new Vector2(ScytheSpeed, 0.0f);
                    }
                    if (flagDirection == "Left")
                    {
                        rb.velocity = new Vector2(-ScytheSpeed, 0.0f);
                    }
                }
                if (flag == "Scythe2")
                {
                    StrayApPortrait.Play("RidingScythe", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    ScytheCol.enabled = true;
                    ScytheCutCol.enabled = true;
                    RightJumpCount = 0;
                    LeftJumpCount = 0;
                    if (flagDirection == "Right")
                    {
                        rb.velocity = new Vector2(ScytheSpeed, 0.0f);
                    }
                    if (flagDirection == "Left")
                    {
                        rb.velocity = new Vector2(-ScytheSpeed, 0.0f);
                    }
                }
                if (flag == "ScytheRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("ScytheAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("ScytheReset", 0.4f);
                    ScytheCol.enabled = true;
                    ScytheCutCol.enabled = true;
                    ScytheParObj.transform.localScale = new Vector3(1, 1, 1);
                    ScytheSPParObj.transform.localScale = new Vector3(1, 1, 1);
                }
                if (flag == "ScytheLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("ScytheAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("ScytheReset", 0.4f);
                    ScytheCol.enabled = true;
                    ScytheCutCol.enabled = true;
                    ScytheParObj.transform.localScale = new Vector3(-1, 1, 1);
                    ScytheSPParObj.transform.localScale = new Vector3(-1, 1, 1);
                }
                if (flag != "ScytheRight" && flag != "ScytheLeft")
                {
                    ScytheSPObj.SetActive(false);
                }
                if (flag == "ScytheRotationRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("RidingScytheAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(5, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("ScytheReset", 0.7f);
                    ScytheCol.enabled = true;
                    ScytheCutCol.enabled = true;
                }
                if (flag == "ScytheRotationLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("RidingScytheAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(-5, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("ScytheReset", 0.7f);
                    ScytheCol.enabled = true;
                    ScytheCutCol.enabled = true;
                }
                if (flag == "HammerAttackRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("HammerAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("FlagMethod", 0.4f);
                    HammerCol.enabled = true;
                    HammerCol2.enabled = true;
                    //HammerSoundCol.enabled = true;
                    ScytheParObj.transform.localScale = new Vector3(1, 1, 1);
                }
                if (flag == "HammerAttackLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("HammerAttack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("FlagMethod", 0.4f);
                    HammerCol.enabled = true;
                    HammerCol2.enabled = true;
                    //HammerSoundCol.enabled = true;
                    ScytheParObj.transform.localScale = new Vector3(-1, 1, 1);
                }
                if (flag == "HammerSlidingRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("HammerSliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);

                    ani.Play("ColliderSlider", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    //Invoke("FlagMethod", 0.4f);
                    //Invoke("HammerSliPar", 0.2f);
                    HammerCol.enabled = true;
                    HammerCol2.enabled = true;
                    if (HamerSlideFlag == "Plus")
                    {
                        rb.velocity = new Vector2(20f, 0);
                        Invoke("HammerSlide", 0.1f);
                    }
                    if (HamerSlideFlag == "Minus")
                    {
                        rb.velocity -= new Vector2(2f, 0);
                        if (rb.velocity.x <= 0)
                        {
                            HamerSlideFlag = "Stop";
                            HSParticle.Stop();
                        }
                    }
                    if (HamerSlideFlag == "Stop")
                    {
                        rb.velocity = new Vector2(0, 0);
                        //flagC = "Off";
                        Invoke("FlagCReset", 0.1f);
                        HSParticle.Stop();
                    }
                    if (flagDirection == "Null")
                    {
                        flag = "true";
                        FlagMethod();
                    }
                }
                if (flag == "HammerSlidingLeft")
                {
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("HammerSliding", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    //rb.velocity = new Vector2(-100f, 0);
                    ani.Play("ColliderSlider", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    //Invoke("FlagMethod", 0.4f);
                    //Invoke("HammerSliPar", 0.2f);
                    HammerCol.enabled = true;
                    HammerCol2.enabled = true;
                    if (HamerSlideFlag == "Plus")
                    {
                        rb.velocity = new Vector2(-20f, 0);
                        Invoke("HammerSlide", 0.1f);
                    }
                    if (HamerSlideFlag == "Minus")
                    {
                        rb.velocity += new Vector2(2f, 0);
                        if (rb.velocity.x >= 0)
                        {
                            HamerSlideFlag = "Stop";
                            HSParticle.Stop();
                        }
                    }
                    if (HamerSlideFlag == "Stop")
                    {
                        rb.velocity = new Vector2(0, 0);
                        //flagC = "Off";
                        Invoke("FlagCReset", 0.1f);
                        HSParticle.Stop();
                    }
                    if (flagDirection == "Null")
                    {
                        flag = "true";
                        FlagMethod();
                    }
                }
                if (flag == "HammerSquelch")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("HammerSquelch", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    //rb.velocity = new Vector2(50f, 0);
                    ani.Play("ColliderIdle", 0, 0.0f);
                    StrayApPortrait.StopLayer(2);
                    Invoke("FlagMethod", 0.4f);
                    HammerCol.enabled = true;
                    HammerCol2.enabled = true;
                }
                if (flagC != "HammerOn")
                {
                    HammerCol.enabled = false;
                    HammerCol2.enabled = false;
                }

                if (flag == "BladeRight")
                {
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    //rb.velocity = Vector3.zero;
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    //rb.gravityScale = 0;
                }
                if (flag == "BladeLeft")
                {
                    //rb.velocity = Vector3.zero;
                    //rb.gravityScale = 0;
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                }

                if (flag == "HCMode")
                {
                    //transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    rb.velocity = Vector3.zero;
                    StrayApPortrait.Play("HeartConnection", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                }
                if (flag == "HCMode2")
                {
                    //transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    rb.velocity = Vector3.zero;
                    StrayApPortrait.Play("HeartConnection2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                }
                /*if (flag == "HCModeLeft")
                {
                    //transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    rb.velocity = Vector3.zero;
                    StrayApPortrait.Play("HeartConnection", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                }
                if (flag == "HCMode2Left")
                {
                    //transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    rb.velocity = Vector3.zero;
                    StrayApPortrait.Play("HeartConnection2", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    StrayApPortrait.StopLayer(2);
                    rb.gravityScale = 0;
                }*/

                if (flagButterfly == "On")
                {
                    ButterflyControl();
                    rb.gravityScale = 0;
                    if (flagDirection == "Null")
                    {
                        rb.velocity = Vector3.zero;
                    }
                }
                if (flag == "Butterfly")
                {
                    StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                if (flag == "ScalesUp")
                {
                    StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, 50f);
                    Invoke("ButterflyStopMethod", 0.1f);
                }
                if (flag == "ScalesAdvance")
                {
                    StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    ButterflySpeed = 2000.0f;
                    Invoke("ButterflyStopMethod", 0.1f);
                }
                /*if (flag == "ScalesAdvance")
                {
                    StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(50f, 0);
                    Invoke("ButterflyStopMethod", 0.1f);
                }*/
                if (flag == "ScalesDown")
                {
                    StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(0, -50f);
                    Invoke("ButterflyStopMethod", 0.1f);
                }
                if (flag == "ScalesBack")
                {
                    StrayApPortrait.Play("ButterflyBack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    ButterflySpeed = 2000.0f;
                    Invoke("ButterflyStopMethod", 0.1f);
                }
                /*if (flag == "ScalesBack")
                {
                    StrayApPortrait.Play("ButterflyBack", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    rb.velocity = new Vector2(-50f, 0);
                    Invoke("ButterflyStopMethod", 0.1f);
                }*/
                if (flag == "ButterflyStop")
                {
                    ButterflySpeed = 200.0f;
                    //rb.velocity = Vector3.zero;
                    Invoke("ButterflyMode", 0.1f);
                }

                if (flag == "ThunderRight")
                {
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    Invoke("FlagMethod", 0.9f);
                    StrayApPortrait.Play("ThunderStray", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                if (flag == "ThunderLeft")
                {
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    Invoke("FlagMethod", 0.9f);
                    StrayApPortrait.Play("ThunderStray", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                if (flag == "ThunderUp")
                {
                    rb.velocity = new Vector2(0, AttackJumpMini);
                    Invoke("FlagMethod", 0.9f);
                    StrayApPortrait.Play("ThunderFall", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }
                /*if (flag == "ThunerRotation")
                {
                    Invoke("FlagMethod", 0.9f);
                    StrayApPortrait.Play("StrayRotation", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                }*/
                if (flag == "Meteor")
                {
                    StrayApPortrait.Play("MeteorFall", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    Invoke("FlagMethod", 0.5f);
                }
                if (flag == "BladeRush")
                {
                    gameObject.layer = LayerMask.NameToLayer("Through");
                    flagY = "Stop";
                    //rb.velocity = Vector3.zero;
                    transform.localScale = new Vector3(1.1f, 1.1f, 1);
                    StrayApPortrait.Play("StrayBladeRush", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    if (flagVector == "Off")
                    {
                        rb.gravityScale = 0;
                        rb.velocity = new Vector2(35, 0);
                    }
                    if (flagVector == "BladeRush")
                    {
                        if (rb.velocity.x >= 0.0f)
                        {
                            rb.gravityScale = 0;
                            rb.velocity -= new Vector2(1.5f, 0);
                        }
                    }
                }
                if (flag == "BladeRushBack")
                {
                    gameObject.layer = LayerMask.NameToLayer("Through");
                    flagY = "Stop";
                    //rb.velocity = Vector3.zero;
                    transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                    StrayApPortrait.Play("StrayBladeRush", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                    if (flagVector == "Off")
                    {
                        rb.gravityScale = 0;
                        rb.velocity = new Vector2(-35, 0);
                    }
                    if (flagVector == "BladeRush")
                    {
                        if (rb.velocity.x <= 0.0f)
                        {
                            rb.gravityScale = 0;
                            rb.velocity -= new Vector2(-1.5f, 0);
                        }
                    }
                }
                /*if (flagGround == "On")
                {
                    StabCountZero();
                }*/
            }
        }               
    }

    public void TimeFlagOff()
    {
        if (this.gameObject.activeSelf)
        {
            //Debug.Log("testC");
            TimeFlag = "Off";
            StrayApPortrait.StopLayer(3);
        }
    }
    /*
    public void ChainLockMethod()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                ChainObj.SetActive(true);
            }
        }                     
    }
    public void ChainLockFalseMethod()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                ChainObj.SetActive(false);
            }
        }                     
    }
    */
    public void DamageMethod()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                if (ShieldCol.enabled == false)
                {
                    GameControlScript.health -= 1;
                    StartCoroutine("Damage");
                    flag = "Damage";
                }
            }
        }                     
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                /*
                if (col.gameObject.tag == "Obstruction")
                {
                    //WindObj.SetActive(true);
                    WindCol.enabled = true;
                }
                */
                if (col.gameObject.tag == "Ground")
                {
                    flagGround = "On";
                }
                
                if (ShieldCol.enabled == false)
                {
                    if (col.gameObject.tag == "Ground2")
                    {
                        //Debug.Log("Collider");
                        //Destroy(this.gameObject);
                        Invoke("ThisDisable", 0.1f);
                        /*
                        GameControlScript.health -= 9;
                        Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
                        FlagMethod();
                        TimeFlagOff();
                        */
                    }
                    if (col.gameObject.tag == "Health-1")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 1;
                        StartCoroutine("Damage");
                        flag = "Damage";
                        //Debug.Log(GameControlScript.health);
                    }
                    if (col.gameObject.tag == "Health-1B")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 1;
                        flag = "Damage";
                    }
                    if (col.gameObject.tag == "Health-3")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 3;
                        flag = "Damage";
                    }
                    if (col.gameObject.tag == "LaserEnd")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 1;
                        flag = "Damage";
                    }
                }
                if (col.gameObject.tag == "Coin")
                {
                    CoinAudioSource.pitch = 1;
                    CoinAudioSource.Play();
                    if (SPGage.fillAmount <= 1 || SPGageB.fillAmount <= 1)
                    {
                        SPGage.fillAmount += 0.042f;
                        SPGageB.fillAmount += 0.042f;
                    }
                    /*
                    if (ChainLock1.activeSelf || ChainLock2.activeSelf || ChainLock3.activeSelf || ChainLock4.activeSelf || ChainLock5.activeSelf || ChainLock6.activeSelf || ChainLock7.activeSelf || ChainLock8.activeSelf || ChainLock9.activeSelf)
                    {
                        ChainLock1.SetActive(false);
                        ChainLock2.SetActive(false);
                        ChainLock3.SetActive(false);
                        ChainLock4.SetActive(false);
                        ChainLock5.SetActive(false);
                        ChainLock6.SetActive(false);
                        ChainLock7.SetActive(false);
                        ChainLock8.SetActive(false);
                        ChainLock9.SetActive(false);
                    }
                    */
                }
                if (col.gameObject.tag == "CoinFull")
                {
                    CoinAudioSource.pitch = 1.5f;
                    CoinAudioSource.Play();
                    if (SPGage.fillAmount <= 1 || SPGageB.fillAmount <= 1)
                    {
                        SPGage.fillAmount += 1f;
                        SPGageB.fillAmount += 1f;
                    }
                    /*
                    if (ChainLock1.activeSelf || ChainLock2.activeSelf || ChainLock3.activeSelf || ChainLock4.activeSelf || ChainLock5.activeSelf || ChainLock6.activeSelf || ChainLock7.activeSelf || ChainLock8.activeSelf || ChainLock9.activeSelf)
                    {
                        ChainLock1.SetActive(false);
                        ChainLock2.SetActive(false);
                        ChainLock3.SetActive(false);
                        ChainLock4.SetActive(false);
                        ChainLock5.SetActive(false);
                        ChainLock6.SetActive(false);
                        ChainLock7.SetActive(false);
                        ChainLock8.SetActive(false);
                        ChainLock9.SetActive(false);
                    }
                    */
                }
            }
        }                     
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                if (col.gameObject.tag == "Ground")
                {
                    flagGround = "Off";
                }
                /*
                if (col.gameObject.tag == "Obstruction")
                {
                    WindCol.enabled = false;
                    //WindObj.SetActive(false);
                }
                */
            }
        }            
    }
    public void ThisDisable()
    {
        if (PauseFlag == "Off")
        {
            //this.gameObject.SetActive(false);
            GameControlScript.health -= 9;
            Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
            FlagMethod();
            TimeFlagOff();
        }            
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                if (ShieldCol.enabled == false)
                {
                    if (trcol.gameObject.tag == "Ground2")
                    {
                        Invoke("ThisDisable", 0.1f);
                        //Debug.Log("trCollider");
                        /*
                        GameControlScript.health -= 9;
                        Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
                        FlagMethod();
                        TimeFlagOff();
                        */
                    }

                    if (trcol.gameObject.tag == "Health-1")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 1;
                        StartCoroutine("Damage");
                        flag = "Damage";
                    }

                    if (trcol.gameObject.tag == "Health-1B")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 1;
                        flag = "Damage";
                    }
                    if (trcol.gameObject.tag == "Health-3")
                    {
                        ScreenShakeController.instance.StartShake(.1f, .1f);
                        GameControlScript.health -= 3;
                        flag = "Damage";
                    }
                    /*
                    if (trcol.gameObject.tag == "Obstruction")
                    {
                        WindCol.enabled = true;
                        //WindObj.SetActive(true);
                    }
                    */
                }
                if (trcol.gameObject.tag == "Gate2")
                {
                    GameConS.Episode8PanelActive();
                    //Debug.Log("tet");
                }
                if (trcol.gameObject.tag == "Coin")
                {
                    CoinAudioSource.pitch = 1;
                    CoinAudioSource.Play();
                    if (SPGage.fillAmount <= 1 || SPGageB.fillAmount <= 1)
                    {
                        SPGage.fillAmount += 0.042f;
                        SPGageB.fillAmount += 0.042f;
                    }
                }
            }
        } 
        if(trcol.gameObject.tag == "AnyPause")
        {
            RunDust.playbackSpeed = 0;
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            RunDust.playbackSpeed = 1;
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (PauseFlag == "Off")
        {
            if (trcol.gameObject.tag == "Obstruction")
            {
                if (transform.localScale.x == 1.1f)
                {
                    this.transform.Translate(WindMoveX, 0, 0);
                }
            }
            if (trcol.gameObject.tag == "Gate")
            {
                if (transform.localScale.x == 1.1f)
                {
                    this.transform.Translate(WindMoveX * 3, 0, 0);
                }
            }
        }            
    }
    public void Disable()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                if (flag == "Damage2")
                {
                    FlagMethod();
                    TimeFlagOff();
                    GameControlScript.health -= 9;
                    Instantiate(EffectPrefab, this.transform.position, this.transform.rotation);
                }
            }
        }                     
    }

    public void DamageMotion()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                flag = "Damage2";
            }
        }                     
    }

    IEnumerator Damage()
    {
        if (this.gameObject.activeSelf)
        {
            //レイヤーをThroughに変更
            gameObject.layer = LayerMask.NameToLayer("Through");
            //while文を10回ループ
            int count = 10;
            while (count > 0)
            {
                //透明にする
                camera.cullingMask &= ~(1 << 9);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                //元に戻す
                camera.cullingMask |= (1 << 9);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                count--;
            }
            //レイヤーをPlayerに戻す
            gameObject.layer = LayerMask.NameToLayer("Player");
            if(ContinueFlag == "Continue")
            {
                ShieldCol.enabled = false;
            }
        }
    }
    public void jumpButton()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off" && flag != "HCMode")
                {
                    if (flagHC == "Off")
                    {
                        flagDirection = "Up";
                        if (flagC == "Off")
                        {
                            if (flagY != "Stop")
                            {
                                if (rb.velocity.y == 0)
                                {
                                    flag = "Jump";
                                    ani.Play("ColliderRotation", 0, 0.0f);
                                    //StrayApPortrait.Play("StrayRotation", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                    rb.velocity = Vector2.up * jumpSpeed;
                                }
                            }
                        }
                        if (flagC == "GekiOn")
                        {
                            flag = "Geki";
                            script.GekiGenerate();
                            if (rb.velocity.y >= 0 || rb.velocity.y <= 0)
                            {
                                rb.velocity = new Vector2(0, AttackJumpMini);
                            }
                        }
                        /*if(flagC == "ScytheOn")
                        {
                            if (rb.velocity.y == 0)
                            {
                                flag = "ScytheJump";
                                ani.Play("ColliderRotation", 0, 0.0f);
                                rb.velocity = Vector2.up * 30f;
                            }
                        }*/
                        if (flagC == "ScytheOn")
                        {
                            if (rb.velocity.y == 0)
                            {
                                rb.velocity = Vector2.up * jumpSpeed;
                            }
                        }
                    }
                }
                if (flagButterfly == "On")
                {
                    flagDirection = "Up";
                }

                if (flag == "HCMode")
                {
                    flagDirection = "Up";
                }
            }
        }                         
    }
    
    public void RightJump()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off")
                {
                    if (flagHC == "Off")
                    {
                        if (JoyColExitFlag == "On")
                        {
                            flagDirection = "Right";

                            if (flagC == "Off")
                            {
                                if (flagY != "Stop")
                                {
                                    if (RightJumpCount < MaxRightJumpCount)
                                    {
                                        ani.Play("ColliderRotation", 0, 0.0f);
                                        StrayApPortrait.Play("StrayRotation", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                        rb.velocity = new Vector2(moveSpeed, moveSpeed);
                                        RightJumpCount++;

                                        /*if (flagB == "BladeVisible")
                                        {
                                            BladeSpinCol.enabled = true;
                                            ///BladeSpinPar.Play();
                                            //BTrail.enabled = true;
                                            BladeCollider2.enabled = true;
                                            StrayApPortrait.Play("StrayBladeRotate", 2);
                                        }*/
                                    }
                                }
                            }

                            if (flagC == "GekiOn")
                            {
                                flag = "Geki2";
                                script.GekiGenerate();
                            }
                            if (flagC == "ShotOn")
                            {
                                flag = "ShotRight";
                            }
                            if (flagC == "ArrowOn")
                            {
                                flag = "ArrowShootRight";
                            }
                            if (flagC == "YoyoOn")
                            {
                                flagYoyoSliding = "Off";
                                flag = "YoyoRight";
                                //YoyoStringObjB.SetActive(false);
                                //TanglerObj.SetActive(false);
                            }
                            /*if (flagC == "ScytheOn")
                            {
                                if (rb.velocity.y == 0)
                                {
                                    rb.velocity = Vector2.right * moveSpeed;
                                    //rb.velocity = new Vector2(moveSpeed, 0);
                                }
                                if (rb.velocity.y < 0 || rb.velocity.y > 0)
                                {
                                    if (RightJumpCount < MaxRightJumpCount)
                                    {
                                        rb.velocity = new Vector2(moveSpeed, 10f);
                                        RightJumpCount++;
                                    }                            
                                }
                            }*/
                        }
                    }
                    if (flagHC == "On")
                    {
                        transform.localScale = new Vector3(1.1f, 1.1f, 1);
                        /*if(flag == "HCModeLeft")
                        {
                            flag = "HCMode";
                        }
                        if (flag == "HCMode2Left")
                        {
                            flag = "HCMode2";
                        }*/
                        MonaObj.transform.localScale = new Vector3(-0.27f, 0.27f, 1);
                        flagDirection = "Right";
                    }
                }
                if (flagButterfly == "On")
                {
                    flagDirection = "Right";
                }
            }
        }                    
    }

    public void LeftJump()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off")
                {
                    if (flagHC == "Off")
                    {
                        if (JoyColExitFlag == "On")
                        {
                            flagDirection = "Left";

                            if (flagC == "Off")
                            {
                                if (flagY != "Stop")
                                {
                                    if (LeftJumpCount < MaxLeftJumpCount)
                                    {
                                        ani.Play("ColliderRotation", 0, 0.0f);
                                        StrayApPortrait.Play("StrayRotation", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                                        rb.velocity = new Vector2(-moveSpeed, moveSpeed);
                                        LeftJumpCount++;

                                        /*if (flagB == "BladeVisible")
                                        {
                                            BladeSpinCol.enabled = true;
                                            //BladeSpinPar.Play();
                                            //BTrail.enabled = true;
                                            BladeCollider2.enabled = true;
                                            StrayApPortrait.Play("StrayBladeRotate", 2);
                                        }*/
                                    }
                                }
                            }

                            if (flagC == "GekiOn")
                            {
                                flag = "Geki3";
                                script.GekiGenerate();
                            }
                            if (flagC == "ShotOn")
                            {
                                flag = "ShotLeft";
                            }
                            if (flagC == "ArrowOn")
                            {
                                flag = "ArrowShootLeft";
                            }
                            if (flagC == "YoyoOn")
                            {
                                flagYoyoSliding = "Off";
                                flag = "YoyoLeft";
                                //YoyoStringObjB.SetActive(false);
                                //TanglerObj.SetActive(false);
                            }
                            /*if(flagC == "ScytheOn")
                            {
                                if (rb.velocity.y == 0)
                                {
                                    rb.velocity = Vector2.left * moveSpeed;
                                    //rb.velocity = Vector2.left * moveSpeed;
                                    //rb.velocity = new Vector2(-moveSpeed, 0);
                                }
                                if (rb.velocity.y < 0 || rb.velocity.y > 0)
                                {
                                    if (LeftJumpCount < MaxRightJumpCount)
                                    {
                                        rb.velocity = new Vector2(-moveSpeed, 10f);
                                        LeftJumpCount++;
                                    }                            
                                }
                            }*/
                        }
                    }
                    if (flagHC == "On")
                    {
                        transform.localScale = new Vector3(-1.1f, 1.1f, 1);
                        /*if (flag == "HCMode")
                        {
                            flag = "HCModeLeft";
                        }
                        if (flag == "HCMode2")
                        {
                            flag = "HCMode2Left";
                        }*/
                        MonaObj.transform.localScale = new Vector3(0.27f, 0.27f, 1);
                        flagDirection = "Left";
                        //Debug.Log("test");
                    }
                }
                if (flagButterfly == "On")
                {
                    flagDirection = "Left";
                }
            }
        }        
    }
    public void JoyColExitMethod()
    {
        if (PauseFlag == "Off")
        {
            JoyColExitFlag = "On";
        }            
    }
    public void Slider()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off")
                {
                    if (flagHC == "Off")
                    {
                        if (flagC != "ScytheOn")
                        {
                            JoyColExitFlag = "Off";
                            //Debug.Log("test");
                            flagDirection = "Down";
                            this.gameObject.layer = LayerMask.NameToLayer("Player2");
                            Invoke("LayerMaskReset", 0.1f);
                            if (rb.velocity.y == 0)
                            {
                                flag = "false";
                            }
                            if (flagC == "YoyoOn")
                            {
                                flagYoyoSliding = "On";
                            }
                        }
                        if (flagC == "ScytheOn")
                        {
                            rb.velocity = new Vector2(0, 0);
                        }
                        if (flagC == "HammerOn")
                        {
                            flag = "HammerAttackRight";
                        }
                    }
                }
                if (flagButterfly == "On" || flagHC == "On")
                {
                    flagDirection = "Down";
                }
            }
        }                    
    }
    public void SliderRight()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off")
                {
                    if (flagHC == "Off")
                    {
                        if (flagC != "ScytheOn")
                        {
                            JoyColExitFlag = "Off";
                            //Debug.Log("test");
                            flagDirection = "DownRight";
                            /*this.gameObject.layer = LayerMask.NameToLayer("Player2");
                            Invoke("LayerMaskReset", 0.1f);*/
                            if (rb.velocity.y == 0)
                            {
                                flag = "SliderRight";
                            }
                            if (flagC == "YoyoOn")
                            {
                                flagYoyoSliding = "On";
                            }
                        }
                        /*if (flagC == "ScytheOn")
                        {
                            if (rb.velocity.y == 0)
                            {
                                rb.velocity = Vector2.right * 10f;
                                //rb.velocity = new Vector2(10f, 0);
                            }
                            if (rb.velocity.y < 0 || rb.velocity.y > 0)
                            {
                                if (RightJumpCount < MaxRightJumpCount)
                                {
                                    rb.velocity = new Vector2(moveSpeed, 10f);
                                    RightJumpCount++;
                                }                        
                            }
                        }*/
                        if (flagC == "HammerOn")
                        {
                            flag = "HammerAttackRight";
                        }
                    }
                }
            }
        }        
    }
    public void SliderLeft()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf && ShieldCol.enabled == false)
            {
                if (flagButterfly == "Off")
                {
                    if (flagHC == "Off")
                    {
                        if (flagC != "ScytheOn")
                        {
                            JoyColExitFlag = "Off";
                            //Debug.Log("test");
                            flagDirection = "DownLeft";
                            /*this.gameObject.layer = LayerMask.NameToLayer("Player2");
                            Invoke("LayerMaskReset", 0.1f);*/
                            if (rb.velocity.y == 0)
                            {
                                flag = "SliderLeft";
                            }
                            if (flagC == "YoyoOn")
                            {
                                flagYoyoSliding = "On";
                            }
                        }
                        /*if (flagC == "ScytheOn")
                        {
                            if (rb.velocity.y == 0)
                            {
                                rb.velocity = Vector2.left * 10f;
                            }
                            if (rb.velocity.y < 0 || rb.velocity.y > 0)
                            {
                                if (LeftJumpCount < MaxRightJumpCount)
                                {
                                    rb.velocity = new Vector2(-moveSpeed, 10f);
                                    LeftJumpCount++;
                                }                        
                            }
                        }*/
                        if (flagC == "HammerOn")
                        {
                            flag = "HammerAttackLeft";
                        }
                    }
                }
            }
        }        
    }

    public void LayerMaskReset()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }                    
    }
    public void DirectionNull()
    {
        if (PauseFlag == "Off")
        {
            flagDirection = "Null";
            transform.localScale = new Vector3(1.1f, 1.1f, 1);
            //YoyoSTPObj.SetActive(false);
            //YoyoSTPObjB.SetActive(false);
            if (flagButterfly == "Off")
            {
                if (flagC == "Off")
                {
                    if (rb.velocity.y == 0)
                    {
                        flag = "true";
                        //flagB = "false";
                    }
                    else if (rb.velocity.y < 0 || rb.velocity.y > 0)
                    {
                        flag = "Jump";
                    }
                    if (flagC == "ScytheOn")
                    {
                        rb.velocity = new Vector2(0, 0);
                    }
                }
                if (flagC == "ShotOn")
                {
                    flag = "ShotRight";
                }
            }
        }                
    }
    public void FlagMethod()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                Count = 0;
                audioLoop.Stop();
                //RushCountRight = 0;
                //RushCountLeft = 0;
                flagY = "Off";
                StabColObj.SetActive(false);
                StabColObjB.SetActive(false);
                flagVector = "Off";
                StabDirector.Stop();
                StabDirectorBack.Stop();
                //ThunderSphirePar.Stop();
                flagHC = "Off";
                HamerSlideFlag = "Plus";
                //SquelchCol.enabled = false;
                HammerCol.enabled = false;
                HammerCol2.enabled = false;
                HammerSoundCol.enabled = false;
                ScytheCol.enabled = false;
                ScytheCutCol.enabled = false;
                RunDust.Stop();
                //YoyoStringObj.SetActive(false);
                /*YoyoSTPObj.SetActive(false);
                YoyoSTPObjB.SetActive(false);
                TanglerObj.SetActive(false);*/
                transform.localScale = new Vector3(1.1f, 1.1f, 1);
                //flagPhoenix = "Off";
                flagDirection = "Null";
                flagC = "Off";
                flagYoyoSliding = "Off";
                //flagBoomerang = "Off";
                rb.gravityScale = 15;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //PlayerCol.enabled = true;
                //BladeSpinPar.Stop();
                //BladeSpinCol.enabled = false;
                BladeSlashPar.Stop();
                if (rb.velocity.y == 0)
                {
                    flag = "true";
                    //flagB = "false";
                }
                else if (rb.velocity.y < 0 || rb.velocity.y > 0)
                {
                    flag = "Jump";
                }
                if (ShieldCol.enabled == true)
                {
                    ShieldCol.enabled = false;
                }
                if (script != null)
                {
                    script.DestroyPrefab();
                    //Debug.Log("gekifx");
                }
                //Debug.Log("test");
            }
        }                    
    }

    public void FlagBReset()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                flagB = "false";
                //BTrail.enabled = false;
                BladeSlashPar.Stop();
                //BladeSpinCol.enabled = false;
            }
        }                    
    }

    public void GekiAttack()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                flagC = "GekiOn";
                if (rb.velocity.y == 0 && flagDirection == "Null")
                {
                    script.GekiGenerate();
                    flag = "Geki";
                }
                if ((rb.velocity.y < 0 && flagDirection == "Null") || (rb.velocity.y > 0 && flagDirection == "Null"))
                {
                    flag = "Geki4";
                }
            }
        }                    
    }

    public void GekiThrowFx()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                if (script != null)
                {
                    script.GekiGenerate3();
                    //Debug.Log("gekifx");
                }
            }
        }                    
    }

    public void BladeAttack()
    {
        if (PauseFlag == "Off")
        {
            if (this.gameObject.activeSelf)
            {
                StrayApPortrait.Play("StrayBladeStart", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
                //BladeCollider2.enabled = true;
                flagC = "BladeOn";
                /*if (rb.velocity.y < 0 || rb.velocity.y > 0)
                {
                    //BTrail.enabled = false;
                    //EffectCollider.enabled = true;
                    BladeCollider1.enabled = true;
                    //flag = "BladeStart";
                    flag = "BladeRotate";
                    //Invoke("FlagMethod", 0.5f);
                }
                if (rb.velocity.y == 0)
                {
                    rb.velocity = new Vector2(0, 50f);
                    //ani.Play("GekiAnim1", 0, 0.0f);
                    flag = "BladeRotate";
                    //Invoke("FlagMethod", 0.5f);
                }
                if (flagDirection == "Left")
                {
                    flag = "IaiNukiLeft";
                }
                if (flagDirection == "Right")
                {
                    flag = "IaiNukiRight";
                }*/
                //flag = "Blade";
                if (flagDirection != "Left")
                {
                    flag = "BladeRight";
                    //rb.velocity = new Vector2(25f, 0);
                }
                if (flagDirection == "Left")
                {
                    flag = "BladeLeft";
                    //rb.velocity = new Vector2(-25f, 0);
                }
                if (flagDirection != "Right" && flagDirection != "Left")
                {
                    flag = "Blade";
                }
                //flagC = "BladeMode";
            }
        }                    
    }
    public void BladeFXA()
    {
        if (PauseFlag == "Off")
        {
            BladeSlashPar.Play();
        }            
    }
    public void BladeFXB()
    {
        FlagMethod();
    }
    public void BladeEndFlag()
    {
        flag = "BladeEnd";
    }
    /*public void ReturnAccessBlade()
    {
        if (this.gameObject.activeSelf)
        {
            flagB = "BladeVisible";
            //Debug.Log("アクセス成功！！");
        }
    }*/

    /*public void MoveMethod()
    {
        if (this.gameObject.activeSelf)
        {
            flag = "Blade1";
        }            
    }*/

    public void ShieldExpand()
    {
        if (this.gameObject.activeSelf)
        {
            if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
            {
                flag = "Shield";
            }
        }            
    }
    public void ShieldExpand2()
    {
        if (this.gameObject.activeSelf)
        {
            flag = "Shield2";
            audioLoop.Play();
        }            
    }
    public void Shieldfalse()
    {
        if (this.gameObject.activeSelf)
        {
            FlagMethod();
            
        }            
    }

    public void LockOnOff()
    {
        if (KeyActObj.activeSelf == false)
        {
            LockCol.enabled = true;
            Invoke("LockColFalse", 0.1f);
            //LockBombScript.instance.LBTLPlayMethod();
            KeyActObj.SetActive(true);
            if (flag != "false")
            {
                flag = "KeyAction";
            }

            if (flagLock == "Off")
            {
                LockMethodOn();
            }
            else if (flagLock == "On")
            {
                LockMethodOff();
            }
        }            
    }
    public void LockMethodOn()
    {
        if (this.gameObject.activeSelf)
        {
            flagLock = "On";
        }            
    }
    public void LockMethodOff()
    {
        if (this.gameObject.activeSelf)
        {
            flagLock = "Off";
        }            
    }
    public void LockColFalse()
    {
        if (PauseFlag == "Off")
        {
            LockCol.enabled = false;
        }            
    }

    public void ShotAttack()
    {
        if (this.gameObject.activeSelf)
        {
            flagC = "ShotOn";
            if (flagDirection == "Null")
            {
                flag = "ShotRight";
            }
        }            
    }
    public void ShotFx()
    {
        if (this.gameObject.activeSelf)
        {
            audioSource.PlayOneShot(ShotSound);
            ShotParticleA.Play();
            GameObject obj17 = ObjectPooler17.current.GetPooledObject();
            if (obj17 == null) return;
            obj17.transform.position = ShotPosRight.transform.position;
            obj17.transform.rotation = ShotPosRight.transform.rotation;
            obj17.SetActive(true);
        }            
    }
    public void ShotFx2()
    {
        if (this.gameObject.activeSelf)
        {
            audioSource.PlayOneShot(ShotSound);
            ShotParticleB.Play();
            GameObject obj17 = ObjectPooler17.current.GetPooledObject();
            if (obj17 == null) return;
            obj17.transform.position = ShotPosLeft.transform.position;
            obj17.transform.rotation = ShotPosLeft.transform.rotation;
            obj17.SetActive(true);
        }            
    }
    public void SliderShotFx()
    {
        audioSource.PlayOneShot(ShotSound);
        if (flagDirection == "Down" || flagDirection == "DownRight")
        {
            SliderShotRight();
        }
        if (flagDirection == "DownLeft")
        {
            SliderShotLeft();
        }
    }
    public void SliderShotRight()
    {
        if (this.gameObject.activeSelf)
        {
            ShotParticleSliderRight.Play();
            GameObject obj17 = ObjectPooler17.current.GetPooledObject();
            if (obj17 == null) return;
            obj17.transform.position = ShotSliderPosRight.transform.position;
            obj17.transform.rotation = ShotSliderPosRight.transform.rotation;
            obj17.SetActive(true);
        }
    }
    public void SliderShotLeft()
    {
        if (this.gameObject.activeSelf)
        {
            ShotParticleSliderLeft.Play();
            GameObject obj17 = ObjectPooler17.current.GetPooledObject();
            if (obj17 == null) return;
            obj17.transform.position = ShotSliderPosLeft.transform.position;
            obj17.transform.rotation = ShotSliderPosLeft.transform.rotation;
            obj17.SetActive(true);
        }
    }

    public void PhoenixMethod()
    {
        if (this.gameObject.activeSelf)
        {
            if (SPGage.fillAmount != 0)
            {
                if (PhoenixObj.activeSelf)
                {
                    PhoenixClose();
                }
                else
                {
                    Invoke("PhoenixActive", 0.01f);
                }
            }
        }                 
    }
    public void PhoenixActive()
    {
        if (this.gameObject.activeSelf)
        {
            PhoenixObj.SetActive(true);
        }
    }
    public void PhoenixClose()
    {
        if (this.gameObject.activeSelf)
        {
            PhSc.CloseMethod();
            /*PhoenixAni.SetBool("EnableBool", false);
            PhoenixAni.SetBool("DisableBool", true);*/
            Invoke("PhoenixFalse", 3.0f);
        }            
    }
    public void PhoenixFalse()
    {
        if (this.gameObject.activeSelf)
        {
            PhoenixObj.SetActive(false);
            if (PatternName3.text == "◇フェニックス")
            {
                PatternName3.text = "";
            }
            if (PatternName2.text == "◇フェニックス")
            {
                PatternName2.text = "";
            }
        }
    }

    public void BombMethod()
    {
        if (this.gameObject.activeSelf)
        {
            if (SPGage.fillAmount != 0)
            {
                if (flag != "Birn")
                {
                    if (flagDirection == "Null")
                    {
                        flag = "Birn";
                        BombObj.SetActive(true);
                        //Debug.Log("test");
                    }
                }
                if (flag != "BirnBackRight")
                {
                    if (flagDirection == "Right")
                    {
                        flag = "BirnBackRight";
                        BombObj.SetActive(true);
                        //Debug.Log("test");
                    }
                }
                if (flag != "BirnBackLeft")
                {
                    if (flagDirection == "Left")
                    {
                        flag = "BirnBackLeft";
                        BombObj.SetActive(true);
                        //Debug.Log("test");
                    }
                }
            }                
        }            
    }
    public void BirnFX()
    {
        if (this.gameObject.activeSelf)
        {
            rb.velocity = new Vector2(0, AttackJumpMini);
            BoSc.BirnMethod();
            SPGage.fillAmount -= 0.05f;
            SPGageB.fillAmount -= 0.05f;
        }            
    }
    public void BirnBackRightMethod()
    {
        if (this.gameObject.activeSelf)
        {
            rb.velocity = new Vector2(-15, 15);
            //BoSc.BirnMethod();
        }
    }
    public void BirnBackLeftMethod()
    {
        if (this.gameObject.activeSelf)
        {
            rb.velocity = new Vector2(15, 15);
            //BoSc.BirnMethod();
        }
    }

    public void ArrowMethod()
    {
        if (this.gameObject.activeSelf)
        {
            flagC = "ArrowOn";
            if (flagDirection == "Null")
            {
                flag = "ArrowShootRight";
            }
        }                 
    }
    public void ArrowShootFX()
    {
        if (this.gameObject.activeSelf)
        {
            if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
            {
                SPGage.fillAmount -= 0.05f;
                SPGageB.fillAmount -= 0.05f;
                ArrowCentor();
                ArrowUp();
                ArrowDown();
            }
        }            
    }
    public void ArrowCentor()
    {
        if (this.gameObject.activeSelf)
        {
            GameObject obj = ObjectPooler30.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.parent = ArrowPos.gameObject.transform;
            obj.transform.position = ArrowPos.transform.position;
            obj.transform.rotation = ArrowPos.transform.rotation;
            obj.SetActive(true);
        }            
    }
    public void ArrowUp()
    {
        if (this.gameObject.activeSelf)
        {
            GameObject obj = ObjectPooler30.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.parent = ArrowPosUp.gameObject.transform;
            obj.transform.position = ArrowPosUp.transform.position;
            obj.transform.rotation = ArrowPosUp.transform.rotation;
            obj.SetActive(true);
        }            
    }
    public void ArrowDown()
    {
        if (this.gameObject.activeSelf)
        {
            GameObject obj = ObjectPooler30.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.parent = ArrowPosDown.gameObject.transform;
            obj.transform.position = ArrowPosDown.transform.position;
            obj.transform.rotation = ArrowPosDown.transform.rotation;
            obj.SetActive(true);
        }         
    }

    public void TimeSlow()
    {
        if (this.gameObject.activeSelf)
        {
            if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
            {
                //Debug.Log("test");
                if (TimeFlag == "Off")
                {
                    //Debug.Log("testA");
                    TimeFlag = "TimeSlow";
                }
                else
                {
                    //Debug.Log("testB");
                    TimeFlagOff();
                    //Invoke("TimeFlagOff", 0.01f);                
                }
            }
        }                     
    }

    /*public void BoomerangMethod()
    {
        if (this.gameObject.activeSelf)
        {
            ChargeParticle.Play();
            // 長押し検知
            this.downBool = true;

            // カウント用変数を0に戻す
            this.time = 0;
            // カウント開始
            StartCoroutine(LongCount());
            flagBoomerang = "Off";
        }                  
    }
    private IEnumerator LongCount()
    {
        if (this.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1);
            if (this.downBool == true)
            {
                this.time += 1;
                if (time == 2)
                {
                    flagBoomerang = "L1";
                    ChargeLevelObj.SetActive(true);
                }
                else
                {
                    // まだ5秒経っていないなら処理を繰り返す
                    StartCoroutine(LongCount());
                    yield break;
                }
            }
            else
            {
                // 長押し検知が解除されてるならコルーチン終了
                yield break;
            }
        }            
    }*/
    public void BoomerangFlagA()
    {
        if (this.gameObject.activeSelf)
        {
            //this.downBool = false;
            //ChargeParticle.Stop();
            if (flagDirection == "Left")
            {
                flag = "BoomerangLeft";
            }
            else
            {
                flag = "BoomerangRight";
            }
        }              
    }
    public void BoomerangShotFX()
    {
        if (this.gameObject.activeSelf)
        {
            if (flagDirection == "Left")
            {
                GameObject obj = ObjectPooler33.current.GetPooledObject();
                if (obj == null) return;
                //obj.transform.parent = ArrowPos.gameObject.transform;
                obj.transform.position = ArrowPos.transform.position;
                //obj.transform.rotation = ArrowPos.transform.rotation;
                obj.SetActive(true);
                /*if (flagBoomerang == "L1")
                {
                    GameObject obj34 = ObjectPooler34.current.GetPooledObject();
                    if (obj34 == null) return;
                    //obj34.transform.parent = ArrowPos.gameObject.transform;
                    obj34.transform.position = ArrowPos.transform.position;
                    //obj34.transform.rotation = ArrowPos.transform.rotation;
                    obj34.SetActive(true);

                    GameObject obj35 = ObjectPooler35.current.GetPooledObject();
                    if (obj35 == null) return;
                    //obj35.transform.parent = ArrowPos.gameObject.transform;
                    obj35.transform.position = ArrowPos.transform.position;
                    //obj35.transform.rotation = ArrowPos.transform.rotation;
                    obj35.SetActive(true);
                }*/
            }
            else
            {
                GameObject obj = ObjectPooler36.current.GetPooledObject();
                if (obj == null) return;
                //obj.transform.parent = ArrowPos.gameObject.transform;
                obj.transform.position = ArrowPos.transform.position;
                //obj.transform.rotation = ArrowPos.transform.rotation;
                obj.SetActive(true);
                /*if (flagBoomerang == "L1")
                {
                    GameObject obj37 = ObjectPooler37.current.GetPooledObject();
                    if (obj37 == null) return;
                    //obj37.transform.parent = ArrowPos.gameObject.transform;
                    obj37.transform.position = ArrowPos.transform.position;
                    //obj37.transform.rotation = ArrowPos.transform.rotation;
                    obj37.SetActive(true);

                    GameObject obj38 = ObjectPooler38.current.GetPooledObject();
                    if (obj38 == null) return;
                    //obj38.transform.parent = ArrowPos.gameObject.transform;
                    obj38.transform.position = ArrowPos.transform.position;
                    //obj38.transform.rotation = ArrowPos.transform.rotation;
                    obj38.SetActive(true);                    
                }*/
            }
        }            
    }

    public void YoyoMethod()
    {
        if (this.gameObject.activeSelf)
        {
            flagC = "YoyoOn";
            if (flagDirection == "Left")
            {
                flag = "YoyoLeft";
            }
            if (flagDirection == "Right")
            {
                flag = "YoyoRight";
            }
            if (flagDirection == "Null")
            {
                flag = "Yoyo";
            }
            if (flagDirection == "Up")
            {
                flag = "Yoyo";
            }
            if (flagDirection == "Down")
            {
                flagYoyoSliding = "On";
                flag = "false";
            }
            if(flagDirection == "DownRight")
            {
                flagYoyoSliding = "On";
                flag = "SliderRight";
            }
            if (flagDirection == "DownLeft")
            {
                flagYoyoSliding = "On";
                flag = "SliderLeft";
            }
        }
    }
    public void SideRoopFX()
    {
        //YoyoStringObj.SetActive(true);
        YoyoSTPObj.SetActive(true);
        Invoke("ActiveLoopB", 0.1f);
    }
    public void ActiveLoopB()
    {
        if (PauseFlag == "Off")
        {
            YoyoSTPObjB.SetActive(true);
        }            
    }
    public void TanglerFX()
    {
        YoyoStringObjB.SetActive(true);
        TanglerObj.SetActive(true);
    }
    public void YoyoSlidingFX()
    {
        YoyoStringObjB.SetActive(true);
        TanglerObj.SetActive(true);
    }

    public void ScytheMethod()
    {
        //Debug.Log("tet");
        if (this.gameObject.activeSelf)
        {
            //Debug.Log("tet");            
            if (flagDirection == "Left" || flagDirection == "DownLeft")
            {
                flag = "ScytheLeft";
            }
            if (flagDirection == "Right" || flagDirection == "DownRight")
            {
                flag = "ScytheRight";
            }
            //↓消したらダメ
            /*if (flagC != "ScytheOn")
            {
                //Debug.Log("tet");            
                if (flagDirection == "Left" || flagDirection == "DownLeft")
                {
                    flag = "ScytheLeft";
                }
                if (flagDirection == "Right" || flagDirection == "DownRight")
                {
                    flag = "ScytheRight";
                }
            }       
            if(flagC == "ScytheOn")
            {
                if (flagDirection == "Left" || flagDirection == "DownLeft")
                {
                    flag = "ScytheRotationLeft";
                }
                if (flagDirection == "Right" || flagDirection == "DownRight")
                {
                    flag = "ScytheRotationRight";
                }
            }*/
            if (flagDirection == "Up" || flagDirection == "Null" || flagDirection == "Down")
            {
                if (flagC == "ScytheOn")
                {
                    Invoke("ScytheFlagOff", 0.05f);
                }
                if (flagC != "ScytheOn")
                {
                    //Debug.Log("tet");
                    flag = "Scythe";
                    flagC = "ScytheOn";
                }
            }
        }
    }
    public void ScytheRide()
    {
        if (PauseFlag == "Off")
        {
            flag = "Scythe2";
        }            
    }
    public void ScytheFlagOff()
    {
        if (PauseFlag == "Off")
        {
            FlagMethod();
            flagC = "Off";
        }            
    }
    public void ScytheReset()
    {
        ScytheSPObj.SetActive(false);
        if (flagC == "ScytheOn")
        {
            flag = "Scythe";
        }
        if (flagC != "ScytheOn")
        {
            FlagMethod();
        }
    }
    public void ScytheSPFX()
    {
        ScytheSlash.Play();
        ScytheSPObj.SetActive(true);
        ScytheSlashSP.Play();
    }

    public void RevolvingCutter()
    {
        if (RevolvObj.activeSelf)
        {
            //Debug.Log("test1");
            Invoke("RevolvActive", 0.01f);
        }
        if (RevolvObj.activeSelf == false)
        {
            //Debug.Log("test2");
            if (SPGage.fillAmount != 0)
            {
                RevolvObj.SetActive(true);
            }
        }
    }
    public void RevolvActive()
    {
        if (this.gameObject.activeSelf)
        {
            RevolvObj.SetActive(false);
            if (PatternName2.text == "◇リボルビングエッジ")
            {
                PatternName2.text = "";
            }
            if (PatternName3.text == "◇リボルビングエッジ")
            {
                PatternName3.text = "";
            }
        }
    }

    public void HammerMethod()
    {
        flagC = "HammerOn";
        if (flagDirection == "Right" || flagDirection == "Up" || flagDirection == "Null" || flagDirection == "DownRight" || flagDirection == "Down")
        {
            flag = "HammerAttackRight";
            //Invoke("ScytheSlashEffect", 0.2f);
        }
        if (flagDirection == "Left" || flagDirection == "DownLeft")
        {
            flag = "HammerAttackLeft";
            //Invoke("ScytheSlashEffect", 0.2f);
        }
        /*if (flagDirection == "DownRight" || flagDirection == "Down")
        {
            flag = "HammerSlidingRight";
            HamerSlideFlag = "Plus";
        }
        if (flagDirection == "DownLeft")
        {
            flag = "HammerSlidingLeft";
            HamerSlideFlag = "Plus";
        }*/
        /*if (flagDirection == "Up" || flagDirection == "Null")
        {
            flag = "HammerSquelch";
            rb.velocity = new Vector2(0, 25f);
            Invoke("HammerSquelchRB", 0.2f);
        }*/
    }
    public void ScytheSlashEffect()
    {
        ScytheSlash.Play();        
    }
    public void HammerSquelchRB()
    {
        rb.velocity = new Vector2(0, -50f);
        //SquelchCol.enabled = true;
    }
    public void HammerAttackFX()
    {
        //Debug.Log("test");
        HAParticle.Play();
        HammerSoundCol.enabled = true;
    }
    public void HammerSlide()
    {
        //HSParticle.Play();
        HamerSlideFlag = "Minus";
    }
    public void HammerSlidingFX()
    {
        HSParticle.Play();        
    }
    public void WhooshFX()
    {
        SoundScript.SoundMethod4();
    }
    public void FlagCReset()
    {
        flagC = "Off";
    }
    /*public void HammerSlideLeft()
    {
        HSParticleLeft.Play();
        HamerSlideFlag = "Minus";
    }*/

    public void FishMethod()
    {
        if(GameControlScript.health != 9)
        {
            if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
            {
                ChargeEndPar.Play();
                GameControlScript.health += 1;
                SPGage.fillAmount -= 0.1f;
                SPGageB.fillAmount -= 0.1f;
                SoundScript.SoundMethod6();
            }
        }      
    }

    public void HCMethod()
    {
        gameObject.layer = LayerMask.NameToLayer("CantTouch");
        //transform.position = new Vector3(-8.3f, -0.6f, 0f);
        flag = "HCMode";
        flagHC = "On";
        Invoke("MonaStop", 1.0f);
        //Invoke("HeartConnectionEndFX", 4.0f);
        //Invoke("MonaMove", 8.0f);
    }
    public void MonaStop()
    {
        if (PauseFlag == "Off")
        {
            MScript.FlagOff();
        }            
    }
    public void MonaMove()
    {
        MScript.FlagOn();
    }
    public void HeartConnectionFX()
    {
        HeartObj.SetActive(true);
        //HCPar.Play();
        flag = "HCMode2";
    }
    public void HeartConnectionEndFX()
    {
        FlagMethod();
        HeartObj.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Player");
        PatternName1.text = "";
    }
    public void ButterflyMode()
    {
        flagButterfly = "On";
        flag = "Butterfly";
        StrayApPortrait.Play("StrayButterfly", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
    }
    public void ButterflyModeOff()
    {
        //FlagMethod();
        flagButterfly = "Off";
    }
    void ButterflyControl()
    {
        //dir.x = Input.GetAxisRaw("Horizontal");
        //dir.y = Input.GetAxisRaw("Vertical");
        if (joystick.InputDir != Vector2.zero)
        {
            dir = joystick.InputDir;
        }
        //Debug.Log("test");
        rb.velocity = new Vector2(dir.x * ButterflySpeed, dir.y * ButterflySpeed) * Time.deltaTime;
    }
    public void ScalesExplosion()
    {
        if (SPGage.fillAmount != 0 || SPGageB.fillAmount != 0)
        {
            SPGage.fillAmount -= 0.05f;
            SPGageB.fillAmount -= 0.05f;
            /*if (flagDirection == "Up")
            {
                flag = "ScalesUp";
                GameObject obj = ObjectPooler34.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosRight.transform.rotation;
                obj.SetActive(true);
                SoundScript.SoundMethod8();
            }
            if (flagDirection == "Right")
            {
                flag = "ScalesAdvance";
                GameObject obj = ObjectPooler34.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosRight.transform.rotation;
                obj.SetActive(true);
                SoundScript.SoundMethod8();
            }
            if (flagDirection == "DownLeft" || flagDirection == "DownRight" || flagDirection == "Down")
            {
                flag = "ScalesDown";
                GameObject obj = ObjectPooler34.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosRight.transform.rotation;
                obj.SetActive(true);
                SoundScript.SoundMethod8();
            }
            if (flagDirection == "Left")
            {
                flag = "ScalesBack";
                GameObject obj = ObjectPooler34.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosRight.transform.rotation;
                obj.SetActive(true);
                SoundScript.SoundMethod8();
            }*/
            if(flagDirection != "Null")
            {
                if(rb.velocity.x >= 0)
                {
                    flag = "ScalesAdvance";
                    GameObject obj = ObjectPooler34.current.GetPooledObject();
                    if (obj == null) return;
                    obj.transform.position = this.transform.position;
                    obj.SetActive(true);
                    SoundScript.SoundMethod8();
                }
                if (rb.velocity.x < 0)
                {
                    flag = "ScalesBack";
                    GameObject obj = ObjectPooler40.current.GetPooledObject();
                    if (obj == null) return;
                    obj.transform.position = this.transform.position;
                    obj.SetActive(true);
                    SoundScript.SoundMethod8();
                }
            }
            if (flagDirection == "Null")
            {
                GameObject obj = ObjectPooler34.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosRight.transform.rotation;
                obj.SetActive(true);
            }
        }        
    }
    public void ButterflyStopMethod()
    {
        flag = "ButterflyStop";
    }
    /*public void ThunderMethod()
    {
        flagThunder = "ThunderMode";
    }
    public void ThunderMethodOff()
    {
        flagThunder = "Off";
    }*/
    public void ThunderFall()
    {
        if(flagDirection == "Right")
        {
            //ThunderSphirePar.Stop();
            flag = "ThunderRight";
        }
        if (flagDirection == "Left")
        {
            //ThunderSphirePar.Stop();
            flag = "ThunderLeft";
        }
        if (flagDirection == "DownLeft" || flagDirection == "DownRight" || flagDirection == "Down" || flagDirection == "Null" || flagDirection == "Up")
        {
            /*
            //Debug.Log("test");
            GameObject obj = ObjectPooler37.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = ThunderPosA.transform.position;
            //obj.transform.rotation = ShotPosRight.transform.rotation;
            obj.SetActive(true);
            //ThunderParB.Play();
            //ThunderSphirePar.Play();
            */
            ThunderObjSide.transform.position = ThunderPosA.transform.position;
            ThunderDirectorSide.Play();
            flag = "ThunderUp";
        }
    }
    public void ThunderFX()
    {
        /*
        //ThunderPar.Play();
        GameObject obj = ObjectPooler37.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = ThunderPosB.transform.position;
        //obj.transform.rotation = ShotPosRight.transform.rotation;
        obj.SetActive(true);
        */
        ThunderObjUp.transform.position = ThunderPosB.transform.position;
        ThunderDirectorUp.Play();
    }

    public void CoinChangeMethod()
    {
        CoinActObj.SetActive(true);
        CoinChangeCol.enabled = true;
        Invoke("CoinChangeOff", 0.2f);
    }
    public void CoinChangeOff()
    {
        if (PauseFlag == "Off")
        {
            CoinChangeCol.enabled = false;
        }            
    }

    public void MagnetMethod()
    {
        MagnetActObj.SetActive(true);
        MagnetCol.enabled = true;
        Invoke("MagnetOff", 0.2f);
    }
    public void MagnetOff()
    {
        if (PauseFlag == "Off")
        {
            MagnetCol.enabled = false;
        }            
    }

    public void MeteorMethod()
    {
        flag = "Meteor";
        MeteorShootA();
        Invoke("MeteorShootB", 0.2f);
        Invoke("MeteorShootC", 0.4f);
        Invoke("MeteorShootD", 0.6f);
        Invoke("MeteorShootE", 0.8f);
    }
    public void MeteorShootA()
    {
        if (PauseFlag == "Off")
        {
            GameObject obj = ObjectPooler39.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = MeteorPosA.transform.position;
            obj.SetActive(true);
        }            
    }
    public void MeteorShootB()
    {
        if (PauseFlag == "Off")
        {
            GameObject obj = ObjectPooler39.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = MeteorPosB.transform.position;
            obj.SetActive(true);
        }        
    }
    public void MeteorShootC()
    {
        if (PauseFlag == "Off")
        {
            GameObject obj = ObjectPooler39.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = MeteorPosC.transform.position;
            obj.SetActive(true);
        }            
    }
    public void MeteorShootD()
    {
        if (PauseFlag == "Off")
        {
            GameObject obj = ObjectPooler39.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = MeteorPosD.transform.position;
            obj.SetActive(true);
        }            
    }
    public void MeteorShootE()
    {
        if (PauseFlag == "Off")
        {
            GameObject obj = ObjectPooler39.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = MeteorPosE.transform.position;
            obj.SetActive(true);
        }            
    }

    public void BladeRushMethod()
    {
        flagC = "Blade";
        if (flagDirection == "Left")
        {
            if (RushCountLeft < MaxRushCountLeft)
            {
                RushCountLeft++;
                flag = "BladeRushBack";
                Invoke("FlagMethod", 0.6f);
                Invoke("StabEnd", 0.61f);
                Invoke("StabCountZero", 1.0f);
            }                
        }
        if (flagDirection == "DownLeft" || flagDirection == "DownRight" || flagDirection == "Down" || flagDirection == "Null" || flagDirection == "Up" || flagDirection == "Right")
        {
            if (RushCountRight < MaxRushCountRight)
            {
                RushCountRight++;
                flag = "BladeRush";
                Invoke("FlagMethod", 0.6f);
                Invoke("StabEnd", 0.61f);
                Invoke("StabCountZero", 1.0f);
            }
        }        
    }
    public void StabFX()
    {
        if (flag == "BladeRush")
        {
            flagVector = "BladeRush";
            StabDirector.Play();
        }        
        if (flag == "BladeRushBack")
        {
            flagVector = "BladeRush";
            StabDirectorBack.Play();
        }
    }
    public void StabEnd()
    {
        if (PauseFlag == "Off")
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            flag = "Jump";
            rb.velocity = new Vector2(0, -AttackJumpMini);
        }            
    }
    public void StabCountZero()
    {
        if (PauseFlag == "Off")
        {
            RushCountRight = 0;
            RushCountLeft = 0;
        }            
    }
    /*void OnDisable() //パターンウィンドウを開いた際にも発動してしまう。pauseの影響。
    {
        FlagMethod();
        TimeFlagOff();
    }*/

    public void AnimPauseMethod()
    {
        StrayApPortrait.PauseAll();
        ThunderDirectorUp.Pause();
        ThunderDirectorSide.Pause();
        PauseFlag = "On";
        if(flag == "Damage")
        {
            StopCoroutine("Damage");
        }        
        if (flag != "HCMode" && flag != "HCMode2")
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
        }
        /*
        if(flagButterfly == "On")
        {
            ButterflyMode();
        }
        */
    }
    public void AnimResumeMethod()
    {
        PauseFlag = "Off";
        ThunderDirectorUp.Resume();
        ThunderDirectorSide.Resume();
        StrayApPortrait.ResumeAll();
        if (flag == "Damage")
        {
            StartCoroutine("Damage");
        }        
        if (flag != "HCMode" && flag != "HCMode2")
        {
            rb.gravityScale = 15;
        }
        /*
        if (flagButterfly == "On")
        {
            ButterflyMode();
        }
        */
    }
}
