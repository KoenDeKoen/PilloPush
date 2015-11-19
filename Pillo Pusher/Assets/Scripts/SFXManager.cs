using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour
{

    // Use this for initialization
    public AudioSource sfxplayer;
    public AudioClip sfxpowerup;
    public AudioClip sfxpowerdown;

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
}
