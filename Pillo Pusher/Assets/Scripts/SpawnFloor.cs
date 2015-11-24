using UnityEngine;
using System.Collections;

public class SpawnFloor : MonoBehaviour {

	// Use this for initialization
	public SpawnedFloors floors;
	private GameObject lastspawnedfloor;
	public GameObject floorprefab;
	public GameObject parent;
	public GameOverPanel gameoverpanel;
	public Material spawnmat;

	void Start () 
	{
		floors.Init ();
		lastspawnedfloor = null;
		spawnFloor (new Vector3(40,0,0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!gameoverpanel.isGameOver())
		{
			checkForNextSpawn ();
		}
		//Debug.Log (lastspawnedfloor.transform.position.x);
	}

	private void spawnFloor(Vector3 pos)
	{
		GameObject floor;
		floor = Instantiate (floorprefab, new Vector3 (pos.x, -0.35F, 0), Quaternion.identity) as GameObject;
		floor.transform.parent = parent.transform;
		//floor.GetComponent<Renderer> ().material = spawnmat;
		floors.addFloor (floor);
		lastspawnedfloor = floor;
	}

	private void checkForNextSpawn()
	{
        //Debug.Log(lastspawnedfloor.transform.position.x);
		if(lastspawnedfloor.transform.position.x >= -250F)
		{
			spawnFloor(new Vector3(lastspawnedfloor.transform.position.x-lastspawnedfloor.GetComponentInChildren<Renderer>().bounds.size.x,0.1F,0));
		}
	}
}
