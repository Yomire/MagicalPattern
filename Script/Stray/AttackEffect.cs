using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject EffectPrefab;
    public GameObject EffectPos;
    //public SpriteRenderer E_SpriteRenderer;
    /*public float ScaleHigh = 1f;
    public float ScaleLow = 1f;*/
    public float RotationHigh = 0;
    public float RotationLow = 0;
    //public float timer = 0.5f;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Health-1")
        {
            GameObject obj = ObjectPooler4.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EffectPos.transform.position;
            obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
            obj.SetActive(true);

            /*//Vector3 hitPos = other.ClosestPoint(this.transform.position);　//全然座標が合わない。
            Instantiate(EffectPrefab, EffectPos.transform.position, EffectPrefab.transform.rotation);
            EffectPrefab.transform.position = EffectPos.transform.position;
            //EffectPrefab.transform.localScale += new Vector3(0, 1, 0);                    //scale,colorはプレハブに直接入ってるスクリプトで演出。本スクリプトでは難しすぎる。
            EffectPrefab.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
            //EffectPrefab.transform.position = hitPos;
            //Debug.Log(EffectPos.transform.position);
            //Debug.Log(EffectPrefab.transform.position);*/
        }
        if (other.gameObject.tag == "Boss")
        {
            GameObject obj = ObjectPooler4.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = EffectPos.transform.position;
            obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
            obj.SetActive(true);
        }
    }
}
