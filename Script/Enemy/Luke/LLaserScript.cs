using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLaserScript : MonoBehaviour
{
    public float ScaleX, ScaleY;
    void OnEnable()
    {
        this.gameObject.transform.localScale = new Vector3(ScaleX, ScaleY, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale += new Vector3(1.0f, 0, 0);
    }
}
