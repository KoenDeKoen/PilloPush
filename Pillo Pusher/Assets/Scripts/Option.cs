using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Settings settings;
    public GameObject audiotoggle;
    private AudioSource mmm;
    // Use this for initialization
    void Start ()
    {
        mmm = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        //Debug.Log(settings.returnAudioState());
        if (settings.returnAudioState())
        {
            mmm.volume = 1;
            audiotoggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            mmm.volume = 0;
            audiotoggle.GetComponent<Toggle>().isOn = false;
        }
	}

    public void audioValueChanged()
    {
        
        if (settings.returnAudioState())
        {
            mmm.volume = 0;
            settings.setAudioState(false);
        }
        else
        {
            mmm.volume = 1;
            settings.setAudioState(true);
        }
        Debug.Log(settings.returnAudioState());
    }

    public void returnToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
