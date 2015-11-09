using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    // Use this for initialization
    private int lives;
	void Start ()
    {
        lives = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    private void lowerLivesWithOne()
    {
        lives--;
        if (lives <= 0)
        {

        }
    }
}
