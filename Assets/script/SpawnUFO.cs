using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnUFO : MonoBehaviour
{
    [SerializeField] GameObject[] lasersUfo;
    [SerializeField] GameObject back;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    
    bool m_canShoot;
    private void Awake()
    {
        m_canShoot = false;
        StartCoroutine(attenteShootUfo());
    }

    

    private void shootUfo()
    {
        
        if (m_canShoot == true)
        {
            for (int i = 0; i < 3; i++)
            {
                var laser = Instantiate(lasersUfo[i], transform.position, Quaternion.identity);
                Destroy(laser, 2);
            }
            StartCoroutine(attenteShootUfo());
        }
    }

    
    
    
    IEnumerator attenteShootUfo()
    {
        m_canShoot = false;
        
        yield return new WaitForSeconds(2);
        m_canShoot = true;
    }
    private void Update()
    {
        if (m_canShoot)
        {

        shootUfo();
        }
    }
}
