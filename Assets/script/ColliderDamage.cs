using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderDamage : MonoBehaviour
{
    [SerializeField] int vie;
    [SerializeField] bool invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        vie = 3;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gros"))
        {
            vie--;
            invincible = true;
            StartCoroutine(invincibilite());
        }
        else if (collision.gameObject.CompareTag("Moyen"))
        {
            vie--;
            invincible = true;
            StartCoroutine(invincibilite());
        }
        else if (collision.gameObject.CompareTag("Petit"))
        {
            vie--;
            invincible = true;
            StartCoroutine(invincibilite());
        }

        else if (collision.gameObject.CompareTag("UFO"))
        {
            vie--;
            invincible = true;
            StartCoroutine(invincibilite());
        }

        else if (collision.gameObject.CompareTag("laserUFO"))
        {
            vie--;
            invincible = true;
            StartCoroutine(invincibilite());
            
        }

        if (vie == 0)
        {
            SceneManager.LoadScene("Terence_Scene");
        }

    }

    IEnumerator invincibilite()
    {
        for(var i = 0; i < 5; i++) {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.2f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.2f);
        }

        invincible = false;
    }
}
