using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;
    //public Lives lives;

    private int lives;
	private float realTime;

    void Start()
    {
        lives = 3;
    }

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("huehue");
		if(col.gameObject.tag == "object")
		{
            //Debug.Log ("huehuejaja");
            lives--;
            if (lives <= 0)
            {
                gameoverpanel.displayScore();
            }
			
		}

		//Debug.Log ("huehue");
		if(col.gameObject.tag == "slow")
		{
			SlowDown();
			Debug.Log ("slow");
			Destroy(col.gameObject);
		}
	}

	void SlowDown()
	{
		realTime += Time.deltaTime;

		if(Time.timeScale == 1.0f)
		{
			Time.timeScale = 0.5f;
		}

		if(realTime >= 5.0f)
		{
			Time.timeScale = 1.0f;
		}
	}
}
