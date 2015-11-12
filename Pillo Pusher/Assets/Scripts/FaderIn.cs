using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaderIn : MonoBehaviour {
	
	// Use this for initialization
	public GameObject image;
	private float time;
	private float alpha;
	void Start () 
	{
		time = 0F;
		alpha = 0F;
	}
	
	public bool fadeIn()
	{
		Vector4 colors = new Vector4(image.GetComponent<Image>().color.r,image.GetComponent<Image>().color.g,image.GetComponent<Image>().color.b,alpha);
		time += Time.deltaTime;
		if(time >= 2f)
		{
			alpha = 255;
			return true;
		}
		alpha += 0.01F;
		//Debug.Log (time);
		image.GetComponent<Image>().color = colors;
		return false;
	}
}
