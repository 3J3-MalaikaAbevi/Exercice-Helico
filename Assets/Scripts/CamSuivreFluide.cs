/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi fluide (avec un amortissement du mouvement) de l'hélicopter
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFluide : MonoBehaviour
{
    //Déclarations des variables 
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
