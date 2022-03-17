using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniLoopCountScript : MonoBehaviour
{
    public KnightScript KS;

    public void KSwingUpRightArmLoop()
    {
        KS.SwingUpLoopCount();
    }
    public void KRamdamNumber()
    {
        KS.KAniRandomMethod();
    }
    public void KAttackEvent()
    {
        KS.KAniEventMethod();
    }
    public void LanceFallEvent()
    {
        KS.LanceFallMethod();
    }
    public void FallBodyEvent()
    {
        KS.FallBodyMethod();
    }
    public void JumpBodyStartEvent()
    {
        KS.JumpMethod();
    }
    public void RunBodyEvent()
    {
        KS.RunBodyMethod();
    }
    public void LanceShotEvent()
    {
        KS.LanceShotEvent();
    }
    public void SwingSEMethod()
    {
        KS.SwingSEMethod();
    }
    public void ThrowSEMethod()
    {
        KS.ThrowSEMethod();
    }
}
