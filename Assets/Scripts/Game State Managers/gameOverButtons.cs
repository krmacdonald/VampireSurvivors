using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverButtons : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
