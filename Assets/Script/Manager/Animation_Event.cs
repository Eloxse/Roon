using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Event : MonoBehaviour
{
    public PlayerController player;

    public void Stop(){
        player.Stop();
    }

    public void Respawn(){
        player.Respawn();
    }
}
