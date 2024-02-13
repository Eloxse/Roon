using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer_Controller : MonoBehaviour
{    
    public float timeValue = 90;

    public GameManager gameOverUI;
    public TextMeshProUGUI txt_Timer;
    public AudioSource gameOverSound;

    void Update(){
        if(timeValue > 0){
            timeValue -= Time.deltaTime;
        }else{
            timeValue = 0;
        }

        DisplayTime(timeValue);

        if(timeValue <= 0){
            gameOverUI.GameOverScreen();
        }
        //Affichage du game over quand le timer est a 0:00
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            gameOverSound.Play();
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float secondes = Mathf.FloorToInt(timeToDisplay % 60);

        txt_Timer.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
    //mise en place du compte a rebour
}