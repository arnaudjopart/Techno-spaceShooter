using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_ufoMove : MonoBehaviour
{
    float width;
    float height;
    Vector3 goal = new Vector3(0,0,0);
    [SerializeField]
    float speed;

    private void Awake()
    {
        width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
    }

    private void Start()
    {
        goal.x = Random.Range(-width, width);
        goal.y = Random.Range(-height, height);

    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, speed*Time.deltaTime);
        if (Vector3.Distance(transform.position, goal) < 1)
        {
            goal.x = Random.Range(-width, width);
            goal.y = Random.Range(-height, height);
        }
    }
}
