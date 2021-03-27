using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        panel.gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
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
        Debug.Log("Oyundan Çıktın");
    }
    
}
