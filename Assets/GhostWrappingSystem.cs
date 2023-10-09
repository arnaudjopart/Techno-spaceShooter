using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWrappingSystem : MonoBehaviour
{
    [SerializeField] private GameObject m_ghostPrefab;

    private Vector3[] m_ghostStartPositions;
    private Transform[] m_ghosts;
    private Vector2 m_bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        m_bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        
        m_ghostStartPositions = new Vector3[8];
        m_ghosts = new Transform[8];
        
        m_ghostStartPositions[0] = 2f * m_bounds.y * Vector3.up;
        m_ghostStartPositions[1] = -m_ghostStartPositions[0];
        m_ghostStartPositions[2] = 2f * m_bounds.x * Vector3.right;
        m_ghostStartPositions[3] = -m_ghostStartPositions[2];
        m_ghostStartPositions[4] = m_ghostStartPositions[0] + m_ghostStartPositions[2];
        m_ghostStartPositions[5] = -m_ghostStartPositions[4];
        m_ghostStartPositions[6] = m_ghostStartPositions[0] - m_ghostStartPositions[2];
        m_ghostStartPositions[7] = -m_ghostStartPositions[6];
        
        InitGhostShips(m_ghostStartPositions);
    }

    private void InitGhostShips(Vector3[] _ghostStartPositions)
    {
        var sprite = GetComponent<SpriteRenderer>().sprite;
        for (var i = 0; i < _ghostStartPositions.Length; i++)
        {
            var item = Instantiate(m_ghostPrefab, _ghostStartPositions[i], Quaternion.identity);
            item.GetComponent<SpriteRenderer>().sprite = sprite;
            m_ghosts[i] = item.transform;
        }
    }
    
    private void Update()
    {
        for (var i = 0; i < 8; i++)
        {
            var currentPosition = m_ghostStartPositions[i] + transform.position;
            m_ghosts[i].position = currentPosition;
            m_ghosts[i].rotation = transform.rotation;
        }
        transform.position = new Vector3((IsOutsideXBounds() ? -1 : 1) * this.transform.position.x, (IsOutsideYBounds() ? -1 : 1) * this.transform.position.y, this.transform.position.z);
    }

    private bool IsOutsideXBounds()
    {
        return this.transform.position.x < -m_bounds.x || this.transform.position.x > m_bounds.x;
    }

    private bool IsOutsideYBounds()
    {
        return this.transform.position.y < -m_bounds.y || this.transform.position.y > m_bounds.y;
    }
}


