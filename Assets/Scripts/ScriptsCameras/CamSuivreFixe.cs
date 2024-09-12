/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fixe de l'h�licopter
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFixe : MonoBehaviour
{
    //D�clarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (h�lico)
    public Vector3 distance; //Vector3 pour la distance souhait� entre la cam�ra et la cible

    // Update is called once per frame
    void Update()
    {
        //La position de la camera se situe � une distance fixe avec l'h�lico
        transform.position = cible.transform.position + distance; 
        //Et on veut que la cam�ra tourne dans la direction de l'h�lico sans se d�placer
        transform.LookAt(cible);
    }
}
