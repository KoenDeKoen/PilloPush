using UnityEngine;
using System.Collections;

public class AudioRegulator : MonoBehaviour {
	
	public AudioSource audioplayer;
	public Score scorekeeper;
	private float scoreinterval;
	private float pitch;
	private float multiplier;
	private bool maxpitchreached;

	void Start () 
	{
		maxpitchreached = false;
		multiplier = 1f;
		scoreinterval = 25f;
		pitch = 0.9f;
		audioplayer.pitch = pitch;
	}

	void Update () 
	{
		if(!maxpitchreached)
		{
			checkForHigherPitch ();
		}
		//Debug.Log (scoreinterval * multiplier);
	}

	private void checkForHigherPitch()
	{
		if(scorekeeper.returnScore() >= scoreinterval * multiplier)
		{
			audioplayer.pitch = pitch += 0.10F;
			multiplier += 1f;
		}
		if(scoreinterval * multiplier >= scoreinterval * 12)
		{
			maxpitchreached = true;
		}
	}
}
