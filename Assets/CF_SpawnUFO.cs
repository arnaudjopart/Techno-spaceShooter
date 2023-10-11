using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_SpawnUFO : MonoBehaviour
{
 

    Vector3 spawnpos;
    private float timer;
    [SerializeField] GameObject ufo;
    private bool peutspawn;
    [SerializeField]
    float minSpawnDelay;
    [SerializeField]
    float maxSpawnDelay;


    private void Start()
    {
        peutspawn = true;
        SpawnMeteor();
    }

    public void Update()
    {
        

        if (peutspawn)
        {

            SpawnMeteor();
        }
    }
    public void SpawnMeteor()
    {
        
        spawnpos = Random.insideUnitCircle.normalized * 12;
        if (peutspawn )
        {
            var instance = Instantiate(ufo, spawnpos, Quaternion.identity);
           
            StartCoroutine(timeraléatoire());
        }
    }


    IEnumerator timeraléatoire()
    {
        peutspawn = false;
        timer = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(timer);
        peutspawn = true;
    }
}
