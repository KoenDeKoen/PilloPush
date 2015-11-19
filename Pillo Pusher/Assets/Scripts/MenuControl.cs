using UnityEngine;
using System.Collections;
using Pillo;

public class MenuControl : MonoBehaviour
{

    public GameObject Optionbtn;
    public GameObject Startbtn;
    public GameObject Calibrationbtn;
    public GameObject Quitbtn;
    public GameObject Tutorialbtn;
    public GameObject Highscorebtn;

    public GameObject Normalmodebtn;
    public GameObject Easymodebtn;

    public ModeSelect modeselect;
	public Animator menu;

    private Vector3 position;
    private bool haspressed1;
    private bool haspressed2;
    private int turnstate;
    private int ystep;
    private int zstep;
    private float time;
    private bool oneispressing;
    private bool twoispressing;
    private bool inmodeselect;
    private bool waitupyo;
    private bool devmode;
   //private bool inhighscore;
    // Use this for initialization
    void Start ()
    {
        // inhighscore = false;
        devmode = false;
        waitupyo = false;
        inmodeselect = false;
        time = 1;
        ystep = 45;
        zstep = 40;
        turnstate = 2;
        haspressed1 = false;
        haspressed2 = false;
        oneispressing = false;
        twoispressing = false;
        position = new Vector3(0, 0, 0);
        Normalmodebtn.transform.localPosition = position;
        Startbtn.transform.localPosition = position;
        position.y = 45;
        position.z = zstep * 1;
        Tutorialbtn.transform.localPosition = position;
        position.y = 90;
        position.z = zstep * 2;
        Calibrationbtn.transform.localPosition = position;
        position.y = -45;
        position.z = zstep * 1;
        Easymodebtn.transform.localPosition = position;
        Optionbtn.transform.localPosition = position;
        position.y = -90;
        position.z = zstep * 2;
        Highscorebtn.transform.localPosition = position;
        position.y = -135;
        position.z = zstep * 3;
        Quitbtn.transform.localPosition = position;
        ConfigureSensorRange(0x50, 0x6f);

    }
	
	// Update is called once per frame
	void Update ()
    {
        checkForPresses();
    }

    private void checkForPresses()
    {
        
        float pct1 = PilloController.GetSensor(Pillo.PilloID.Pillo1);
        float pct2 = PilloController.GetSensor(Pillo.PilloID.Pillo2);

        if (Input.GetKey("d") && Input.GetKey("e") && Input.GetKey("v"))
        {
            devmode = true;
        }

        if (devmode)
        {
            if (!waitupyo && (pct1 >= 0.05 || Input.GetKey("a")))
            {
                haspressed1 = false;
                oneispressing = true;
            }
            if (!waitupyo && (pct2 >= 0.05 || Input.GetKey("d")))
            {
                haspressed2 = false;
                twoispressing = true;
            }
            if ((oneispressing || waitupyo) && Input.GetKeyUp("a"))
            {
                waitupyo = false;
                haspressed1 = true;
                oneispressing = false;
                time = 1;
            }
            if ((twoispressing || waitupyo) && Input.GetKeyUp("d"))
            {
                waitupyo = false;
                haspressed2 = true;
                twoispressing = false;
                time = 1;
            }
        }

        if (!devmode)
        {
            //Debug.Log(pct1);
            if (!haspressed1 && !oneispressing && !waitupyo && pct1 >= 0.05)
            {
                haspressed1 = false;
                oneispressing = true;
            }
            if(!haspressed2 && !twoispressing && !waitupyo && pct2 >= 0.05)
            {
                haspressed2 = false;
                twoispressing = true;
            }
            if((oneispressing || waitupyo) && pct1 <= 0)
            {
                waitupyo = false;
                haspressed1 = true;
                oneispressing = false;
                time = 1;
            }
            if ((twoispressing || waitupyo) && pct2 <= 0)
            {
                waitupyo = false;
                haspressed2 = true;
                twoispressing = false;
                time = 1;
            }
        }

        if (oneispressing && twoispressing)
        {
            time -= Time.deltaTime;
			menu.Play("SelectEnter");
            if (time <= 0)
            {
                selectButton();
            }
        }

        else if (haspressed1)
        {
			menu.Play("SelectUp");
			turnButtonsDown();
            changePosition();
            haspressed1 = false;
            haspressed2 = false;
        }
        else if (haspressed2)
        {
			menu.Play("SelectDown");
			turnButtonsUp();
            changePosition();
            haspressed1 = false;
            haspressed2 = false;
        }
    }

    private void turnButtonsDown()
    {
        if (!inmodeselect)
        {
            if (turnstate >= 0)
            {
                turnstate--;
                if (turnstate <= -1)
                {
                    turnstate = 5;
                }
            }
        }
        if (inmodeselect)
        {
            if (turnstate >= 0)
            {
                turnstate--;
                if (turnstate <= -1)
                {
                    turnstate = 1;
                }
            }
        }
    }

    private void turnButtonsUp()
    {
        if (inmodeselect)
        {
            if (turnstate <= 1)
            {
                turnstate++;
                if (turnstate >= 2)
                {
                    turnstate = 0;
                }
            }
        }
        else
        {
            if (turnstate <= 5)
            {
                turnstate++;
                if (turnstate >= 6)
                {
                    turnstate = 0;
                }
            }
        }
    }
    // le trole le joey le appears in le code

    private void changePosition()
    {
        if (inmodeselect)
        {
            if (turnstate == 0)
            {
                Normalmodebtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Easymodebtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            }
            if (turnstate == 1)
            {
                Normalmodebtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Easymodebtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            }
        }
        else
        {
            if (turnstate == 0)
            {
                //H-Q-C-T-S-O
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Startbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
            }
            if (turnstate == 1)
            {
                //Q-C-T-S-O-H
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Startbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
            }
            if (turnstate == 2)
            {
                //C-T-S-O-H-Q
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
                Startbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
            }
            if (turnstate == 3)
            {
                //T-S-O-H-Q-C
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
                Startbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
            }
            if (turnstate == 4)
            {
                //S-O-H-Q-C-T
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
                Startbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            }

            if (turnstate == 5)
            {
                //O-H-Q-C-T-S
                Calibrationbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
                Tutorialbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
                Startbtn.transform.localPosition = new Vector3(0, ystep * -3, zstep * 3);
                Optionbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
                Highscorebtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
                Quitbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            }
        }
    }

    private void selectButton()
    {
        oneispressing = false;
        twoispressing = false;
        time = 1;
        //oneispressing = false;
        //twoispressing = false;
        if (inmodeselect)
        {
            if (turnstate == 0)
            {
                modeselect.setMode(1);
                Application.LoadLevel("CharacterSelect");
            }
            if (turnstate == 1)
            {
                modeselect.setMode(2);
                Application.LoadLevel("CharacterSelect");
            }
        }
        else 
        {  
            waitupyo = true;
            if (turnstate == 0)
            {
                Application.LoadLevel("Calibration");
            }
            if (turnstate == 1)
            {
                //tutorial
				Tutorialbtn.transform.parent.gameObject.SetActive(false);
				modeselect.setMode(3);
				Application.LoadLevel("CharacterSelect");
            }
            if (turnstate == 2)
            {
                //start
                inmodeselect = true;
                Normalmodebtn.transform.parent.gameObject.SetActive(true);
                Startbtn.transform.parent.gameObject.SetActive(false);
                turnstate = 0;
            }
            if (turnstate == 3)
            {
                //options
            }
            if (turnstate == 4)
            {
                //HighscorePanel.SetActive(true);
                //menuhighscore.printHighscore();
                //inhighscore = true;
                Application.LoadLevel("Highscore");
            }
            if (turnstate == 5)
            {
                Application.Quit();
            }
        }
        
    }
    public static void ConfigureSensorRange(int min, int max)
    {
        PilloSender.SensorMin = min;
        PilloSender.SensorMax = max;
    }
}
