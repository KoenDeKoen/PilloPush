using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PowerUpBar : MonoBehaviour {
	
	public GameObject bar;
	public GameObject camera;
	public RectTransform timeBar;

	float height;
	float width;//4f max; 
	float posx;
	float posy;

	// Use this for initialization
	void Start () {
		timeBar = bar.GetComponent<RectTransform>();

		height = 0.4f;
		width = 4.0f;
		posx = 210f;
		posy = 450f;

		timeBar.transform.localScale = new Vector2(width, height);
		timeBar.transform.localPosition = new Vector2(posx, posy);
		timeBar.anchorMax = new Vector2(0f,0.5f);
		timeBar.anchorMin = new Vector2(0f,0.5f);
		timeBar.pivot = new Vector2(0.5f,0.5f);

//		camera.GetComponent<VignetteAndChromaticAberration>().blurDistance = 10f;
//		camera.GetComponent<VignetteAndChromaticAberration>().blur = 10f;
//		camera.AddComponent<VignetteAndChromaticAberration>().intensity = 10f;
//		camera.AddComponent<VignetteAndChromaticAberration>().blurDistance = 10f;
	}
	
	// Update is called once per frame
	void Update () {

		if(!CollisionPlayer.activeSlow)
		{
			width = 4.0f;
			timeBar.transform.localScale = new Vector2(width, height);
		}

		if(CollisionPlayer.activeSlow)
		{
			width -= Time.deltaTime * 0.7f;

			timeBar.transform.localScale = new Vector2(width, height);

			if(width <= 0.0f)
			{
				width = 0.0f;
			}
		}
	}
}
