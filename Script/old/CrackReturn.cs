using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackReturn : MonoBehaviour
{
    public Transform BlackOut;

    public void PosReset()
    {
        Vector3 BlackPos = new Vector3(30, 0, 0);
        BlackOut.transform.position = BlackPos;
    }
}
