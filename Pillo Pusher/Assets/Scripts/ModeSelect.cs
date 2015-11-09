using UnityEngine;
using System.Collections;

public class ModeSelect : MonoBehaviour {

    // Use this for initialization
    static private int mode;

    public void setMode(int state)
    {
        mode = state;
    }

    public int getMode()
    {
        return mode;
    }
}
