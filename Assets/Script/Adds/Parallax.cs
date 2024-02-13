using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxCoef;
    
    public Transform camera;

    private float _length;
    private float _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _startPosition = transform.position.y; //mouvement background en y
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (camera.transform.position.x * parallaxCoef);

        transform.position = new Vector3(_startPosition + distance, camera.transform.position.y, transform.position.z);
        //la deuxieme declaration, mouvement du background en y, en meme temps que la camera
    
        /////////////////////////////////////////////////////////////////////
        
        float temp = camera.transform.position.x * (1 - parallaxCoef);

        if(temp > _startPosition + _length){
            _startPosition += _length;
        }else if(temp < _startPosition - _length){
            _startPosition -= _length;
        }
    }
}
