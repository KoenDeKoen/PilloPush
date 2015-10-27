using UnityEngine;
using System.Collections;

public class DespawnFloor : MonoBehaviour 
{

	// Use this for initialization
	public SpawnedFloors floors;
	public GameOverPanel gameoverpanel;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!gameoverpanel.isGameOver())
		{
			checkForDespawn ();
		}
	}

	private void checkForDespawn()
	{
		for(int i = 0; i < floors.returnFloors().Count; i++)
		{
			if(floors.returnFloors()[i].transform.position.x >= 45 + floors.returnFloors()[i].GetComponent<Renderer>().bounds.size.x / 2)
			{
				GameObject toremove = floors.returnFloors()[i];
				floors.removeFloor(toremove);
				Destroy(toremove);
			}
		}
	}
}
