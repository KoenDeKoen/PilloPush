using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{

    // Use this for initialization
    static private bool audioenabled;

    public bool returnAudioState()
    {
        return audioenabled;
    }

    public void setAudioState(bool state)
    {
        audioenabled = state;
    }
}
