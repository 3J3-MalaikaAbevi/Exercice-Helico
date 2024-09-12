/* Fonctionnement et utilit� g�n�rale du script
 * Script non-optimis� de la gestion des cam�ras
 *  ******
 **** Voir le script ----> ControleCamOptimise.cs ****
 *  ******
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCam : MonoBehaviour
{
    //D�clarations des variables 
    public GameObject cam1; //1�re cam�ra
    public GameObject cam2; //2eme cam�ra
    public GameObject cam3; //3eme cam�ra
    public GameObject cam4; //4eme cam�ra

    void Start()
    {
        //Au d�part, la 1�re cam�ra est active et les autres sont d�sactiv�es
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {   
        //Si la touche 1 est press�e, la 1�re cam�ra est active et les autres sont d�sactiv�es
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Start(); //Au lieu de tout r��crire, on appelle la fonction Start()
        }

        //Si la touche 2 est press�e, la 2eme cam�ra est active et les autres sont d�sactiv�es
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
        }

        //Si la touche 3 est press�e, la 3eme cam�ra est active et les autres sont d�sactiv�es
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
        }

        //Si la touche 4 est press�e, la 4eme cam�ra est active et les autres sont d�sactiv�es
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
        }
        
    }
}
