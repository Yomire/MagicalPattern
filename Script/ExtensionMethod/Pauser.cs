using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pauser : MonoBehaviour
{
	//public Rigidbody2D rb;
	//public float StartGravity;
	static List<Pauser> targets = new List<Pauser>();   // ポーズ対象のスクリプト

	// ポーズ対象のコンポーネント
	Behaviour[] pauseBehavs = null;

	Rigidbody[] rgBodies = null;
	Vector3[] rgBodyVels = null;
	Vector3[] rgBodyAVels = null;

	Rigidbody2D[] rg2dBodies = null;
	Vector2[] rg2dBodyVels = null;
	float[] rg2dBodyAVels = null;

	// 初期化
	void Start()
	{
        /*if (rb != null)
        {
			//Debug.Log(StartGravity);
			rb = GetComponent<Rigidbody2D>();
			StartGravity = rb.gravityScale;
		}*/

		// ポーズ対象に追加する
		targets.Add(this);
	}

	// 破棄されるとき
	void OnDestory()
	{
		// ポーズ対象から除外する
		targets.Remove(this);
	}

	// ポーズされたとき
	void OnPause()
	{
		if (pauseBehavs != null)
		{
			return;
		}

		// 有効なコンポーネントを取得
		pauseBehavs = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => { return obj.enabled; });
		foreach (var com in pauseBehavs)
		{
			com.enabled = false;
		}

		rgBodies = Array.FindAll(GetComponentsInChildren<Rigidbody>(), (obj) => { return !obj.IsSleeping(); });
		rgBodyVels = new Vector3[rgBodies.Length];
		rgBodyAVels = new Vector3[rgBodies.Length];
		for (var i = 0; i < rgBodies.Length; ++i)
		{
			rgBodyVels[i] = rgBodies[i].velocity;
			rgBodyAVels[i] = rgBodies[i].angularVelocity;
			rgBodies[i].Sleep();
		}

		rg2dBodies = Array.FindAll(GetComponentsInChildren<Rigidbody2D>(), (obj) => { return !obj.IsSleeping(); });
		rg2dBodyVels = new Vector2[rg2dBodies.Length];
		rg2dBodyAVels = new float[rg2dBodies.Length];
		for (var i = 0; i < rg2dBodies.Length; ++i)
		{
			rg2dBodyVels[i] = rg2dBodies[i].velocity;
			rg2dBodyAVels[i] = rg2dBodies[i].angularVelocity;
			rg2dBodies[i].Sleep();
		}

		//Physics.gravity = new Vector3(0f, 0f, 0f); //+
		//Debug.Log(Physics.gravity);
		/*if (rb != null)
		{
			if (rb.bodyType == RigidbodyType2D.Dynamic)
			{
				rb.bodyType = RigidbodyType2D.Static;
				Invoke("DynamicMethod", 0.1f);
			}
			rb.gravityScale = 0;
			//Debug.Log(rb.gravityScale);
			rb.velocity = Vector2.zero;
		}*/
	}

	/*public void DynamicMethod()
    {
		if (rb.bodyType == RigidbodyType2D.Static)
        {
			rb.bodyType = RigidbodyType2D.Dynamic;
		}
	}*/

	// ポーズ解除されたとき
	void OnResume()
	{
		if (pauseBehavs == null)
		{
			return;
		}

		// ポーズ前の状態にコンポーネントの有効状態を復元
		foreach (var com in pauseBehavs)
		{
			com.enabled = true;
		}

		for (var i = 0; i < rgBodies.Length; ++i)
		{
			rgBodies[i].WakeUp();
			rgBodies[i].velocity = rgBodyVels[i];
			rgBodies[i].angularVelocity = rgBodyAVels[i];
		}

		for (var i = 0; i < rg2dBodies.Length; ++i)
		{
			rg2dBodies[i].WakeUp();
			rg2dBodies[i].velocity = rg2dBodyVels[i];
			rg2dBodies[i].angularVelocity = rg2dBodyAVels[i];
		}

		pauseBehavs = null;

		rgBodies = null;
		rgBodyVels = null;
		rgBodyAVels = null;

		rg2dBodies = null;
		rg2dBodyVels = null;
		rg2dBodyAVels = null;

		//Physics.gravity = new Vector3(0f, -9.81f, 0f); //+
		/*if (rb != null)
        {
			if (rb.bodyType == RigidbodyType2D.Static)
			{
				rb.bodyType = RigidbodyType2D.Dynamic;
			}
			rb.gravityScale = StartGravity;
		}*/
			
	}

	// ポーズ
	public static void Pause()
	{
		foreach (var obj in targets)
		{
			if (obj != null)
            {
				obj.OnPause();
			}
		}
	}

	// ポーズ解除
	public static void Resume()
	{
		foreach (var obj in targets)
		{
			if (obj != null)
            {
				obj.OnResume();
            }
				
		}
	}
}