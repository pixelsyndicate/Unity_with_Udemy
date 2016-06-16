using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public void QuitRequest()
    {
        Debug.Log("QuitRequest() was called.");
        Application.Quit();
    }

    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel() was called for " + name);
        SceneManager.LoadScene("Boss");
    }
}
