using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerActivateCol : MonoBehaviour
{
    public GameObject DangerPosObj;

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "DestroyEnemy")
        {
            GearDengerMethod();
        }
    }

    public void GearDengerMethod()
    {
        GameObject obj5 = ObjectPooler5.current.GetPooledObject();
        if (obj5 == null) return;
        obj5.transform.position = DangerPosObj.transform.position;
        obj5.transform.rotation = DangerPosObj.transform.rotation;
        obj5.SetActive(true);
    }
}
