/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la cam�ra qui fait un suivi fixe de l'h�licopter
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSurveille : MonoBehaviour
{
    //D�clarations des variables 
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
