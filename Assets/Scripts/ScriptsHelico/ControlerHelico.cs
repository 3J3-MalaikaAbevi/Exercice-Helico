/* Fonctionnement et utilité générale du script
   Gestion du contrôle de l'hélico
   Gestion du déplacement et des vitesse de l'hélico
   Par : Malaïka Abevi
   Dernière modification : 11/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerHelico : MonoBehaviour
{
    //Déclarations des variables 
    [Header ("PROPRIÉTÉS DE VITESSE")]
    public float vitesseTourne; //Vitesse de rotation de l'hélico
    public float vitesseMonte;  //Vitesse de la montée et de la descente de l'hélico
    public float vitesseAvant;  //Vitesse de déplacement vers l'avant de l'hélico
    public float vitesseAvantMax; //Vitesse maximale que l'hélico peut avancer
    public float forceAcceleration;  //Force d'accélération pour le déplacement vers l'avant de l'hélico
    
    float forceMonte; //Force d'accélération de la montée et descente de l'hélico de l'hélico
    [SerializeField] float forceRotation; //Force d'accélération de la rotation de l'hélico


    [Header ("OBJETS UTILES")]
    public GameObject refHelice; //Le GameObject de référence pour l'accès au script de la rotation des hélices
    public GameObject heliceAvant; //Le 
    public GameObject heliceArriere; //Le 
    public GameObject explosion;  //Variable pour l'explosion (animation/particules) de l'hélico
    public GameObject controleCam; 
    public AudioClip sonBidon;  //Le son pour le bidon


    //Gestion des touches pour contrôler l'hélico///////////////////
    void Update()
    {
        /*On veut que la force de rotation s'accentue au fur et a mesure que l'on
          presse les touches qui contrôle à l'horizontale (gauche - droite & A - D)*/
        forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
        /*On veut que la force de montée s'accentue au fur et a mesure que l'on
          presse les touches qui contrôle à la verticale (haut - bas & W - S)*/
        forceMonte = Input.GetAxis("Vertical") * vitesseMonte;

        //Si la touche E est pressée et que la vitesse maximale n'est pas atteinte, alors l'hélico accélère 
        if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax)
        {
            vitesseAvant += forceAcceleration;
            vitesseMonte += vitesseAvant * 0.0005f;
        }

        //Si la touche Q est pressée et que la vitesse est plus grande que 0, alors l'hélico décélère 
        if (Input.GetKey(KeyCode.Q) && vitesseAvant > 0)
        {
            vitesseAvant -= forceAcceleration;
            vitesseMonte -= vitesseAvant * 0.0005f;
        }

        /*On s'assure que l'hélico fait uniquement des rotations en Y (gauche-droite pour les rotations)
          Alors, on force la rotation à 0f pour X et Z et on utilise les localEulerAngles, 
          plus optimals pour la 3d et contrer les bogues */
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
    }
   
    //On utilise le FixedUpdate pour un rythme d'update constant, plus approprié pour appliquer des forces
    void FixedUpdate()
    {
        //Variables locales en lien avec les données du script TournerHelice***
        var vitesseHelice = refHelice.GetComponent<TournerHelice>().vitesseRotation.y; //Vitesse de rotation en Y de l'helice de reference
        var vitesseMaxHelice = refHelice.GetComponent<TournerHelice>().vitesseMax;  //Vitesse de rotation maximale en Y de l'helice de reference

        //Si la vitesse de rotation de l'hélice atteint la vitesse maximale, alors l'hélico peut décoler
        if (vitesseHelice > vitesseMaxHelice)
        {
            GetComponent<Rigidbody>().useGravity = false; //Désactivation de la gravité
            GetComponent<Rigidbody>().AddRelativeTorque(0f, forceRotation, 0f); //Application d'une force de rotation à l'hélico
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceMonte, vitesseAvant); //Application d'une force de translation à l'hélico
            //print("ça tourne");
        }
        else if(!refHelice.GetComponent<TournerHelice>().moteurEnMarche) //Sinon, si le moteur de l'hélico est en arrêt, l'hélico chute 
        {
            GetComponent<Rigidbody>().useGravity = true;  //Réactivation de la gravité de l'hélico
            //print("on chute !");
        }
    }

    void OnTriggerEnter(Collider infoCollider){
        if(infoCollider.gameObject.name == "bidon3D"){
            Destroy(infoCollider.gameObject);
            GetComponent<AudioSource>().PlayOneShot(sonBidon);
        }
    }

    void OnCollisionEnter(Collision infoCollision){

        float vitesseDeplacement = GetComponent<Rigidbody>().velocity.magnitude;
        print(vitesseDeplacement);

        if(infoCollision.gameObject.tag == "Decor" && vitesseDeplacement > 1){
            explosion.SetActive(true);
            GetComponent<Rigidbody>().useGravity = true; //Réactivation de la gravité de l'hélico
            GetComponent<Rigidbody>().drag = 0;
            GetComponent<Rigidbody>().angularDrag = 0;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;            
            heliceAvant.GetComponent<TournerHelice>().moteurEnMarche = false;
            heliceArriere.GetComponent<TournerHelice>().moteurEnMarche = false;
            controleCam.GetComponent<ControleCamOptimise>().ActiverCam(2);
            vitesseAvant = 0;

            Invoke("Relancer", 8f);
        }
    }

    void Relancer(){
        Scene laScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(laScene.name);
    }
}
