using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

	// Use this for initialization
	private int firstplace;
	private int secondplace;
	private int thirdplace;
	private string firstkey;
	private string secondkey;
	private string thirdkey;
	private string name1stkey;
	private string name2ndkey;
	private string name3rdkey;
	private string name1stplace;
	private string name2ndplace;
	private string name3rdplace;

	void Start () 
	{
		updateScores ();
		firstkey = "1st";
		secondkey = "2nd";
		thirdkey = "3rd";
		name1stkey = "n1st";
		name2ndkey = "n2nd";
		name3rdkey = "n3rd";
	}

	public List<int> returnScores()
	{
		List<int> scores = new List<int>();
		updateScores ();
		scores.Add (firstplace);
		scores.Add (secondplace);
		scores.Add (thirdplace);
		return scores;
	}

	public void updateScoreText(Text scoretext, Text scoretext2,Text scoretext3)
	{
		//achieved the highscore of
		updateScores ();
		scoretext.text = "1st place: " + name1stplace + " scored " + firstplace;
		scoretext2.text = "2nd place: " + name2ndplace + " scored " + secondplace;
		scoretext3.text = "3rd place: " + name3rdplace + " scored " + thirdplace;
	}

	private void updateScores()
	{
		firstplace = PlayerPrefs.GetInt (firstkey, 0);
		secondplace = PlayerPrefs.GetInt (secondkey, 0);
		thirdplace = PlayerPrefs.GetInt (thirdkey, 0);
		name1stplace = PlayerPrefs.GetString (name1stplace, "Bot");
		name2ndplace = PlayerPrefs.GetString (name2ndplace, "Bot");
		name3rdplace = PlayerPrefs.GetString (name3rdplace, "Bot");
	}

	public int checkForNewLeaderboardScore(int newscore)
	{
		updateScores ();
		if(newscore > firstplace)
		{
			firstplace = newscore;
			PlayerPrefs.SetInt(firstkey, firstplace);
			PlayerPrefs.Save();
			return 1;
		}
		else if(newscore > secondplace)
		{
			secondplace = newscore;
			PlayerPrefs.SetInt(secondkey, secondplace);
			PlayerPrefs.Save();
			return 2;
		}
		else if(newscore > thirdplace)
		{
			thirdplace = newscore;
			PlayerPrefs.SetInt(thirdkey, thirdplace);
			PlayerPrefs.Save();
			return 3;
		}
		else
		{
			return 0;
		}
	}

	public void inputName(int place,string name)
	{
		switch(place)
		{
		case 1:
			name1stplace = name;
			PlayerPrefs.SetString(name1stkey, name1stplace);
			break;

		case 2:
			name2ndplace = name;
			PlayerPrefs.SetString(name2ndkey, name2ndplace);
			break;

		case 3:
			name3rdplace = name;
			PlayerPrefs.SetString(name3rdkey, name3rdplace);
			break;
		}
	}
}
