using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	public GameObject parent;
	private bool hastolerp;
	private Vector3 nextpos;
	void Start () 
	{
		hastolerp = true;
		nextpos = new Vector3 (0,0,0);
		nextpos = parent.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hastolerp)
		{
			nextpos.x += 0.5F;
			parent.transform.position = Vector3.Lerp(parent.transform.position, nextpos, Time.deltaTime * 1);                                                                       
		}
	}
}
