using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMeteorManager : MonoBehaviour
{

    Vector3 spawnpos;
    Vector3 spawnPosUfo;
    private float timer;
    [SerializeField] int speed;
    [SerializeField] GameObject[] meteors;
    private bool peutspawn;
    int nbmeteor;
    [SerializeField] GameObject ufo;
    private bool peutSpawnUfo;
    private int nbUfo;

    private void Awake()
    {
        speed = 1;
    }
    private void Start()
    {
        peutSpawnUfo = true;
        peutspawn = true;
        SpawnMeteor();
    }

    public void Update()
    {
        nbmeteor = GameObject.FindObjectsOfType<spawnMeteorManager>().Length;
        if (peutSpawnUfo)
        {
            SpawnUfo();
        }
        if (peutspawn)
        {

            SpawnMeteor();
        }
    }
    public void SpawnMeteor()
    {
        int meteor = Random.Range(0, meteors.Length - 1);
        spawnpos = Random.insideUnitCircle.normalized * 12;
        if (peutspawn && nbmeteor <= 10)
        {
            var instance = Instantiate(meteors[meteor], spawnpos, transform.rotation);
            instance.GetComponent<meteordirection>().SetRandomDirection();
            nbmeteor++;
            StartCoroutine(timeraléatoire());
        }
    }

    public void SpawnUfo()
    {
        spawnPosUfo = Random.insideUnitCircle.normalized * 12;
        if (peutSpawnUfo && nbUfo == 0)
        {
            var instanceUfo = Instantiate(ufo,spawnPosUfo, transform.rotation);
            instanceUfo.GetComponent<meteordirection>().SetRandomDirection();
            nbUfo++;
            StartCoroutine(timerUfo());
        }
    }


    IEnumerator timeraléatoire()
    {
        peutspawn = false;
        timer = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(timer);
        peutspawn = true;
    }

    IEnumerator timerUfo()
    {
        peutSpawnUfo = false;
        timer = Random.Range(5,10);
        yield return new WaitForSeconds(timer);
        peutSpawnUfo = true;
    }
}
