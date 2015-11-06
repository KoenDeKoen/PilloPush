using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuHighscore : MonoBehaviour {

    // Use this for initialization
    public Leaderboard leaderboard;
    public Text text1;
    public Text text2;
    public Text text3;

    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void printHighscore()
    {
        leaderboard.updateScoreText(text1, text2, text3);
    }
}
