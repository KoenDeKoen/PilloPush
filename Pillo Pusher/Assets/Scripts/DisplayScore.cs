using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	public Score scorekeeper;
	public Text textbox;
	private List<Color> colors;
    private ModeSelect ms;
	private float time;
	private int index;
	void Start () 
	{
        ms = gameObject.GetComponent<ModeSelect>();
		time = 0f;
		index = 0;
		colors = new List<Color> ();
		colors.Add (Color.cyan);
		colors.Add (Color.green);
		colors.Add (Color.magenta);
		colors.Add (Color.red);
		colors.Add (Color.yellow);
		colors.Add (Color.white);
	}
	
	// Update is called once per frame
	void Update () 
	{
		updateScore ();
	}

	private void updateScore()
	{
        if (ms.getMode() == 1)
        {
            time += Time.deltaTime;
            textbox.text = "Score: " + ((int)scorekeeper.returnScore() * 10).ToString();
            if (time >= 0.5F)
            {
                time = 0f;
                if (index >= colors.Count)
                {
                    index = 0;
                }
                textbox.GetComponent<Text>().color = colors[index];
                index++;
            }
        }
        else
        {
            textbox.gameObject.SetActive(false);
        }
	}
}
