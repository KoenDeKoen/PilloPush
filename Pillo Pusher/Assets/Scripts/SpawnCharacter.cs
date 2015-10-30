using UnityEngine;
using System.Collections;

public class SpawnCharacter : MonoBehaviour 
{

	// Use this for initialization
	public Camera maincamera;
	public SelectedCharacter selectedcharacter;
	private GameObject character;
	public GameOverPanel gameoverpanel;
	public MainMenuMusic mainmenumusic;

	public void Init () 
	{
		mainmenumusic.stopMusic ();
		character = Instantiate (selectedcharacter.getCharacter (), new Vector3(40,selectedcharacter.getCharacter().transform.position.y,0), Quaternion.identity) as GameObject;
		character.AddComponent<CollisionPlayer> ();
		character.GetComponent<CollisionPlayer> ().gameoverpanel = gameoverpanel;
		//character = selectedcharacter.getCharacter ();
		//character.transform.position = new Vector3 (40, 0, 0);
		maincamera.transform.parent = character.transform;
		//maincamera.transform.localPosition = new Vector3 (4.5f, maincamera.transform.localPosition.y, maincamera.transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public GameObject returnCharacter()
	{
		return character;
	}
}
