using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

	// Use this for initialization
	public Text scoretext;
	public Score scorekeep;
	public GameObject panel;
	private bool gameover;
	void Start () 
	{
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameover)
		{
			checkForRetry ();
		}
	}

	public void displayScore()
	{
		scoretext.text = (((int)scorekeep.returnScore ()) * 10).ToString();
		scorekeep.setEnd (true);
		panel.SetActive (true);
		gameover = true;
	}

	private void checkForRetry()
	{
		float pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		float pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);

		if((pct1 >= 0.5F || pct2 >= 0.5F) || (Input.GetKeyDown("a")))
		{
			Application.LoadLevel("Game");
		}
	}

	public bool isGameOver()
	{
		return gameover;
	}
}
