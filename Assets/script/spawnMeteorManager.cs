using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMeteorManager : MonoBehaviour
{

    Vector3 spawnpos;
    private float timer;
    [SerializeField] int speed;
    [SerializeField] GameObject[] meteors;
    private bool peutspawn;
    int nbmeteor;

    private void Awake()
    {
        speed = 1;
    }
    private void Start()
    {
        peutspawn = true;
        SpawnMeteor();
    }

    public void Update()
    {
        nbmeteor = GameObject.FindObjectsOfType<spawnMeteorManager>().Length;

        if (peutspawn)
        {

            SpawnMeteor();
        }
    }
    public void SpawnMeteor()
    {
        int meteor = Random.Range(0, meteors.Length-1);
        spawnpos = Random.insideUnitCircle.normalized * 12;
        if (peutspawn && nbmeteor <= 50) 
        {
            var instance = Instantiate(meteors[meteor], spawnpos, transform.rotation);
            instance.GetComponent<meteordirection>().SetRandomDirection();
            nbmeteor++;
            StartCoroutine(timeraléatoire());
        }
    }


    IEnumerator timeraléatoire()
    {
        peutspawn = false;
        timer = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(timer);
        peutspawn = true;
    }
}
