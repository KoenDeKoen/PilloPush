using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour {

	public CharacterSelect cs;
	public GameObject player;

	public GameObject boy;
	public GameObject girl;

	Mesh boyMesh;
	Mesh girlMesh;

	void Start () {
		boyMesh = boy.GetComponent<MeshFilter>().mesh;
		girlMesh = girl.GetComponent<MeshFilter>().mesh;
	}

	// Update is called once per frame
	void Update () {
		if(cs.boySelected == true)
		{
			//Debug.Log();
			player.GetComponent<MeshFilter>().mesh = boyMesh;
		}

		if(cs.girlSelected == true)
		{
			player.GetComponent<MeshFilter>().mesh = girlMesh;
		}
	}
}
