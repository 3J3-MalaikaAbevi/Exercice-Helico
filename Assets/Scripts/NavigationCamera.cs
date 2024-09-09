/* Fonctionnement et utilité générale du script
 * Deplacement de la caméra avec la souris et les touche du clavier 
 * (Script utile avant la création et la gestion des autres caméras)***
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationCamera : MonoBehaviour 
{
    //Déclarations des variables 
    public float vitesseRotationSouris = 2.0f;
    public float vitesseDeDeplacement = 0.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
	

	void Update () {

        rotationX += Input.GetAxis("Mouse X") * vitesseRotationSouris;
        rotationY += Input.GetAxis("Mouse Y") * vitesseRotationSouris;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        transform.position += transform.forward * vitesseDeDeplacement * Input.GetAxis("Vertical");
        transform.position += transform.right * vitesseDeDeplacement * Input.GetAxis("Horizontal");
	}
}
