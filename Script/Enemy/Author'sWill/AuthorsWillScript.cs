using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class AuthorsWillScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //public Animator Blackani, Blackani2;
    EnemyGenerate EnemyScript;
    public apPortrait AWApPortrait;
    public string flag = "Idle", flagHP = "false", flagAttack= "Stop";
    public float nowPosi;
    public SpriteRenderer HP1, HP2, HP3, HP4, HP5;
    public Transform PlayerPos, BlackOut;
    public float RotationLow, RotationHigh, BlackSpeedX = 1.0f;
    public int EndCount = 0, EndCountMax = 100;
    private float countTime = 0;
    public float AttackTime = 0;
    public GameObject SkullFangObj, SkullFangObj2, SkullPos, FangLockObj, FangLockObj2;

    public Collider2D AWCollider1;

    // Start is called before the first frame update
    void Start()
    {
        //AWSkullGenerate2();
        EnemyScript = GameObject.Find("EnemyGenerateObj").GetComponent<EnemyGenerate>();
        //Blackani = GetComponent<Animator>();
        //AWLaser();
        //AWJustFang();
        nowPosi = this.transform.position.y;
        flagHP = "HP1Set";
        flag = "Idle";
        //flagAttack = "FollowLaser";
        //HP1 = GetComponent<SpriteRenderer>();
        //HP1.drawMode = SpriteDrawMode.Tiled;
        //Vector3 PlayerPos = PlayerObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AWBlackOutFangLock();
        countTime -= Time.deltaTime;
        if(flag == "Idle")
        {
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 3, 0.3f), transform.position.z);
            AWApPortrait.Play("Idle", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
        }

        if(flagHP == "Idle")
        {
            if (HP1.size.x <= 1.28)
            {
                flagHP = "HP1Set";
            }
        }

        if(flagHP == "HP1Set")
        {
            HP1.size += new Vector2(0.05f, 0.0f);
            if(HP1.size.x >= 15)
            {
                flagHP = "Idle";
            }
        }
        if(countTime <= 0.0)
        {
            countTime = 1.0f;
            if(flagAttack == "FollowLaser")
            {
                flag = "Idle";
                AWLaser();
                //AWJustFang();
            }
            else if (flagAttack == "FollowFang")
            {
                AWJustFang();
            }
        }

        if(flagAttack == "BlackOutLock")
        {
            AWBlackOutFangLock();
        }

        if (EndCount == 5)
        {
            flagAttack = "FollowFang";
        }
        else if (EndCount == 10)
        {
            flagAttack = "Fire";
        }
    }

    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            AWApPortrait.Play("Damage", 2, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            Invoke("AWResetMethod", 0.5f);
            HP1.size -= new Vector2(0.005f, 0.0f);
        }
    }

    void AWAttackReset()
    {
        Vector3 BlackPos = new Vector3(30, 0, 0);
        BlackOut.transform.position = BlackPos;
        AttackTime = 0;
        flagAttack = "Stop";
    }

    void AWResetMethod()
    {
        AWApPortrait.StopLayer(2);
    }

    void AWLaser()
    {
        GameObject obj = ObjectPooler7.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = PlayerPos.transform.position;
        obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
        obj.SetActive(true);
        EndCount++;
    }

    void AWJustFang()
    {
        GameObject obj2 = ObjectPooler8.current.GetPooledObject();
        if (obj2 == null) return;
        obj2.transform.position = PlayerPos.transform.position;
        //obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
        obj2.SetActive(true);
        EndCount++;
    }

    void AWBlackOut()
    {
        if(PlayerPos != null)
        {
            if (BlackOut.transform.position.x >= 0)
            {
                EndCount++;
                BlackOut.transform.Translate(BlackSpeedX, 0, 0);
            }
            if (BlackOut.transform.position.x <= 0)
            {
                AttackTime++;
            }
            if (AttackTime >= 30 && AttackTime <= 60)
            {
                GameObject obj = ObjectPooler9.current.GetPooledObject();
                if (obj == null) return;
                obj.SetActive(true);
                obj.transform.position = PlayerPos.transform.position;
                AttackTime = 0;
            }
        }
        
    }

    void AWBlackOutFangLock()
    {
        if (PlayerPos != null)
        {
            if (BlackOut.transform.position.x >= 0)
            {
                EndCount++;
                BlackOut.transform.Translate(BlackSpeedX, 0, 0);
            }
            if (BlackOut.transform.position.x <= 0)
            {
                AttackTime++;
            }
            if (AttackTime >= 30 && AttackTime <= 60)
            {
                FangLockObj.SetActive(true);
                FangLockObj.transform.position = PlayerPos.transform.position;
                AttackTime = 0;
                flagAttack = "Stop";
                /*GameObject obj = ObjectPooler10.current.GetPooledObject();
                if (obj == null) return;
                obj.SetActive(true);
                obj.transform.position = PlayerPos.transform.position;
                AttackTime = 0;
                flagAttack = "Stop";*/
            }
        }

    }
    void AWBlackOutFangLock2()
    {
        if (PlayerPos != null)
        {
            if (BlackOut.transform.position.x >= 0)
            {
                EndCount++;
                BlackOut.transform.Translate(BlackSpeedX, 0, 0);
            }
            if (BlackOut.transform.position.x <= 0)
            {
                AttackTime++;
            }
            if (AttackTime >= 30 && AttackTime <= 60)
            {
                FangLockObj2.SetActive(true);
                FangLockObj2.transform.position = PlayerPos.transform.position;
                AttackTime = 0;
                flagAttack = "Stop";
                /*GameObject obj = ObjectPooler10.current.GetPooledObject();
                if (obj == null) return;
                obj.SetActive(true);
                obj.transform.position = PlayerPos.transform.position;
                AttackTime = 0;
                flagAttack = "Stop";*/
            }
        }

    }
    /*void AWFangLock()
    {
        GameObject obj10 = ObjectPooler10.current.GetPooledObject();
        if (obj10 == null) return;
        //obj10.transform.position = PlayerPos.transform.position;
    }*/

    void AWEnemyGenerate()
    {
        EndCount++;
        EnemyScript.BatCreate();
    }

    void AWSkullGenerate()
    {
        EndCount++;
        SkullFangObj.gameObject.SetActive(true);
        SkullFangObj.transform.position = SkullPos.transform.position;
    }
    void AWSkullGenerate2()
    {
        EndCount++;
        SkullFangObj2.gameObject.SetActive(true);
        SkullFangObj2.transform.position = SkullPos.transform.position;
    }
}
