/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi fixe de l'hélicopter
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSuivreFixe : MonoBehaviour
{
    //Déclarations des variables 
    public Transform cible; //Le transform d'un GameObject qui sera la cible (hélico)
    public Vector3 distance; //Vector3 pour la distance souhaité entre la caméra et la cible

    // Update is called once per frame
    void Update()
    {
        //La position de la camera se situe à une distance fixe avec l'hélico
        transform.position = cible.transform.position + distance; 
        //Et on veut que la caméra tourne dans la direction de l'hélico sans se déplacer
        transform.LookAt(cible);
    }
}
