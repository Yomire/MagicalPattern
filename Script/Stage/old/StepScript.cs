using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour
{
	bool setOff;
	BoxCollider2D colliderOfGround;

	void Start()
	{
		colliderOfGround = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		if (setOff)
		{
			colliderOfGround.enabled = false;
		}
		if (!setOff)
		{
			colliderOfGround.enabled = true;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			setOff = true;
			Debug.Log("surinuke");
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			setOff = false;
			Debug.Log("hureru");
		}
	}
}
