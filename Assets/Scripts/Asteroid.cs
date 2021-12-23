using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid //: Enemy
{
    float randx, randy;
    Vector2 randDirection;
    private AsteroidView asteroidView;

    public Asteroid(AsteroidView view)
    {
        asteroidView = view;
    }

    public void Update()
    {
        asteroidView.Move(randDirection);
    }
    public Vector2 RandomRotation(string place)
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
        return randDirection;
    }
    
}
