using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_Health : MonoBehaviour
{
    [SerializeField]
    int life;
    [SerializeField]
    GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LooseLife();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LooseLife();
    }

    void LooseLife()
    {
        life--;
        if (life <= 0)
        {
            if (hitEffect != null)
            {
                hitEffect.gameObject.SetActive(true);
            }
            GetComponent<Collider2D>().enabled = false;
            var sprites = GetComponentsInChildren<SpriteRenderer>();
            if (sprites != null)
            {
                foreach (var sprite in sprites)
                {
                    sprite.enabled = false;
                }
            }

            var parentSprite  = GetComponent<SpriteRenderer>();
            if (parentSprite != null) 
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            Destroy(gameObject, 1f);



        }
    }
}
