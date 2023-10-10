using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnUFO : MonoBehaviour
{
    Vector3 posShoot;
    Vector3 lastpos;
    public GameObject laserUFO;
    bool m_canShoot;
    private void Awake()
    {
        m_canShoot = true;
        posShoot = transform.position;
    }

    private void shootUfo()
    {
        
        if (m_canShoot == true)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(laserUFO, lastpos + new Vector3(Random.Range(0, 15f), Random.Range(0, 15f), 0), Quaternion.identity);
                StartCoroutine(attenteShootUfo());
                Destroy(laserUFO,3f);
            }
        }
        }
    
    
    IEnumerator attenteShootUfo()
    {
        m_canShoot = false;
        
        yield return new WaitForSeconds(4);
        m_canShoot = true;
    }
    private void Update()
    {
        lastpos = transform.position - posShoot; 
        shootUfo();
    }
}
