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
	public GameObject inputtext;

	public Leaderboard lb;
	public Text score1;
	public Text score2;
	public Text score3;
	private int place;

	void Start () 
	{
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((gameover && place == 0) || (gameover && lb.getNameDone()))
		{
            panel.SetActive(true);
            lb.inputName(place, lb.getName());
            inputtext.SetActive(false);
            lb.updateScoreText(score1, score2, score3);
            checkForRetry ();
		}
		if(gameover && place > 0 && !lb.getNameDone())
		{
            panel.SetActive(true);
            inputtext.SetActive(true);
		}
	}

    void OnGUI()
    {
        if (gameover && place > 0 && !lb.getNameDone())
        {
            lb.buildName();
            inputtext.GetComponent<Text>().text = lb.getName();
            
        }
    }

	public void displayScore()
	{
		place = lb.checkForNewLeaderboardScore((int)scorekeep.returnScore() * 10);
		lb.updateScoreText(score1, score2, score3);
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
