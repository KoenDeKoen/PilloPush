using UnityEngine;
using System.Collections;

public class BorderCollision : MonoBehaviour 
{
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "object")
		{
			Destroy(col.gameObject);
		}
	}
}
