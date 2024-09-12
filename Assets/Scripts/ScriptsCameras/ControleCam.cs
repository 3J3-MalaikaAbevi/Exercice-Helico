/* Fonctionnement et utilité générale du script
 * Script non-optimisé de la gestion des caméras
 *  ******
 **** Voir le script ----> ControleCamOptimise.cs ****
 *  ******
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCam : MonoBehaviour
{
    //Déclarations des variables 
    public GameObject cam1; //1ère caméra
    public GameObject cam2; //2eme caméra
    public GameObject cam3; //3eme caméra
    public GameObject cam4; //4eme caméra

    void Start()
    {
        //Au départ, la 1ère caméra est active et les autres sont désactivées
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {   
        //Si la touche 1 est pressée, la 1ère caméra est active et les autres sont désactivées
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Start(); //Au lieu de tout réécrire, on appelle la fonction Start()
        }

        //Si la touche 2 est pressée, la 2eme caméra est active et les autres sont désactivées
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
        }

        //Si la touche 3 est pressée, la 3eme caméra est active et les autres sont désactivées
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
        }

        //Si la touche 4 est pressée, la 4eme caméra est active et les autres sont désactivées
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
        }
        
    }
}
