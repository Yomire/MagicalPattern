using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainEndButton : MonoBehaviour
{
    public Animator ExplainAnim;
    public void ExplainClose()
    {
        ExplainAnim.SetBool("ENullBool", true);
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
        Invoke("DisableMethod", 1.0f);
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
