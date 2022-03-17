using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSprite : MonoBehaviour
{
    //public Color LightColor;
    public string flag = "Down";
    Color alpha = new Color(0, 0, 0, 0.01f);
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().material.color.a == 0)
        {
            flag = "Up";
        }
        if (GetComponent<SpriteRenderer>().material.color.a == 1)
        {
            flag = "Down";
        }
        if(flag == "Up")
        {
            GetComponent<SpriteRenderer>().material.color += alpha;
        }
        if (flag == "Down")
        {
            GetComponent<SpriteRenderer>().material.color -= alpha;
        }
    }
}
