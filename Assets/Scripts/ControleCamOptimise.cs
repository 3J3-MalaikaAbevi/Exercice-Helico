/* Fonctionnement et utilité générale du script
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamOptimise : MonoBehaviour
{
    //Déclarations des variables  
    public GameObject[] lesCameras;

    void Start()
    {
        ActiverCam(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Start();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiverCam(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCam(2);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiverCam(3);
        }
        
    }

    void ActiverCam(int indexCam){
        foreach(GameObject laCam in lesCameras){
            laCam.SetActive(false);
        }

        lesCameras[indexCam].SetActive(true);

    }
}
