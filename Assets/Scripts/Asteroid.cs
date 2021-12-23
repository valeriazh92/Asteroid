using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    float randx, randy;
    Vector2 randDirection;


    public override void Initialize()
    {
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(randDirection);
    }
    public void RandomRotation(string place)
    {
        if(place == "top")
        {
            randx = Random.Range(-20f, 20f);
            randy = Random.Range(-20f, 0f);
        }
        else if (place == "down")
        {
            randx = Random.Range(-20f, 20f);
            randy = Random.Range(0f, 20f);
        }
        else if (place == "right")
        {
            randx = Random.Range(-20f,0f);
            randy = Random.Range(-20f, 20f);
        }
        randDirection = new Vector2(randx, randy);
        randDirection = Vector2.ClampMagnitude(randDirection, 0.05f);//change at speed

    }
    void AAAA()
    {
        //if (transform.position.x > maxBoundaries.x || transform.position.x < minBoundaries.x || transform.position.y > maxBoundaries.y || transform.position.y < minBoundaries.y)
        //{

        //}
    }
}
