using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagePauline : EnemyBaseClass
{
    // [SerializeField] GameObject exploded;


    private void Start()
    {
       // StartCoroutine(ShipDamages());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBaseClass>() != null)
        {
            var dam = collision.GetComponent<EnemyBaseClass>().GetCollisionDamage();
            TakeDamage(dam);
            Destroy(collision.gameObject);
        }
    }
   
    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_lives <= 0) 
        {
            Destroy(this.gameObject);
            
        }
    }

  
    /*IEnumerator ShipDamages()
    {
        Instantiate(exploded,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2);
        exploded.SetActive(false);
    }
    */




}
