using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawn : MonoBehaviour {

	public ObstacleList obl;
	public bool ritme;
	public float time = 1f;
	float startPos = -250f;
	public GameObject parent;
	public GameOverPanel gameoverpanel;
	
	// Use this for initialization
	void Start () 
	{
		obl.Init();
		ritme = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!gameoverpanel.isGameOver())
		{
			ObjectSpawner(parent);
			//ObstacleDespawn ();
		}
	}

	public void ObjectSpawner(GameObject parentground)
	{
		int newStartPos = 0;
		int typeObstacle1 = 0;
		int typeObstacle2 = 0;

		newStartPos = Random.Range(0, obl.returnStartPos().Count);
		typeObstacle1 = Random.Range(0, obl.returnObstacles().Count);
		typeObstacle2 = Random.Range(0, obl.returnObstacles().Count);

		if(typeObstacle1 == typeObstacle2)
		{
			typeObstacle2++;
			if(typeObstacle2 >= 3)
			{
				typeObstacle2 = 0;
			}
		}

		Vector3 pos1 = new Vector3(startPos, obl.returnObstacles()[typeObstacle1].transform.position.y, obl.returnPosObstacles()[typeObstacle1]);
		Vector3 pos2 = new Vector3(obl.returnStartPos()[newStartPos], obl.returnObstacles()[typeObstacle2].transform.position.y, obl.returnPosObstacles()[typeObstacle2]);

		time -= Time.deltaTime * 0.65f; 
		
		if(time <= 0f){
			ritme = true;
		}
		
		if(ritme){
			GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle1]) as GameObject;
			obstacle.transform.position = pos1;//pos1, Quaternion.Euler(new Vector3(obl.returnObstacles()[typeObstacle1].transform.rotation.x, obl.returnObstacles()[typeObstacle1].transform.rotation.y, obl.returnObstacles()[typeObstacle1].transform.rotation.z))) as GameObject;
			obstacle.transform.parent = parentground.transform;

			//GameObject obstacle2 = Instantiate(obl.returnObstacles()[typeObstacle2], pos2, Quaternion.Euler(new Vector3(obl.returnObstacles()[typeObstacle2].transform.rotation.x, obl.returnObstacles()[typeObstacle2].transform.rotation.y, obl.returnObstacles()[typeObstacle2].transform.rotation.z))) as GameObject;
			GameObject obstacle2 = Instantiate(obl.returnObstacles()[typeObstacle2]) as GameObject;
			obstacle2.transform.position = pos2;
			obstacle2.transform.parent = parentground.transform;

			time = 1f;
			ritme = false;
		}


	}
}
