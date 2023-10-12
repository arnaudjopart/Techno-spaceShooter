using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vieUFO : MonoBehaviour
{
    public int vie;
    bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        vie = 3;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser") && invincible == false)
        {
            vie--;
            StartCoroutine(invincibilite());
            Destroy(collision.gameObject);
            invincible = true;

        }

        if (vie == 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator invincibilite()
    {
        for (var i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.2f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.2f);
        }

        invincible = false;
    }
}
