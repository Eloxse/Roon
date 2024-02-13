using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camSpeed = 3;
    public float offsetX, offsetY, offsetZ;
    
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.position.x + offsetX, camSpeed * Time.deltaTime),
                                        Mathf.Lerp(transform.position.y, player.position.y + offsetY, camSpeed * Time.deltaTime),
                                        offsetZ);
    }
}
