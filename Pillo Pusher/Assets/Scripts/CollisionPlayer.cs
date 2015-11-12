using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

    private int lives;
	private float realTime;
    private Animator charanimator;
    private Mechanic mc;

    void Start()
    {
        mc = FindObjectOfType<Mechanic>();
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
}
