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
	float angle;
	float direction;

	// Use this for initialization
	void Start ()
    {
		timeBar = bar.GetComponent<RectTransform>();

		height = 0.4f;
		width = 4.0f;
		posx = 210f;
		posy = 450f;

		angle = 0f;
		direction = 20f;

		timeBar.transform.localScale = new Vector2(width, height);
		timeBar.transform.localPosition = new Vector2(posx, posy);
		timeBar.anchorMax = new Vector2(0f,0.5f);
		timeBar.anchorMin = new Vector2(0f,0.5f);
		timeBar.pivot = new Vector2(0.5f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {

		if(!CollisionPlayer.activeSlow)
		{
			camera.GetComponent<VignetteAndChromaticAberration>().enabled = false;

			width = 4.0f;
			timeBar.transform.localScale = new Vector2(width, height);
		}

		if(CollisionPlayer.activeSlow)
		{
			camera.GetComponent<VignetteAndChromaticAberration>().enabled = true;

			width -= Time.deltaTime * 0.7f;

			timeBar.transform.localScale = new Vector2(width, height);

			if(width <= 0.0f)
			{
				width = 0.0f;
			}
		}

		if(!CollisionPlayer.activeTrip)
		{
			camera.GetComponent<MotionBlur>().enabled = false;
			camera.GetComponent<Twirl>().enabled = false;

			width = 4.0f;

			timeBar.transform.localScale = new Vector2(width, height);
		}

		if(CollisionPlayer.activeTrip)
		{
			camera.GetComponent<MotionBlur>().enabled = true;
			camera.GetComponent<Twirl>().enabled = true;

			angle += Time.deltaTime * direction;

			Debug.Log(angle);

			width -= Time.deltaTime * 1.4f;

			timeBar.transform.localScale = new Vector2(width, height);

			camera.GetComponent<Twirl>().angle = angle;

			if(angle >= 40f)
			{
				direction = -20f;
			}
			if(angle <= -40f)
			{
				direction = 20f;
			}

			if(width <= 0.0f)
			{
				width = 0.0f;
			}
		}
	}
}
