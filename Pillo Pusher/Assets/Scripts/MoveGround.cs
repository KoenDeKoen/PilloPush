using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	public GameObject parent;
	private bool hastolerp;
	private Vector3 nextpos;
	public GameOverPanel gameoverpanel;

	float speed = 0.5f;

	void Start () 
	{
		hastolerp = true;
		nextpos = new Vector3 (0,0,0);
		nextpos = parent.transform.position;
		speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		speed += Time.deltaTime * 0.005f;

		if(hastolerp && !gameoverpanel.isGameOver())
		{
			nextpos.x += speed;
			parent.transform.position = Vector3.Lerp(parent.transform.position, nextpos, Time.deltaTime * 1);                                                                       
		}
	}
}
