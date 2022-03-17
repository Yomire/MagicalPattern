using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColSyncScript : MonoBehaviour
{
    public ASCScript ASCS;
    public BHCoffinScript BHS;
    public CoffinScript CS;
    public CrossRainScript CRS;
    public KingScript KingS;
    public KingCoffinScript KCS;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(ASCS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                ASCS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                ASCS.HPMinusMethodSP();
            }
        }
        if(BHS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                BHS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                BHS.HPMinusMethodSP();
            }
        }
        if (CS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                CS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                CS.HPMinusMethodSP();
            }
        }
        if (CRS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                CRS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                CRS.HPMinusMethodSP();
            }
        }
        if (KingS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                KingS.DamageMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                KingS.DamageMethodSP();
            }
        }
        if (KCS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                KCS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                KCS.HPMinusMethodSP();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (ASCS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                ASCS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                ASCS.HPMinusMethodSP();
            }
        }
        if (BHS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                BHS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                BHS.HPMinusMethodSP();
            }
        }
        if (CS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                CS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                CS.HPMinusMethodSP();
            }
        }
        if (CRS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                CRS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                CRS.HPMinusMethodSP();
            }
        }
        if (KingS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                KingS.DamageMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                KingS.DamageMethodSP();
            }
        }
        if (KCS != null)
        {
            if (col.gameObject.tag == "Attack")
            {
                KCS.HPMinusMethod();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                KCS.HPMinusMethodSP();
            }
        }
    }
}
