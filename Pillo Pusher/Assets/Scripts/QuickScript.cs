using UnityEngine;
using System.Collections;

public class QuickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("s"))
		{
			Application.LoadLevel("Menu");
		}
	}
}
