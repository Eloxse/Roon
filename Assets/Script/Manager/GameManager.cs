using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool GameIsPaused = false;

    public GameObject gameOverUI;
    public GameObject winUI;
    public GameObject pauseMenuUI;
    public AudioSource coinSound;
    public AudioSource gameOverSound;
    public AudioSource loseLifeSound;
    public AudioSource winSound;
    public AudioSource ambianceSound;

    private UI_Manager _ui;

    private int _doubleCoins;
    private int _coins;
    public int _life = 3;
    private int _totalCoins;
    private bool _isDead;
    
    void Awake()
    {
        if(instance != null){
            Destroy(gameObject);
        }

        instance = this;
    }

    void Start(){
        _ui = UI_Manager.instance;
        ambianceSound.Play();
    }

    void Update(){
        if(_life <= 0 && !_isDead){
            _isDead = true;
            gameOverSound.Play();
            GameOverScreen();
        }
        //Game over screen uniquement quand le player n'a plus de vie

        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
        //Mettre le jeu en pause
    }

    public void AddCoins(){
        _coins++;
        _totalCoins++;
        _ui.UpdateCoinText(_totalCoins);
        coinSound.Play();

    }

    public void AddDoubleCoins(){
        _doubleCoins +=2;
        _totalCoins +=2;
        _ui.UpdateCoinText(_totalCoins);
        coinSound.Play();
    }
    //Feature additionnel

    public void LifeCounts(){
        _life -= 1;
        _ui.UpdateLifeImage(_life);
        loseLifeSound.Play();
    }
    //Perdre une vie

    public void GameOverScreen(){
        gameOverUI.SetActive(true);
    }
    //Activer le game over screen

    public void WinScreen(){
        winSound.Play();
        winUI.SetActive(true);
    }
    //Activer le win screen

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //pause + freez time
}