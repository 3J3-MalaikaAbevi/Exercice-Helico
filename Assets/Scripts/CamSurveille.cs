/* Fonctionnement et utilité générale du script
   Gestion de la caméra qui fait un suivi fixe de l'hélicopter
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSurveille : MonoBehaviour
{
    //Déclarations des variables 
    public Transform cible;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cible);   
    }
}
