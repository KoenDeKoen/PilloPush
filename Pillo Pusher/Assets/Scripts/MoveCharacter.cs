using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	// Use this for initialization
	private Vector3 pos;
	public GameObject character;
	private float lerptime;
	private bool jump;
	private float jumptimer;
	public SpawnCharacter spawnedcharacter;

	public void Init () 
	{
		spawnedcharacter.Init ();
		character = spawnedcharacter.returnCharacter ();
		pos = new Vector3 (40, spawnedcharacter.returnCharacter().transform.position.y, spawnedcharacter.returnCharacter().transform.position.z);
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
			if(jumptimer < 0.20F)
			{
				pos.y = 0;
				if(character.transform.position.y <= 0.01)
				{
					jump = false;
				}
			}
		}
		//player speed switch lane
		if(!jump)
		{
			lerptime += Time.deltaTime / 0.5F;
		}
		//player stays on z.pos after jump
		if(lerptime < 1F)
		{
			if(jump)
			{
				//Debug.Log("Jump: " + pos.y + " " + pos.z);
				character.transform.position = new Vector3(pos.x, Mathf.Lerp(character.transform.position.y, pos.y, lerptime), character.transform.position.z); 
			}
			else
			{
				//Debug.Log("Non jump: " + pos.y + " " + pos.z);
				character.transform.position = new Vector3(pos.x, character.transform.position.y, Mathf.Lerp(character.transform.position.z, pos.z, lerptime));
			}

		}
		else if(character.transform.position != pos)
		{
			character.transform.position = new Vector3(pos.x, pos.y, pos.z);
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
		jumptimer = 1F;
		pos.y = 4F;
		lerptime = 0;
	}

	public bool isJumping()
	{
		return jump;
	}
}
