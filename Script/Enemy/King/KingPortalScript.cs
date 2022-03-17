using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPortalScript : MonoBehaviour
{
    public GameObject LancePos;

    public void LanceMethod()
    {
        GameObject obj = ObjectPooler48.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = LancePos.transform.position;
        obj.transform.rotation = LancePos.transform.rotation;
        obj.SetActive(true);
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
