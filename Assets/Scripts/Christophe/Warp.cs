using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    float width;
    float height;

 float minHorizontalBorderSize;
 float minVerticalBorderSize;
    [SerializeField] GameObject prefab;
    bool onBorderXpos, onBorderXneg, onBorderYpos, onBorderYneg;
    public delegate void OnInsideScreen();
    public static OnInsideScreen onInsideScreen;
    public delegate void OnOutsideScreen(bool isCorner);
    public static OnOutsideScreen onOutsideScreen;
    Vector3 screenSize;
    bool isOut;
    public bool cornerExist;




    void Awake()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        onBorderXneg = false;
        onBorderYneg = false;
        onBorderXpos = false;
        onBorderYpos= false;
        cornerExist = false;
        width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        minHorizontalBorderSize = width;
        minVerticalBorderSize = height;

    }

    private void Start()
    {
        float rightSideOffScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;

    }

    void Update()
    {
        onBorderXpos = CheckOutsideScreen(transform.position.x, minHorizontalBorderSize, onBorderXpos, true, true);
        onBorderXneg = CheckOutsideScreen(transform.position.x, minHorizontalBorderSize, onBorderXneg, false, true);
        onBorderYpos = CheckOutsideScreen(transform.position.y, minVerticalBorderSize, onBorderYpos, true, false);
        onBorderYneg = CheckOutsideScreen(transform.position.y, minVerticalBorderSize, onBorderYneg, false, false);
        isInsideScreen();
        isOutsideScreen();
        CornerWarp();

    }

    private void isInsideScreen()
    {
        if (Mathf.Abs(transform.position.x)<Mathf.Abs(minHorizontalBorderSize-0.51f) && Mathf.Abs(transform.position.y)< Mathf.Abs(minVerticalBorderSize-0.51f))
        {
   
            onInsideScreen?.Invoke();
            isOut = false;
            cornerExist = false;

        }

    }
    private void isOutsideScreen()
    {
        if (!isOut)
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(minHorizontalBorderSize+0.5f ) || Mathf.Abs(transform.position.y) > Mathf.Abs(minVerticalBorderSize+0.5f ))
        {
            Debug.Log("eventout");
            onOutsideScreen?.Invoke(cornerExist);
                isOut = true;

        }

    }

    private void CornerWarp()
    {
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(minHorizontalBorderSize ) - 0.51f && Mathf.Abs(transform.position.y) > Mathf.Abs(minVerticalBorderSize ) - 0.51f)
        {
            if(!cornerExist)
            {
                Debug.Log("isCorner");
                Vector3 spawnPosition = new Vector3(-transform.position.x, -transform.position.y, 0);
                GameObject cornerShip = Instantiate(prefab, spawnPosition, transform.rotation);
                cornerShip.GetComponent<ShipFollow>().isForcedWarp = true;
            }

            cornerExist = true;

        }
    }


    //check si le vaisseau est dans la bordure
    private bool CheckOutsideScreen(float positionToCheck, float border, bool onBorder, bool isPositive, bool isX)
    {
        float offset;
        bool isOut;
        //modifie la fonction si les coordonnées sont positives ou négatives
        if (isPositive)
        {
  
            offset = -0.5f;
            isOut = positionToCheck > border + offset;
        }
        else
        {
    
            offset = 0.5f;
            border = -border;
            isOut = positionToCheck < border + offset;
        }


        //si le vaisseau est dans la bordure
        if (isOut)
        {
            //si il n'y était pas déjà le frame d'avant
            if (!onBorder)
            {
                //spawn un fantome du vaisseau
                Vector3 spawnPosition = transform.position;
                if (isX)
                {
                    spawnPosition.x = -border+offset ;
                }
                else
                {
                    spawnPosition.y = -border+offset;
                }

                Instantiate(prefab, spawnPosition, transform.rotation);
            }
            onBorder = true;

        }
        else
        {
            onBorder = false;

        }
        return onBorder;
    }
}
