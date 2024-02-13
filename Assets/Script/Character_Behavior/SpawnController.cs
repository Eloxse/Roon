using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject player;
    public Transform camera;
    public AudioSource spawnSound;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer(){
        GameObject monPlayer = Instantiate(player, transform.position, Quaternion.identity);
        camera.GetComponent<CameraController>().player = monPlayer.transform;
        spawnSound.Play();
    }
}
