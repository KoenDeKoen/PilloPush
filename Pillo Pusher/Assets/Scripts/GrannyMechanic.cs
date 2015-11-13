using UnityEngine;
using System.Collections;
using Pillo;

public class GrannyMechanic : MonoBehaviour
{

    // Use this for initialization
    private int state;
    private Vector3 nextpos;

    public MoveCharacter charactermover;
    public GameOverPanel gameoverpanel;
    //public SpeakerFeedback speakerFeedback;

    public Animator speaker1;
    public Animator speaker2;
    private Animator charanimator;

    //private bool p1pressing;
    //private bool p2pressing;
    private bool p1pressed;
    private bool p2pressed;
    private bool p1released;
    private bool p2released;
    // private bool hasjumped;
    private bool devmode;
    public string animstate;

    //public GameObject pillo1feedback;
    //public GameObject pillo2feedback;

    float pct1;
    float pct2;

    void Start()
    {
        //  p1pressing = false;
        //   p2pressing = false;
        charactermover.Init();
        animstate = "Idle1";
        charanimator = FindObjectOfType<CollisionPlayer>().gameObject.GetComponentInChildren<Animator>();
        charanimator.SetInteger("State", 0);
        devmode = false;
        p1pressed = false;
        p2pressed = false;
        p1released = true;
        p2released = true;
      //  hasjumped = false;
        state = 1;
        nextpos = new Vector3(40, 0, 0);

        //speakerFeedback.SpeakerLeftIdle();
        //speakerFeedback.SpeakerRightIdle();

        speaker1.SetInteger("SwitchState", 0);
        speaker2.SetInteger("SwitchState", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameoverpanel.isGameOver())
        {
            if (animstate != "Idle1" && charanimator.GetCurrentAnimatorStateInfo(0).IsName(animstate))
            {
                //Debug.Log(animstate);
                charanimator.SetInteger("State", 0);
                animstate = "Idle1";
            }
            pct1 = PilloController.GetSensor(Pillo.PilloID.Pillo1);
            pct2 = PilloController.GetSensor(Pillo.PilloID.Pillo2);
            checkPresses();
        }
    }

    private void checkPresses()
    {
        if (Input.GetKey("d") && Input.GetKey("e") && Input.GetKey("v"))
        {
            devmode = true;
        }

        if (devmode)
        {
            if (Input.GetKeyDown("a"))
            {
                p1pressed = true;
                speaker1.SetInteger("SwitchState", 1);
            }
            if (Input.GetKeyUp("a"))
            {
                speaker1.SetInteger("SwitchState", 0);
            }
            if (Input.GetKeyDown("d"))
            {
                p2pressed = true;
                speaker2.SetInteger("SwitchState", 1);
            }
            if (Input.GetKeyUp("d"))
            {
                speaker2.SetInteger("SwitchState", 0);
            }
        }
        if (!devmode)
        {
            if (pct1 >= 0.05 && p1released)
            {
                p1pressed = true;
                p1released = false;
                speaker1.SetInteger("SwitchState", 1);
            }
            if (pct1 <= 0)
            {
                p1released = true;
                speaker1.SetInteger("SwitchState", 0);
            }
            if (pct2 >= 0.05 && p2released)
            {
                p2pressed = true;
                p2released = false;
                speaker2.SetInteger("SwitchState", 1);
            }
            if (pct2 <= 0)
            {
                p2released = true;
                speaker2.SetInteger("SwitchState", 0);
            }
        }

        if (p1pressed)
        {
            if (state > 0)
            {
                animstate = "Dash_L1";
                charanimator.SetInteger("State", 4);
                state--;
            }
            switch (state)
            {
                case 0:
                    nextpos.z = -3;
                    charactermover.setNextPos(nextpos);
                    break;

                case 1:
                    nextpos.z = 0;
                    charactermover.setNextPos(nextpos);
                    break;
            }
            p1pressed = false;
            //speaker1.SetInteger("SwitchState", 0);
        }
        if (p2pressed)
        {
            if (state < 2)
            {
                animstate = "Dash_R1";
                charanimator.SetInteger("State", 2);
                state++;
            }
            switch (state)
            {
                case 1:
                    nextpos.z = 0;
                    charactermover.setNextPos(nextpos);
                    break;

                case 2:
                    nextpos.z = 3;
                    charactermover.setNextPos(nextpos);
                    break;
            }
            p2pressed = false;
           // speaker2.SetInteger("SwitchState", 0);
        }
    }
}
