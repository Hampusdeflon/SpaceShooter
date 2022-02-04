using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int currentSceneQueue = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneQueue + 1); // Load next Scene in queue
    }

    public void QuitGame()
    {
        Debug.Log("Player Quit");
        Application.Quit();
    }
}
