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



	public static bool tutorial = false;
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
        lives = 3;
		realTime = 0f;
		slowdown = false;
    }

	void Update()
	{
		if(slowdown)
		{
			SlowMotion();
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
