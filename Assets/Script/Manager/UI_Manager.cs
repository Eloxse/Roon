using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text txt_Coin; //Prefab de coeur
    public GameObject heartPrefab;
    public Transform heartParent;//Nombre de coeurs dans l'UI
    
    public static UI_Manager instance;

    private GameObject[] _hearts;
    
    void Awake()
    {
        if(instance != null){
            Destroy(gameObject);
        }

        instance = this;
    }

    void Start(){
        CreateHearts();
    }

    private void CreateHearts(){
        _hearts = new GameObject[GameManager.instance._life];

        for(int i = 0; i < GameManager.instance._life; i++){
            GameObject heart = Instantiate(heartPrefab, heartParent);
            _hearts[i] = heart;
        }
    }
    //Afficher les coeurs en debut de partie

    public void UpdateCoinText(int nbCoin){
        txt_Coin.text = nbCoin.ToString();
    }

    public void UpdateLifeImage(int nbLife)
    {
        _hearts[nbLife].SetActive(false);
    }
    //Enlever un coeur
}