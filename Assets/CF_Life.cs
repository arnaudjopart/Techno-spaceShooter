using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_Life : MonoBehaviour
{
    [SerializeField] GameObject[] lifes;
    int index;
    public delegate void OnDeath();
    public static OnDeath ondeath;
    [SerializeField]
    GameObject gameOver;
    int maxLife;


    private void Awake()
    {
        index = lifes.Length-1;
        maxLife = index;
    }

    private void OnEnable()
    {
        CF_AddLife.liveup+= GainLife;
    }

    private void OnDisable()
    {
        CF_AddLife.liveup -= GainLife;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CompareTag("Laser"))
        {
            if (index >= 0) 
            {
                lifes[index].SetActive(false);
                index--;
                if (index < 0)
                {
                    gameOver.SetActive(true);
                    ondeath?.Invoke();
                }
            }
           

        }
    }

    void GainLife()
    {
        if (index < maxLife)
        {
            index++;
            lifes[index].SetActive(true);

        }

    }
}
