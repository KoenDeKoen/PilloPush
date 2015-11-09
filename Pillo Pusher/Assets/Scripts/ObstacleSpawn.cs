using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawn : MonoBehaviour {
	
	public bool ritmeObject;
	public bool ritmePowerup;
	public bool maxed;
	float timeObject;
	float timePowerup;
	public float speed;
	public float round;
	public float multi;
	public float startPos;
	
	public GameObject parent;

	public GameOverPanel gameoverpanel;
	public ObstacleList obl;
	public PowerupList pwl;
	public ObjectPosistionList objpos;
	public Score scoreTracker;
	
	// Use this for initialization
	void Start () 
	{
		obl.Init();
		pwl.Init();
		objpos.Init();
		ritmeObject = false;
		ritmePowerup = false;
		maxed = false;

		timeObject = 2.5f;
		timePowerup = 9f;
		speed = 0.0f;
		round = 25f;
		multi = 1f;
		startPos = -160f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!gameoverpanel.isGameOver())
		{
			ObjectSpawner(parent);
		}
	}

	public void ObjectSpawner(GameObject parentground)
	{
		int typeObstacle1 = Random.Range(0, obl.returnObstacles().Count);
		int typeObstacle2 = Random.Range(0, obl.returnObstacles().Count);

		int objPlacePos1 = Random.Range (0, objpos.returnPosObjects().Count);
		int objPlacePos2 = 0;//Random.Range (0, obl.returnPosObstacles ().Count);

		int pwlType = Random.Range (0, pwl.returnPowerups ().Count);
		int pwlPlacePos = 0;

		int newStartPos = Random.Range(0, obl.returnStartPos().Count);

		for(int i = 0; i < objpos.returnPosObjects().Count; i++)
		{
			if(i != objPlacePos1)
			{
				objPlacePos2 = i;
			}
		}

		for(int k = 0; k < objpos.returnPosObjects().Count; k++)
		{
			if(k == objPlacePos1)continue;
			if(k == objPlacePos2)continue;
			if(k != objPlacePos1)
			{
				pwlPlacePos = k;
			}
		}

		Vector3 pos1 = new Vector3(startPos, obl.returnObstacles()[typeObstacle1].transform.position.y, objpos.returnPosObjects()[objPlacePos1]);

		Vector3 pos2 = new Vector3(obl.returnStartPos()[newStartPos], obl.returnObstacles()[typeObstacle2].transform.position.y, objpos.returnPosObjects()[objPlacePos2]);

		Vector3 pos3 = new Vector3(startPos, pwl.returnPowerups()[pwlType].transform.position.y, objpos.returnPosObjects()[pwlPlacePos]);


		if(scoreTracker.returnScore() >= round * multi)
		{
			speed += 0.5f;
			multi += 1f;
		}

		if(multi >= 4.0f || speed >= 1.8f)
		{
			speed = 1.8f;
			multi = 4.0f;
		}

		timeObject -= Time.deltaTime;
		timePowerup -= Time.deltaTime;
		Debug.Log (timeObject);
		//Debug.Log (timePowerup);

		if(timeObject <= 0f){
			ritmeObject = true;
		}
		
		if(ritmeObject){
			GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle1]) as GameObject;
			obstacle.transform.position = pos1;
			obstacle.transform.parent = parentground.transform;

			GameObject obstacle2 = Instantiate(obl.returnObstacles()[typeObstacle2]) as GameObject;
			obstacle2.transform.position = pos2;
			obstacle2.transform.parent = parentground.transform;

			timeObject = 2.5f - speed;
			ritmeObject = false;
		}

		if(timePowerup <= 0f)
		{
			ritmePowerup = true;
		}

		if(ritmePowerup)
		{
			GameObject powerup = Instantiate(pwl.returnPowerups()[pwlType]) as GameObject;
			powerup.transform.position = pos3;
			powerup.transform.parent = parentground.transform;

			timePowerup = 9f - speed;
			ritmePowerup = false;
		}
	}
}
