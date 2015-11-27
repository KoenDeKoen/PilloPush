using UnityEngine;
using System.Collections;


public class Option : MonoBehaviour
{
    public Settings settings;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void audioValueChanged()
    {
        if (settings.returnAudioState())
        {
            settings.setAudioState(false);
        }
        else
        {
            settings.setAudioState(true);
        }
    }

    public void returnToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
