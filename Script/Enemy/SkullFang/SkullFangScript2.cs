using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullFangScript2 : MonoBehaviour
{
    public float ScrollSpeed1 = 2.0f, ScrollSpeed2 = 1.0f, DisableTime = 30.0f, HP = 10, SpeedDownPosX = -9;
    private Rigidbody2D rb;
    public Animator Skullani;
    public string flag = "Null";
    public GameObject CoinPos1, CoinPos2, CoinPos3, CoinPos4;

    private void OnEnable()
    {
        flag = "Null";
        Invoke("Shake", 0.8f);
        Skullani.SetLayerWeight(1, 0f);
        rb = GetComponent<Rigidbody2D>();
        //Vector3 StartPos = new Vector3(0, 0, 0);
        //StartPos.x = -17f;
        //StartPos.y = -1.3f;
        //this.transform.position = StartPos;

        Invoke("Disable", DisableTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == "Null")
        {
            if (rb != null)
            {
                rb.velocity = Vector2.left * ScrollSpeed1;
            }
        }
        if (flag == "SpeedDown")
        {
            if (rb != null)
            {
                rb.velocity = Vector2.left * ScrollSpeed2;
            }
        }

        if (HP <= 0)
        {
            Disable();
        }

        if (this.transform.localPosition.x >= SpeedDownPosX)
        {
            flag = "SpeedDown";
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
        Shake();
        CoinGenerate();
        GameObject obj14 = ObjectPooler14.current.GetPooledObject();
        if (obj14 == null) return;
        obj14.transform.position = this.transform.position;
        obj14.SetActive(true);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            Skullani.SetLayerWeight(1, 1f);
            Invoke("AniReset", 0.5f);
            HP -= 0.1f;
        }
    }

    void AniReset()
    {
        Skullani.SetLayerWeight(1, 0f);
    }

    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.2f, .1f);
    }

    void CoinGenerate()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);

        GameObject obj12B = ObjectPooler12.current.GetPooledObject();
        if (obj12B == null) return;
        obj12B.transform.position = CoinPos1.transform.position;
        obj12B.SetActive(true);

        GameObject obj12C = ObjectPooler12.current.GetPooledObject();
        if (obj12C == null) return;
        obj12C.transform.position = CoinPos2.transform.position;
        obj12C.SetActive(true);

        GameObject obj12D = ObjectPooler12.current.GetPooledObject();
        if (obj12D == null) return;
        obj12D.transform.position = CoinPos3.transform.position;
        obj12D.SetActive(true);

        GameObject obj12E = ObjectPooler12.current.GetPooledObject();
        if (obj12E == null) return;
        obj12E.transform.position = CoinPos4.transform.position;
        obj12E.SetActive(true);
    }
}
