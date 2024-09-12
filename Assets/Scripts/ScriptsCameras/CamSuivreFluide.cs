/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fluide (avec un amortissement du mouvement) 
    de l'h�licopter en Third Person Perspective
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFluide : MonoBehaviour
{
    //D�clarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (h�lico)
    public Vector3 distance; //Vector3 pour la distance souhait� entre la cam�ra et la cible

    public float amortissement;
    // Update is called once per frame
    void FixedUpdate()
    {
        //La position de la camera se situe � une distance fixe avec l'h�lico
        Vector3 positionFin = cible.TransformPoint(distance);

        //On veut que la cam�ra tourne et avec une transition fluide
        transform.position = Vector3.Lerp(transform.position, positionFin, amortissement);
        
        //Et on veut que la cam�ra tourne dans la direction de l'h�lico sans se d�placer
        transform.LookAt(cible);
    }
}
