using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournerHelice : MonoBehaviour
{
    public Vector3 vitesseRotation;
    public float vitesseMax;
    public float acceleration;

    bool moteurEnMarche;

    void Start()
    {
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moteurEnMarche = !moteurEnMarche;
        }

        if (moteurEnMarche)
        {
            if (vitesseRotation.y < vitesseMax) vitesseRotation.y += acceleration;
        }
        else 
        {
            if (vitesseRotation.y > 0) vitesseRotation.y -= acceleration;
        }

        if(vitesseRotation.y < 0) vitesseRotation.y = 0;

        transform.Rotate(vitesseRotation);
    }

}
