using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupList : MonoBehaviour {

	private List<GameObject> powerups;

	public GameObject slow;
	public GameObject trip;

	// Use this for initialization
	public void Init()
	{
		powerups = new List<GameObject> ();
		powerups.Add (slow);
		powerups.Add (trip);
	}

	public List<GameObject> returnPowerups()
	{
		return powerups;
	}
}
