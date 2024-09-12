/* Fonctionnement et utilit� g�n�rale du script
   Gestion de la rotation d'une h�lice
   Gestion du d�marrage et de l'arr�t, de la vitesse et de l'acc�l�ration d'une h�lice
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournerHelice : MonoBehaviour
{
    //D�clarations des variables 
    public Vector3 vitesseRotation;   //Variable Vector3 pour la gestion de la vitesse de rotation de l'h�lice
    public float vitesseMax;    //Variable float pour d�finir la vitesse de rotation maximale que peut atteindre l'h�lice
    public float acceleration;    //Variable float pour la gestion de l'acc�leration de la rotation de l'h�lice

    public bool moteurEnMarche;    //Variable bool�enne pour d�terminer si le moteur de l'h�licopter est en marche ou non

    void Update()
    {
        //Si la touche Entrer est appuy�e, on d�marre ou arr�te le moteur
        if (Input.GetKeyDown(KeyCode.Return))
        {
            moteurEnMarche = !moteurEnMarche;
        }

        //Si le moteur est en marche... 
        if (moteurEnMarche)
        {
            /*Et si la vitesse de rotation en Y est en dessous de la vitesse maximale de rotation,
              on incr�mente la vitesse de rotation en Y avec la valeur d'acc�l�ration*/ 
            if (vitesseRotation.y < vitesseMax) vitesseRotation.y += acceleration;
        }
        else //Si le moteur n'est pas en marche...
        {
            //Et que si la vitesse de rotation en Y est plus grand que 0, alors on d�cr�mente avec la valeur d'acc�l�ration
            if (vitesseRotation.y > 0) vitesseRotation.y -= acceleration;
        }

        /*Pour �viter que l'h�lice aille dans le sens inverse (surtout lors de la d�c�l�ration),
          si la vitesse de rotation en Y est plus petit que 0, alors on ram�ne la valeur � 0 (arr�t) */
        if(vitesseRotation.y < 0) vitesseRotation.y = 0;

        //Puis on fait tourner l'h�lice en appliquant la vitesse de rotation actuelle (variable Vector 3)
        transform.Rotate(vitesseRotation);
    }

}
