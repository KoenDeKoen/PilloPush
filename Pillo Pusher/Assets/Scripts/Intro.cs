﻿using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    // Use this for initialization
    private float time;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            Application.LoadLevel("Menu");
        }
	}
}
