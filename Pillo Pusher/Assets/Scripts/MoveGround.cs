using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	public GameObject parent;
	private bool hastolerp;
	private Vector3 nextpos;
	public GameOverPanel gameoverpanel;
	public Score scoreTracker;

	float speed;
	float scoreinterval;
	float multi;
	float slowdown;

	void Start () 
	{
		hastolerp = true;
		nextpos = new Vector3 (0,0,0);
		nextpos = parent.transform.position;
		speed = 0.4f;
		scoreinterval = 25f;
		multi = 1f;
		slowdown = 1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!CollisionPlayer.activeSlow)
		{
			slowdown = 1f;
		}

		if(CollisionPlayer.activeSlow)
		{
			slowdown = 2f;
		}

		if(scoreTracker.returnScore() >= scoreinterval * multi)
		{
			speed += 0.2f;
			multi += 1;
		}

		if(hastolerp && !gameoverpanel.isGameOver())
		{
			nextpos.x += speed / slowdown;
			parent.transform.position = Vector3.Lerp(parent.transform.position, nextpos, speed);                                                                      
		}
	}
}
