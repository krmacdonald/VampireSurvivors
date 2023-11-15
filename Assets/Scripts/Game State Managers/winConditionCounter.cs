using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class winConditionCounter : MonoBehaviour
{
    public int numEnemies;
    public int curEnemies;
    public GameObject text;
    private TextMeshProUGUI actualText;
    public playerLifeManager healthGetter;
    void Start()
    {
        actualText = text.GetComponent<TextMeshProUGUI>();
        curEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthGetter.isAlive)
        {
            actualText.text = "Cultists Purged\n" + curEnemies + " / " + numEnemies;
        }
        else
        {
            actualText.text = "REST IN PEACE\n Press R to try again";
        }
        if(numEnemies == curEnemies)
        {
            endGame();
        }
    }

    public void addEnemies(int enemiesToAdd)
    {
        curEnemies += enemiesToAdd;
    }

    public void endGame()
    {
        SceneManager.LoadScene("Victory Screen");
    }
}
