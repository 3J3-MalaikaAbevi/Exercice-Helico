/* Fonctionnement et utilit� g�n�rale du script
 * Script optimis� de la gestion des cam�ras
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamOptimise : MonoBehaviour
{
    //D�clarations des variables  
    public GameObject[] lesCameras; //Tableau pour enregistrer les cam�ras � controler, bien plus optimale

    void Start()
    {
        //Au d�part, la 1�re cam�ra est active et les autres sont d�sactiv�es
        ActiverCam(0); // ******le 0 correspond � la premi�re position dans un tableau*******
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Au lieu de tout r��crire, on appelle la fonction Start()
            Start();
        }

        //Si la touche 2 est press�e, la fonction ActiverCam() est appeler pour activer la cam�ra 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiverCam(1);
        }

        //Si la touche 3 est press�e, la fonction ActiverCam() est appeler pour activer la cam�ra 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCam(2);
        }

        //Si la touche 4 est press�e, la fonction ActiverCam() est appeler pour activer la cam�ra 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiverCam(3);
        }
        
    }

    public void ActiverCam(int indexCam){
        //Boucle foreach pour activer la cam�ra selon le num�ro press� et d�sactiver toutes les autres
        foreach(GameObject laCam in lesCameras){
            laCam.SetActive(false);
        }

        lesCameras[indexCam].SetActive(true); //Activation de la cam�ra avec l'index correspondant

    }
}
