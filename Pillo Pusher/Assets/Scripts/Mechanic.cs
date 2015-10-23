using UnityEngine;
using System.Collections;

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
		checkPresses ();
	}

	private void checkPresses()
	{
		if(Input.GetKeyDown("a"))
		{
			p1pressing = true;
			p1pressed = false;
		}

		if(Input.GetKeyDown("d"))
		{
			p2pressing = true;
			p2pressed = false;
		}

		if(Input.GetKeyUp("a") && p1pressing)
		{
			p1pressed = true;
			hasjumped = false;
			p1pressing = false;
		}

		if(Input.GetKeyUp("d") && p2pressing)
		{
			p2pressed = true;
			hasjumped = false;
			p2pressing = false;
		}


		if(p1pressing && p2pressing)
		{
			//JUMP
			if(!hasjumped)
			{
				charactermover.jumpCharacter();
				hasjumped=true;
			}
		}

		if(p1pressed && !p2pressed)
		{
			Debug.Log("ehhh");
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

		if(p2pressed && !p1pressed)
		{
			Debug.Log("ehhh2");
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
