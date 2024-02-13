using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slime_Controller : MonoBehaviour
{
    public int vitesseSlime = 5;

    public Transform[] checkpoints;

    private int _currentCheckpointID = 1;    

    void Start()
    {
        DOTween.Init();
        StartCoroutine(Patrol(checkpoints[_currentCheckpointID]));
    }

    IEnumerator Patrol(Transform checkpoint){
        transform.DOMoveX(checkpoint.position.x, vitesseSlime, false).SetEase(Ease.Linear);

        while(transform.position.x < checkpoint.position.x - 0.2f || transform.position.x > checkpoint.position.x +0.2f){
            yield return new WaitForEndOfFrame();
        }

        _currentCheckpointID++;

        if(_currentCheckpointID>checkpoints.Length - 1){
            _currentCheckpointID = 0;
        }

        StartCoroutine(Patrol(checkpoints[_currentCheckpointID]));
    }
}
