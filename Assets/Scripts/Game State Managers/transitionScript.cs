using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("AreaTwo");
            Debug.Log("asdf");
        }
    }

}
