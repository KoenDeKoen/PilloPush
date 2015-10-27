using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "object")
		{
			gameoverpanel.displayScore();
		}
	}
}
