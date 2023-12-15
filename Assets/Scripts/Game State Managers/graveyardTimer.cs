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
    // Start is called before the first frame update
    void Start()
    {
        timerText = thingWithText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timerText.text = "" + (int)(timeToSurvive - timePassed);

        if(timePassed > timeToSurvive)
        {
            SceneManager.LoadScene("Victory Screen");
        }
    }
}
