using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleList : MonoBehaviour {

	List<GameObject> obstacles = new List<GameObject>();

	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;

	// Use this for initialization
	public void Initialise  ()
	{
		obstacles = new List<GameObject> ();
		obstacles.Add (obj1);
		obstacles.Add (obj2);
		obstacles.Add (obj3);
	}

	public List<GameObject> returnObstacles()
	{
		return obstacles;
	}
}
