using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidView : Enemy
{
    [SerializeField] private GameObject prefab;
    public  Vector2 direction;
    public int numberOfShards;

    private void Update()
    {
        Move(direction);
        CrossBoubdaries();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Divide(numberOfShards, prefab, false, direction);
        Debug.Log("Collision with " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
