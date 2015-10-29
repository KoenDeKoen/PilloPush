using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour {
	
	public GameObject player;
	public SelectedCharacter selectedcharacter;


	void Start () 
	{
		player.GetComponent<MeshFilter>().mesh = selectedcharacter.getCharacter().GetComponent<MeshFilter>().sharedMesh;
		player.GetComponent<MeshRenderer>().material = selectedcharacter.getCharacter().GetComponent<MeshRenderer>().sharedMaterial;
		player.AddComponent<>
	}

	// Update is called once per frame
	void Update () {
	
	}
}
