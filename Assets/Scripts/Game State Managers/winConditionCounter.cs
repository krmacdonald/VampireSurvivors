using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winConditionCounter : MonoBehaviour
{
    public int numEnemies;
    public int curEnemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
