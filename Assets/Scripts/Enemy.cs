using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IBoundariesFinder
{
    private int health;
    private int damage;
    private int speed;
    private Vector2 minBoundaries, maxBoundaries;
    private Camera mainCam;
    private Shard shardScript;
    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }

    public void Divide(int amount, GameObject prefab, bool isRight,Vector3 shardDirection)
    {
        Debug.Log("1");
        int angleBetweeenShard = 0;
     for (int i = 0; i < amount; i++)
        {
            Debug.Log("2");
            var shard = Instantiate(prefab, transform.position,Quaternion.identity);
            var shardS = shard.GetComponent<Shard>();
            if (!isRight)
            {
                Debug.Log("3");
                shardS.direction = Quaternion.Euler(0, 0, angleBetweeenShard+35) * shardDirection;
                angleBetweeenShard += i * 120 + Random.Range(-30, 30);
            }
            //shard.GetComponent
        }
    }

    
    public void Damage()
    {

    }

    public void CheckBoundaries()
    {
        mainCam = Camera.main;
        minBoundaries = mainCam.ViewportToWorldPoint(new Vector2(0f, 0f));
        maxBoundaries = mainCam.ViewportToWorldPoint(new Vector2(1f, 1f));
    }

    public void CrossBoubdaries()
    {
        if (transform.position.x > maxBoundaries.x || transform.position.x < minBoundaries.x || transform.position.y > maxBoundaries.y || transform.position.y < minBoundaries.y)
        {
            Destroy(gameObject);
            }
    }

}
