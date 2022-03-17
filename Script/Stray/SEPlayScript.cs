using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayScript : MonoBehaviour
{
    SEScript script;
    public int SoundNumber;

    // Start is called before the first frame update
    /*void Start()
    {
        script = GameObject.Find("SEManagerForPrefab").GetComponent<SEScript>();
    }*/

    void OnEnable()
    {
        script = GameObject.Find("SEManagerForPrefab").GetComponent<SEScript>();

        if (SoundNumber == 1)
        {
            script.SoundMethod1();
        }
        if (SoundNumber == 2)
        {
            script.SoundMethod2();
        }
        if (SoundNumber == 4)
        {
            script.SoundMethod4();
        }
        if (SoundNumber == 7)
        {
            script.SoundMethod7();
        }
        if (SoundNumber == 3)
        {
            script.SoundMethod3();
        }
        if (SoundNumber == 9)
        {
            script.SoundMethod9();
        }
        if (SoundNumber == 10)
        {
            script.SoundMethod10();
        }
        if (SoundNumber == 11)
        {
            script.SoundMethod11();
        }
    }

    // Update is called once per frame
    public void SoundMethod8()
    {
        script.SoundMethod8();
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (SoundNumber == 5)
        {
            if (trcol.gameObject.tag == "Ground")
            {
                script.SoundMethod5();
                Shake();
            }                
        }
    }
    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
}
