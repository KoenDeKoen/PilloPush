using UnityEngine;
using System.Collections;
using Pillo;
using UnityEngine.UI;

public class PilloCalibration : MonoBehaviour {

    // Use this for initialization
    public Text instructiontext;
    private float pct1;
    private float pct2;
    private int startingpillo;
    private bool instartsequence;
    private float passedtime;
    private int instructionstate;
    private int pilloscallibrated;
    private bool done;
    private int presscounter;

	void Start ()
    {
        presscounter = 0;
        done = false;
        pilloscallibrated = 0;
        instructionstate = 0;
        passedtime = 3;
        instartsequence = true;
        instructiontext.text = "Press either Pillo to start calibrating that Pillo";
        ConfigureSensorRange(0x50, 0x6f);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        pct1 = PilloController.GetSensor(Pillo.PilloID.Pillo1);
        pct2 = PilloController.GetSensor(Pillo.PilloID.Pillo2);
        if (pct1 <= 0 && pct2 <= 0)
        {
            presscounter++;
        }
        if (presscounter >= 2)
        {
            if (!done)
            {
                if (instartsequence)
                {
                    startSequence();
                }
                else
                {
                    calibrationTime();
                }
            }
            else
            {
                instructionstate = 4;
                passedtime -= Time.deltaTime;
                if (passedtime <= 0)
                {
                    SaveCalibrationValues();
                    Application.LoadLevel("Menu");
                }
            }
        }

        changeText();
    }

    public void SetMaximumPilloValue(int pilloIndex)
    {
        PilloController.SetCalibratedMaximum(PilloController.GetSensor((PilloID)pilloIndex), pilloIndex);
    }

    public void SaveCalibrationValues()
    {
        PilloController.SaveCalibrationValues();
    }

    private void startSequence()
    {
        if (pct1 > 0)
        {
            startingpillo = 1;
            instartsequence = false;
        }
        if (pct2 > 0)
        {
            startingpillo = 2;
            instartsequence = false;
        }
    }

    private void calibrationTime()
    {
        if (instructionstate != 3)
        {
            instructionstate = 1;
        }
        if (startingpillo == 1)
        {
            if (pct1 > 0)
            {
                instructionstate = 2;
                passedtime -= Time.deltaTime;
                if (passedtime <= 0)
                {
                    SetMaximumPilloValue(0);
                    pilloscallibrated++;
                    passedtime = 3;
                    if (pilloscallibrated < 2)
                    {
                        startingpillo = 2;
                        instructionstate = 3;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            else
            {
                passedtime = 3;
            }
        }
        if (instructionstate != 3)
        {
            instructionstate = 1;
        }
        if (startingpillo == 2)
        {
            if (pct2 > 0)
            {
                instructionstate = 2;
                passedtime -= Time.deltaTime;
                if (passedtime <= 0)
                {
                    SetMaximumPilloValue(1);
                    pilloscallibrated++;
                    passedtime = 3;
                    if (pilloscallibrated < 2)
                    {
                        startingpillo = 1;
                        instructionstate = 3;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            else
            {
                passedtime = 3;
            }
        }
    }

    private void changeText()
    {
        switch (instructionstate)
        {
            case 0:
                instructiontext.text = "Press either Pillo to start calibrating that Pillo";
                break;

            case 1:
                instructiontext.text = "Now fully press the Pillo";
                break;

            case 2:
                instructiontext.text = "Keep pressing for: " + (int)passedtime + " seconds!";
                break;

            case 3:
                instructiontext.text = "Now fully press the other Pillo";
                break;

            case 4:
                instructiontext.text = "The Pillos are now calibrated! Going back to the menu in " + (int)passedtime + " seconds";
                break;
        }
        
    }
    public static void ConfigureSensorRange(int min, int max)
    {
        PilloSender.SensorMin = min;
        PilloSender.SensorMax = max;
    }
}
