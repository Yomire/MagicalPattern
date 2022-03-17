using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTrueScript : MonoBehaviour
{
    public GameObject EnableObjA, EnableObjB, EnableObjC, EnableObjD, EnableObjE, EnableObjF, EnableObjG;

    public void ThisDisable()
    {
        this.gameObject.SetActive(false);
    }
    public void ActiveMethodA()
    {
        EnableObjA.gameObject.SetActive(true);
    }
    public void ActiveMethodB()
    {
        EnableObjB.gameObject.SetActive(true);
    }
    public void ActiveMethodC()
    {
        EnableObjC.gameObject.SetActive(true);
    }
    public void ActiveMethodD()
    {
        EnableObjD.gameObject.SetActive(true);
    }
    public void ActiveMethodEFG()
    {
        EnableObjE.gameObject.SetActive(true);
        EnableObjF.gameObject.SetActive(true);
        EnableObjG.gameObject.SetActive(true);
    }
}
