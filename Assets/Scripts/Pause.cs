using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private Score sc;
    private int actualScore;
    private int expectedScore;
    
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void continuar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
     }
    //Metodo que tengo que explicar
    public void mainMenu(int scene)
    {
        if (scene == 1 || scene == 6 || scene == 7 || scene == 8)
        {
            int num = PlayerPrefs.GetInt("juegoNormal", 0);
            if (num == 1)
            {
                GameObject gameControllerObject = GameObject.FindWithTag("GameController");
                sc = gameControllerObject.GetComponent<Score>();
                actualScore = sc.getScore();
                expectedScore = PlayerPrefs.GetInt("score", 0) + actualScore;
                PlayerPrefs.SetInt("score", expectedScore);
                Debug.Log(PlayerPrefs.GetInt("score"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("juegoNormal", 0);
        }
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
