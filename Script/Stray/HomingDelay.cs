using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingDelay : MonoBehaviour
{
    public HomingScript HoSc;
    public string flag;
    public float Delay = 0.5f, SpeedX = 1.0f;
    public TrailRenderer Trail;
    SEScript script;
    // Start is called before the first frame update
    void OnEnable()
    {
        script = GameObject.Find("SEManagerForPrefab").GetComponent<SEScript>();
        flag = "Go";
        Invoke("ParentNullMethod", 0.1f);
        Invoke("FlagMethod", Delay);        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Go")
        {
            this.transform.Translate(SpeedX, 0, 0);
        }
    }
    public void ParentNullMethod()
    {
        this.gameObject.transform.parent = null;
    }
    public void FlagMethod()
    {        
        flag = "Stop";
        HoSc.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Ground")
        {
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            //Shake();
            //script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "Enemy")
        {
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            Shake();
            script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "Block")
        {
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            Shake();
            script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "Boss")
        {
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            Shake();
            script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            Shake();
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "Health-1")
        {
            Shake();
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            script.SoundMethod2();
        }
        if (trcol.gameObject.tag == "DestroyEnemy")
        {
            HoSc.enabled = false;
            Invoke("Disable", 0.01f);
            Shake();
            script.SoundMethod2();
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj = ObjectPooler32.current.GetPooledObject();
        if (obj == null) return;
        obj.SetActive(true);
        obj.transform.position = this.transform.position;
        Trail.Clear();
    }

    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
}
