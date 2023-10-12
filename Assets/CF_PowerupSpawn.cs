using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_PowerupSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] powerUp;
    int randomIndex;
    float randomDrop;
    [SerializeField]
    float dropRate;

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        randomDrop = Random.value;
        randomIndex = Random.Range(0, powerUp.Length);
        if (randomDrop < dropRate)
        {
            Instantiate(powerUp[randomIndex], transform.position, Quaternion.identity);
        }

    }


}
