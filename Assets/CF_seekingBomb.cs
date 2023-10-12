using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_seekingBomb : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
