using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public Text pointsText;
    public GameObject player;

   public void SetupScreen(int score)
    {
        Time.timeScale = 0;         //Pause the screen
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("fst_Level");
        Time.timeScale = 1;         

    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

}
