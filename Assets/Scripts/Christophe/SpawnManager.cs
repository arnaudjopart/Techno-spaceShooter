using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector2 spawnPosition;
    [SerializeField] GameObject Asteroids;
    [SerializeField] float radius;
    [SerializeField] float delayMax;
    [SerializeField] int StartingNumberOfAsteroids;


    // Start is called before the first frame update
    void Start()
    {
     for (int i = 0; i < StartingNumberOfAsteroids; i++)
        {
            SpawnAsteroids();
        }

     StartCoroutine(RandomlySpawnAsteroids());


    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroids()
    {
        spawnPosition = Random.insideUnitCircle.normalized * radius;
        Instantiate(Asteroids, spawnPosition, Quaternion.identity);
    }

    IEnumerator RandomlySpawnAsteroids()
    {
        while (true)
        {
            float delay = Random.Range(0, delayMax);
            SpawnAsteroids();
            yield return new WaitForSeconds(delay);

        }

    }
}
