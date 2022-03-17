using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class AWScript : MonoBehaviour
{
    public apPortrait AWApPortrait;
    public string flag = "Go", flagHP = "false";


    // Start is called before the first frame update
    void Start()
    {
        flag = "Stop";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BigHandFallen()
    {
        GameObject obj = ObjectPooler28.current.GetPooledObject();
        if (obj == null) return;

        //obj.transform.position = PPos.transform.position;
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
    }
}
