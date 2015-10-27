using UnityEngine;
using System.Collections;
using Pillo;


public class CharacterSelect : MonoBehaviour {

	public GameObject rotateParent;
	public GameObject girl;
	public GameObject boy;

	bool leftR;
	bool rightR;

	public float degreesPerSecond = 45f;
	private float totalRotation = 0;
	private float time = 3f;

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

		if(Input.GetKey("a")){
			leftR = true;
			rightR = false;
		}

		if(Input.GetKey("d")){
			leftR = false;
			rightR = true;
		}

		if(leftR)
		{
			RotateLeft ();
		}

		if(rightR)
		{
			RotateRight ();
		}
	}

	void RotateLeft ()
	{
		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void RotateRight ()
	{
		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void StopRotation(float angle)
	{
		if(angle >= 0f && angle <= 1f || angle >= 179f && angle <= 181f)
		{
			leftR = false;
			rightR = false;
		}
	}
}
