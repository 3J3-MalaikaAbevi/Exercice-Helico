/* Fonctionnement et utilité générale du script
   Script pour la gestion du compteur
   Par : Malaïka Abevi
   Dernière modification : 23/09/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestionCompteur : MonoBehaviour
{
    // A définir dans l'inspecteur (zone de texte)
    public TextMeshProUGUI texteCompteur;
    // valeur du compteur au départ
    public int valCompteur = 120;

    public GameObject helicopterRef;  //GameObject pour avoir l'hélico en reference pour accéder à son script
    public GameObject[] heliceRef;  //GameObject pour avoir les hélices en reference pour accéder à son script

    // Appelle de la fonction Compteur() à chaque seconde
    void Start()
    {
        InvokeRepeating("Compteur", 1, 1); //à chaque seconde appelle Compteur
    }
    void Compteur()
    {
        //Si le compteur est plus grand que 0, il est décrémenté
        if(valCompteur > 0){
            valCompteur -= 1;
        }
        else
        {
            //On arrète la fonction qui décrémente le compteur   
            CancelInvoke("Compteur");   
            //On désactive le moteur dans chaque hélice pour que l'hélico tombe
            foreach(GameObject unHelice in heliceRef){
                unHelice.GetComponent<TournerHelice>().moteurEnMarche = false;
                //On désactive la possibilité de démarrer le moteur en cliquant sur Entrer
                unHelice.GetComponent<TournerHelice>().finJeu = true;
            }

            //Et on fait exploser l'hélico en appelant la fonction dans le script du controle de l'hélico
            helicopterRef.GetComponent<ControlerHelico>().ExploserHelico();
        }
        //Convertir la valeur du compteur en texte et l'afficher
        texteCompteur.text = valCompteur.ToString();      
     }

}
