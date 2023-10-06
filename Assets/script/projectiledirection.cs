using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class projectiledirection : MonoBehaviour
{
    [SerializeField]int speed;
    private void Update()
    {
        transform.Translate((Vector3.up) * Time.deltaTime * speed);        
    }
    
    
    
}
