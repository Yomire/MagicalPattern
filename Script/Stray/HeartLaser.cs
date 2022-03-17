using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        this.gameObject.transform.localScale = new Vector3(5, 5, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale += new Vector3(1.0f, 0, 0);
    }
}
