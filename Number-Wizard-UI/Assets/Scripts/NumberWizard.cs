using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;

    int maxGuessesAllowed = 5;

    public Text text;
    public Text remainingGuessesText;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();

    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;
        max = max + 1; // do this so division can guess 1000;
        text.text = guess.ToString();
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        text.text = guess.ToString();
        maxGuessesAllowed = maxGuessesAllowed - 1;
        remainingGuessesText.text = "Only " + maxGuessesAllowed + " left!";
        if (maxGuessesAllowed <= 0)
        {
            Application.LoadLevel("Win");
        }
    }
}