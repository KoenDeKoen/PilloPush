using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

    private int lives;
	private float realTime;

    void Start()
    {
        lives = 3;
    }

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "object")
		{
			LosLife();
		}

		if(col.gameObject.tag == "Car")
		{
			LosLife();
		}

		if(col.gameObject.tag == "Bar")
		{
			LosLife();
		}

		if(col.gameObject.tag == "slow")
		{
			//SlowDown();
			Debug.Log ("slow");
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
			gameoverpanel.displayScore();
		}
	}
}
