using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public GameObject[] liste;
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
                if (liste.Length > 0 )
            {
            int asteroide = Random.Range(0,liste.Length-1);
            for (int i = 0; i < 2; i++) 
                {
                    Instantiate(liste[asteroide], transform.position + new Vector3(Random.Range (0,0.5f),Random.Range(0,0.5f),0), Quaternion.identity);
                }
            }
            Destroy(this.gameObject);
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            int asteroide = Random.Range(0, liste.Length - 1);
            
            Destroy(gameObject);
            for (int i = 0; i < 2; i++)
            {
                Instantiate(liste[asteroide], transform.position, Quaternion.identity);
            }
        }
    
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
