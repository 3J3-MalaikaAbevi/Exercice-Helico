using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionVictoire : MonoBehaviour
{
    public bool victoire; //Variable pour vérifier si la partie est gagnée
    public GameObject[] elementsUI; //Variable d'un tableau GameObject pour enregistrer les éléments du UI à désactiver
    public TextMeshProUGUI texteVictoire; //Variable pour le texte de félicitations
    void Update()
    {
        if(victoire){
            //Pour désactiver chaque élément du UI dans le tableau des élémentsUI
            foreach(GameObject unElement in elementsUI){
                unElement.SetActive(false);
            }

            //Et activer le texte de félicitations
            texteVictoire.gameObject.SetActive(true);
        } 
    }
}
