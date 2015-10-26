using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleList : MonoBehaviour {

	private List<GameObject> obstacles;
	private List<Vector3> posObstacles;
	
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	
	private Vector3 pos1 = new Vector3(-100f,1.1f,3);
	private Vector3 pos2 = new Vector3(-100f,1.1f,0);
	private Vector3 pos3 = new Vector3(-100f,1.1f,-3);
	
	// Use this for initialization
	public void Init()
	{
		obstacles = new List<GameObject> ();
		obstacles.Add (obj1);
		obstacles.Add (obj2);
		obstacles.Add (obj3);
		
		posObstacles = new List<Vector3> ();
		posObstacles.Add (pos1);
		posObstacles.Add (pos2);
		posObstacles.Add (pos3);
	}
	
	public List<GameObject> returnObstacles()
	{
		return obstacles;
	}
	
	public List<Vector3> returnPosObstacles()
	{
		return posObstacles;
	}

}
