using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

    private int lives;
	private float realTime;
    private Animator charanimator;
    private Mechanic mc;
    private GrannyMechanic gmc;
    private ModeSelect ms;
    private Lives lifescript;



	public static bool tutorial = false;

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
			//SlowDown();
			//Debug.Log ("slow");
			Destroy(col.gameObject);
		}
        
        
	}

	void SlowDown()
	{
		realTime -= Time.deltaTime;

		if(Time.timeScale == 1.0f)
		{
			Time.timeScale = 0.5f;
		}

		if(realTime >= 5.0f)
		{
			Time.timeScale = 1.0f;
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
