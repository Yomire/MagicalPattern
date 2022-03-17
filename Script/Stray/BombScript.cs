using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public string flag = "Stop";
    public float SpeedY = 1.0f;
    //private Animator ani;

    // Start is called before the first frame update
    void OnEnable()
    {
        //ani = GetComponent<Animator>();
        //ani.Play("BombDisableAni", 0, 0.0f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        flag = "Stop";
    }
    public void BirnMethod()
    {
        GameObject obj = ObjectPooler31.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

        Invoke("DisableMethod", 0.01f);
    }

    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
