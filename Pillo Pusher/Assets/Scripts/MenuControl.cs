using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour
{

    public GameObject Optionbtn;
    public GameObject Startbtn;
    public GameObject Calibrationbtn;
    public GameObject Quitbtn;
    public GameObject Tutorialbtn;
    private Vector3 position;
    private bool haspressed1;
    private bool haspressed2;
    private int turnstate;
    private int ystep;
    private int zstep;
    private float time;
    private bool oneispressing;
    private bool twoispressing;
    // Use this for initialization
    void Start ()
    {
        time = 0;
        ystep = 45;
        zstep = 40;
        turnstate = 2;
        haspressed1 = false;
        haspressed2 = false;
        oneispressing = false;
        twoispressing = false;
        position = new Vector3(0, 0, 0);
        Startbtn.transform.localPosition = position;
        position.y = 45;
        position.z = zstep * 1;
        Tutorialbtn.transform.localPosition = position;
        position.y = 90;
        position.z = zstep * 2;
        Calibrationbtn.transform.localPosition = position;
        position.y = -45;
        position.z = zstep * 1;
        Optionbtn.transform.localPosition = position;
        position.y = -90;
        position.z = zstep * 2;
        Quitbtn.transform.localPosition = position;

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
        if (!haspressed1 && !oneispressing && (pct1 >= 0.05 || Input.GetKeyDown("a")))
        {
            haspressed1 = false;
            oneispressing = true;
        }
        if (!haspressed2 && !twoispressing && (pct2 >= 0.05 || Input.GetKeyDown("d")))
        {
            haspressed2 = false;
            twoispressing = true;
        }
        if (oneispressing && (pct1 <= 0.01 || Input.GetKeyUp("a")))
        {
            haspressed1 = true;
            oneispressing = false;
        }
        if (twoispressing && (pct2 <= 0.01 || Input.GetKeyUp("d")))
        {
            haspressed2 = true;
            twoispressing = false;
        }

        if (haspressed1 && haspressed2)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                selectButton();
            }
        }

        else if (haspressed1)
        {
            turnButtonsDown();
            changePosition();
            haspressed1 = false;
            haspressed2 = false;
        }
        else if (haspressed2)
        {
            turnButtonsUp();
            changePosition();
            haspressed1 = false;
            haspressed2 = false;
        }
    }

    private void turnButtonsDown()
    {
        if (turnstate >= 0)
        { 
            turnstate--;
            if (turnstate <= -1)
            {
                turnstate = 4;
            }
        }
    }

    private void turnButtonsUp()
    {
        if (turnstate <= 4)
        {
            turnstate++;
            if(turnstate >= 5)
            {
                turnstate = 0;
            }
        }
    }
    // le trole le joey le appears in le code

    private void changePosition()
    {
        if (turnstate == 0)
        {
            Calibrationbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            Tutorialbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
            Startbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
            Optionbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
            Quitbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
        }
        if (turnstate == 1)
        {
            Calibrationbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
            Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
            Startbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
            Optionbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            Quitbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
        }
        if (turnstate == 2)
        {
            Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
            Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
            Startbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            Optionbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            Quitbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
        }
        if (turnstate == 3)
        {
            Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
            Tutorialbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            Startbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            Optionbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
            Quitbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
        }
        if (turnstate == 4)
        {
            Calibrationbtn.transform.localPosition = new Vector3(0, ystep * 0, zstep * 0);
            Tutorialbtn.transform.localPosition = new Vector3(0, ystep * -1, zstep * 1);
            Startbtn.transform.localPosition = new Vector3(0, ystep * -2, zstep * 2);
            Optionbtn.transform.localPosition = new Vector3(0, ystep * 2, zstep * 2);
            Quitbtn.transform.localPosition = new Vector3(0, ystep * 1, zstep * 1);
        }
    }

    private void selectButton()
    {
        if (turnstate == 0)
        {
            Application.Quit();
        }
        if (turnstate == 1)
        {
            //here be options
        }
        if (turnstate == 2)
        {
            //here be mode select
        }
        if (turnstate == 3)
        {
            //here be tutorial
        }
        if (turnstate == 4)
        {
            //here be callibration
        }
    }
}
