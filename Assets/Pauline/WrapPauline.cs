using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WrapPauline : MonoBehaviour
{
    Camera cam;

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main;

        Vector3 viewportPosition= cam.WorldToViewportPoint(transform.position);
        
        Vector3 moveAdjustment = Vector3.zero;

        if (viewportPosition.x < 0)
        {
            moveAdjustment.x += 1;
        }
        else if (viewportPosition.x > 1)
        {
            moveAdjustment.x -= 1;
        }
        else if (viewportPosition.y < 0)
        {
            moveAdjustment.y += 1;
        }
        else if (viewportPosition.y > 1)
        {
            moveAdjustment.y -= 1;
        }

        transform.position = cam.ViewportToWorldPoint(viewportPosition + moveAdjustment);
    }
}
