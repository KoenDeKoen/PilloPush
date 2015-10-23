using UnityEngine;
using System.Collections;

public class SpawnFloor : MonoBehaviour {

	// Use this for initialization
	public SpawnedFloors floors;
	private GameObject lastspawnedfloor;
	public GameObject floorprefab;
	public GameObject parent;

	void Start () 
	{
		floors.Init ();
		lastspawnedfloor = null;
		spawnFloor (new Vector3(0,0,0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForNextSpawn ();
		//Debug.Log (lastspawnedfloor.transform.position.x);
	}

	private void spawnFloor(Vector3 pos)
	{
		GameObject floor;
		floor = Instantiate (floorprefab, new Vector3 (pos.x, -0.50F, 0), Quaternion.identity) as GameObject;
		floor.transform.parent = parent.transform;
		floors.addFloor (floor);
		lastspawnedfloor = floor;
	}

	private void checkForNextSpawn()
	{
		if(lastspawnedfloor.transform.position.x >= 200F)
		{
			spawnFloor(new Vector3(lastspawnedfloor.transform.position.x-lastspawnedfloor.GetComponent<Renderer>().bounds.size.x,0,0));
		}
	}
}
