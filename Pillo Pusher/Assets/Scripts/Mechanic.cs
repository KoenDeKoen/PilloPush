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
    private Animator maleanimator;


	private bool p1pressing;
	private bool p2pressing;
	private bool p1pressed;
	private bool p2pressed;
	private bool hasjumped;
    private bool devmode;
    public string animstate;

	//public GameObject pillo1feedback;
	//public GameObject pillo2feedback;

	float pct1;
	float pct2;
	
	void Start () 
	{
        animstate = "Idle1";
        maleanimator = FindObjectOfType<CollisionPlayer>().gameObject.GetComponentInChildren<Animator>();
        maleanimator.SetInteger("State", 0);
        devmode = false;
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
        //Debug.Log(charactermover.isJumping());
        
        
        if (!gameoverpanel.isGameOver ()) 
		{
            //maleanimator.SetInteger("State", 0);
            
            if (animstate != "Idle1" && maleanimator.GetCurrentAnimatorStateInfo(0).IsName(animstate))
            {
              //Debug.Log(animstate);
              maleanimator.SetInteger("State", 0);
              animstate = "Idle1";
            }

            pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
			pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);
			checkPresses (); 
        }
	}

	private void checkPresses()
	{
        if (Input.GetKey("d") && Input.GetKey("e") && Input.GetKey("v"))
        {
            devmode = true;
        }

        if (devmode)
        {
            if (Input.GetKeyDown("a"))// && !charactermover.isJumping())
            {
                p1pressing = true;
                p1pressed = false;
                speaker1.SetInteger("SwitchState", 1);
            }
            if (Input.GetKeyUp("a"))// && p1pressing && !charactermover.isJumping())
            {
                p1pressed = true;
                hasjumped = false;
                p1pressing = false;
                speaker1.SetInteger("SwitchState", 0);
            }
            if (Input.GetKeyDown("d"))// && !charactermover.isJumping())
            {
                p2pressing = true;
                p2pressed = false;
                speaker2.SetInteger("SwitchState", 1);
            }
            if (Input.GetKeyUp("d") && p2pressing)// && !charactermover.isJumping())
            {
                p2pressed = true;
                hasjumped = false;
                p2pressing = false;
                speaker2.SetInteger("SwitchState", 0);
            }
        }

        if (!devmode)
        {
            if (pct1 >= 0.05)// && !charactermover.isJumping())
            {
                p1pressing = true;
                p1pressed = false;
                speaker1.SetInteger("SwitchState", 1);
            }
            if (pct1 <= 0.01 && p1pressing)// && !charactermover.isJumping())
            {
                p1pressed = true;
                hasjumped = false;
                p1pressing = false;
                speaker1.SetInteger("SwitchState", 0);
            }
            if (pct2 >= 0.05)// && !charactermover.isJumping())
            {
                p2pressing = true;
                p2pressed = false;
                speaker2.SetInteger("SwitchState", 1);
            }
            if (pct2 <= 0.01 && p2pressing)// && !charactermover.isJumping())
            {
                p2pressed = true;
                hasjumped = false;
                p2pressing = false;
                speaker2.SetInteger("SwitchState", 0);
            }
        }

		if((p1pressing && p2pressing) && !charactermover.isJumping())
		{
			if(!hasjumped)
			{
				charactermover.jumpCharacter();
                animstate = "Dash_Jump1";
                maleanimator.SetInteger("State", 3);
                hasjumped = true;
			}
			p1pressed = false;
			p2pressed = false;
		}

		if((p1pressed && !p2pressed) && !charactermover.isJumping())
		{
			if(state > 0)
			{
                animstate = "Dash_L1";
                maleanimator.SetInteger("State", 4);
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

		if((p2pressed && !p1pressed) && !charactermover.isJumping())
		{
			if(state < 2)
			{
                animstate = "Dash_R1";
                maleanimator.SetInteger("State", 2);
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
        if (charactermover.isJumping())
        {
            p1pressed = false;
            p2pressed = false;
            p1pressing = false;
            p2pressing = false;
            speaker2.SetInteger("SwitchState", 0);
            speaker1.SetInteger("SwitchState", 0);
        }
	}
}
