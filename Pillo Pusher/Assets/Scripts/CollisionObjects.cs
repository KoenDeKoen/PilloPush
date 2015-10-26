using UnityEngine;
using System.Collections;

public class CollisionObjects : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "object"){
			Destroy(col.gameObject);
		}
	}
}
