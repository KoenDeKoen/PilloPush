using UnityEngine;
using System.Collections;
using Pillo;

public class Mechanic : MonoBehaviour {

	// Use this for initialization
	private int state;
	private Vector3 nextpos;
	private Vector3 blastleftdown;
	private Vector3 blastrightdown;
	private Vector3 blastleftup;
	private Vector3 blastrightup;

	public MoveCharacter charactermover;
	public GameOverPanel gameoverpanel;

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

	public GameObject shockwave1;
	public GameObject shockwave2;
	public GameObject speakerLeft;
	public GameObject speakerRight;

	float pct1;
	float pct2;
	
	void Start () 
	{
        charactermover.Init();
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

		blastleftdown = new Vector3 (speaker1.transform.position.x, speaker1.transform.position.y + 1f, speaker1.transform.position.z);
		blastrightdown = new Vector3 (speaker2.transform.position.x, speaker2.transform.position.y + 1f, speaker2.transform.position.z);

		blastleftup = new Vector3 (speaker1.transform.position.x, speaker1.transform.position.y + 2f, speaker1.transform.position.z);
		blastrightup = new Vector3 (speaker2.transform.position.x, speaker2.transform.position.y + 2f, speaker2.transform.position.z);;

		speaker1.SetInteger("SwitchState", 0);
		speaker2.SetInteger("SwitchState", 0);
        ConfigureSensorRange(0x50, 0x6f);
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
				BlastLeft(blastleftdown, blastleftup);

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
				BlastRight(blastrightdown, blastrightup);
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
				BlastLeft(blastleftdown, blastleftup);
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
				BlastRight(blastrightdown, blastrightup);
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
				BlastLeft(blastleftdown, blastleftup);
				BlastRight(blastrightdown, blastrightup);
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

    public static void ConfigureSensorRange(int min, int max)
    {
        PilloSender.SensorMin = min;
        PilloSender.SensorMax = max;
    }

	public void BlastRight(Vector3 pos, Vector3 pos2)
	{
		GameObject blast1 = Instantiate(shockwave2, pos, Quaternion.identity) as GameObject;
		GameObject blast2 = Instantiate(shockwave2, pos2, Quaternion.identity) as GameObject;

		Destroy(blast1, 2f);
		Destroy(blast2, 2f);
	}

	public void BlastLeft(Vector3 pos, Vector3 pos2)
	{
		GameObject blast1 = Instantiate(shockwave1, pos, Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
		GameObject blast2 = Instantiate(shockwave1, pos2, Quaternion.Euler(new Vector3(0,180,0))) as GameObject;

		Destroy(blast1, 2f);
		Destroy(blast2, 2f);
	}
}
