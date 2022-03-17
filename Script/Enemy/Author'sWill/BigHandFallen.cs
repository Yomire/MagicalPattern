using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHandFallen : MonoBehaviour
{
    public GameObject PPos;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Shield")
        {            
            DisableParticle();
            Shake();
            Invoke("DisableMethod", 0.01f);
        }
    }

    public void DisableParticle()
    {
        GameObject obj = ObjectPooler29.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = PPos.transform.position;
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
    }

    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }

    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
}
