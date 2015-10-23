using UnityEngine;
using System.Collections;

public class Mechanic : MonoBehaviour {

	// Use this for initialization
	private int state;
	private Vector3 nextpos;
	public MoveCharacter charactermover;
	void Start () 
	{
		state = 1;
		nextpos = new Vector3 (0, 0.56F, 0);
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
		}

		if(Input.GetKeyDown("d"))
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
		}
	}
}
