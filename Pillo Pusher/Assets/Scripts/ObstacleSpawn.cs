using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour {

	public ObstacleList obl;
	public bool ritme;
	public float time = 1f;
	public GameObject parent;
	
	// Use this for initialization
	void Start () {
		obl.Init();
		ritme = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		ObjectSpawner(parent);
	}

	public void ObjectSpawner(GameObject parentground)
	{
		int typeObstacle = 0;
		typeObstacle = Random.Range(0, 2);
		Vector3 position = new Vector3(parent.transform.position.x, parent.transform.position.y + (float)0.5f, obl.returnPosObstacles()[typeObstacle]);

		time -= Time.deltaTime; 
		
		if(time <= 0f){
			ritme = true;
		}
		
		if(ritme){
			GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle], position, Quaternion.identity) as GameObject;
			obstacle.transform.parent = parentground.transform;
			obstacle.transform.localPosition = position;
			time = 1f;
			ritme = false;
		}
	}
}
