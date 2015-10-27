using UnityEngine;
using System.Collections;

public class AudioRegulator : MonoBehaviour {

	// Use this for initialization
	public AudioSource audioplayer;
	public Score scorekeeper;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForHigherPitch ();
		Debug.Log (scorekeeper.returnScore ());
	}

	private void checkForHigherPitch()
	{
		if(scorekeeper.returnScore() >= 25)
		{
			audioplayer.pitch = 1.10F;
		}
		if(scorekeeper.returnScore() >= 50)
		{
			audioplayer.pitch = 1.20F;
		}
		if(scorekeeper.returnScore() >= 75)
		{
			audioplayer.pitch = 1.30F;
		}
		if(scorekeeper.returnScore() >= 100)
		{
			audioplayer.pitch = 1.40F;
		}
		if(scorekeeper.returnScore() >= 125)
		{
			audioplayer.pitch = 1.50F;
		}
		if(scorekeeper.returnScore() >= 1150)
		{
			audioplayer.pitch = 1.60F;
		}
	}
}
