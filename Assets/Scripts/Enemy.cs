using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int health;
    private int damage;
    private int speed;
    public GameObject prefab;

    public abstract void Initialize();

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }

    public void Divide(int amount)
    { 
     for (int i = 0; i < amount; i++)
        {
            GameObject shard = Instantiate(prefab, transform.position,Quaternion.identity);
            //shard.GetComponent
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage();
        }
    }
    public void Damage()
    {

    }

}
