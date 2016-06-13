using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text TextBox;

    private string startingText;
    private States state;

    private enum States
    {
        cell,
        mirror, sheets_0,
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
        credits
    }



    // Use this for initialization
    void Start()
    {
        state = States.start;

    }

    // Update is called once per frame
    void Update()
    {
        StateMachine(state);
        print(state);

    }

    private void StateMachine(States s)
    {

        if (s == States.cell)
        {
            state_cell();

        }
        else if (s == States.sheets_0)
        {
            state_sheets_0();

        }
        else if (s == States.stairs_0)
        {
            state_stairs_0();

        }
        else if (s == States.stairs_1)
        {
            state_stairs_1();

        }
        else if (s == States.stairs_2)
        {
            state_stairs_2();

        }
        else if (s == States.mirror)
        {
            state_mirror();

        }
        else if (s == States.lock_0)
        {
            state_lock_0();

        }
        else if (s == States.sheets_1)
        {
            state_sheets_1();

        }
        else if (s == States.cell_mirror)
        {
            state_cell_mirror();

        }
        else if (s == States.lock_1)
        {
            state_lock_1();

        }
        else if (s == States.corridor_0)
        {
            state_corridor_0();

        }
        else if (s == States.corridor_3)
        {
            state_corridor_3();

        }
        else if (s == States.corridor_1)
        {
            state_corridor_1();

        }
        else if (s == States.corridor_2)
        {
            state_corridor_2();

        }
        else if (s == States.floor)
        {
            state_floor();

        }
        else if (s == States.closet_door)
        {
            closet_door();

        }
        else if (s == States.in_closet)
        {
            state_in_closet();

        }
        else if (s == States.courtyard)
        {
            state_courtyard();
        }
        else if (s == States.credits)
        {
            state_credits();
        }
        else if (s == States.start)
        {
            start();
        }
    }

    private void state_courtyard()
    {
        TextBox.text = "Description: The guard gives you a nod and releases a latch on the barred exit, allowing you to leave without incident. You've made it to the courtyard of the city jail and are on your way HOME! MacGuiver should be on netflix still. \n\n Press [E] to end this adventure.";


        if (Input.GetKeyDown(KeyCode.E))
        {
            state = States.credits;
        }
    }

    private void state_in_closet()
    {
        TextBox.text = "Description: obsessive MacGuiver binge watching has got you  into the closet. There's a janitors uniform in here. \n\n Press [D] to dress yourself in it or [R] to return to the corridor.";


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
        TextBox.text = "Description: The door to the Janitorial closet is locked. Press [R] to return";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.floor;
        }
    }

    private void state_corridor_2()
    {
        TextBox.text = "Description: You are in  a corridor. Press [S] to take the stairs or [R] to return to the closet";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.stairs_2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.in_closet;
        }
    }

    private void state_corridor_1()
    {
        TextBox.text = "Description: You are in  a corridor and you have a hairpin in your inventory. Press [S] to take the stairs or [P] to pick the janitor's closet door lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.stairs_1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            state = States.in_closet;
        }
    }

    private void state_corridor_3()
    {
        TextBox.text = "Description: You are in  a corridor dressed as a janitor. Press [S] to take the stairs or [U] to return to the closet and take this silly uniform off.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.courtyard;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            state = States.in_closet;
        }
    }

    private void state_stairs_2()
    {
        TextBox.text = "Description: You head down the stairs, but see at the bottom a burley guard. Geeze. If only you had some kind of disguise! Press [R] to Return up the stairs.";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_2;
        }
    }

    private void state_stairs_1()
    {
        TextBox.text = "Description: You head down the stairs, but see at the bottom a burley guard. This hair in your inventory seems to be insignificant to the task of getting past this guard.  Press [R] to Return up the stairs.";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_1;
        }
    }

    private void state_stairs_0()
    {
        TextBox.text = "Description: You head down the stairs, but see at the bottom a burley guard. This wont work. Press [R] to Return up the stairs.";


        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.floor;
        }
    }

    private void state_corridor_0()
    {
        TextBox.text = "Description: You have reached a corridor. There are [S] stairs to the left, a [D] closet door marked 'Janitor' [F] and something on the floor.";

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

    private void start()
    {
        TextBox.text =
            "You wake in a cold jail cell. You have a foggy recollection of a smoky ... bar? party? house fire? \n\n You just want to escape. Press SPACE to continue;";
        if (Input.GetKeyDown(KeyCode.Space))
            state = States.cell;
    }

    private void state_floor()
    {
        TextBox.text = "Description: You look at the floor and notice a hair pin. Press [H] to pick-up the hairpin on the floor or [R] to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.corridor_0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            state = States.corridor_1;
        }
    }



    private void state_lock_1()
    {
        TextBox.text = "Description: You see in the mirrors reflection, a key in the lock. \n\n Press O to Open the lock or R to return.";

        if (Input.GetKeyDown(KeyCode.O))
        {
            state = States.corridor_0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell_mirror;
        }
    }

    private void state_cell_mirror()
    {
        TextBox.text = "Description: You have in your inventory a mirror. \n\n Press S to look at the sheets, or L to look at the door Lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.sheets_1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            state = States.lock_1;
        }
    }

    private void state_sheets_1()
    {
        TextBox.text = "Description: The mirror in your hand does nothing to make those sheets look any better. \n\n Press R to return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell_mirror;
        }
    }

    private void state_lock_0()
    {
        TextBox.text = "Description: The lock seems pretty solid, and looking through the lock you can see the key is in it, on the other side. \n\n Press R to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
    }

    private void state_mirror()
    {
        TextBox.text = "Description: The mirror reflects a bedraggled you. \n\n Press T to Take the mirror, or R to return.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            state = States.cell_mirror;
        }
    }

    private void state_sheets_0()
    {
        TextBox.text = "Description: These sheets have seen better days. \n\n Press R to return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = States.cell;
        }
    }

    private void state_cell()
    {
        TextBox.text =
            "Description: There are some dirty sheets on the bed, a mirror on the wall, and a locked door. \n\n To inspect these things, press S for sheets, M or mirror or L for lock.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            state = States.sheets_0;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            state = States.mirror;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            state = States.lock_0;
        }
    }

    private void state_credits()
    {
        TextBox.text = "Thank you for playing Prison. Build with Unity. Copyright 2016 by The Pixel Syndicate";
    }
}
