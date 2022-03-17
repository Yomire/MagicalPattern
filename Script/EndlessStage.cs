using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class EndlessStage : MonoBehaviour
{
    public GameObject WakuseiObj, QueenObj, QueenSkyObj, GroundMoveObj, CountObj, HintObj, JointGenerateObj, KnightObj, LukeObj, BishopObj, KingObj, KingSkyObj, ADBossObj, 
        ACBossObj, ARBossObj, MoonObj, CryArm1, CryArm2, LevelObj, StartEffectObj;
    public WakuseiScript WS;
    public QueenScript QS;
    public QSkyScript QSkyS;
    public KnightScript KS;
    public LukeScript LS;
    public BishopScript BS;
    public KingScript KingS;
    public KingSkyScript KSkyS;
    public ADBossScript ADS;
    public ACScript ACS;
    public ARageScriptVer2 ARS;
    public MoonScript MoonS;
    public CryArmScript CArmS1, CArmS2;
    public int Count, LevelCount;
    public float GroundMoveX, EndPos_X, MoonPosUp;
    public string GroundFlag, Flag, LevelFlag;
    public ParticleSystem SkyPar;
    public LevelGenerateScript LevelS;
    public AudioClip NormalBGMClip, ChessBGMClip;
    public AudioSource BGMASours;
    public Collider2D GroundCol;
    public GameControlScript GCS;
    bool isCalledOnce = false;
    public Info1 info;
    void Start()
    {
        //VSARBoss();
        LevelCount = 0;
        Count = 0;
        GroundFlag = "Ground";
        LevelFlag = "NumberChoice";
        SkyPar.Stop();
        Flag = null;
        BGMASours.clip = NormalBGMClip;
        BGMASours.Play();
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        BGMASours.volume = info.BGMVolume;
    }
    public void StageStartMethod()
    {
        StartEffectObj.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(GroundFlag == "SkyReady")
        {
            GroundMoveObj.transform.Translate(GroundMoveX, 0, 0);
            if (GroundMoveObj.transform.localPosition.x <= EndPos_X)
            {
                HintObj.SetActive(false);
                CountObj.SetActive(false);
                Count = 0;
                GroundFlag = "Sky";
                GroundMoveObj.transform.position = new Vector3(30, 0, 0);
                GroundCol.enabled = false;
            }
        }
        if (GroundFlag == "GroundReady")
        {
            GroundMoveObj.transform.Translate(GroundMoveX, 0, 0);
            if (GroundMoveObj.transform.localPosition.x <= 0)
            {
                CountObj.SetActive(false);
                Count = 0;
                GroundFlag = "Ground";
                //GroundMoveObj.transform.position = new Vector3(30, 0, 0);
            }
        }
    }

    public void VSWakusei()
    {
        WakuseiObj.SetActive(true);
        WS.WakuseiEnable();
    }
    public void VSQueenOnLand()
    {
        QueenObj.SetActive(true);
        QS.QueenEnabled();
    }
    public void VSQueenOnSky()
    {
        QueenSkyObj.SetActive(true);
        QSkyS.QueenEnabledOnSky();
        CountObj.SetActive(true);
        Flag = "QSky";
        HintObj.SetActive(true);

        SkyPar.Play();
        if (CryArm1.activeSelf)
        {
            CArmS1.Disable();
        }
        if (CryArm2.activeSelf)
        {
            CArmS2.Disable();
        }
    }
    public void VSKnight()
    {
        KnightObj.SetActive(true);
        KS.KnightEnable();
    }
    public void VSLuke()
    {
        LukeObj.SetActive(true);
        LS.LukeEnable();
    }
    public void VSBishop()
    {
        BishopObj.SetActive(true);
        BS.BishopEnable();
    }
    public void VSKing()
    {
        KingObj.SetActive(true);
        KingS.KingEnable();
    }
    public void VSKingOnSky()
    {
        KingSkyObj.SetActive(true);
        KSkyS.KingEnabledOnSky();
        CountObj.SetActive(true);
        Flag = "QSky";
        HintObj.SetActive(true);

        SkyPar.Play();
        if (CryArm1.activeSelf)
        {
            CArmS1.Disable();
        }
        if (CryArm2.activeSelf)
        {
            CArmS2.Disable();
        }
    }
    public void VSADBoss()
    {
        ADBossObj.SetActive(true);
        ADS.DisapprovalEnable();
    }
    public void VSACBoss()
    {
        ACBossObj.SetActive(true);
        ACS.ACEnable();
    }
    public void VSARBoss()
    {
        ARBossObj.SetActive(true);
        ARS.ARageEnable();
    }
    public void TGGBLevel()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableTGGB();
    }
    public void LeafLevel()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableLeaf();
    }
    public void Mix1Level()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableMix1();
    }
    public void LockLevel()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableLock();
    }
    public void Mix2Level()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableMix2();
    }
    public void SkyMixLevel()
    {
        CountObj.SetActive(true);
        HintObj.SetActive(true);
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableSkyMix();
        Flag = "QSky";
        SkyPar.Play();
        if (CryArm1.activeSelf)
        {
            CArmS1.Disable();
        }
        if (CryArm2.activeSelf)
        {
            CArmS2.Disable();
        }
    }
    public void Mix3Level()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableMix3();
    }
    public void BonusLevel()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableBonus();
    }
    public void BonusBlockLevel()
    {
        LevelObj.SetActive(true);
        LevelS.LevelOnEnableBonusBlock();
    }

    public void CountMethod()
    {
        if(Flag == "QSky")
        {
            if (GroundFlag == "Ground")
            {
                Count++;
                SkyPar.Play();
                if (Count == 5)
                {
                    GroundFlag = "SkyReady";
                    JointGenerateObj.SetActive(false);
                    GCS.SkyMethod();
                }
            }
            if (GroundFlag == "Sky")
            {
                Count++;
                SkyPar.Stop();
                if (Count == 5)
                {
                    JointGenerateObj.SetActive(true);
                    GroundFlag = "GroundReady";
                    GroundCol.enabled = true;
                    GCS.GroundMethod();
                }
            }
        }        
    }
    
    public void LevelCountMethod()
    {
        if(LevelFlag == "NumberChoice")
        {
            LevelCount = Random.Range(1, 100);
        }    
        if(LevelFlag == "Disapproval" || LevelFlag == "Cry" || LevelFlag == "Rage" || LevelFlag == "WakuseiReady" || LevelFlag == "Level" || LevelFlag == "LevelSky" || LevelFlag == "Wakusei")
        {
            if(BGMASours.volume == 0)
            {
                VolumeChangeUp();
                BGMASours.clip = NormalBGMClip;
                BGMASours.Play();
            }
        }
        if (LevelFlag == "KingOnSky" || LevelFlag == "King" || LevelFlag == "Bishop" || LevelFlag == "Luke" || LevelFlag == "Knight" || LevelFlag == "QueenOnSky" || LevelFlag == "Queen")
        {
            if (BGMASours.volume == 0)
            {
                VolumeChangeUp();
                BGMASours.clip = ChessBGMClip;
                BGMASours.Play();
            }
        }
    }
    public void LevelChoiceMethod()
    {
        if (!isCalledOnce)
        {
            isCalledOnce = true;
            StartEffectObj.SetActive(true);
        }
        if (LevelFlag == "NumberChoice" && LevelObj.activeSelf == false)
        {
            if (LevelCount >= 1 && LevelCount <= 6) //6%
            {
                if (ADBossObj.activeSelf == false)
                {
                    LevelFlag = "Disapproval";
                    VSADBoss();
                    if(BGMASours.clip == ChessBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 7 && LevelCount <= 12) //6%
            {
                if (ACBossObj.activeSelf == false)
                {
                    LevelFlag = "Cry";
                    VSACBoss();
                    if (BGMASours.clip == ChessBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 13 && LevelCount <= 18) //6%
            {
                if (ARBossObj.activeSelf == false)
                {
                    LevelFlag = "Rage";
                    VSARBoss();
                    if (BGMASours.clip == ChessBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 19 && LevelCount <= 23) //5%
            {
                if (KingSkyObj.activeSelf == false)
                {
                    LevelFlag = "KingOnSky";
                    VSKingOnSky();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 24 && LevelCount <= 28) //5%
            {
                if (KingObj.activeSelf == false)
                {
                    LevelFlag = "King";
                    VSKing();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 29 && LevelCount <= 31) //3%
            {
                if (BishopObj.activeSelf == false)
                {
                    LevelFlag = "Bishop";
                    VSBishop();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 32 && LevelCount <= 34) //3%
            {
                if (LukeObj.activeSelf == false)
                {
                    LevelFlag = "Luke";
                    VSLuke();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 35 && LevelCount <= 37) //3%
            {
                if (KnightObj.activeSelf == false)
                {
                    LevelFlag = "Knight";
                    VSKnight();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 38 && LevelCount <= 42) //5%
            {
                if (QueenSkyObj.activeSelf == false)
                {
                    LevelFlag = "QueenOnSky";
                    VSQueenOnSky();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 43 && LevelCount <= 47) //5%
            {
                if (QueenObj.activeSelf == false)
                {
                    LevelFlag = "Queen";
                    VSQueenOnLand();
                    if (BGMASours.clip == NormalBGMClip)
                    {
                        VolumeChange();
                    }
                }
            }
            if (LevelCount >= 48 && LevelCount <= 50) //3%
            {
                if (WakuseiObj.activeSelf == false)
                {
                    LevelFlag = "WakuseiReady";
                    if (BGMASours.clip == ChessBGMClip)
                    {
                        VolumeChange();
                    }
                    if (MoonObj.transform.localPosition.y <= MoonPosUp)
                    {
                        MoonS.UpMethod();
                    }                    
                }
            }
            if (LevelCount >= 51 && LevelCount <= 54) //4%
            {
                TGGBLevel();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 55 && LevelCount <= 58) //4%
            {
                LeafLevel();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 59 && LevelCount <= 66) //8%
            {
                Mix1Level();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 67 && LevelCount <= 74) //8%
            {
                LockLevel();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 75 && LevelCount <= 82) //8%
            {
                Mix2Level();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 83 && LevelCount <= 90) //8%
            {
                SkyMixLevel();
                LevelFlag = "LevelSky";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 91 && LevelCount <= 98) //8%
            {
                Mix3Level();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 99 && LevelCount <= 99) //1%
            {
                BonusLevel();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
            if (LevelCount >= 100 && LevelCount <= 100) //1%
            {
                BonusBlockLevel();
                LevelFlag = "Level";
                if (BGMASours.clip == ChessBGMClip)
                {
                    VolumeChange();
                }
            }
        }
        if (MoonObj.transform.localPosition.y >= MoonPosUp)
        {
            if(LevelFlag == "WakuseiReady")
            {
                VSWakusei();
                LevelFlag = "Wakusei";
            }
        }
    }
    public void ReChoiceMethod()
    {
        if(LevelFlag == "Disapproval")
        {
            if(ADBossObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Cry")
        {
            if (ACBossObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Rage")
        {
            if (ARBossObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "KingOnSky")
        {
            if (KingSkyObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
                GroundFlag = "GroundReady";
                GroundCol.enabled = true;
                JointGenerateObj.SetActive(true);
            }
        }
        if (LevelFlag == "King")
        {
            if (KingObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Bishop")
        {
            if (BishopObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Luke")
        {
            if (LukeObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Knight")
        {
            if (KnightObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "QueenOnSky")
        {
            if (QueenSkyObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
                GroundFlag = "GroundReady";
                GroundCol.enabled = true;
                JointGenerateObj.SetActive(true);
            }
        }
        if (LevelFlag == "Queen")
        {
            if (QueenObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                //LevelFlag = "NumberChoice";
            }
        }
        if (LevelFlag == "Wakusei")
        {
            if (WakuseiObj.activeSelf == false)
            {
                if(MoonObj.transform.localPosition.y >= MoonPosUp)
                {
                    Invoke("NumReady", 0.01f);
                    //LevelFlag = "NumberChoice";
                    MoonS.DownMethod();
                }                
            }
        }
        if (LevelFlag == "Level")
        {
            if (LevelObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
            }
        }
        if (LevelFlag == "LevelSky")
        {
            if (LevelObj.activeSelf == false)
            {
                Invoke("NumReady", 0.01f);
                GroundFlag = "GroundReady";
                GroundCol.enabled = true;
                JointGenerateObj.SetActive(true);
            }
        }

        if (LevelFlag == "NumberChoiceReady")
        {
            LevelFlag = "NumberChoice";
        }
    }

    public void NumReady()
    {
        LevelFlag = "NumberChoiceReady";
    }

    public void VolumeChange()
    {
        StartCoroutine("VolumeDown");
    }
    public void VolumeChangeUp()
    {
        StartCoroutine("VolumeUp");
    }
    IEnumerator VolumeDown()
    {
        while (BGMASours.volume > 0)
        {
            BGMASours.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator VolumeUp()
    {
        while (BGMASours.volume < info.BGMVolume)
        {
            BGMASours.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
