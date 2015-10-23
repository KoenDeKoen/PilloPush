using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnedFloors : MonoBehaviour 
{
	private List<GameObject> floors;

	public void Init () 
	{
		floors = new List<GameObject> ();
	}

	public void addFloor(GameObject floor)
	{
		floors.Add (floor);
	}

	public void removeFloor(GameObject floor)
	{
		floors.Remove(floor);
	}

	public List<GameObject> returnFloors()
	{
		return floors;
	}
}
