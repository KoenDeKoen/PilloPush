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
			if(jumptimer < 0.25F)
			{
				pos.y = 0;
				if(character.transform.position.y <= 0.01)
				{
					jump = false;
				}
			}
		}
		if(!jump)
		{
			lerptime += Time.deltaTime / 2F;
		}
		if(lerptime < 1F)
		{
			if(jump)
			{
				Debug.Log("Jump: " + pos.y + " " + pos.z);
				character.transform.position = new Vector3(pos.x, Mathf.Lerp(character.transform.position.y, pos.y, lerptime), character.transform.position.z); 
			}
			else
			{
				Debug.Log("Non jump: " + pos.y + " " + pos.z);
				character.transform.position = new Vector3(pos.x, character.transform.position.y, Mathf.Lerp(character.transform.position.z, pos.z, lerptime));
			}

		}
		else if(character.transform.position != pos)
		{
			character.transform.position = new Vector3(pos.x, pos.y, pos.z);
		}
		/*if(lerptime >= 0)
		{
			lerptime -= Time.deltaTime;
			if(jump)
			{
				jumptimer -= Time.deltaTime;
				if(jumptimer <= 0.5F)
				{
					pos.y = 0;
				}
				character.transform.position = Vector3.Lerp(character.transform.position, new Vector3(character.transform.position.x,pos.y,character.transform.position.z), Time.deltaTime * 3);
			}
			else
			{
				character.transform.position = Vector3.Lerp(character.transform.position, new Vector3(character.transform.position.x,character.transform.position.y,pos.z), Time.deltaTime * 3);
			}
		}
		else
		{
			character.transform.position = pos;
			jump = false;
		}*/
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
