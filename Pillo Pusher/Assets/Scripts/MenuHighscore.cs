using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuHighscore : MonoBehaviour {

    // Use this for initialization
    public Leaderboard leaderboard;
    public Text text1;
    public Text text2;
    public Text text3;

    private int presscounter;
    void Start ()
    {
        presscounter = 0;
        leaderboard.updateScoreText(text1, text2, text3);
    }
	
	// Update is called once per frame
	void Update ()
    {
        checkPresses();
	}

    public void printHighscore()
    {
        leaderboard.updateScoreText(text1, text2, text3);
    }

    private void checkPresses()
    {
        float pct1 = PilloController.GetSensor(Pillo.PilloID.Pillo1);
        float pct2 = PilloController.GetSensor(Pillo.PilloID.Pillo2);

        if (((pct1 >= 0.05 || pct2 >= 0.05) || (Input.GetKeyDown("a") || Input.GetKeyDown("d"))) && presscounter >= 2)
        {
            Application.LoadLevel("Menu");
        }

        if ((pct1 <= 0 && pct2 <= 0) || (Input.GetKeyUp("a") || Input.GetKeyUp("d")))
        {
            presscounter++;
        }
    }
}
