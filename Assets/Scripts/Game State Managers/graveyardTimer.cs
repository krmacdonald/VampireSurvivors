using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class graveyardTimer : MonoBehaviour
{
    public float timeToSurvive;
    public GameObject thingWithText;
    public TextMeshProUGUI timerText;
    private float timePassed;
    public playerLifeManager lifeGetter;
    // Start is called before the first frame update
    void Start()
    {
        timerText = thingWithText.GetComponent<TextMeshProUGUI>();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeGetter.isAlive)
        {
            timePassed += Time.deltaTime;
            timerText.text = "" + (int)(timeToSurvive - timePassed);

            if (timePassed > timeToSurvive)
            {
                SceneManager.LoadScene("Victory Screen");
            }
        }
        else
        {
            timerText.text = "YOU DIED\nPRESS R TO RESTART";
        }
    }
}
