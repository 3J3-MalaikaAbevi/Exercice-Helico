/* Fonctionnement et utilit� g�n�rale du script
 *****Script du d�fi de l'exercice (optionnel)******
   Gestion du tremblement de la cam�ra en First Person Pespective (CamFPS)
   Par : Mala�ka Abevi
   Derni�re modification : 11/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTremblementFPS : MonoBehaviour
{
    public GameObject refHelice;  //Variable GameObject pour la reference au script de l'h�lice
    Vector3 tremblement;  //Vector3 pour changer la position de la cam�ra pour faire des tremblements
    public Vector3 maxTremblement; //Vector3 pour pour �tablir la limite de changement de position de la cam�ra (tremblements)

    // Update is called once per frame
    void Update()
    {
       //Si le moteur de l'h�lico est en marche
        if (refHelice.GetComponent<TournerHelice>().moteurEnMarche)
        {
            //On change la position local de la cam�ra
            //la cam�ra est enfant d'un GameObject pour ne pas que le point de r�ference de la position soit celui du monde (soit le centre du terrain)
            transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
        }

        //Si la position d�vit trop, on repositionne la cam�ra � la limite la plus proche
        if (Mathf.Abs(transform.localPosition.x) > maxTremblement.x)
        {
            if (transform.localPosition.x > 0f)
            {
                tremblement.x = maxTremblement.x;
                //print("positif");
            }   
            if (transform.localPosition.x < 0)
            {
                tremblement.x = -(maxTremblement.x);
                //print("negatif");
            }

            //Puis on attribue la limite en Y et Z au vecteur de tremblements
            tremblement.y = maxTremblement.y;
            tremblement.z = maxTremblement.z;

            //Enfin, on change la position de la cam�ra avec la valeur de la variable tremblement
            transform.localPosition = tremblement;
        }
    }
}
