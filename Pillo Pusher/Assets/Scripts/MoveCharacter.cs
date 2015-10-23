using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	// Use this for initialization
	private bool hastolerp;
	private Vector3 pos;
	public GameObject character;
	private float lerptime;
	void Start () 
	{
		hastolerp = false;
		pos = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(lerptime < 1F)
		{
			lerptime += Time.deltaTime / 1F;
			character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, Mathf.Lerp(character.transform.position.z, pos.z, lerptime)); 
		}
		else if(character.transform.position.z != pos.z)
		{
			character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, pos.z);
		}

	}

	public void setNextPos(Vector3 position)
	{
		hastolerp = true;
		pos = position;
		lerptime = 0;
	}
}
