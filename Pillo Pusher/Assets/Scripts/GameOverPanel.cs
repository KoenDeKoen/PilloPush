using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

	// Use this for initialization
	//public Text scoretext;
	public Score scorekeep;
	public GameObject panel;
	private bool gameover;

	public Leaderboard lb;
	public Text score1;
	public Text score2;
	public Text score3;

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
		//scoretext.text = (((int)scorekeep.returnScore ()) * 10).ToString();
		//score1.text = (lb.returnScores ()).ToString();
		//score2.text = (lb.returnScores ()).ToString();
		//score3.text = (lb.returnScores ()).ToString();

		lb.checkForNewLeaderboardScore((int)scorekeep.returnScore() * 10);
		lb.updateScoreText(score1, score2, score3);
		int newPlace = lb.checkForNewLeaderboardScore((int)scorekeep.returnScore());
		string name = "killer";

		lb.inputName(newPlace, name);

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
