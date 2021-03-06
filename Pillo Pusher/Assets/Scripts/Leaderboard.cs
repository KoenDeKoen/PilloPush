﻿using UnityEngine;
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
    private string playername;
    private bool namedone;

	void Start () 
	{
        namedone = false;
        playername = "";
		updateScores ();
		PlayerPrefs.DeleteKey (firstkey);
		firstkey = "1st";
		secondkey = "2nd";
		thirdkey = "3rd";
		name1stkey = "n1st";
		name2ndkey = "n2nd";
		name3rdkey = "n3rd";
        //PlayerPrefs.DeleteAll();
	
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
		name1stplace = PlayerPrefs.GetString (name1stkey, "???");
		name2ndplace = PlayerPrefs.GetString (name2ndkey, "???");
		name3rdplace = PlayerPrefs.GetString (name3rdkey, "???");
	}

	public int checkForNewLeaderboardScore(int newscore)
	{
		updateScores ();
		int place = 0;
		if(newscore > firstplace)
		{
			int oldfirst = firstplace;
			string old1stname = name1stplace;
			firstplace = newscore;
			PlayerPrefs.SetInt(firstkey, firstplace);
            int oldsecond = secondplace;
            string old2ndname = name2ndplace;
            name2ndplace = old1stname;
            secondplace = oldfirst;
            PlayerPrefs.SetInt(secondkey, secondplace);
            PlayerPrefs.SetString(name2ndkey, name2ndplace);
            name3rdplace = old2ndname;
            thirdplace = oldsecond;
            PlayerPrefs.SetInt(thirdkey, thirdplace);
            PlayerPrefs.SetString(name3rdkey, name3rdplace);
			PlayerPrefs.Save();
			place = 1;
		}
		else if(newscore > secondplace)
		{
			string old2ndname = name2ndplace;
			int oldsecond = secondplace;
			secondplace = newscore;
			PlayerPrefs.SetInt(secondkey, secondplace);
            name3rdplace = old2ndname;
            thirdplace = oldsecond;
            PlayerPrefs.SetInt(thirdkey, thirdplace);
            PlayerPrefs.SetString(name3rdkey, name3rdplace);
			PlayerPrefs.Save();
			place = 2;
		}
		else if(newscore > thirdplace)
		{
			thirdplace = newscore;
			PlayerPrefs.SetInt(thirdkey, thirdplace);
			PlayerPrefs.Save();
			place = 3;
		}
		else
		{
			place = 0;
		}
		return place;
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

    public void buildName()
    {       
        Event e = Event.current;
        if (e != null && e.isKey && !namedone)
        {
            if (e.type == EventType.KeyDown && e.keyCode.ToString() != "None" && e.keyCode.ToString().Length == 1)
            {
                playername += e.keyCode.ToString();
            }
            if (e.type == EventType.KeyDown && e.keyCode.ToString() != "None" && e.keyCode.ToString() == "Backspace")
            {
                if (playername.Length - 1 >= 0)
                {
                    playername = playername.Substring(0, playername.Length - 1);
                }
            }
            if (e.type == EventType.KeyDown && e.keyCode.ToString() != "None" && e.keyCode.ToString() == "Space")
            {
                playername = playername + " ";
            }
            if (e.type == EventType.KeyDown && e.keyCode.ToString() != "None" && e.keyCode.ToString() == "Return")
            {
                namedone = true;
            }
        }
    }

    public string getName()
    {
        return playername;
    }

    public bool getNameDone()
    {
        return namedone;
    }
}
