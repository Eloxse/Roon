using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour
{
    public GameObject btn_Open;
    public GameObject coin;

    private bool _isOpen = false;

    private GameObject _newCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && !_isOpen){
            btn_Open.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            btn_Open.SetActive(false);
        }
    }

    public void Open(){
        if(!_isOpen){
            _isOpen = true;
            GetComponent<Animator>().SetBool("Open", true);
            btn_Open.SetActive(false);
            _newCoin = Instantiate(coin, transform.position, Quaternion.identity);
            _newCoin.transform.DOMoveY(transform.position.y + 1f, 1f, false).SetEase(Ease.OutCubic);
            StartCoroutine(ActivateCoin());
        }
    }

    IEnumerator ActivateCoin(){
        _newCoin.transform.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        _newCoin.transform.GetComponent<CircleCollider2D>().enabled = true;
    }
}
