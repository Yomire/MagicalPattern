using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Pause : MonoBehaviour
{
    public Rigidbody2D rb;
    public float StartGravity;
    //Pausable script;
    LockPattern script;
    public AudioSource SEASource1, SEASource2, SEASource3, SEASourceLoop, SEASourceLoop2, SEASourceLoop3;
    public ParticleSystem MonaSphere, LukeLaserPar, MonaStrayLaserPar, LukeLaserB1, LukeLaserB2, WSparklePar1, WSparklePar2,
        GearASparklePar1, GearASparklePar2, GearASparklePar3, GearASparklePar4, GearASparklePar5, GearASparklePar6, GearASparklePar7, GearASparklePar8,
        WBackPar1, WBackPar2, WBackPar3, WBackPar4, WBackPar5, WBackPar6, WBackPar7, WBackPar8, WBackPar9, WBackPar10,
        BigGearLeftPar, HugeGearPar1, HugeGearPar2, HugeGearPar3, HugeGearPar4, HugeGearPar5, HugeGearPar6, HugeGearPar7,
        JetPar1, JetPar2, JetPar3, JetPar4, JetPar5, JetPar6, JetPar7, JetPar8, JetPar9, JetPar10, TrueLukeLaser, TrueLukeLaserStartPar, TrueLukeLaserEndPar,
        JetB1, JetB2, JetB3, JetB4, JetB5, JetB6, LukeSparkle, LukeRunDustPar, LukeRushPar, LukeTackle1, LukeTackle2, LukeTackle3, 
        KnightSparcle, BurnGearPar1, BurnGearPar2, WFallPar1, WFallPar2, WFallPar3, WBloomPar1, WBloomPar2, WBloomPar3, WBloomPar4, WBloomPar5, WBloomPar6, WBloomPar7, WBloomPar8, WBloomPar9, 
        RageMarkPar1, RageMarkPar2, RageMarkPar3, RageMarkPar4, RageMarkPar5, RageMarkPar6, RageMarkPar7, RageMarkPar8, RageMarkPar9, RageMarkPar10, RageMarkPar11, RageMarkPar12,
        RageMarkPar13, RageMarkPar14, RageMarkPar15, RageMarkPar16, RageMarkPar17, 
        RageThunderPar1, RageThunderPar2, RageThunderPar3, RageThunderPar4, RageThunderPar5, RageThunderPar6, RageThunderPar7, RageThunderPar8, RageThunderPar9, 
        RageDrumPar1, RageDrumPar2, RageDrumPar3, RageDrumPar4, RageDrumPar5, RageDrumPar6, RageDrumPar7, RageDrumPar8;
    public Endless EndlessScript;
    public MonaObjScript MonaScript;
    public MonaScript MonaScript2;
    public Player PlayerScript;
    public Collider2D QueenLegCol1, QueenLegCol2, AnyPauseCol;
    public PlayableDirector StabTL1, StabTL2, FOPTL;
    public TrailRenderer GearTrail1, GearTrail2, Gear8SetTrail1, Gear8SetTrail2, Gear8SetTrail3, Gear8SetTrail4, Gear8SetTrail5, Gear8SetTrail6, Gear8SetTrail7, Gear8SetTrail8,
        LukeEyeTrail, KnightTrail1, KnightTrail2, KnightTrail3, KnightTrail4, KnightTrail5 , KnightTrail6;
    public string TutorialFlag, CheckmateFlag;
    //public Grid GridA1, GridA2;

    void Start()
    {

        //Debug.Log(StartGravity);
        //rb = GetComponent<Rigidbody2D>();
        StartGravity = rb.gravityScale;

        //script = GameObject.Find("PausableObjects").GetComponent<Pausable>();
        script = GameObject.Find("Grid").GetComponent<LockPattern>();
        //GridA1 = GameObject.Find("TGGB2").GetComponent<Grid>();
        //GridA2 = GameObject.Find("TGGB2").GetComponent<Grid>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pause")
        {
            PauseOnMethod();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pause")
        {
            PauseOffMethod();
        }
    }

    public void QLegColMethod()
    {
        QueenLegCol1.enabled = true;
        QueenLegCol2.enabled = true;
    }

    public void PauseOnMethod()
    {
        //script.Pause();
        Pauser.Pause();

        rb.gravityScale = 0;
        //Debug.Log(rb.gravityScale);
        rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        SEASource1.Pause();
        SEASource2.Pause();
        SEASource3.Pause();
        SEASourceLoop.Pause();
        SEASourceLoop2.Pause();
        SEASourceLoop3.Pause();
        MonaSphere.playbackSpeed = 0;
        MonaStrayLaserPar.playbackSpeed = 0;
        if (MonaScript != null)
        {
            MonaScript.AnimPauseMethod();
        }
        if (MonaScript2 != null)
        {
            MonaScript2.AnimPauseMethod();
        }
        if (PlayerScript != null)
        {
            PlayerScript.AnimPauseMethod();
        }        
        //Invoke("AnyEnableMethod", 0.01f);
        StabTL1.Pause();
        StabTL2.Pause();
        AnyPauseCol.enabled = true;
        EndlessScript.enabled = false;
        if (TutorialFlag != "On")
        {
            Invoke("QLegColMethod", 0.01f);
            LukeLaserPar.playbackSpeed = 0;
            LukeLaserB1.playbackSpeed = 0;
            LukeLaserB2.playbackSpeed = 0;
            WSparklePar1.playbackSpeed = 0;
            WSparklePar2.playbackSpeed = 0;
            GearASparklePar1.playbackSpeed = 0;
            GearASparklePar2.playbackSpeed = 0;
            GearASparklePar3.playbackSpeed = 0;
            GearASparklePar4.playbackSpeed = 0;
            GearASparklePar5.playbackSpeed = 0;
            GearASparklePar6.playbackSpeed = 0;
            GearASparklePar7.playbackSpeed = 0;
            GearASparklePar8.playbackSpeed = 0;
            WBackPar1.playbackSpeed = 0;
            WBackPar2.playbackSpeed = 0;
            WBackPar3.playbackSpeed = 0;
            WBackPar4.playbackSpeed = 0;
            WBackPar5.playbackSpeed = 0;
            WBackPar6.playbackSpeed = 0;
            WBackPar7.playbackSpeed = 0;
            WBackPar8.playbackSpeed = 0;
            WBackPar9.playbackSpeed = 0;
            WBackPar10.playbackSpeed = 0;
            BigGearLeftPar.playbackSpeed = 0;
            HugeGearPar1.playbackSpeed = 0;
            HugeGearPar2.playbackSpeed = 0;
            HugeGearPar3.playbackSpeed = 0;
            HugeGearPar4.playbackSpeed = 0;
            HugeGearPar5.playbackSpeed = 0;
            HugeGearPar6.playbackSpeed = 0;
            HugeGearPar7.playbackSpeed = 0;
            JetPar1.playbackSpeed = 0;
            JetPar2.playbackSpeed = 0;
            JetPar3.playbackSpeed = 0;
            JetPar4.playbackSpeed = 0;
            JetPar5.playbackSpeed = 0;
            JetPar6.playbackSpeed = 0;
            JetPar7.playbackSpeed = 0;
            JetPar8.playbackSpeed = 0;
            JetPar9.playbackSpeed = 0;
            JetPar10.playbackSpeed = 0;
            TrueLukeLaser.playbackSpeed = 0;
            JetB1.playbackSpeed = 0;
            JetB2.playbackSpeed = 0;
            JetB3.playbackSpeed = 0;
            JetB4.playbackSpeed = 0;
            JetB5.playbackSpeed = 0;
            JetB6.playbackSpeed = 0;
            LukeSparkle.playbackSpeed = 0;
            LukeRunDustPar.playbackSpeed = 0;
            TrueLukeLaserStartPar.playbackSpeed = 0;
            TrueLukeLaserEndPar.playbackSpeed = 0;
            LukeRushPar.playbackSpeed = 0;
            LukeTackle1.playbackSpeed = 0;
            LukeTackle2.playbackSpeed = 0;
            LukeTackle3.playbackSpeed = 0;
            KnightSparcle.playbackSpeed = 0;
            BurnGearPar1.playbackSpeed = 0;
            BurnGearPar2.playbackSpeed = 0;
            WFallPar1.playbackSpeed = 0;
            WFallPar2.playbackSpeed = 0;
            WFallPar3.playbackSpeed = 0;
            WBloomPar1.playbackSpeed = 0;
            WBloomPar2.playbackSpeed = 0;
            WBloomPar3.playbackSpeed = 0;
            WBloomPar4.playbackSpeed = 0;
            WBloomPar5.playbackSpeed = 0;
            WBloomPar6.playbackSpeed = 0;
            WBloomPar7.playbackSpeed = 0;
            WBloomPar8.playbackSpeed = 0;
            WBloomPar9.playbackSpeed = 0;
            RageMarkPar1.playbackSpeed = 0;
            RageMarkPar2.playbackSpeed = 0;
            RageMarkPar3.playbackSpeed = 0;
            RageMarkPar4.playbackSpeed = 0;
            RageMarkPar5.playbackSpeed = 0;
            RageMarkPar6.playbackSpeed = 0;
            RageMarkPar7.playbackSpeed = 0;
            RageMarkPar8.playbackSpeed = 0;
            RageMarkPar9.playbackSpeed = 0;
            RageMarkPar10.playbackSpeed = 0;
            RageMarkPar11.playbackSpeed = 0;
            RageMarkPar12.playbackSpeed = 0;
            RageMarkPar13.playbackSpeed = 0;
            RageMarkPar14.playbackSpeed = 0;
            RageMarkPar15.playbackSpeed = 0;
            RageMarkPar16.playbackSpeed = 0;
            RageMarkPar17.playbackSpeed = 0;
            RageThunderPar1.playbackSpeed = 0;
            RageThunderPar2.playbackSpeed = 0;
            RageThunderPar3.playbackSpeed = 0;
            RageThunderPar4.playbackSpeed = 0;
            RageThunderPar5.playbackSpeed = 0;
            RageThunderPar6.playbackSpeed = 0;
            RageThunderPar7.playbackSpeed = 0;
            RageThunderPar8.playbackSpeed = 0;
            RageThunderPar9.playbackSpeed = 0;
            RageDrumPar1.playbackSpeed = 0;
            RageDrumPar2.playbackSpeed = 0;
            RageDrumPar3.playbackSpeed = 0;
            RageDrumPar4.playbackSpeed = 0;
            RageDrumPar5.playbackSpeed = 0;
            RageDrumPar6.playbackSpeed = 0;
            RageDrumPar7.playbackSpeed = 0;
            RageDrumPar8.playbackSpeed = 0;            
            FOPTL.Pause();
            GearTrail1.enabled = false;
            GearTrail2.enabled = false;
            Gear8SetTrail1.enabled = false;
            Gear8SetTrail2.enabled = false;
            Gear8SetTrail3.enabled = false;
            Gear8SetTrail4.enabled = false;
            Gear8SetTrail5.enabled = false;
            Gear8SetTrail6.enabled = false;
            Gear8SetTrail7.enabled = false;
            Gear8SetTrail8.enabled = false;
            LukeEyeTrail.enabled = false;
            KnightTrail1.enabled = false;
            KnightTrail2.enabled = false;
            KnightTrail3.enabled = false;
            KnightTrail4.enabled = false;
            KnightTrail5.enabled = false;
            KnightTrail6.enabled = false;
        }
        if (CheckmateFlag == "On")
        {
            Invoke("QLegColMethod", 0.01f);
            LukeLaserPar.playbackSpeed = 0;
            LukeLaserB1.playbackSpeed = 0;
            LukeLaserB2.playbackSpeed = 0;
            
            JetPar1.playbackSpeed = 0;
            JetPar2.playbackSpeed = 0;
            JetPar3.playbackSpeed = 0;
            JetPar4.playbackSpeed = 0;
            JetPar5.playbackSpeed = 0;
            JetPar6.playbackSpeed = 0;
            JetPar7.playbackSpeed = 0;
            JetPar8.playbackSpeed = 0;
            JetPar9.playbackSpeed = 0;
            JetPar10.playbackSpeed = 0;
            TrueLukeLaser.playbackSpeed = 0;
            JetB1.playbackSpeed = 0;
            JetB2.playbackSpeed = 0;
            JetB3.playbackSpeed = 0;
            JetB4.playbackSpeed = 0;
            JetB5.playbackSpeed = 0;
            JetB6.playbackSpeed = 0;
            LukeSparkle.playbackSpeed = 0;
            LukeRunDustPar.playbackSpeed = 0;
            TrueLukeLaserStartPar.playbackSpeed = 0;
            TrueLukeLaserEndPar.playbackSpeed = 0;
            LukeRushPar.playbackSpeed = 0;
            LukeTackle1.playbackSpeed = 0;
            LukeTackle2.playbackSpeed = 0;
            LukeTackle3.playbackSpeed = 0;
            KnightSparcle.playbackSpeed = 0;
            
            
            FOPTL.Pause();
            
            LukeEyeTrail.enabled = false;
            KnightTrail1.enabled = false;
            KnightTrail2.enabled = false;
            KnightTrail3.enabled = false;
            KnightTrail4.enabled = false;
            KnightTrail5.enabled = false;
            KnightTrail6.enabled = false;
        }
    }
    public void PauseOffMethod()
    {
        //script.Resume();
        Pauser.Resume();
        //Debug.Log("movestart");
        script.InputResetMethod();

        rb.gravityScale = StartGravity;
        SEASource1.UnPause();
        SEASource2.UnPause();
        SEASource3.UnPause();
        SEASourceLoop.UnPause();
        SEASourceLoop2.UnPause();
        SEASourceLoop3.UnPause();
        MonaSphere.playbackSpeed = 1;
        MonaStrayLaserPar.playbackSpeed = 10;
        if (MonaScript != null)
        {
            MonaScript.AnimResumeMethod();
        }
        if (MonaScript2 != null)
        {
            MonaScript2.AnimResumeMethod();
        }
        if (PlayerScript != null)
        {
            PlayerScript.AnimResumeMethod();
        }
        StabTL1.Resume();
        StabTL2.Resume();
        AnyPauseCol.enabled = false;
        EndlessScript.enabled = true;
        if (TutorialFlag != "On")
        {
            LukeLaserPar.playbackSpeed = 10;
            LukeLaserB1.playbackSpeed = 10;
            LukeLaserB2.playbackSpeed = 10;
            WSparklePar1.playbackSpeed = 1;
            WSparklePar2.playbackSpeed = 1;
            GearASparklePar1.playbackSpeed = 1;
            GearASparklePar2.playbackSpeed = 1;
            GearASparklePar3.playbackSpeed = 1;
            GearASparklePar4.playbackSpeed = 1;
            GearASparklePar5.playbackSpeed = 1;
            GearASparklePar6.playbackSpeed = 1;
            GearASparklePar7.playbackSpeed = 1;
            GearASparklePar8.playbackSpeed = 1;
            WBackPar1.playbackSpeed = 1;
            WBackPar2.playbackSpeed = 1;
            WBackPar3.playbackSpeed = 1;
            WBackPar4.playbackSpeed = 1;
            WBackPar5.playbackSpeed = 1;
            WBackPar6.playbackSpeed = 1;
            WBackPar7.playbackSpeed = 1;
            WBackPar8.playbackSpeed = 1;
            WBackPar9.playbackSpeed = 1;
            WBackPar10.playbackSpeed = 1;
            BigGearLeftPar.playbackSpeed = 1;
            HugeGearPar1.playbackSpeed = 1;
            HugeGearPar2.playbackSpeed = 1;
            HugeGearPar3.playbackSpeed = 1;
            HugeGearPar4.playbackSpeed = 1;
            HugeGearPar5.playbackSpeed = 1;
            HugeGearPar6.playbackSpeed = 1;
            HugeGearPar7.playbackSpeed = 1;
            JetPar1.playbackSpeed = 1;
            JetPar2.playbackSpeed = 1;
            JetPar3.playbackSpeed = 1;
            JetPar4.playbackSpeed = 1;
            JetPar5.playbackSpeed = 1;
            JetPar6.playbackSpeed = 1;
            JetPar7.playbackSpeed = 1;
            JetPar8.playbackSpeed = 1;
            JetPar9.playbackSpeed = 1;
            JetPar10.playbackSpeed = 1;
            JetB1.playbackSpeed = 1;
            JetB2.playbackSpeed = 1;
            JetB3.playbackSpeed = 1;
            JetB4.playbackSpeed = 1;
            JetB5.playbackSpeed = 1;
            JetB6.playbackSpeed = 1;
            LukeSparkle.playbackSpeed = 1;
            TrueLukeLaser.playbackSpeed = 10;
            LukeRunDustPar.playbackSpeed = 1;
            TrueLukeLaserStartPar.playbackSpeed = 10;
            TrueLukeLaserEndPar.playbackSpeed = 10;
            LukeRushPar.playbackSpeed = 1;
            LukeTackle1.playbackSpeed = 1;
            LukeTackle2.playbackSpeed = 1;
            LukeTackle3.playbackSpeed = 1;
            KnightSparcle.playbackSpeed = 1;
            BurnGearPar1.playbackSpeed = 1;
            BurnGearPar2.playbackSpeed = 1;
            WFallPar1.playbackSpeed = 1;
            WFallPar2.playbackSpeed = 1;
            WFallPar3.playbackSpeed = 1;
            WBloomPar1.playbackSpeed = 1;
            WBloomPar2.playbackSpeed = 1;
            WBloomPar3.playbackSpeed = 1;
            WBloomPar4.playbackSpeed = 1;
            WBloomPar5.playbackSpeed = 1;
            WBloomPar6.playbackSpeed = 1;
            WBloomPar7.playbackSpeed = 1;
            WBloomPar8.playbackSpeed = 1;
            WBloomPar9.playbackSpeed = 1;
            RageMarkPar1.playbackSpeed = 1;
            RageMarkPar2.playbackSpeed = 1;
            RageMarkPar3.playbackSpeed = 1;
            RageMarkPar4.playbackSpeed = 1;
            RageMarkPar5.playbackSpeed = 1;
            RageMarkPar6.playbackSpeed = 1;
            RageMarkPar7.playbackSpeed = 1;
            RageMarkPar8.playbackSpeed = 1;
            RageMarkPar9.playbackSpeed = 1;
            RageMarkPar10.playbackSpeed = 1;
            RageMarkPar11.playbackSpeed = 1;
            RageMarkPar12.playbackSpeed = 1;
            RageMarkPar13.playbackSpeed = 1;
            RageMarkPar14.playbackSpeed = 1;
            RageMarkPar15.playbackSpeed = 1;
            RageMarkPar16.playbackSpeed = 1;
            RageMarkPar17.playbackSpeed = 1;
            RageThunderPar1.playbackSpeed = 1;
            RageThunderPar2.playbackSpeed = 1;
            RageThunderPar3.playbackSpeed = 1;
            RageThunderPar4.playbackSpeed = 1;
            RageThunderPar5.playbackSpeed = 1;
            RageThunderPar6.playbackSpeed = 1;
            RageThunderPar7.playbackSpeed = 1;
            RageThunderPar8.playbackSpeed = 1;
            RageThunderPar9.playbackSpeed = 1;
            RageDrumPar1.playbackSpeed = 1;
            RageDrumPar2.playbackSpeed = 1;
            RageDrumPar3.playbackSpeed = 1;
            RageDrumPar4.playbackSpeed = 1;
            RageDrumPar5.playbackSpeed = 1;
            RageDrumPar6.playbackSpeed = 1;
            RageDrumPar7.playbackSpeed = 1;
            RageDrumPar8.playbackSpeed = 1;            
            FOPTL.Resume();
            GearTrail1.enabled = true;
            GearTrail2.enabled = false;
            Gear8SetTrail1.enabled = true;
            Gear8SetTrail2.enabled = true;
            Gear8SetTrail3.enabled = true;
            Gear8SetTrail4.enabled = true;
            Gear8SetTrail5.enabled = true;
            Gear8SetTrail6.enabled = true;
            Gear8SetTrail7.enabled = true;
            Gear8SetTrail8.enabled = true;
            LukeEyeTrail.enabled = true;
            KnightTrail1.enabled = true;
            KnightTrail2.enabled = true;
            KnightTrail3.enabled = true;
            KnightTrail4.enabled = true;
            KnightTrail5.enabled = true;
            KnightTrail6.enabled = true;
        }
        if (CheckmateFlag == "On")
        {
            LukeLaserPar.playbackSpeed = 10;
            LukeLaserB1.playbackSpeed = 10;
            LukeLaserB2.playbackSpeed = 10;
            
            JetPar1.playbackSpeed = 1;
            JetPar2.playbackSpeed = 1;
            JetPar3.playbackSpeed = 1;
            JetPar4.playbackSpeed = 1;
            JetPar5.playbackSpeed = 1;
            JetPar6.playbackSpeed = 1;
            JetPar7.playbackSpeed = 1;
            JetPar8.playbackSpeed = 1;
            JetPar9.playbackSpeed = 1;
            JetPar10.playbackSpeed = 1;
            JetB1.playbackSpeed = 1;
            JetB2.playbackSpeed = 1;
            JetB3.playbackSpeed = 1;
            JetB4.playbackSpeed = 1;
            JetB5.playbackSpeed = 1;
            JetB6.playbackSpeed = 1;
            LukeSparkle.playbackSpeed = 1;
            TrueLukeLaser.playbackSpeed = 10;
            LukeRunDustPar.playbackSpeed = 1;
            TrueLukeLaserStartPar.playbackSpeed = 10;
            TrueLukeLaserEndPar.playbackSpeed = 10;
            LukeRushPar.playbackSpeed = 1;
            LukeTackle1.playbackSpeed = 1;
            LukeTackle2.playbackSpeed = 1;
            LukeTackle3.playbackSpeed = 1;
            KnightSparcle.playbackSpeed = 1;
            
            FOPTL.Resume();
            
            LukeEyeTrail.enabled = true;
            KnightTrail1.enabled = true;
            KnightTrail2.enabled = true;
            KnightTrail3.enabled = true;
            KnightTrail4.enabled = true;
            KnightTrail5.enabled = true;
            KnightTrail6.enabled = true;
        }
    }
}
