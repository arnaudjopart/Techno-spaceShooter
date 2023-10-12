using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class wrapping : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        lastPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = transform.position - lastPosition;
        lastPosition = transform.position;
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        float rightSideOffScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOffScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x;

        float topOffScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)).y;
        float bottomOffScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        if (screenPos.x <= 0 && lastPosition.x < 0)
        {
            transform.position = new Vector2(rightSideOffScreenInWorld, transform.position.y);
        }
        if (screenPos.x >= 1 && lastPosition.x > 0)
        {
            transform.position = new Vector2(leftSideOffScreenInWorld,transform.position.y);
        }
         if (screenPos.y <= 0 && lastPosition.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topOffScreenInWorld);
        }
         if(screenPos.y >= 1 && lastPosition.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomOffScreenInWorld);
        }
    }
}
