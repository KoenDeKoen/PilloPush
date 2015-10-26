using UnityEngine;
using System.Collections;

public class DespawnObstacle : MonoBehaviour {

	//public ObstacleList obl;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per fram
	void Update () 
	{
		//ObstacleDespawn ();
	}
	
	/*private void ObstacleDespawn()
	{
		for(int i = 0; i < obl.returnObstacles().Count; i++)
		{
			if(obl.returnObstacles()[i].transform.position.x >= 40)
			{
				GameObject removeO = obl.returnObstacles()[i];
				obl.removeObstacle(removeO);
				Destroy(removeO);
			}
		}
	}*/
}
