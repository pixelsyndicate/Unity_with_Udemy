using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int _max;
    int _min;
    int _guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           // Debug.Log("Pressed " + KeyCode.UpArrow);
            _min = _guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           // Debug.Log("Pressed " + KeyCode.DownArrow);
            _max = _guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
          //  Debug.Log("Pressed " + KeyCode.Return);
            print("I Won!");
            StartGame();
        }
    }


    void StartGame()
    {
        _max = 1000;
        _min = 1;
        _guess = 500;

        print("=== Welcome to Number Wizard ===");
        print("Pick a number in your head, but don't tell me.");

        print("The number must be between " + _min + " and " + _max);

        print("Is the number higher or lower than " + _guess + "?");
        print("UP = higher, DOWN = lower, ENTER for equal.");

        _max = _max + 1; // do this so division can guess 1000;
    }

    void NextGuess()
    {
        _guess = (_max + _min)/2;
        print("Is the number higher or lower than " + _guess + "?");
    }
}