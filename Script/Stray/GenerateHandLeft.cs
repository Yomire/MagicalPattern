using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHandLeft : MonoBehaviour
{
    public GameObject GekiPrefab;
    //public GameObject GekiPrefab2;
    public GameObject GekiPrefab3;
    public float RotateZ = -45;
    public int counter;
    public int CounterRange = 1;
    public Transform GeneratePos;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    public void GekiGenerate()
    {
        if(counter < CounterRange)
        {
            GekiPrefab.gameObject.SetActive(true);
            //GameObject clone = Instantiate(GekiPrefab, transform.position, transform.rotation);
            //clone.transform.parent = this.transform;
            //Debug.Log("generate");
            counter++;
        }
    }

    public void DestroyPrefab()
    {
        /*if (GekiPrefab.activeSelf)
        {
            GekiPrefab.gameObject.SetActive(false);
            counter--;
        }
        if (GekiPrefab2.activeSelf)
        {
            GekiPrefab2.gameObject.SetActive(false);
            counter--;
        }*/
        
        foreach (Transform c in this.transform) //foreach (Transform c in this.transform)?
        {
            if(c != null)
            {
                c.gameObject.SetActive(false);
                //GameObject.Destroy(c.gameObject);
                counter--;
                //Debug.Log("cDestroy");
            }
        }
        //GameObject.Destroy(Transform, GameObject, in this.transform);
    }

    /*public void GekiGenerate2()
    {
        GekiPrefab2.gameObject.SetActive(true);
        //GameObject clone = Instantiate(GekiPrefab2, transform.position, transform.rotation);
        //clone.transform.parent = this.transform;
        counter++;
        //Debug.Log("generate");
    }*/

    public void GekiGenerate3()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = GeneratePos.position;
        obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
        obj.transform.parent = null;
        //Instantiate(GekiPrefab3, transform.position, Quaternion.Euler(0, 0, RotateZ));
        //GameObject clone = Instantiate(GekiPrefab3, transform.position, transform.rotation);
        //clone.transform.parent = this.transform;
        //counter++;
        //Debug.Log("generate");
    }
}
