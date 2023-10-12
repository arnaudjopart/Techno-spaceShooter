using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CF_MeteorHealth : MonoBehaviour
{
    public GameObject[] liste;
    [SerializeField] int health;
    [SerializeField] GameObject explosionFX;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            health--;
            Debug.Log("!!!!!!!!!!!!" + health);

            Destroy(collision.gameObject);
            
            var crush = Instantiate(explosionFX, collision.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(crush, 0.5f);


            if(health <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                Debug.Log("*********************KILL * ***************************");
                if (liste.Length > 0)
                {
                    int asteroide = Random.Range(0, liste.Length - 1);
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(liste[asteroide], transform.position + new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), 0), Quaternion.identity);
                    }
                }
                Destroy(this.gameObject);

            }


        }
    }
}
