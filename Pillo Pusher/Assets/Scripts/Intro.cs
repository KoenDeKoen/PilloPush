using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public Settings settings;

	void Start ()
	{
		settings.setAudioState(true);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

	public void NextScene()
	{
		Application.LoadLevel("PilloIntro");
	}
}
