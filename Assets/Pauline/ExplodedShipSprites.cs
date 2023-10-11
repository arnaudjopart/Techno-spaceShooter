using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedShipSprites : MonoBehaviour
{
    [SerializeField] Sprite[] m_damaged;
    SpriteRenderer m_spriteRenderer;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_spriteRenderer.sprite = m_damaged[Random.Range(0, m_damaged.Length)];
    }
}
