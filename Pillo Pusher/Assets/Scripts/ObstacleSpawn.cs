using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawn : MonoBehaviour {
	
	public bool ritmeObject;
	public bool ritmePowerup;
	public bool placeCar;
	float timeObject;
	float timePowerup;
	float timeCar;
	float speed;
	float round;
	float multi;
	float startPos;
	
	public GameObject parent;
	public GameObject car;
	public GameObject bench;

	public GameOverPanel gameoverpanel;
	public ObstacleList obl;
	public PowerupList pwl;
	public ObjectPosistionList objpos;
	public Score scoreTracker;
    public ModeSelect ms;
	
	// Use this for initialization
	void Start () 
	{
        ms = gameObject.AddComponent<ModeSelect>();
		obl.Init();
		pwl.Init();
		objpos.Init();
		ritmeObject = false;
		ritmePowerup = false;
		placeCar = false;

		timeObject = 2.5f;
		timePowerup = 9f;
		timeCar = 20f;
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
		int objPlacePos2 = 0;
		int objPlacePos3 = Random.Range (0, objpos.returnPosBench().Count);

		int pwlType = Random.Range (0, pwl.returnPowerups ().Count);
		int pwlPlacePos = 0;

		int state = Random.Range(0, pwl.returnPowerups ().Count);

		if(objPlacePos1 == objPlacePos2)
		{
			objPlacePos2++;
			if(objPlacePos2 >= 3)
			{
				objPlacePos2 = 0;
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

		Vector3 pos2 = new Vector3(startPos, obl.returnObstacles()[typeObstacle2].transform.position.y, objpos.returnPosObjects()[objPlacePos2]);

		Vector3 pos3 = new Vector3(startPos, pwl.returnPowerups()[pwlType].transform.position.y, objpos.returnPosObjects()[pwlPlacePos]);

		Vector3 pos4 = new Vector3(startPos, -0.45f, 0f);

		Vector3 pos5 = new Vector3(startPos, -0.45f, objpos.returnPosBench()[objPlacePos3]);

		if(scoreTracker.returnScore() >= round * multi)
		{
			speed += 0.35f;
			multi += 1f;
		}

		if(multi >= 6.0f || speed >= 1.5f)
		{
			speed = 1.5f;
			multi = 6.0f;
		}

		timeObject -= Time.deltaTime;
		timePowerup -= Time.deltaTime;
        if (ms.getMode() == 1)
        {
            timeCar -= Time.deltaTime;
        }

		if(timeCar <= 0)
		{
			placeCar = true;
		}

		if(timeObject <= 0f)
		{
			ritmeObject = true;
		}
		
		if(ritmeObject){
			if(!placeCar){
				GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle1]) as GameObject;
				obstacle.transform.position = pos1;
				obstacle.transform.parent = parentground.transform;

				GameObject obstacle2 = Instantiate(obl.returnObstacles()[typeObstacle2]) as GameObject;
				obstacle2.transform.position = pos2;
				obstacle2.transform.parent = parentground.transform;

				timeObject = 2.5f - speed;
				ritmeObject = false;
			}

			if(placeCar){
				switch(state)
				{
				case 0:
					GameObject obstacle3 = Instantiate(car) as GameObject;
					obstacle3.transform.position = pos4;
					obstacle3.transform.parent = parentground.transform;
					break;

				case 1:
					GameObject obstacle4 = Instantiate(bench) as GameObject;
					obstacle4.transform.position = pos5;
					obstacle4.transform.parent = parentground.transform;
					break;
				}

				timeCar = 20f - speed;
				timeObject = 2.5f - speed;
				placeCar = false;
				ritmeObject = false;
			}
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

			timePowerup = 10f - speed;
			ritmePowerup = false;
		}
	}
}
