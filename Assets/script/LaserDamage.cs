using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public GameObject[] liste;
    public AudioClip boomSound;
    AudioSource audioBoom;
    SpriteRenderer spriteRenderer;
    deplacement roquette;
    public GameObject particule;

    private void Awake()
    {
        audioBoom = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        roquette = GetComponent<deplacement>();

    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("laserUFO"))
        {
            audioBoom.PlayOneShot(boomSound);
            Instantiate(particule,transform.position,Quaternion.identity);
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
            spriteRenderer.enabled = false;
            Destroy(this.gameObject,0.5f);
        }
    }
  
}
