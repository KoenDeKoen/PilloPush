using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour {

	// Use this for initialization
	private GameObject musicplayer;
    public Settings settings;

	void Start () 
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
        if (settings.returnAudioState())
        {
            musicplayer.GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            musicplayer.GetComponent<AudioSource>().volume = 0;
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void resumeMusic()
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
		musicplayer.GetComponent<AudioSource> ().Play ();

	}

	public void stopMusic()
	{
		musicplayer = GameObject.Find ("MainMenuMusic");
		musicplayer.GetComponent<AudioSource> ().Stop ();
	}

    public void setVolume(float volume)
    {
        musicplayer.GetComponent<AudioSource>().volume = volume;
    }
}
