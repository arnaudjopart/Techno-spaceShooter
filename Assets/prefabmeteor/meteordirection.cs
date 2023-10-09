using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class meteordirection : EnemyBaseClass
{
    [SerializeField] float speed;
    [SerializeField] float rotation=45f;
    Vector3 direction;
    Vector3 random;
    [SerializeField] private GameObject[] m_liste;

    public void Awake()
    {
        SetRandomDirection();
        
    }
    private void Update()
    {
        transform.position+= direction.normalized * (Time.deltaTime * speed);
        transform.Rotate(0,0, rotation *Time.deltaTime);
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }

    public void SetRandomDirection()
    {
        random = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5));
        direction = -transform.position + random;
    }

    public void SetRandomDirectionAroundThisVector(Vector3 _baseDirection)
    {
        random = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5));
        direction = -transform.position + random;
        
    }

    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        GetComponent<CircleCollider2D>().enabled = false;
        if (m_liste.Length > 0 )
        {
            int asteroide = Random.Range(0,m_liste.Length-1);
            for (int i = 0; i < 2; i++) 
            {
                Instantiate(m_liste[asteroide], transform.position + new Vector3(Random.Range (0,0.5f),Random.Range(0,0.5f),0), Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}
