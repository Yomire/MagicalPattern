using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBlockGenerate2 : MonoBehaviour
{
    public void OnEnable()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.transform.rotation = this.gameObject.transform.rotation;
        obj.SetActive(true);
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
