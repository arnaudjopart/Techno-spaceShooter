using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawnerPauline : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    private float spawnRate;
    Vector3 spawnDirection;
    bool canSpawn;
    [SerializeField] int m_meteorsCount;
    [SerializeField] int maxMeteorsSpawn = 50;


    private void Awake()
    {
        m_meteorsCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }
    

    private void SpawnMeteors()
    {

      
        if (m_meteorsCount <= maxMeteorsSpawn)
        {
            canSpawn = true;
            int meteorsSpawned = Random.Range(0, meteors.Length);
            spawnDirection = Random.insideUnitCircle.normalized * 12f;

            m_meteorsCount++;
            var item = Instantiate(meteors[meteorsSpawned], spawnDirection, Quaternion.identity);
            item.GetComponent<AsteroidDivisionPauline>().SetSpawner(this);

            StartCoroutine(WaitMeteors());
        }
        if(m_meteorsCount >= maxMeteorsSpawn)
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

    internal void UpdateAsteroidCount(int v)
    {
        m_meteorsCount += v;
    }
}
