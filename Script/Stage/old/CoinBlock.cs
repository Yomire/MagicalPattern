using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "CoinChange")
        {
            Shake();
            GameObject obj = ObjectPooler12.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = this.transform.position;
            //obj.transform.rotation = ShotPosLeft.transform.rotation;
            obj.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
}
