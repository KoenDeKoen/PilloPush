using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour
{

    // Use this for initialization
    public AudioSource sfxplayer;
    public AudioClip sfxpowerup;
    public AudioClip sfxpowerdown;
    public AudioClip sfxbuttonpress;
    public AudioClip sfxcoin;
    public Settings settings;

    void Start()
    {
        if (settings.returnAudioState())
        {
            sfxplayer.volume = 1;
        }
        else
        {
            sfxplayer.volume = 0;
        }
    }

    public void playPowerUp()
    {
        sfxplayer.clip = sfxpowerup;
        sfxplayer.Play();
    }

    public void playPowerDown()
    {
        sfxplayer.clip = sfxpowerdown;
        sfxplayer.Play();
    }

    public void playButtonPress()
    {
        sfxplayer.clip = sfxbuttonpress;
        sfxplayer.Play();
    }

    public void playCoin()
    {
        sfxplayer.clip = sfxcoin;
        sfxplayer.Play();
    }
}
