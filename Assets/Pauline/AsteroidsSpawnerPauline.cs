using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawnerPauline : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    private float spawnRate;
    Vector3 spawnDirection;
    bool canSpawn;
    [SerializeField] int meteorsCount;


    private void Awake()
    {
        meteorsCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }
    

    private void SpawnMeteors()
    {

      
        if (meteorsCount <= 50)
        {
            canSpawn = true;
            int meteorsSpawned = Random.Range(0, meteors.Length);
            spawnDirection = Random.insideUnitCircle.normalized * 12f;

            meteorsCount++;
            Instantiate(meteors[meteorsSpawned], spawnDirection, Quaternion.identity);
            StartCoroutine(WaitMeteors());
        }
        if(meteorsCount >= 50)
        {
            canSpawn = false;
        }
        
      
    }
    IEnumerator WaitMeteors()
    {
        canSpawn = false;
        spawnRate = Random.Range(1, 3f);
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
      if (canSpawn)
        {
            SpawnMeteors();
        }
    }
}
