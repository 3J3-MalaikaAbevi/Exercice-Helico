/* Fonctionnement et utilit� g�n�rale du script
 * Test pour le d�placement du cube/rectangle
   Par : Mala�ka Abevi
   Derni�re modification : 08/09/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCube : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //D�placement du rectangle sur l'axe des Z sur 1 m�tre par seconde
        //(Beaucoup plus controlable que de se fier au raffraichissement par seconde de l'ordi)
        transform.Translate(0f, 0f, 1f * Time.deltaTime);   
    }
}
