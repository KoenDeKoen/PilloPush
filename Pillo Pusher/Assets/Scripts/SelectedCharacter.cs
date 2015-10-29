using UnityEngine;
using System.Collections;

public class SelectedCharacter : MonoBehaviour {

	// Use this for initialization
	static private GameObject character;
	public GameObject boy;
	public GameObject girl;
	void Start () 
	{
		character = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void isBoy()
	{
		character = boy;
	}

	public void isGirl()
	{
		character = girl;
	}

	public GameObject getCharacter()
	{
		return character;
	}

}
