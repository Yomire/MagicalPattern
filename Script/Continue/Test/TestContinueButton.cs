using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestContinueButton : MonoBehaviour
{
    public GameControlScript GameConS;
    public GameObject AdsFailedObj, AdsFailedObjEnglish, PanelObj;
    public void ContinueButton()
    {
        PanelObj.SetActive(false);
        GameConS.ContinueMethod();
    }
}
