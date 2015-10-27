using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	private float score;
	private bool calcscore;

	void Start () 
	{
		score = 0;
		calcscore = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(calcscore)
		{
			addScore();
		}
		//Debug.Log (score);
	}

	private void addScore()
	{
		score += Time.deltaTime;
	}

	public void setEnd(bool end)
	{
		calcscore = !end;
	}

	public float returnScore()
	{
		return score;
	}
}
