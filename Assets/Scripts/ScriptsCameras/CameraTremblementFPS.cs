/* Fonctionnement et utilité générale du script
 *****Script du défi de l'exercice (optionnel)******
   Gestion du tremblement de la caméra en First Person Pespective (CamFPS)
   Par : Malaïka Abevi
   Dernière modification : 11/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTremblementFPS : MonoBehaviour
{
    public GameObject refHelice;  //Variable GameObject pour la reference au script de l'hélice
    Vector3 tremblement;  //Vector3 pour changer la position de la caméra pour faire des tremblements
    public Vector3 maxTremblement; //Vector3 pour pour établir la limite de changement de position de la caméra (tremblements)

    // Update is called once per frame
    void Update()
    {
       //Si le moteur de l'hélico est en marche
        if (refHelice.GetComponent<TournerHelice>().moteurEnMarche)
        {
            //On change la position local de la caméra
            //la caméra est enfant d'un GameObject pour ne pas que le point de réference de la position soit celui du monde (soit le centre du terrain)
            transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
        }

        //Si la position dévit trop, on repositionne la caméra à la limite la plus proche
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

            //Enfin, on change la position de la caméra avec la valeur de la variable tremblement
            transform.localPosition = tremblement;
        }
    }
}
