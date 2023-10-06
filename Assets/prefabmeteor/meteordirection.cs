using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class meteordirection : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotation=45f;
    Vector3 direction;
    Vector3 random;
    public void Awake()
    {
        random = new Vector3 (Random.Range(-10,10), Random.Range(-5,5));
        direction = -transform.position + random;
    }
    private void Update()
    {
        transform.position+= direction.normalized * Time.deltaTime * speed;
        transform.Rotate(0,0, rotation *Time.deltaTime);
        
    }
    
    
    
}
