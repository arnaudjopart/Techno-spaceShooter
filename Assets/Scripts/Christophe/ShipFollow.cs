using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollow : MonoBehaviour
{
    GameObject player;
    Vector3 relativePosition;
    public int ghostNumber;
    public bool isForcedWarp = false;
    // Start is called before the first frame update

    private void Awake()
    {
        ghostNumber = FindObjectsOfType<ShipFollow>().Length;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        relativePosition = transform.position - player.transform.position;

    }


    void LateUpdate()
    {
        transform.position = player.transform.position + relativePosition;
        transform.rotation = player.transform.rotation;

    }

    private void OnEnable()
    {
       
            Warp.onOutsideScreen += Teleport;


        Warp.onInsideScreen += DestroyShip;


    }

    private void OnDisable()
    {
        Warp.onOutsideScreen -= Teleport;
        Warp.onInsideScreen -= DestroyShip;
    }

    void DestroyShip()
    {
        Debug.Log("destroy" + transform.position);
        Destroy(gameObject,0.1f);
    }

    private void Teleport(bool b)
    {
        if (b)
        {
            if (isForcedWarp)
            {
                player.transform.position = transform.position;
                player.GetComponent<Warp>().cornerExist = false;
            }
        }
        else
        {
            player.transform.position = transform.position;
        }
            
    }

}
