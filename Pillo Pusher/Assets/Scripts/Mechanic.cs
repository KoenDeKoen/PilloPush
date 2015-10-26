using UnityEngine;
using System.Collections;
using Pillo;

public class Mechanic : MonoBehaviour {

	// Use this for initialization
	private int state;
	private Vector3 nextpos;
	public MoveCharacter charactermover;
	private bool p1pressing;
	private bool p2pressing;
	private bool p1pressed;
	private bool p2pressed;
	private bool hasjumped;
	float pct1;
	float pct2;
	void Start () 
	{
		p1pressing = false;
		p2pressing = false;
		p1pressed = false;
		p2pressed = false;
		hasjumped = false;
		state = 1;
		nextpos = new Vector3 (40, 0, 0);

	}
	
	// Update is called once per frame
	void Update () 
	{
		pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);
		Debug.Log (pct2);
		Debug.Log (pct1);
		checkPresses ();
	}

	private void checkPresses()
	{
		if(Input.GetKeyDown("a") || pct1 >= 0.5)
		{
			p1pressing = true;
			p1pressed = false;
			Debug.Log(1);
		}

		if(Input.GetKeyDown("d") || pct2 >= 0.5)
		{
			p2pressing = true;
			p2pressed = false;
			Debug.Log(2);
		}

		if((Input.GetKeyUp("a") && p1pressing) ||(pct1 <= 0.2 && p1pressing))
		{
			p1pressed = true;
			hasjumped = false;
			p1pressing = false;
			Debug.Log(3);
		}

		if((Input.GetKeyUp("d") && p2pressing) || (pct2 <= 0.2 && p2pressing))
		{
			p2pressed = true;
			hasjumped = false;
			p2pressing = false;
			Debug.Log(4);
		}

		if(p1pressing && p2pressing)
		{
			//JUMP
			if(!hasjumped)
			{
				Debug.Log(5);
				charactermover.jumpCharacter();
				hasjumped=true;
			}
		}

		if((p1pressed && !p2pressed))
		{
			if(state > 0)
			{
				state--;
			}
			switch(state)
			{
			case 0:
				nextpos.z = -3;
				charactermover.setNextPos(nextpos);
				break;
				
			case 1:
				nextpos.z = 0;
				charactermover.setNextPos(nextpos);
				break;
			}
			p1pressed = false;
		}

		if((p2pressed && !p1pressed))
		{
			if(state < 2)
			{
				state++;
			}
			switch(state)
			{
			case 1:
				nextpos.z = 0;
				charactermover.setNextPos(nextpos);
				break;
				
			case 2:
				nextpos.z = 3;
				charactermover.setNextPos(nextpos);
				break;
			}
			p2pressed = false;
		}
	}
}
