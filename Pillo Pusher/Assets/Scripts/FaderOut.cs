using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaderOut : MonoBehaviour {
	
	// Use this for initialization
	public GameObject image;
	public float time;
	public float alpha;
	public float delay;
	public bool done;

	void Start () 
	{
		done = false;
		alpha = 1.0f;
		time = 0f;
		delay = 5.0f;
	}

	void Update()
	{
		if(!done)
		{
			fadeOut();
		}
	}

	public void fadeOut()
	{
		Color colors = new Color(image.GetComponent<Image>().color.r,image.GetComponent<Image>().color.g,image.GetComponent<Image>().color.b,alpha);
		time += Time.deltaTime;
		if(time >= 5f)
		{
			alpha = 0f;
			done = true;
		}
		alpha = 1-time/delay;
		//Debug.Log (alpha);
		image.GetComponent<Image>().color = colors;
	}
}
