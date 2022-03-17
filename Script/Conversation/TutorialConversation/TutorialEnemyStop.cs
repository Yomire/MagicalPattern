using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyStop : MonoBehaviour
{
    public TerrorNearScript EnemyObj, EnemyObj2, EnemyObj3;

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Health-1")
        {
            EnemyObj.SpeedZero();
            EnemyObj2.SpeedZero();
            EnemyObj3.SpeedZero();
        }
    }
}
