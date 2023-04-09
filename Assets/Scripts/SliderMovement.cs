using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    public float speed = 2f;

    private int moveDirection = 1;

    public bool isMoving;

    public static SliderMovement Instance;

    
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(isMoving){
            transform.Translate(new Vector3(speed * moveDirection * Time.deltaTime, 0, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("wall1")){
            
            speed = 0;
            
            
        }

        if(other.gameObject.CompareTag("wall2")){
            
            moveDirection *= -1;
            
        }

        
    }
}
