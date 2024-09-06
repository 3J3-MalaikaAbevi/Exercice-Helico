using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerHelico : MonoBehaviour
{
    [Header ("PROPRIÉTÉS DE VITESSE")]
    public float vitesseTourne;
    public float vitesseMonte;
    public float vitesseAvant;
    public float forceAcceleration;
    float forceMonte;
    [SerializeField] float forceRotation;
    public float vitesseMax;

    [Header ("OBJETS UTILES")]
    public GameObject helice;

    void Update()
    {
        forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
        forceMonte = Input.GetAxis("Vertical") * vitesseMonte;

        if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseMax)
        {
            vitesseAvant += forceAcceleration;
        }

        if (Input.GetKey(KeyCode.Q) && vitesseAvant > 0)
        {
            vitesseAvant -= forceAcceleration;
        }

        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
    }

    void FixedUpdate()
    {
        if (helice.GetComponent<TournerHelice>().moteurEnMarche)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddRelativeTorque(0f, forceRotation, 0f);
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceMonte, vitesseAvant);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
