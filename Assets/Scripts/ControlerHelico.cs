/* Fonctionnement et utilité générale du script
   Par : Malaïka Abevi
   Dernière modification : 08/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerHelico : MonoBehaviour
{
    //Déclarations des variables 
    [Header ("PROPRIÉTÉS DE VITESSE")]
    public float vitesseTourne;
    public float vitesseMonte;
    public float vitesseAvant;
    public float forceAcceleration;
    float forceMonte;
    [SerializeField] float forceRotation;
    public float vitesseAvantMax;

    [Header ("OBJETS UTILES")]
    public GameObject refHelice;

    void Update()
    {
        forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
        forceMonte = Input.GetAxis("Vertical") * vitesseMonte;

        if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax)
        {
            vitesseAvant += forceAcceleration;
            vitesseMonte += vitesseAvant / 200;
        }

        if (Input.GetKey(KeyCode.Q) && vitesseAvant > 0)
        {
            vitesseAvant -= forceAcceleration;
            vitesseMonte -= vitesseAvant / 200;
        }

        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
    }

    void FixedUpdate()
    {
        var vitesseHelice = refHelice.GetComponent<TournerHelice>().vitesseRotation.y;
        var vitesseMaxHelice = refHelice.GetComponent<TournerHelice>().vitesseMax;
        
        //print(refHelice.GetComponent<TournerHelice>().vitesseRotation.y);

        if (vitesseHelice > vitesseMaxHelice)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddRelativeTorque(0f, forceRotation, 0f);
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceMonte, vitesseAvant);
            //print("ca tourne");
        }
        else if(!refHelice.GetComponent<TournerHelice>().moteurEnMarche)
        {
            GetComponent<Rigidbody>().useGravity = true;
            //print("on chute !");
        }
    }
}
