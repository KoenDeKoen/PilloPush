using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	public GameOverPanel gameoverpanel;

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("huehue");
		if(col.gameObject.tag == "object")
		{
			Debug.Log ("huehuejaja");
			gameoverpanel.displayScore();
		}
	}
}
