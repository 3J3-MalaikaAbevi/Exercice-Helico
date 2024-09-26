/* Fonctionnement et utilité générale du script
   Script pour le démarrage du jeu avec un bouton
   Par : Malaïka Abevi
   Dernière modification : 23/09/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Départ : MonoBehaviour
{
    public GameObject[] objetADesactiver;
    public GameObject[] objetAActiver;

    public void LancerJeu(){
        foreach (GameObject objet in objetADesactiver)
        {
            objet.SetActive(false);   
        }

        foreach (GameObject objet in objetAActiver)
        {
            objet.SetActive(true);   
        }
    }
}
