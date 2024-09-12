/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi fluide (avec un amortissement du mouvement) 
    de l'hélicopter en Third Person Perspective
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFluide : MonoBehaviour
{
    //Déclarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (hélico)
    public Vector3 distance; //Vector3 pour la distance souhaité entre la caméra et la cible

    public float amortissement;
    // Update is called once per frame
    void FixedUpdate()
    {
        //La position de la camera se situe à une distance fixe avec l'hélico
        Vector3 positionFin = cible.TransformPoint(distance);

        //On veut que la caméra tourne et avec une transition fluide
        transform.position = Vector3.Lerp(transform.position, positionFin, amortissement);
        
        //Et on veut que la caméra tourne dans la direction de l'hélico sans se déplacer
        transform.LookAt(cible);
    }
}
