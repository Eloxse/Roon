using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craked_Block : MonoBehaviour
{
    public GameObject btn_Brocken;

    private bool _isBrocken = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && !_isBrocken){
            btn_Brocken.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            btn_Brocken.SetActive(false);
        }
    }

    public void Brocken(){
        if(!_isBrocken){
            Destroy(gameObject);
            _isBrocken = true;
            btn_Brocken.SetActive(false);
        }
    }

    //Interaction avec le bloc de sable pour le detruire
}
