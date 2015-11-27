using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Settings settings;
    public GameObject audiotoggle;
    private AudioSource mmm;
   // private bool idk;
    // Use this for initialization
    void Start ()
    {
        //idk = false;
        mmm = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        //Debug.Log(settings.returnAudioState());
        if (!settings.returnAudioState())
        {
            mmm.volume = 0;
            audiotoggle.GetComponent<Toggle>().isOn = false;
            audioValueChanged();
            //idk = true;
        }
	}

    void Update()
    {
        //Debug.Log(idk);
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
    }

    public void returnToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
