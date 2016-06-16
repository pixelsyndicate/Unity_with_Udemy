using System;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text TextBox;


    private States state;

    private enum States
    {
        cell,
        mirror,
        sheets_0,
        lock_0,
        cell_mirror,
        lock_1,
        sheets_1,
        floor,
        stairs_0,
        stairs_1,
        stairs_2,
        closet_door,
        in_closet,
        corridor_0,
        corridor_1,
        corridor_2,
        corridor_3,
        courtyard,
        start,
        credits,
        Quit
    }

    private void StateMachine(States currentState)
    {
        switch (currentState)
        {
            case States.cell:
                cell();
                break;
            case States.sheets_0:
                sheets_0();
                break;
            case States.sheets_1:
                sheets_1();
                break;
            case States.corridor_0:
                corridor_0();
                break;
            case States.corridor_1:
                corridor_1();
                break;
            case States.corridor_2:
                corridor_2();
                break;
            case States.corridor_3:
                corridor_3();
                break;
            case States.stairs_0:
                stairs_0();
                break;
            case States.stairs_1:
                stairs_1();
                break;
            case States.stairs_2:
                stairs_2();
                break;
            case States.mirror:
                mirror();
                break;
            case States.lock_0:
                lock_0();
                break;
            case States.lock_1:
                lock_1();
                break;
            case States.floor:
                floor();
                break;
            case States.cell_mirror:
                cell_mirror();
                break;
            case States.closet_door:
                closet_door();
                break;
            case States.in_closet:
                in_closet();
                break;
            case States.courtyard:
                courtyard();
                break;
            case States.credits:
                credits();
                break;
            case States.start:
                letsStart();
                break;
            case States.Quit:
                Quit();
                break;

        }
    }


    // Use this for initialization
    void Start()
    {
        state = States.start;

    }



    void Quit()
    {
        Application.Quit();
    }



    // Update is called once per frame
    void Update()
    {
        StateMachine(state);
        print(state);
    }



    #region Action Methods

    private void in_closet()
    {
        TextBox.text =
            "Description: obsessive MacGuiver binge watching has got you  into the closet. There's a janitors uniform in here. \n\n Press [D] to dress yourself in it or [R] to return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            state = States.corridor_3;
        }
    }

    private void closet_door()
    {
        TextBox.text = "Description: The door to the Janitorial closet is locked. \n\n Press [R] to return";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.floor;
        }
    }

    private void corridor_2()
    {
        TextBox.text = "Description: You are in  a corridor. " +
                       "\n\n Press [S] to take the stairs or [R] to return to the closet";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.stairs_2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.in_closet;
        }
    }

    private void corridor_1()
    {
        TextBox.text = "Description: You are in  a corridor and you have a hairpin in your inventory. " +
                       "\n\n Press [S] to take the stairs or [P] to pick the janitor's closet door lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.stairs_1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            state = States.in_closet;
        }
    }

    private void corridor_3()
    {
        TextBox.text = "Description: You are in  a corridor dressed as a janitor. " +
                       "\n\n Press [S] to take the stairs or [U] to return to the closet and take this silly uniform off.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.courtyard;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            state = States.in_closet;
        }
    }

    private void stairs_2()
    {
        TextBox.text =
            "Description: You head down the stairs, but see at the bottom a burley guard. Geeze. If only you had some kind of disguise! " +
            "\n\n Press [R] to Return up the stairs.";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_2;
        }
    }

    private void stairs_1()
    {
        TextBox.text =
            "Description: You head down the stairs, but see at the bottom a burley guard. This hair in your inventory seems to be insignificant to the task of getting past this guard.  " +
            "\n\n Press [R] to Return up the stairs.";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_1;
        }
    }

    private void stairs_0()
    {
        TextBox.text = "Description: You head down the stairs, but see at the bottom a burley guard. This wont work. " +
                       "\n\n Press [R] to Return up the stairs.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.floor;
        }
    }

    private void corridor_0()
    {
        TextBox.text = "Description: You have reached a corridor. " +
                       "\n\n There are [S] stairs to the left, a [D] closet door marked 'Janitor' [F] and something on the floor.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.stairs_0;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            state = States.floor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            state = States.closet_door;
        }
    }

    private void letsStart()
    {
        TextBox.text =
            "You wake in a cold jail cell. You have a foggy recollection of a smoky ... bar? party? house fire? " +
            "\n\n You just want to escape. Press [SPACE] to continue;";
        if (Input.GetKeyDown(KeyCode.Space))
            state = States.cell;
    }

    private void floor()
    {
        TextBox.text = "Description: You look at the floor and notice a hair pin. " +
                       "\n\n Press [H] to pick-up the hairpin on the floor or [R] to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            state = States.corridor_1;
        }
    }

    private void lock_1()
    {
        TextBox.text = "Description: You see in the mirrors reflection a key in the other side of the door. " +
                       "\n\n Press [O] to Open the lock or [R] to return.";

        if (Input.GetKeyDown(KeyCode.O))
        {
            state = States.corridor_0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell_mirror;
        }
    }

    private void cell_mirror()
    {
        TextBox.text = "Description: You have in your inventory a mirror. " +
                       "\n\n Press [S] to look at the sheets, or [L] to look at the door Lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.sheets_1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            state = States.lock_1;
        }
    }

    private void sheets_1()
    {
        TextBox.text = "Description: The mirror in your hand does nothing to make those sheets look any better. " +
                       "\n\n Press [R] to return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell_mirror;
        }
    }

    private void lock_0()
    {
        TextBox.text =
            "Description: The lock seems pretty solid, and looking through the lock you can see the key is in it, on the other side. " +
            "\n\n Press [R] to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
    }

    private void mirror()
    {
        TextBox.text = "Description: The mirror reflects a bedraggled you. " +
                       "\n\n Press [T] to Take the mirror, or [R] to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            state = States.cell_mirror;
        }
    }

    private void sheets_0()
    {
        TextBox.text = "Description: These sheets have seen better days. You scarely can bear to touch it. " +
                       "\n\n Press R to return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
    }

    private void cell()
    {
        TextBox.text =
            "Description: There are some dirty sheets on the bed, a mirror on the wall, and a locked door. " +
            "\n\n To inspect these things, press S for sheets, M or mirror or L for lock.";
        if (Input.GetKeyDown(KeyCode.S))
            state = States.sheets_0;

        if (Input.GetKeyDown(KeyCode.M))
            state = States.mirror;

        if (Input.GetKeyDown(KeyCode.L))
            state = States.lock_0;
    }

    private void credits()
    {

        TextBox.text =
            "Thank you for playing Prison. \n\n Build with Unity, Personal Edition. &copy; Copyright 2016 by The Pixel Syndicate" +
            "\n\n Press Space to start over. Press Q to quit.";
        if (Input.GetKeyDown(KeyCode.Space))
            state = States.start;
        if (Input.GetKeyDown(KeyCode.Q))
            state = States.Quit;
        if (Input.GetKeyDown(KeyCode.Escape))
            state = States.Quit;
    }

    private void courtyard()
    {
        TextBox.text =
            "Description: The guard gives you a brotherly nod and a fist-bump, releasing the latch on the barred exit, allowing you to leave without incident. You've made it to the public courtyard and without much time lost, on way HOME! MacGuiver's season 2 is playing on Netflix this evening. Perhaps you should go settle down with a bowl of popcorn. " +
            "\n\n Press [E] to end this adventure.";

        if (Input.GetKeyDown(KeyCode.E))
            state = States.credits;
    }

    #endregion
}