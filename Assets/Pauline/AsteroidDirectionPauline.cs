using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof (Rigidbody2D), typeof(SpriteRenderer))] 
public class AsteroidDirectionPauline : MonoBehaviour
{
    [SerializeField] float speedAsteroid = 2f;
    [SerializeField] Sprite[] m_asteroids;
    SpriteRenderer m_spriteRenderer;
    Rigidbody2D m_rigibody2D;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_spriteRenderer.sprite = m_asteroids[Random.Range(0, m_asteroids.Length)];

        Vector2 direction = new Vector2(Random.Range(0,10), Random.Range(0,10)).normalized;
        m_rigibody2D.AddForce(direction * speedAsteroid, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
