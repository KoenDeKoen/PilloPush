using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour {

	public ObstacleList obl;
	public bool ritme;
	public float time = 1f;
	//public Vector3 velocity = new Vector3(5,0,0);
	
	// Use this for initialization
	void Start () {
		obl.Init();
		ritme = false;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime; 
		
		if(time <= 0f){
			ritme = true;
		}
		
		if(ritme){
			int typeObstacle = 0;
			typeObstacle = Random.Range(0, obl.returnObstacles().Count);
			GameObject obstacle = Instantiate(obl.returnObstacles()[typeObstacle], obl.returnPosObstacles()[typeObstacle], Quaternion.identity) as GameObject;
			//obstacle.transform.position += velocity * Time.deltaTime;
			obstacle.AddComponent<Rigidbody>();
			obstacle.GetComponent<Rigidbody>().velocity = new Vector3(25,0,0);
			obstacle.GetComponent<Rigidbody>().useGravity = false;
			time = 1f;
			ritme = false;
		}
	}
}
