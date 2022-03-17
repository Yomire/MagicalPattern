using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class PChoiceButton : MonoBehaviour
{
    public Info1 info;
    public string flagScene;
    public Text EnterText;
    public GameObject ExplainObj, KeyPUI, KeyQPUI, FishPUI, FishQPUI, GekiPUI, GekiQPUI, ShieldPUI, ShieldQPUI, ResonancePUI, ResonanceQPUI, ButterflyPUI, ButterflyQPUI,
        HummerPUI, HummerQPUI, CoinPUI, CoinQPUI, PhoenixPUI, PhoenixQPUI, SlowPUI, SlowQPUI, BladePUI, BladeQPUI, BoomerangPUI, BoomerangQPUI,
        ThunderPUI, ThunderQPUI, MagnetPUI, MagnetQPUI, ArcherPUI, ArcherQPUI, BombPUI, BombQPUI, RevolvingEdgePUI, RevolvingEdgeQPUI, ScythePUI, ScytheQPUI,
        TanglerPUI, TanglerQPUI, StarPUI, StarQPUI;
    public Animator ExplainAnim;
    public AudioSource SESource;
    public AudioClip EnterSound, ErrorSound;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        ExplainAnim.SetBool("ENullBool", false);
        ExplainAnim.SetBool("BulletEBool", false);
        ExplainAnim.SetBool("KeyEBool", false);
        ExplainAnim.SetBool("FishEBool", false);
        ExplainAnim.SetBool("GekiEBool", false);
        ExplainAnim.SetBool("ShieldEBool", false);
        ExplainAnim.SetBool("ResonanceEBool", false);
        ExplainAnim.SetBool("ButterflyEBool", false);
        ExplainAnim.SetBool("HummerEBool", false);
        ExplainAnim.SetBool("CoinEBool", false);
        ExplainAnim.SetBool("PhoenixEBool", false);
        ExplainAnim.SetBool("SlowEBool", false);
        ExplainAnim.SetBool("BladeEBool", false);
        ExplainAnim.SetBool("BoomerangEBool", false);
        ExplainAnim.SetBool("ThunderEBool", false);
        ExplainAnim.SetBool("MagnetEBool", false);
        ExplainAnim.SetBool("ArcherEBool", false);
        ExplainAnim.SetBool("BombEBool", false);
        ExplainAnim.SetBool("RevolvingEdgeEBool", false);
        ExplainAnim.SetBool("ScytheEBool", false);
        ExplainAnim.SetBool("TanglerEBool", false);
        ExplainAnim.SetBool("StarEBool", false);
        if (info.KeyPFlag == "On")
        {
            KeyPUI.SetActive(true);
            KeyQPUI.SetActive(false);
        }
        if (info.KeyPFlag != "On")
        {
            KeyPUI.SetActive(false);
            KeyQPUI.SetActive(true);
        }
        if (info.FishPFlag == "On")
        {
            FishPUI.SetActive(true);
            FishQPUI.SetActive(false);
        }
        if (info.FishPFlag != "On")
        {
            FishPUI.SetActive(false);
            FishQPUI.SetActive(true);
        }
        if (info.GekiPFlag == "On")
        {
            GekiPUI.SetActive(true);
            GekiQPUI.SetActive(false);
        }
        if (info.GekiPFlag != "On")
        {
            GekiPUI.SetActive(false);
            GekiQPUI.SetActive(true);
        }
        if (info.ShieldPFlag == "On")
        {
            ShieldPUI.SetActive(true);
            ShieldQPUI.SetActive(false);
        }
        if (info.ShieldPFlag != "On")
        {
            ShieldPUI.SetActive(false);
            ShieldQPUI.SetActive(true);
        }
        if (info.ResonancePFlag == "On")
        {
            ResonancePUI.SetActive(true);
            ResonanceQPUI.SetActive(false);
        }
        if (info.ResonancePFlag != "On")
        {
            ResonancePUI.SetActive(false);
            ResonanceQPUI.SetActive(true);
        }
        if (info.ButterflyPFlag == "On")
        {
            ButterflyPUI.SetActive(true);
            ButterflyQPUI.SetActive(false);
        }
        if (info.ButterflyPFlag != "On")
        {
            ButterflyPUI.SetActive(false);
            ButterflyQPUI.SetActive(true);
        }
        if (info.HummerPFlag == "On")
        {
            HummerPUI.SetActive(true);
            HummerQPUI.SetActive(false);
        }
        if (info.HummerPFlag != "On")
        {
            HummerPUI.SetActive(false);
            HummerQPUI.SetActive(true);
        }
        if (info.CoinPFlag == "On")
        {
            CoinPUI.SetActive(true);
            CoinQPUI.SetActive(false);
        }
        if (info.CoinPFlag != "On")
        {
            CoinPUI.SetActive(false);
            CoinQPUI.SetActive(true);
        }
        if (info.PhoenixPFlag == "On")
        {
            PhoenixPUI.SetActive(true);
            PhoenixQPUI.SetActive(false);
        }
        if (info.PhoenixPFlag != "On")
        {
            PhoenixPUI.SetActive(false);
            PhoenixQPUI.SetActive(true);
        }
        if (info.SlowPFlag == "On")
        {
            SlowPUI.SetActive(true);
            SlowQPUI.SetActive(false);
        }
        if (info.SlowPFlag != "On")
        {
            SlowPUI.SetActive(false);
            SlowQPUI.SetActive(true);
        }
        if (info.BladePFlag == "On")
        {
            BladePUI.SetActive(true);
            BladeQPUI.SetActive(false);
        }
        if (info.BladePFlag != "On")
        {
            BladePUI.SetActive(false);
            BladeQPUI.SetActive(true);
        }
        if (info.BoomerangPFlag == "On")
        {
            BoomerangPUI.SetActive(true);
            BoomerangQPUI.SetActive(false);
        }
        if (info.BoomerangPFlag != "On")
        {
            BoomerangPUI.SetActive(false);
            BoomerangQPUI.SetActive(true);
        }
        if (info.ThunderPFlag == "On")
        {
            ThunderPUI.SetActive(true);
            ThunderQPUI.SetActive(false);
        }
        if (info.ThunderPFlag != "On")
        {
            ThunderPUI.SetActive(false);
            ThunderQPUI.SetActive(true);
        }
        if (info.MagnetPFlag == "On")
        {
            MagnetPUI.SetActive(true);
            MagnetQPUI.SetActive(false);
        }
        if (info.MagnetPFlag != "On")
        {
            MagnetPUI.SetActive(false);
            MagnetQPUI.SetActive(true);
        }
        if (info.ArcherPFlag == "On")
        {
            ArcherPUI.SetActive(true);
            ArcherQPUI.SetActive(false);
        }
        if (info.ArcherPFlag != "On")
        {
            ArcherPUI.SetActive(false);
            ArcherQPUI.SetActive(true);
        }
        if (info.BombPFlag == "On")
        {
            BombPUI.SetActive(true);
            BombQPUI.SetActive(false);
        }
        if (info.BombPFlag != "On")
        {
            BombPUI.SetActive(false);
            BombQPUI.SetActive(true);
        }
        if (info.RevolvingEdgePFlag == "On")
        {
            RevolvingEdgePUI.SetActive(true);
            RevolvingEdgeQPUI.SetActive(false);
        }
        if (info.RevolvingEdgePFlag != "On")
        {
            RevolvingEdgePUI.SetActive(false);
            RevolvingEdgeQPUI.SetActive(true);
        }
        if (info.ScythePFlag == "On")
        {
            ScythePUI.SetActive(true);
            ScytheQPUI.SetActive(false);
        }
        if (info.ScythePFlag != "On")
        {
            ScythePUI.SetActive(false);
            ScytheQPUI.SetActive(true);
        }
        if (info.TanglerPFlag == "On")
        {
            TanglerPUI.SetActive(true);
            TanglerQPUI.SetActive(false);
        }
        if (info.TanglerPFlag != "On")
        {
            TanglerPUI.SetActive(false);
            TanglerQPUI.SetActive(true);
        }
        if (info.StarPFlag == "On")
        {
            StarPUI.SetActive(true);
            StarQPUI.SetActive(false);
        }
        if (info.StarPFlag != "On")
        {
            StarPUI.SetActive(false);
            StarQPUI.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "BulletPattern")
        {
            flagScene = "Bullet";
            EnterText.text = "Bullet";
        }
        if (trcol.gameObject.tag == "KeyPattern")
        {
            if (info.KeyPFlag == "On")
            {
                flagScene = "Key";
                EnterText.text = "Key";
            }
            if (info.KeyPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "FishPattern")
        {
            if (info.FishPFlag == "On")
            {
                flagScene = "Fish";
                EnterText.text = "Fish";
            }
            if (info.FishPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "GekiPattern")
        {
            if (info.GekiPFlag == "On")
            {
                flagScene = "Geki";
                EnterText.text = "Geki";
            }
            if (info.GekiPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ShieldPattern")
        {
            if (info.ShieldPFlag == "On")
            {
                flagScene = "Shield";
                EnterText.text = "Shield";
            }
            if (info.ShieldPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ResonancePattern")
        {
            if (info.ResonancePFlag == "On")
            {
                flagScene = "Resonance";
                EnterText.text = "Resonance";
            }
            if (info.ResonancePFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ButterflyPattern")
        {
            if (info.ButterflyPFlag == "On")
            {
                flagScene = "Butterfly";
                EnterText.text = "Butterfly";
            }
            if (info.ButterflyPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "HummerPattern")
        {
            if (info.HummerPFlag == "On")
            {
                flagScene = "Hummer";
                EnterText.text = "Hummer";
            }
            if (info.HummerPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "CoinPattern")
        {
            if (info.CoinPFlag == "On")
            {
                flagScene = "Coin";
                EnterText.text = "Coin";
            }
            if (info.CoinPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "PhoenixPattern")
        {
            if (info.PhoenixPFlag == "On")
            {
                flagScene = "Phoenix";
                EnterText.text = "Phoenix";
            }
            if (info.PhoenixPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "SlowPattern")
        {
            if (info.SlowPFlag == "On")
            {
                flagScene = "Slow";
                EnterText.text = "Slow";
            }
            if (info.SlowPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "BladePattern")
        {
            if (info.BladePFlag == "On")
            {
                flagScene = "Blade";
                EnterText.text = "Blade";
            }
            if (info.BladePFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "BoomerangPattern")
        {
            if (info.BoomerangPFlag == "On")
            {
                flagScene = "Boomerang";
                EnterText.text = "Boomerang";
            }
            if (info.BoomerangPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ThunderPattern")
        {
            if (info.ThunderPFlag == "On")
            {
                flagScene = "Thunder";
                EnterText.text = "Thunder";
            }
            if (info.ThunderPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "MagnetPattern")
        {
            if (info.MagnetPFlag == "On")
            {
                flagScene = "Magnet";
                EnterText.text = "Magnet";
            }
            if (info.MagnetPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ArcherPattern")
        {
            if (info.ArcherPFlag == "On")
            {
                flagScene = "Archer";
                EnterText.text = "Archer";
            }
            if (info.ArcherPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "BombPattern")
        {
            if (info.BombPFlag == "On")
            {
                flagScene = "Bomb";
                EnterText.text = "Bomb";
            }
            if (info.BombPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "RevolvingEdgePattern")
        {
            if (info.RevolvingEdgePFlag == "On")
            {
                flagScene = "RevolvingEdge";
                EnterText.text = "RevolvingEdge";
            }
            if (info.RevolvingEdgePFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "ScythePattern")
        {
            if (info.ScythePFlag == "On")
            {
                flagScene = "Scythe";
                EnterText.text = "Scythe";
            }
            if (info.ScythePFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "TanglerPattern")
        {
            if (info.TanglerPFlag == "On")
            {
                flagScene = "Tangler";
                EnterText.text = "Tangler";
            }
            if (info.TanglerPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
        if (trcol.gameObject.tag == "StarPattern")
        {
            if (info.StarPFlag == "On")
            {
                flagScene = "Star";
                EnterText.text = "Star";
            }
            if (info.StarPFlag != "On")
            {
                flagScene = "NotYet";
                EnterText.text = "???";
            }
        }
    }
    public void ButtonMethod()
    {
        if(flagScene == "NotYet")
        {
            SESource.PlayOneShot(ErrorSound);
        }
        if (flagScene == "Bullet")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", true);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Key")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", true);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Fish")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", true);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Geki")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", true);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Shield")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", true);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Resonance")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", true);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Butterfly")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", true);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Hummer")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", true);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Coin")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", true);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Phoenix")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", true);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Slow")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", true);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Blade")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", true);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Boomerang")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", true);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Thunder")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", true);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Magnet")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", true);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Archer")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", true);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Bomb")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", true);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "RevolvingEdge")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", true);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Scythe")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", true);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Tangler")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", true);
            ExplainAnim.SetBool("StarEBool", false);
        }
        if (flagScene == "Star")
        {
            SESource.PlayOneShot(EnterSound);
            ExplainObj.SetActive(true);
            ExplainAnim.SetBool("ENullBool", false);
            ExplainAnim.SetBool("BulletEBool", false);
            ExplainAnim.SetBool("KeyEBool", false);
            ExplainAnim.SetBool("FishEBool", false);
            ExplainAnim.SetBool("GekiEBool", false);
            ExplainAnim.SetBool("ShieldEBool", false);
            ExplainAnim.SetBool("ResonanceEBool", false);
            ExplainAnim.SetBool("ButterflyEBool", false);
            ExplainAnim.SetBool("HummerEBool", false);
            ExplainAnim.SetBool("CoinEBool", false);
            ExplainAnim.SetBool("PhoenixEBool", false);
            ExplainAnim.SetBool("SlowEBool", false);
            ExplainAnim.SetBool("BladeEBool", false);
            ExplainAnim.SetBool("BoomerangEBool", false);
            ExplainAnim.SetBool("ThunderEBool", false);
            ExplainAnim.SetBool("MagnetEBool", false);
            ExplainAnim.SetBool("ArcherEBool", false);
            ExplainAnim.SetBool("BombEBool", false);
            ExplainAnim.SetBool("RevolvingEdgeEBool", false);
            ExplainAnim.SetBool("ScytheEBool", false);
            ExplainAnim.SetBool("TanglerEBool", false);
            ExplainAnim.SetBool("StarEBool", true);
        }
    }
}
