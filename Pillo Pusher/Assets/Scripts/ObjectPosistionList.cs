using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPosistionList : MonoBehaviour {

	private List<float> posObjects;

	private float pos1 = 3f;
	private float pos2 = 0f;
	private float pos3 = -3f;

	// Use this for initialization
	public void Init () {
		posObjects = new List<float> ();
		posObjects.Add (pos1);
		posObjects.Add (pos2);
		posObjects.Add (pos3);
	}

	public List<float> returnPosObjects()
	{
		return posObjects;
	}
}
