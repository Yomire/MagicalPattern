using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	public GameObject objTarget, DefaultPos;
	public Vector3 offset;

	void Start()
	{
		updatePostion();
	}

	void LateUpdate()
	{
		updatePostion();
	}

	void updatePostion()
	{
		if(objTarget == null)
        {
			this.transform.position = DefaultPos.transform.position;
		}

		if (objTarget != null)
		{
			Vector3 pos = objTarget.transform.localPosition;

			transform.localPosition = pos + offset;
		}
	}
}
