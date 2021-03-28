using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    //public GameObject scoreText;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        panel.gameObject.GetComponent<GameObject>();
       // scoreText.gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
       // scoreText.SetActive(false);
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
