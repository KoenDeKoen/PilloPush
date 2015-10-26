using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "object"){
			Application.LoadLevel("Intro");
		}
	}
}
