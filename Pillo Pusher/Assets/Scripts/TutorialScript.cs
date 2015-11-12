﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour {
	
	//public Animator textBaloon;
	public ObstacleList obl;
	public ObjectPosistionList objpos;
	public PowerupList pwl;
	public FaderIn fadeIn;

	public GameObject parent;
	public GameObject auto;

	float time;
	float timePower;
	float startpos;
	float timeState;
	float interval;
	float multi;

	int state;

	bool ritme;
	bool ritmePower;

	// Use this for initialization
	void Start () {
		obl.Init();
		pwl.Init();
		objpos.Init();
		CollisionPlayer.tutorial = true;

		startpos = -160f;
		time = 3.0f;
		timeState = 0.0f;
		interval = 20f;
		multi = 1f;
		timePower = 6f;

		state = 1;

		ritme = false;
		ritmePower = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeState += Time.deltaTime;

		if(timeState >= interval * multi)
		{
			state += 1;
			multi += 1f;
		}

		//avoide obstacles
		if(state == 1)
		{
			SpawnTutorialObstacle(parent);
		}
		//jump obstacles
		if(state == 2)
		{
			SpawnTutorialCar(parent);
		}
		//
		if(state == 3)
		{
			SpawnTutorialSlow(parent);
			SpawnTutorialObstacle(parent);
		}
		//
		if(state == 4)
		{
			//SpawnTutorialTrip(parent);
			SpawnTutorialObstacle(parent);
		}

		if(state == 5)
		{
			EndTutorial();
		}
	}

	public void SpawnTutorialObstacle(GameObject parentground)
	{
		int posrnd = Random.Range(0, objpos.returnPosObjects().Count);
		int typernd = Random.Range(0, obl.returnObstacles().Count);

		Vector3 pos = new Vector3(startpos, obl.returnObstacles()[typernd].transform.position.y, objpos.returnPosObjects()[posrnd]);

		time -= Time.deltaTime;

		if(time <= 0f)
		{
			ritme = true;
		}

		if(ritme){
			GameObject obstacles = Instantiate(obl.returnObstacles()[typernd]) as GameObject;
			obstacles.transform.position = pos;
			obstacles.transform.parent = parentground.transform;
				
			time = 3.0f;
			ritme = false;
		}
	}

	public void SpawnTutorialCar(GameObject parentground)
	{
		int typernd = 0;
		
		Vector3 pos = new Vector3(startpos, obl.returnObstacles()[typernd].transform.position.y, 0.0f);
		
		time -= Time.deltaTime;
		
		if(time <= 0f)
		{
			ritme = true;
		}
		
		if(ritme){
			GameObject car = Instantiate(auto) as GameObject;
			car.transform.position = pos;
			car.transform.parent = parentground.transform;
			
			time = 4.0f;
			ritme = false;
		}
	}

	public void SpawnTutorialSlow(GameObject parentground)
	{
		int typernd = 0;
		int posrnd = Random.Range(0, objpos.returnPosObjects().Count);

		Vector3 pos = new Vector3(startpos, obl.returnObstacles()[typernd].transform.position.y, objpos.returnPosObjects()[posrnd]);
		
		timePower -= Time.deltaTime;
		
		if(timePower <= 0f)
		{
			ritmePower = true;
		}
		
		if(ritmePower){
			GameObject slow = Instantiate(pwl.returnPowerups()[typernd]) as GameObject;
			slow.transform.position = pos;
			slow.transform.parent = parentground.transform;
			
			timePower = 5.0f;
			ritmePower = false;
		}
	}

	//	public void SpawnTutorialTrip(GameObject parentground)
//	{
//		int typernd = 1;
//		int posrnd = Random.Range(0, objpos.returnPosObjects().Count);
//		
//		Vector3 pos = new Vector3(startpos, obl.returnObstacles()[typernd].transform.position.y, objpos.returnPosObjects()[posrnd]);
//		
//		timePower -= Time.deltaTime;
//		
//		if(timePower <= 0f)
//		{
//			ritmePower = true;
//		}
//		
//		if(ritmePower){
//			GameObject slow = Instantiate(pwl.returnPowerups()[typernd]) as GameObject;
//			slow.transform.position = pos;
//			slow.transform.parent = parentground.transform;
//			
//			timePower = 5.0f;
//			ritmePower = false;
//		}
//	}

	public void EndTutorial()
	{

		if (fadeIn.fadeIn())
		{
			CollisionPlayer.tutorial = false;
			Application.LoadLevel("Menu");
		}
	}
}
