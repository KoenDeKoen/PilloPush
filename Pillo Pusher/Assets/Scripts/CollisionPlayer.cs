using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {
	public GameOverPanel gameoverpanel;
	private int lives;
	public float realTime;

	private Animator charanimator;
	private Mechanic mc;
	private GrannyMechanic gmc;
	private ModeSelect ms;
	private Lives lifescript;
    private SFXManager sfxm;
    private GameObject audiom;
			
	public static bool tutorial = false;
	public static bool activeSlow;
	public static bool activeTrip;
	public bool badtrip;
	public bool slowdown;
		
	void Start()		
	{
		lifescript = gameObject.AddComponent<Lives>();
		//gameoverpanel.Init();
		ms = gameObject.AddComponent<ModeSelect>();
		
		if (ms.getMode() == 1)	
		{
			mc = FindObjectOfType<Mechanic>();
		}
		
		if (ms.getMode() == 2)
		{
			gmc = FindObjectOfType<GrannyMechanic>();
		}
		
		charanimator = FindObjectOfType<CollisionPlayer>().gameObject.GetComponentInChildren<Animator>();
        sfxm = FindObjectOfType<SFXManager>().GetComponent<SFXManager>();
        audiom = FindObjectOfType<AudioRegulator>().gameObject;
		lives = 3;
		realTime = 0f;
		slowdown = false;
		badtrip = false;
		activeSlow = false;
		activeTrip = false;
	}

	void Update()
	{
		if(slowdown)
		{
			SlowMotion();
		}

		if(badtrip)
		{
			BadTrip();
		}
	}

	void OnCollisionEnter(Collision col)		
	{
		if(col.gameObject.tag == "Car")	
		{	
			LosLife();
		}

		if(col.gameObject.tag == "Bar")
		{
			LosLife();
		}

		if(col.gameObject.tag == "Light")
		{
			LosLife();
		}

		if(col.gameObject.tag == "Bal")
		{
			LosLife();
		}

		if(col.gameObject.tag == "slow")
		{
			slowdown = true;
			activeSlow = true;
            audiom.GetComponent<AudioSource>().pitch = 0.8F;
            sfxm.playPowerUp();
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "trip")
		{
			badtrip = true;
			activeTrip = true;
            sfxm.playPowerDown();
            Destroy(col.gameObject);
		}
	}

	public void SlowMotion()	
	{
		realTime += Time.deltaTime;

		if(Time.timeScale >= 1.0f)
		{
			Time.timeScale = 0.5f;
		}

		if(realTime >= 6.0f)
		{
			Time.timeScale = 1.0f;
			realTime = 0f;
			slowdown = false;
			activeSlow = false;
            audiom.GetComponent<AudioSource>().pitch = audiom.GetComponent<AudioRegulator>().returnPitch(); ;
        }
	}

	public void BadTrip()	
	{
		realTime += Time.deltaTime;

		if(realTime >= 12.0f)
		{
			realTime = 0f;
			badtrip = false;
			activeTrip = false;
		}
	}

	void LosLife()
	{
		if(!tutorial)
		{
			lives--;
			if (lives <= 0)	
			{
				if (ms.getMode() == 1)
				{
					mc.animstate = "Gameover1";
				}
				
				if (ms.getMode() == 2)
				{
					gmc.animstate = "Gameover1";
				}
				
				charanimator.SetInteger("State", 6);
				gameoverpanel.displayScore();
			}
			else
			{
				if (ms.getMode() == 1)
				{
					mc.animstate = "Hit1";
				}
				
				if (ms.getMode() == 2)
				{
					gmc.animstate = "Hit1";
				}
				
				charanimator.SetInteger("State", 5);
			}
			lifescript.setLives(lives);
		}
		
		if(tutorial)
		{
			if (ms.getMode() == 1)
			{
				mc.animstate = "Hit1";
			}
			
			if (ms.getMode() == 2)
			{
				gmc.animstate = "Hit1";
			}
			
			charanimator.SetInteger("State", 5);
			//mc.animstate = "Hit1";
		}
	}
}




