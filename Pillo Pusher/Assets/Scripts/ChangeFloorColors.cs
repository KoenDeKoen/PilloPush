using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeFloorColors : MonoBehaviour {

	// Use this for initialization
	public Material texture1;
	public Material texture2;
	public Material texture3;
	public Material texture4;
	private List<Material> textures;
	public SpawnedFloors floors;
	private float passedtime;
	void Start () 
	{
		textures = new List<Material> ();
		if(texture1 != null)
		{
			textures.Add(texture1);
		}
		if(texture2 != null)
		{
			textures.Add(texture2);
		}
		if(texture3 != null)
		{
			textures.Add(texture3);
		}
		if(texture4 != null)
		{
			textures.Add(texture4);
		}
		passedtime = 0F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		changeColors ();
	}

	private void changeColors()
	{
		passedtime += Time.deltaTime;
		if(passedtime >= 0.5F)
		{
			passedtime = 0f;
			for(int i = 0; i < floors.returnFloors().Count; i++)
			{
				int number = Random.Range(0,textures.Count);
				floors.returnFloors()[i].GetComponent<Renderer>().material = textures[number];
			}
		}
	}
}
