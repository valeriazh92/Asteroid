using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour, IBoundariesFinder
{
    [SerializeField] private AsteroidView asteroidPrefab;
    private Asteroid aster;

    private Vector2 minBoundaries, maxBoundaries;
    private Camera mainCam;
    int spawnRand;

    //[SerializeField] private ShardBomb shardBomb;
    //[SerializeField] private Bomb bomb;
    void Start()
    {
        mainCam = Camera.main;
        CheckBoundaries();
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckBoundaries()
    {
        minBoundaries = mainCam.ViewportToWorldPoint(new Vector2(0f, 0f));
        maxBoundaries = mainCam.ViewportToWorldPoint(new Vector2(1f, 1f));
    }

    public void CrossBoubdaries()
    {
        if (transform.position.x > maxBoundaries.x) { transform.position = new Vector3(minBoundaries.x, transform.position.y, 0f); }
        if (transform.position.x < minBoundaries.x) { transform.position = new Vector3(maxBoundaries.x, transform.position.y, 0f); }
        if (transform.position.y > maxBoundaries.y) { transform.position = new Vector3(transform.position.x, minBoundaries.y, 0f); }
        if (transform.position.y < minBoundaries.y) { transform.position = new Vector3(transform.position.x, maxBoundaries.y, 0f); }
    }
    private void SpawnEnemy()
    {
        var asteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
        var aster = new Asteroid(asteroid);
        asteroid.CheckBoundaries();
        spawnRand = Random.Range(0, 3);
        if (spawnRand == 0)
        {
            asteroid.direction = aster.RandomRotation("top");
            asteroid.transform.position = new Vector3(Random.Range(minBoundaries.x, maxBoundaries.x), maxBoundaries.y, 0f);
        }
        else if(spawnRand == 1)
        {
            asteroid.direction = aster.RandomRotation("down");
            asteroid.transform.position = new Vector3(Random.Range(minBoundaries.x, maxBoundaries.x), minBoundaries.y, 0f);
        }
        else
        {
            asteroid.direction = aster.RandomRotation("top");
            asteroid.transform.position = new Vector3(maxBoundaries.x, Random.Range(minBoundaries.y, maxBoundaries.y), 0f);
        }
        
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnEnemy();
        StartCoroutine(Spawner());
    }

}
