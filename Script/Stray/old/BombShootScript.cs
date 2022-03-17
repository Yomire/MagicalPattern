using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShootScript : MonoBehaviour
{
    public void BombCreateMethod()
    {
        GameObject obj = ObjectPooler30.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
        obj.transform.parent = this.transform;
    }
}
