using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Screen : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public void LoadSceneMenu(string _menu){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void LoadLevelOne(){
        SceneManager.LoadScene("Level_One", LoadSceneMode.Single);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadLevelTwo(){
        SceneManager.LoadScene("Level_Two", LoadSceneMode.Single);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}