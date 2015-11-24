using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialText : MonoBehaviour {

	public GameObject textTutorial;
	Text txt;

	// Use this for initialization
	void Start () {
		txt = textTutorial.GetComponent<Text>();
	}

	public void IntroTextTutorial()
	{
		txt.text = "Welcome to the disco dodger tutorial"+"\n"+"First we will begin with movement"+"\n"+"press the left pillo to go to the right and vice versa";
	}

	public void JumpTextTutorial()
	{
		txt.text = "Jump by pressing both pillos at the same time";
	}

	public void SlowTextTutorial()
	{
		txt.text = "Pickup the LP to slow down time";
	}

	public void TripTextTutorial()
	{
		txt.text = "Try avoiding the martini's."+"\n"+"They will make it difficult to focus";
	}
}