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
    public GameObject infotext;
    private ModeSelect ms;

    private Lives lifescript;

	public Leaderboard lb;
	public Text score1;
	public Text score2;
	public Text score3;
    public Image life1;
    public Image life2;
    public Image life3;
    public Sprite lifesprite;
    public Sprite lifelesssprite;
	private int place;
    private int previouslifes;

	void Start () 
	{
        ms = gameObject.AddComponent<ModeSelect>();
        lifescript = gameObject.AddComponent<Lives>();
        life1.sprite = lifesprite;
        life2.sprite = lifesprite;
        life3.sprite = lifesprite;
        previouslifes = lifescript.returnLives();
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
        displayLives();
		if((gameover && place == 0) || (gameover && lb.getNameDone()))
		{
            panel.SetActive(true);
            lb.inputName(place, lb.getName());
            inputtext.SetActive(false);
            infotext.SetActive(false);
            lb.updateScoreText(score1, score2, score3);
            checkForRetry ();
		}
		if(gameover && place > 0 && !lb.getNameDone())
		{
            panel.SetActive(true);
            infotext.SetActive(true);
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

    public void displayLives()
    {
        if (previouslifes != lifescript.returnLives())
        {
            previouslifes = lifescript.returnLives();
            switch (previouslifes)
            {
                case 2:
                    life3.sprite = lifelesssprite;
                    break;

                case 1:
                    life2.sprite = lifelesssprite;
                    break;

                case 0:
                    life1.sprite = lifelesssprite;
                    break;
            }
        }
    }

	private void checkForRetry()
	{
		float pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		float pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);

		if((pct1 >= 0.5F || pct2 >= 0.5F) || (Input.GetKeyDown("a")))
		{
            if (ms.getMode() == 1)
            {
                Application.LoadLevel("Game");
            }
            if (ms.getMode() == 2)
            {
                Application.LoadLevel("GrannyMode");
            }
		}
	}

	public bool isGameOver()
	{
		return gameover;
	}
}
