using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDrumScript : MonoBehaviour
{
    //public GameObject NightObj;
    private void OnEnable()
    {
        //NightObj.SetActive(true);
        Shake();
        Invoke("Disable", 0.8f);
    }

    // Update is called once per frame
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
    public void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(0.2f, 0.1f);
    }
    private void OnDisable()
    {
        //NightObj.SetActive(false);
        CancelInvoke();
    }
}
