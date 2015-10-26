using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleList : MonoBehaviour {

	private List<GameObject> obstacles;
	private List<float> posObstacles;
	
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	
	private float pos1 = 3f;
	private float pos2 = 0f;
	private float pos3 = -3f;
	
	// Use this for initialization
	public void Init()
	{
		obstacles = new List<GameObject> ();
		obstacles.Add (obj1);
		obstacles.Add (obj2);
		obstacles.Add (obj3);
		
		posObstacles = new List<float> ();
		posObstacles.Add (pos1);
		posObstacles.Add (pos2);
		posObstacles.Add (pos3);
	}
	
	public List<GameObject> returnObstacles()
	{
		return obstacles;
	}
	
	public List<float> returnPosObstacles()
	{
		return posObstacles;
	}

}
