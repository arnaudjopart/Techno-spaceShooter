using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class meteordirection : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;
    private void Awake()
    {
        direction = -transform.position;
    }
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        
    }
    
    
    
}
