using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    // Use this for initialization
    static private int lives;
    public void setLives(int live)
    {
        lives = live;
	}
	
	// Update is called once per frame

    public int returnLives()
    {
        return lives;
    }
}
