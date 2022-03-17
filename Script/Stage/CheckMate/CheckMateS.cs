using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CheckMateS : MonoBehaviour
{
    public Info1 info;
    public AdsLoadScript AdsLS;
    public ContinueButton ConBS;
    public ScoreManager ScoreManagerS;
    public Animator PanelAnim;
    public ParticleSystem StartPar;
    public GameObject PawnObj, LastBattleObj, KnightObj, BishopObj, LukeObj, CompleteUIObj, StartUIObj, ScorePanelObj;
    public PawnScript PawnS;
    public KnightScript KS;
    public BishopScript BS;
    public LukeScript LS;
    public LastBoss LBS;
    public int Count;
    public AudioSource BGMASours;
    public string Flag, PauseFlag;
    private ScoreManager sm;
    public int scoreValue;
    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        BGMASours.volume = info.BGMVolume;
        BGMASours.Play();
        Count = 0;
        //Flag = "Start";
        PauseFlag = "Off";
        //VSLastBattle();
        StartUIObj.SetActive(true);
        StartPar.Play();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3f);
            if (PauseFlag == "Off")
            {
                if(Flag == "Start")
                {
                    if(PawnObj.activeSelf == false)
                    {
                        //Debug.Log("test");
                        VSPawn();
                        Flag = "Pawn";
                    }
                }
                if(Flag == "Pawn")
                {
                    if(PawnObj.activeSelf == false)
                    {
                        VSKnight();
                        Flag = "Knight";
                    }
                }
                if (Flag == "Knight")
                {
                    if (KnightObj.activeSelf == false)
                    {
                        VSBishop();
                        Flag = "Bishop";
                    }
                }
                if (Flag == "Bishop")
                {
                    if (BishopObj.activeSelf == false)
                    {
                        VSLuke();
                        Flag = "Luke";
                    }
                }
                if (Flag == "Luke")
                {
                    if (LukeObj.activeSelf == false)
                    {
                        VSLastBattle();
                        Flag = "LastBattle";
                    }
                }
                if (Flag == "LastBattle")
                {
                    if (LastBattleObj.activeSelf == false)
                    {
                        CompleteUIObj.SetActive(true);
                        StartPar.Play();
                        sm.AddScore(scoreValue);
                        Flag = "End";
                        AdsLS.EpiFlagOn();
                    }
                }
                if (Flag == "End")
                {
                    ScorePanelObj.SetActive(true);
                    PanelAnim.SetBool("GetExpBool", true);
                    PanelAnim.SetBool("ContinueBool", false);
                    PanelAnim.SetBool("GetExpEndBool", false);
                    PanelAnim.SetBool("GetExpEpiBool", false);
                    ScoreManagerS.ResultMethod();
                    ConBS.EpiFlagMethod();
                    Flag = "PanelEnable";
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
        }
    }
    public void VSPawn()
    {
        PawnObj.SetActive(true);
        PawnS.PawnEnable();
        //Debug.Log("test1");
    }
    public void VSKnight()
    {
        KnightObj.SetActive(true);
        KS.KnightEnable();
    }
    public void VSBishop()
    {
        BishopObj.SetActive(true);
        BS.BishopEnable();
    }
    public void VSLuke()
    {
        BishopObj.SetActive(true);
        LS.LukeEnable();
    }
    public void VSLastBattle()
    {
        LastBattleObj.SetActive(true);
        LBS.KingQueenEnable();
    }
}
