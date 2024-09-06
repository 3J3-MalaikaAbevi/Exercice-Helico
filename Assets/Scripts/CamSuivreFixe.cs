using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFixe : MonoBehaviour
{

    public Transform cible;
    public Vector3 distance;

    // Update is called once per frame
    void Update()
    {
        transform.position = cible.transform.position + distance;   
        transform.LookAt(cible);
    }
}
