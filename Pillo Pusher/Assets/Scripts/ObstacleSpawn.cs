using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawn : MonoBehaviour {

	public ObstacleList obl;
	public bool ritme;
	public float time = 1f;
	public GameObject parent;
	
	// Use this for initialization
	void Start () {
		obl.Init();
		ritme = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		ObjectSpawner(parent);
		ObstacleDespawn ();
	}

	public void ObjectSpawner(GameObject parentground)
	{
		int typeObstacle = 0;
		typeObstacle = Random.Range(0, obl.returnObstacles().Count);
		Vector3 position = new Vector3(-425f, parent.transform.position.y + (float)1f, obl.returnPosObstacles()[typeObstacle]);

		time -= Time.deltaTime; 
		
		if(time <= 0f){
			ritme = true;
		}
		
		if(ritme){
			GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle], position, Quaternion.identity) as GameObject;
			obstacle.transform.parent = parentground.transform;
			time = 1f;
			ritme = false;
		}
	}

	private void ObstacleDespawn()
	{
		for(int i = 0; i < obl.returnObstacles().Count; i++)
		{
			if(obl.returnObstacles()[i].transform.position.x >= 40)
			{
				GameObject removeO = obl.returnObstacles()[i];
				obl.removeObstacle(removeO);
				Destroy(removeO);
			}
		}
	}
}
