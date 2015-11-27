using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{

    // Use this for initialization
    private static bool audio;
	void Start ()
    {
        //audio = true; 
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public bool returnAudioState()
    {
        return audio;
    }

    public void setAudioState(bool state)
    {
        audio = state;
    }
}
