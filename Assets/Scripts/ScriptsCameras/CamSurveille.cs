/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi de l'h�lico dans un style de cam�ra de surveillance 
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSurveille : MonoBehaviour
{
    //D�clarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (h�lico)

    // Update is called once per frame
    void Update()
    {
        //On veut simplement que la cam�ra tourne dans la direction de l'h�lico sans se d�placer
        transform.LookAt(cible);   
    }
}
