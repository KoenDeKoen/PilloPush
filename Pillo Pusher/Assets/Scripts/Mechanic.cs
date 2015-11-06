using UnityEngine;
using System.Collections;
using Pillo;

public class Mechanic : MonoBehaviour {

	// Use this for initialization
	private int state;
	private Vector3 nextpos;

	public MoveCharacter charactermover;
	public GameOverPanel gameoverpanel;
	//public SpeakerFeedback speakerFeedback;

	public Animator speaker1;
	public Animator speaker2;

	private bool p1pressing;
	private bool p2pressing;
	private bool p1pressed;
	private bool p2pressed;
	private bool hasjumped;

	public GameObject pillo1feedback;
	public GameObject pillo2feedback;

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

		//speakerFeedback.SpeakerLeftIdle();
		//speakerFeedback.SpeakerRightIdle();

		speaker1.SetInteger("SwitchState", 0);
		speaker2.SetInteger("SwitchState", 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!gameoverpanel.isGameOver ()) 
		{
			pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
			pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);
			checkPresses ();
		}
	}

	private void checkPresses()
	{
		if(Input.GetKeyDown("a") || pct1 >= 0.05)
		{
			p1pressing = true;
			p1pressed = false;
			pillo1feedback.GetComponent<Renderer>().material.color = Color.green;
			//speakerFeedback.SpeakerLeftShake();
			speaker1.SetInteger("SwitchState", 1);
		}
		else
			if((Input.GetKeyUp("a")||pct1 <= 0.01) && p1pressing)
		{
			p1pressed = true;
			hasjumped = false;
			p1pressing = false;
			pillo1feedback.GetComponent<Renderer>().material.color = Color.red;
			//speakerFeedback.SpeakerLeftIdle();
			speaker1.SetInteger("SwitchState", 0);
		}

		if(Input.GetKeyDown("d") || pct2 >= 0.05)
		{
			p2pressing = true;
			p2pressed = false;
			pillo2feedback.GetComponent<Renderer>().material.color = Color.green;
			//speakerFeedback.SpeakerRightShake();
			speaker2.SetInteger("SwitchState", 1);
		}
		else
		if((Input.GetKeyUp("d") || pct2 <= 0.01) && p2pressing)
		{
			p2pressed = true;
			hasjumped = false;
			p2pressing = false;
			pillo2feedback.GetComponent<Renderer>().material.color = Color.red;
			//speakerFeedback.SpeakerRightIdle();
			speaker2.SetInteger("SwitchState", 0);
		}

		if(p1pressing && p2pressing && !charactermover.isJumping())
		{
			if(!hasjumped)
			{
				charactermover.jumpCharacter();
				hasjumped = true;
			}
			p1pressed = false;
			p2pressed = false;
		}

		if((p1pressed && !p2pressed))// && !charactermover.isJumping())
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

		if((p2pressed && !p1pressed))// && !charactermover.isJumping())
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
