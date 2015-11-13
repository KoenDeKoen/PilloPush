using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

    private int lives;
	public float realTime;
    private Animator charanimator;
    private Mechanic mc;

	public static bool tutorial = false;
	public static bool activeSlow;
	public bool slowdown;

    void Start()
    {
        mc = FindObjectOfType<Mechanic>();
        charanimator = FindObjectOfType<CollisionPlayer>().gameObject.GetComponentInChildren<Animator>();
        lives = 3;
		realTime = 0f;
		slowdown = false;
		activeSlow = false;
    }

	void Update()
	{
		if(slowdown)
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
				activeSlow = false;
				slowdown = false;
			}
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
			activeSlow = true;
			slowdown = true;
			Destroy(col.gameObject);
		}
	}

	void LosLife()
	{
		if(!tutorial)
		{
			lives--;
			if (lives <= 0)
			{
            	charanimator.SetInteger("State", 6);
            	mc.animstate = "Gameover1";
				gameoverpanel.displayScore();
			}
        	else
       		{
            charanimator.SetInteger("State", 5);
           	mc.animstate = "Hit1";
        	}
		}
		if(tutorial)
		{
			charanimator.SetInteger("State", 5);
			mc.animstate = "Hit1";
		}
	}
}
