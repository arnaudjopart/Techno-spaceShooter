using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : MonoBehaviour
{

    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.DOAnchorPosX(-868, 0.5f, false);
    }


}
