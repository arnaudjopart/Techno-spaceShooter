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
    [SerializeField] int timer = 4;
    vieUFO myvie;
    
    bool m_canShoot;
    private void Awake()
    {
        m_canShoot = false;
        StartCoroutine(attenteShootUfo());
        myvie = GetComponent<vieUFO>();
        
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
       
        yield return new WaitForSeconds(timer);
        m_canShoot = true;
    }
    private void Update()
    {
        if (m_canShoot)
        {

        shootUfo();
        }

        if (myvie.vie == 3) timer = 4;

        if (myvie.vie == 2) timer = 2;

        if (myvie.vie == 1) timer = 1;
    }
}
