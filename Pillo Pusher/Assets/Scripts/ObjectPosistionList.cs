using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPosistionList : MonoBehaviour {

	private List<float> posObjects;
	private List<float> posBench;

	private float pos1 = 3f;
	private float pos2 = 0f;
	private float pos3 = -3f;

	private float pos4 = 1.5f;
	private float pos5 = -1.5f;
	
	// Use this for initialization
	public void Init () {
		posObjects = new List<float> ();
		posObjects.Add (pos1);
		posObjects.Add (pos2);
		posObjects.Add (pos3);

		posBench = new List<float>();
		posBench.Add (pos4);
		posBench.Add (pos5);
	}

	public List<float> returnPosObjects()
	{
		return posObjects;
	}

	public List<float> returnPosBench()
	{
		return posBench;
	}
}
