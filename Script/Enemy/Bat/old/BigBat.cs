using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class BigBat : MonoBehaviour
{
    public float SpeedX = 7.0f, SpeedY = 0.0f, HP = 10;
    private Rigidbody2D rb;
    public apPortrait BatApPortrait;
    public string flag = "Normal";

    private void OnEnable()
    {
        BatApPortrait.Initialize();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (rb.velocity.x > 0)
        {
            BatApPortrait.Play("RotateBatRight", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
        if (rb.velocity.x < 0)
        {
            BatApPortrait.Play("RotateBatLeft", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }
        if (HP <= 0)
        {
            Disable();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(SpeedX, SpeedY);
    }

    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            BatApPortrait.Play("BatColorFlash", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            Invoke("AniReset", 0.5f);
            HP -= 0.1f;
        }
    }

    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            BatApPortrait.Play("BatColorFlash", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            Invoke("AniReset", 0.5f);
            HP -= 1.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (flag == "FallenDown")
        {
            if (col.gameObject.tag == "Ground")
            {
                Shake2();
                SpeedY = -SpeedY;
            }
        }
    }

    void Shake()
    {
        ScreenShakeController.instance.StartShake(.5f, .2f);
    }
    void Shake2()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    void AniReset()
    {
        BatApPortrait.StopLayer(2);
    }
    void Disable()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);

        gameObject.SetActive(false);
        Shake();
        GameObject obj14 = ObjectPooler14.current.GetPooledObject();
        if (obj14 == null) return;
        obj14.transform.position = this.transform.position;
        obj14.SetActive(true);
    }
}
