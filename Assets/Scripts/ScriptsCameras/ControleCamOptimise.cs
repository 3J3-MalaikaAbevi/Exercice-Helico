/* Fonctionnement et utilité générale du script
 * Script optimisé de la gestion des caméras
   Par : Malaïka Abevi
   Dernière modification : 23/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamOptimise : MonoBehaviour
{
    //D�clarations des variables  
    public GameObject[] lesCameras; //Tableau pour enregistrer les caméras é controler, bien plus optimale

    void Start()
    {
        //Au départ, la 1ère caméra est active et les autres sont désactivées
        ActiverCam(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Si la touche 1 est pressée, la fonction ActiverCam() est appeler pour activer la caméra 1
            ActiverCam(0); // ******le 0 correspond à la premiére position dans un tableau*******
        }

        //Au lieu de tout récrire, on appelle la fonction Start()
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Start();
        }

        //Si la touche 3 est pressée, la fonction ActiverCam() est appeler pour activer la caméra 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCam(2);
        }

        //Si la touche 4 est pressée, la fonction ActiverCam() est appeler pour activer la caméra 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiverCam(3);
        }      
    }

    public void ActiverCam(int indexCam){
        //Boucle foreach pour activer la caméra selon le numéro pressé et désactiver toutes les autres
        foreach(GameObject laCam in lesCameras){
            laCam.SetActive(false);
        }

        lesCameras[indexCam].SetActive(true); //Activation de la caméra avec l'index correspondant

    }
}
