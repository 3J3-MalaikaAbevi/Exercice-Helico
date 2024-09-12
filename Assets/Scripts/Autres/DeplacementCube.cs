/* Fonctionnement et utilité générale du script
 * Test pour le déplacement du cube/rectangle
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCube : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Déplacement du rectangle sur l'axe des Z sur 1 mètre par seconde
        //(Beaucoup plus controlable que de se fier au raffraichissement par seconde de l'ordi)
        transform.Translate(0f, 0f, 1f * Time.deltaTime);   
    }
}
