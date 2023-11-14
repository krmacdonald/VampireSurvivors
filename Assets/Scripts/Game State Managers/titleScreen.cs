using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("AreaOne");
    }
}
