using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : Enemy
{
    public Vector2 direction;
    void Update()
    {
        Move(direction);
        //CrossBoubdaries();
    }
    
}
