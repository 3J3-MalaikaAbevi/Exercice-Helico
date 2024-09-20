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

    // Appelle de la fonction Compteur() à chaque seconde
    void Start()
    {
        InvokeRepeating("Compteur", 1, 1); //à chaque seconde appelle Compteur
    }
    void Compteur()
    {
        valCompteur -= 1;
        //convertit la valeur en texte et l'affiche
        texteCompteur.text = valCompteur.ToString();      
     }

}
