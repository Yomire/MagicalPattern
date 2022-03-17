using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGenerate : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Create")
        {
            GameObject obj = ObjectPooler22.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);
        }
    }
}
