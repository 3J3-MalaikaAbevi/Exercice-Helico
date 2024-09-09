/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fluide (avec un amortissement du mouvement) de l'h�licopter
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFluide : MonoBehaviour
{
    //D�clarations des variables 
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
