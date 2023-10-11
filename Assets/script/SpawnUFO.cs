using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnUFO : MonoBehaviour
{
    
    public GameObject laserUFO;
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
            for (int i = 0; i < 3; i++) { 
            var laser = Instantiate(laserUFO, transform.position, Quaternion.identity);
            Destroy(laser, 2);
            StartCoroutine(attenteShootUfo());
            
            //+new Vector3(Random.Range(0, 1f), Random.Range(0, 1f),0)
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
        if (m_canShoot)
        {

        shootUfo();
        }
    }
}
