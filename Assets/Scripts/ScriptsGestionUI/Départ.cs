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
