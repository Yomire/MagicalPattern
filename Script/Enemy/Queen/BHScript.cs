using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHScript : MonoBehaviour
{
    public QueenScript QS;
    public QSkyScript QSS;
    public GameObject QLandObj, QSkyObj;
    
    public void QLeaveMethod()
    {
        if (QLandObj.activeSelf)
        {
            QS.BladePurgeLeave();
        }
        if (QSkyObj.activeSelf)
        {
            QSS.QBSetObjEndMethod();
        }
    }
}
