using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpBar : MonoBehaviour {
	
	public GameObject bar;
	public RectTransform timeBar;
	public CollisionPlayer colPlayer;

	bool active;

	float height;
	float width;//4f max; 
	float posx;
	float posy;

	// Use this for initialization
	void Start () {

		bar.AddComponent<RectTransform>();
		timeBar = bar.GetComponent<RectTransform>();

		height = 0.4f;
		width = 0.0f;
		posx = 210f;
		posy = 450f;

		timeBar.transform.localScale = new Vector2(width, height);
		timeBar.transform.localPosition = new Vector2(posx, posy);
		timeBar.anchorMax = new Vector2(0f,0.5f);
		timeBar.anchorMin = new Vector2(0f,0.5f);
		timeBar.pivot = new Vector2(0.5f,0.5f);

		active = false;
	}
	
	// Update is called once per frame
	void Update () {


		if(!active)
		{

		}
	}
}
