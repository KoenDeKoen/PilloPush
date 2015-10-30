using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour {

	// Use this for initialization
	private GameObject musicplayer;
	void Start () 
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void resumeMusic()
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
		musicplayer.GetComponent<AudioSource> ().Play ();
	}

	public void stopMusic()
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
		musicplayer.GetComponent<AudioSource> ().Stop ();
	}
}
