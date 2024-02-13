using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public void LoadPLay(){
        SceneManager.LoadScene("Level_One", LoadSceneMode.Single);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadLevel_Selection(){
        SceneManager.LoadScene("Level_Selection", LoadSceneMode.Single);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //retour au jeu (pour le pause screen)
}
