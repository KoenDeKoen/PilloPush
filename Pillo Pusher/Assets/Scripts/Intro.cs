using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    // Use this for initialization
    public Settings settings;
    private float time;
	void Start ()
    {
        settings.setAudioState(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            Application.LoadLevel("PilloIntro");
        }
	}
}
