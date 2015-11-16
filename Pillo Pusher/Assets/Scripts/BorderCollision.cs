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

		if(col.gameObject.tag == "slow")
		{
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Car")
		{
			Destroy(col.gameObject);
		}
		
		if(col.gameObject.tag == "Bar")
		{
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Light")
		{
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Bal")
		{
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "trip")
		{
			Destroy(col.gameObject);
		}
	}
}
