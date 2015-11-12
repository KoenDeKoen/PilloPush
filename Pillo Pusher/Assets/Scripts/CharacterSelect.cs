using UnityEngine;
using System.Collections;
using Pillo;


public class CharacterSelect : MonoBehaviour {

	public SelectedCharacter selectedcharacter;
    public ModeSelect modeselect;
	public FaderIn fadein;

	public GameObject rotateParent;
	public GameObject girl;
	public GameObject boy;
    //private Animator maleanimator;

	bool leftR;
	bool rightR;
	bool pressedL;
	bool pressedR;
	bool fade;

	int state;
	
	private float degreesPerSecond = 60f;
	private float totalRotation = 0;
    private int presscounter;
    private bool cancontinue;

	float delay = 1f;
	float pct1;
	float pct2;

	// Use this for initialization
	void Start ()
	{
        cancontinue = false;
        presscounter = 0;
        GameObject.Find("MaleAnimatedPrefab").GetComponentInChildren<Animator>().SetInteger("State", 1);
       // maleanimator.SetInteger("State", 1);
		leftR = false;
		rightR = false;
		fade = false;
	}
	
	// Update is called once per frame
	void Update (){
		pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);

        if ((pct1 <= 0 && pct2 <= 0) || (Input.GetKeyUp("a") || Input.GetKeyUp("d")))
        {
            presscounter++;
        }

        if (((pct1 >= 0.05 || pct2 >= 0.05) || (Input.GetKeyDown("a") || Input.GetKeyDown("d"))) && presscounter >= 2)
        {
            cancontinue = true;
        }

        if (cancontinue)
        {
            if (fade)
            {
                if (modeselect.getMode() == 1)
                {
                    if (fadein.fadeIn())
                    {
                        Application.LoadLevel("Game");
                    }
                }
                if (modeselect.getMode() == 2)
                {
                    if (fadein.fadeIn())
                    {
                        Application.LoadLevel("GrannyMode");
                    }
                }
				if (modeselect.getMode() == 3)
				{
					if (fadein.fadeIn())
					{
						Application.LoadLevel("Tutorial");
					}
				}
            }

            else
            {
                if (Input.GetKey("a") && Input.GetKey("d") || pct1 >= 0.5 && pct2 >= 0.5)
                {
                    fade = true;
                }

                if (Input.GetKeyDown("a") || pct1 >= 0.5)
                {
                    pressedL = true;
                }

                if (Input.GetKeyDown("d") || pct2 >= 0.5)
                {
                    pressedR = true;
                }

                if ((Input.GetKeyUp("a") || pct1 <= 0.2) && pressedL)
                {
                    leftR = true;
                    rightR = false;
                    pressedL = false;
                }

                if ((Input.GetKeyUp("d") || pct2 <= 0.2) && pressedR)
                {
                    leftR = false;
                    rightR = true;
                    pressedR = false;
                }

                if (leftR)
                {
                    RotateLeft();
                }

                if (rightR)
                {
                    RotateRight();
                }

                switch (state)
                {
                    case 0:
                        selectedcharacter.isGirl();
                        break;
                    case 1:
                        selectedcharacter.isBoy();
                        break;
                }
            }
        }
	}

	void RotateLeft ()
	{
		delay -= Time.deltaTime;

		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void RotateRight ()
	{
		delay -= Time.deltaTime;

		float currentAngle = rotateParent.transform.rotation.eulerAngles.y;
		rotateParent.transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;

		StopRotation(currentAngle);
	}

	void StopRotation(float angle)
	{
		if(angle >= 0f && angle <= 1f && delay <= 0f || angle >= 179f && angle <= 180f && delay <= 0f)
		{
			leftR = false;
			rightR = false;
			delay = 1f;
		}

		if(angle >= 0f && angle <= 1f)
		{
			state = 0;
		}

		if(angle >= 179f && angle <= 180f)
		{
			state = 1;
		}
	}
}
