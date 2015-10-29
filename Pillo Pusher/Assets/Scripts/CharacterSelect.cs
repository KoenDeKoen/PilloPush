﻿using UnityEngine;
using System.Collections;
using Pillo;


public class CharacterSelect : MonoBehaviour {

	public GameObject rotateParent;
	public GameObject girl;
	public GameObject boy;

	bool leftR;
	bool rightR;
	bool pressedL;
	bool pressedR;

	public bool boySelected;
	public bool girlSelected;

	float delay = 2f;
	int state;
	
	private float degreesPerSecond = 60f;
	private float totalRotation = 0;

	//float pct1;
	//float pct2;

	// Use this for initialization
	void Start ()
	{
		leftR = false;
		rightR = false;
	}
	
	// Update is called once per frame
	void Update (){
		//pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		//pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);

		if(Input.GetKeyUp("a"))
		{
			leftR = true;
			rightR = false;
		}

		if(Input.GetKeyUp("d"))
		{
			leftR = false;
			rightR = true;
		}

		if(Input.GetKeyDown("a") && Input.GetKeyDown("d"))
		{
			Application.LoadLevel("Game");
		}

		if(leftR)
		{
			RotateLeft ();
		}

		if(rightR)
		{
			RotateRight ();
		}

		switch(state)
		{
		case 0:
			Debug.Log("girl");
			girlSelected = true;
			boySelected = false;
			//character girl
			break;
		case 1:
			//character boy
			Debug.Log("boy");
			girlSelected = false;
			boySelected = true;
			break;
		}
	}

	void RotateLeft ()
	{
		delay -= Time.deltaTime;

		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void RotateRight ()
	{
		delay -= Time.deltaTime;

		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void StopRotation(float angle)
	{
		if(angle >= 0f && angle <= 1f && delay <= 0f || angle >= 179f && angle <= 180f && delay <= 0f)
		{
			leftR = false;
			rightR = false;
			delay = 2f;
		}

		if(angle >= 0f && angle <= 1f)
		{
			state = 0;
		}

		if(angle >= 179f && angle <= 180f)
		{
			state = 1;
		}
	}
}