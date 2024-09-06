using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFluide : MonoBehaviour
{

    public Transform cible;
    public Vector3 distance;

    public float amortissement;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 positionFin = cible.TransformPoint(distance);

        transform.position = Vector3.Lerp(transform.position, positionFin, amortissement);   
        transform.LookAt(cible);
    }
}
