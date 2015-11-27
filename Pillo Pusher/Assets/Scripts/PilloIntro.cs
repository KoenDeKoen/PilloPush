using UnityEngine;
using System.Collections;
using Pillo;
using UnityEngine.UI;

public class PilloIntro : MonoBehaviour {

    // Use this for initialization
    public Sprite pillo1notpressed;
    public Sprite pillo1pressed;
    public Sprite pillo2notpressed;
    public Sprite pillo2pressed;
    public GameObject pillo1image;
    public GameObject pillo2image;
    public GameObject timertext;

    private float pct1;
    private float pct2;
    private float timer;
    private int state;
    private bool countdown;

	void Start ()
    {
        countdown = false;
        state = 0;
        ConfigureSensorRange(0x50, 0x6f);
        timer = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        pct1 = PilloController.GetSensor(Pillo.PilloID.Pillo1);
        pct2 = PilloController.GetSensor(Pillo.PilloID.Pillo2);
        if (pct1 >= 0.05 && pct2 >= 0.05 && state != 1)
        {
            pillo1image.GetComponent<Image>().sprite = pillo1pressed;
            pillo2image.GetComponent<Image>().sprite = pillo2pressed;
            state = 1;
            countdown = true;
        }
        else if (pct1 >= 0.05 && pct2 == 0 && state != 2)
        {
            pillo1image.GetComponent<Image>().sprite = pillo1pressed;
            pillo2image.GetComponent<Image>().sprite = pillo2notpressed;
            state = 2;
            countdown = false;
            timer = 3;
        }
        else if (pct2 >= 0.05 && pct1 == 0 && state != 3)
        {
            pillo1image.GetComponent<Image>().sprite = pillo1notpressed;
            pillo2image.GetComponent<Image>().sprite = pillo2pressed;
            state = 3;
            countdown = false;
            timer = 3;
        }
        else if (pct1 == 0 && pct2 == 0 && state != 4)
        {
            pillo1image.GetComponent<Image>().sprite = pillo1notpressed;
            pillo2image.GetComponent<Image>().sprite = pillo2notpressed;
            state = 4;
            countdown = false;
            timer = 3;
        }
        if (countdown)
        {
            timertext.GetComponent<Text>().text = ((int)timer + 1).ToString();
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer <= 0)
        {
            Application.LoadLevel("Menu");
        }
        if (Input.GetKeyDown("s"))
        {
            Application.LoadLevel("Menu");
        }
    }

    public static void ConfigureSensorRange(int min, int max)
    {
        PilloSender.SensorMin = min;
        PilloSender.SensorMax = max;
    }
}
