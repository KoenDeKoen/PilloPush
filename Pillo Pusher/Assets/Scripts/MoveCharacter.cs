using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	// Use this for initialization
	private Vector3 pos;
	public GameObject character;
	private float lerptime;
	private bool jump;
	private float jumptimer;

	void Start () 
	{
		pos = new Vector3 (40, 0, 0);
		jump = false;
		jumptimer = 1F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(jump)
		{
			lerptime += Time.deltaTime / 2.5F;
			jumptimer -= Time.deltaTime;
			if(jumptimer <= 0)
			{
				pos.y = 0;
				jump = false;
				jumptimer = 1;
			}
		}
		if(!jump)
		{
			lerptime += Time.deltaTime / 2F;
		}
		if(lerptime < 1F)
		{
			character.transform.position = new Vector3(character.transform.position.x, Mathf.Lerp(character.transform.position.y, pos.y, lerptime), Mathf.Lerp(character.transform.position.z, pos.z, lerptime)); 
		}
		else if(character.transform.position != pos)
		{
			character.transform.position = new Vector3(character.transform.position.x, pos.y, pos.z);
		}
	}

	public void setNextPos(Vector3 position)
	{
		pos.z = position.z;
		lerptime = 0;
	}

	public void jumpCharacter()
	{
		jump = true;
		pos.y = 4F;
		lerptime = 0;
	}
}
