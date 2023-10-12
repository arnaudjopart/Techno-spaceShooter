using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_ShootBomb : MonoBehaviour
{
    [SerializeField]
    GameObject bombPrefab;
    [SerializeField]
    float minDelay;
    [SerializeField]
    float maxDelay;
    [SerializeField]
    float initialDelay;


    private void Start()
    {
        StartCoroutine(Shoot());
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }


    }
}
