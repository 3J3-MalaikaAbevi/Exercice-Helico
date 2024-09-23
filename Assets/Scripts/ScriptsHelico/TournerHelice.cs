/* Fonctionnement et utilité générale du script
   Gestion de la rotation d'une hélice
   Gestion du démarrage et de l'arrét, de la vitesse et de l'accélération d'une hélice
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournerHelice : MonoBehaviour
{
    //Déclarations des variables 
    public Vector3 vitesseRotation;   //Variable Vector3 pour la gestion de la vitesse de rotation de l'hélice
    public float vitesseMax;    //Variable float pour définir la vitesse de rotation maximale que peut atteindre l'hélice
    public float acceleration;    //Variable float pour la gestion de l'accéleration de la rotation de l'hélice

    public bool moteurEnMarche;    //Variable booléenne pour déterminer si le moteur de l'hélicopter est en marche ou non

    void Update()
    {
        //Si la touche Entrer est appuyée, on démarre ou arréte le moteur
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moteurEnMarche = !moteurEnMarche;
        }

        //Si le moteur est en marche... 
        if (moteurEnMarche)
        {
            /*Et si la vitesse de rotation en Y est en dessous de la vitesse maximale de rotation,
              on incrémente la vitesse de rotation en Y avec la valeur d'accélération*/ 
            if (vitesseRotation.y < vitesseMax) vitesseRotation.y += acceleration;
        }
        else //Si le moteur n'est pas en marche...
        {
            //Et que si la vitesse de rotation en Y est plus grand que 0, alors on décrémente avec la valeur d'accélération
            if (vitesseRotation.y > 0) vitesseRotation.y -= acceleration;
        }

        /*Pour éviter que l'hélice aille dans le sens inverse (surtout lors de la décélération),
          si la vitesse de rotation en Y est plus petit que 0, alors on raméne la valeur é 0 (arrét) */
        if(vitesseRotation.y < 0) vitesseRotation.y = 0;

        //Puis on fait tourner l'hélice en appliquant la vitesse de rotation actuelle (variable Vector 3)
        transform.Rotate(vitesseRotation);
    }

}
