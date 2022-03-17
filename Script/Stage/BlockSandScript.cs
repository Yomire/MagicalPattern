using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSandScript : MonoBehaviour
{
    public GameObject LeftPos;
    public GameObject RightPos;
    public GameObject Effect;
    public GameObject EffectParent;
    public GameObject BoundBatObj, BoundBatObj2;
    public float DelayTime = 0.0f;
    public float GenerateDelayTime = 1.0f;
    public float DisableTime = 10.0f;
    public string flag = "Laser";

    private void OnEnable()
    {
        Invoke("BlockAttack", DelayTime);
        Invoke("Disable", DisableTime);
    }

    public void BlockAttack()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = this.transform.position;
        obj.transform.rotation = EffectParent.transform.rotation;
        obj.SetActive(true);

        Invoke("GenerateBlockMethod", GenerateDelayTime);
    }

    public void GenerateBlockMethod()
    {
        if (flag == "Laser")
        {
            if (LeftPos != null)
            {
                GameObject obj = ObjectPooler6.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = LeftPos.transform.position;
                obj.transform.rotation = LeftPos.transform.rotation;
                obj.transform.parent = LeftPos.transform;
                obj.SetActive(true);
            }
            if (RightPos != null)
            {
                GameObject obj = ObjectPooler6.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = RightPos.transform.position;
                obj.transform.rotation = RightPos.transform.rotation;
                obj.transform.parent = RightPos.transform;
                obj.SetActive(true);
            }
        }

        if (flag == "RotateBlade")
        {
            if (LeftPos != null)
            {
                GameObject obj = ObjectPooler10.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = LeftPos.transform.position;
                obj.transform.rotation = LeftPos.transform.rotation;
                obj.transform.parent = LeftPos.transform;
                obj.SetActive(true);
            }
            if (RightPos != null)
            {
                GameObject obj = ObjectPooler10.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = RightPos.transform.position;
                obj.transform.rotation = RightPos.transform.rotation;
                obj.transform.parent = RightPos.transform;
                obj.SetActive(true);
            }
        }
        if (flag == "RotateBlade2")
        {
            if (LeftPos != null)
            {
                GameObject obj = ObjectPooler15.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = LeftPos.transform.position;
                obj.transform.rotation = LeftPos.transform.rotation;
                obj.transform.parent = LeftPos.transform;
                obj.SetActive(true);
            }
            if (RightPos != null)
            {
                GameObject obj = ObjectPooler15.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = RightPos.transform.position;
                obj.transform.rotation = RightPos.transform.rotation;
                obj.transform.parent = RightPos.transform;
                obj.SetActive(true);
            }
        }
        if (flag == "BigBatFallen")
        {
            if(BoundBatObj != null)
            {
                if (LeftPos != null)
                {
                    BoundBatObj.SetActive(true);
                    BoundBatObj.transform.position = LeftPos.transform.position;
                }
                if (RightPos != null)
                {
                    BoundBatObj2.SetActive(true);
                    BoundBatObj2.transform.position = RightPos.transform.position;
                }
            }
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
