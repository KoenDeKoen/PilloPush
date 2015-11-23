using UnityEngine;
using System.Collections;
using Pillo;

public class PilloIntro : MonoBehaviour {

    // Use this for initialization
    public Texture pillo1notpressed;
    public Texture pillo1pressed;
    public Texture pillo2notpressed;
    public Texture pillo2pressed;
    public GameObject pillo1image;
    public GameObject pillo2image;
    public GameObject timertext;
    
	void Start ()
    {
        ConfigureSensorRange(0x50, 0x6f);

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public static void ConfigureSensorRange(int min, int max)
    {
        PilloSender.SensorMin = min;
        PilloSender.SensorMax = max;
    }
}
