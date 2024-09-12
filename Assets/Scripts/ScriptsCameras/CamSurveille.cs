/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi de l'hélico dans un style de caméra de surveillance 
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSurveille : MonoBehaviour
{
    //Déclarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (hélico)

    // Update is called once per frame
    void Update()
    {
        //On veut simplement que la caméra tourne dans la direction de l'hélico sans se déplacer
        transform.LookAt(cible);   
    }
}
