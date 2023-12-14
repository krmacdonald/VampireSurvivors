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
    public void startInstructions()
    {
        SceneManager.LoadScene("Instructions");
        Debug.Log("kljadsf");
    }
    public void startLore()
    {
        SceneManager.LoadScene("Lore");
    }
}
