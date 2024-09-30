/* Fonctionnement et utilité générale du script
   Gestion du contrôle de l'hélico
   Gestion du déplacement et des vitesse de l'hélico
   Gestion de l'essence
   Gestion du son de l'hélico
   Par : Malaïka Abevi
   Dernière modification : 25/09/2024
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

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

    /*Les deux variables suivantes auraient être gérées avec un tableau de type GameObject, comme dans le script GestionCompteur*/
    public GameObject heliceAvant; //Le GameObject de l'hélice avant
    public GameObject heliceArriere; //Le GameObject de l'hélice arrière 

    public GameObject explosion;  //Variable pour l'explosion (animation/particules) de l'hélico
    public GameObject controleCam; //Gameobject du gestionnaire de caméra (servira pour le changement de caméra lors d'une explosion)


    [Header ("LES AUDIOCLIPS")]
    public AudioSource laSourceAudio; //Variable pour le component de l'AudioSource de l'hélico
    public AudioClip sonBidon;  //Le son pour le bidon
    public AudioClip sonExplosion; //Le son pour l'explosion


    [Header("MESH")]
    public Mesh helicoAccidente; //Mesh accidenté lorsque l'hélico explose


    [Header("GESTION DE L'ESSENCE")]
    public float quantiteEssence; //Variable pour la quantite d'essence actuelle de l'hélico
    public float essenceMax; //Variable pour déterminer la quantité maximale d'essence que l'hélico peut avoir
    public Image niveauEssenceIMG;  //Variable de type Image pour la gestion du UI pour la quantité d'essence actuelle
    public TextMeshProUGUI texteAvertissement; //Variable pour le texte d'avertissement de niveau faible d'essence
    

    bool finJeu;  //Variable de type booléenne pour savoir si la partie est terminé ou non
    bool sonHelicoJoue; //Variable pour déterminer si le AudioSource de l'hélico joue déja
    bool clignotementEnCours; //Variable pour determiner si le clignotement est en cours 

    void Start(){
        quantiteEssence = essenceMax;
    }

    //Gestion des touches pour contrôler l'hélico///////////////////
    void Update()
    {   
        //Si la partie n'est pas finie, on peut utiliser les touches
        if(!finJeu){
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
        }

        /*On s'assure que l'hélico fait uniquement des rotations en Y (gauche-droite pour les rotations)
          Alors, on force la rotation à 0f pour X et Z et on utilise les localEulerAngles, 
          plus optimals pour la 3d et contrer les bogues */
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);


        //GESTION DE L'AUDIOLISTENER
        //Chaque fois que le touche M sera enfoncée, le AudioListener se mettra en pause ou fera jouer le son global 
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioListener.pause = !AudioListener.pause;//Pour mettre le son global du jeu en pause ou le redémarrer
        }
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

        
        ////GESTION DU SON DE L'HÉLICO****************/
        //Si le AudioSource de l'hélico n'est pas encore en marche et que le moteur démarre 
        if(refHelice.GetComponent<TournerHelice>().moteurEnMarche && !sonHelicoJoue)
        {
            //On démarre l'audiosource
            laSourceAudio.Play();
            //Et on indique que le audioSource a été démarré (on veut faire ça une seule fois)
            /*Ça évite surtout un souci de son, surtout avec le pitch!!!*/
            sonHelicoJoue = true;
        }
        //On augmente ou diminue le volume du bruit graduellement en se référent à la vitesse de rotation de l'hélico
        laSourceAudio.volume = vitesseHelice/10;

        //On augmente ou diminue le volume du bruit graduellement en se référent à la vitesse de rotation de l'hélico
        laSourceAudio.pitch = vitesseHelice/10;

        //On ramène la valeur du pitch à 0,5 lorsqu'il diminue au plus bas (On veut que la limite minimale du pitch soit à 0,5)
        if(laSourceAudio.pitch < 0.5f){
            laSourceAudio.pitch = 0.5f;
        }
        //On ramène la valeur du pitch à 0,5 lorsqu'il augmente au plus haut (On veut que la limite maximale du pitch soit à 1)
        if (laSourceAudio.pitch > 1f)
        {
            laSourceAudio.pitch = 1f;
        }

        //GESTION DE L'ESSENCE
        //Si le moteur est en marche, on veut appeler la fonction qui gère l'essence
        if(heliceArriere.GetComponent<TournerHelice>().moteurEnMarche){
            GestionEssence();
            //Également, si le niveau d'essence est inferieur à 30%, alors un message d'avertissement apparait
            if (quantiteEssence <= 30 && quantiteEssence > 0 && !clignotementEnCours)
            {
                clignotementEnCours = true; //On met a true, comme ça l'appel avec invoke ce fait une seule fois
                texteAvertissement.gameObject.SetActive(true); //On rend visible le texte
                InvokeRepeating("ClignotementAvertissement", 0.7f, 0.7f); //Et on appelle la fonction à chaque 700ms
            }
        }
        //Sinon, si le moteur n'est pas en marche ou que le niveau d'essence est suffisant, alors on arrête le clignotement
        else if(quantiteEssence > 30 || quantiteEssence < 0 || !heliceArriere.GetComponent<TournerHelice>().moteurEnMarche)
        {
            clignotementEnCours = false; //On met a false, comme ça on peut à nouveau appeler la fonction avec un Invoke
            texteAvertissement.gameObject.SetActive(false); //On fait disparaitre le texte
            CancelInvoke("ClignotementAvertissement"); //On annule le invoke qui fait le clignotement
        }
    }

    void OnTriggerEnter(Collider infoCollider){
        //GESTION DE LA COLLECT DE BIDON
        if(infoCollider.gameObject.name == "bidon"){
            Destroy(infoCollider.gameObject); //On fait disparaître le bidon
            laSourceAudio.PlayOneShot(sonBidon); //On fait jouer une fois le son du bidon recolté
            quantiteEssence += 30; //On augmente la quantité d'essence de l'hélico
        }
    }

    void OnCollisionEnter(Collision infoCollision){

        float vitesseDeplacement = GetComponent<Rigidbody>().velocity.magnitude;

        /*Pour que l'hélico n'explose pas au moindre contact avec le terrain,
         *on verifie la vitesse lors de la collision*/
        if(infoCollision.gameObject.tag == "Decor" && vitesseDeplacement > 1){
            ExploserHelico(); //On appelle la fonction pour l'explosion de l'hélico 
            finJeu = true; //On indique que la partie est terminée
        }

        if(infoCollision.gameObject.name == "Drone" || infoCollision.gameObject.name == "Dome"){
            ExploserHelico(); //On appelle la fonction pour l'explosion de l'hélico 
            finJeu = true; //On indique que la partie est terminée
        }

        if(infoCollision.gameObject.name == "PlatformeAtterrissage" && GetComponent<GestionCompteur>().valCompteur > 0){
            GetComponent<GestionVictoire>().victoire = true;
        }
    }

    //Script pour exploser l'hélico
    public void ExploserHelico(){
        //On active le GameObject qui animer l'explosion
        explosion.SetActive(true);
        //**On arrete de moteur de l'hélico**//
        heliceAvant.GetComponent<TournerHelice>().moteurEnMarche = false;
        heliceArriere.GetComponent<TournerHelice>().moteurEnMarche = false;
        //On met la vitesse avant à zéro pour que l'hélico arrête d'avancer
        vitesseAvant = 0;
        //On met la caméra de suivi à distance
        controleCam.GetComponent<ControleCamOptimise>().ActiverCam(2);
        //S'assurer de désactiver le texte d'avertissment au cas ou qu'il soit là
        //texteAvertissement.gameObject.SetActive(false);

        //***MODIFICATIONS AVEC LE RIGIDBODY***//
        GetComponent<Rigidbody>().useGravity = true; //Réactivation de la gravité de l'hélico
        GetComponent<Rigidbody>().drag = 0.5f;
        GetComponent<Rigidbody>().angularDrag = 1f;
        //On désactive toutes les contraintes qui empechaient l'helico de faire des rotations dans d'autres axes
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; 

        //***MODIFICATIONS AVEC LE SON***//
        laSourceAudio.PlayOneShot(sonExplosion); //On fait jouer une fois le son du bidon recolté
        laSourceAudio.Stop(); //On arrete le son de l'hélico
        laSourceAudio.spatialBlend = 0.1f;  //On amène le son à 90% 2d et 10% 3d

        //***MODIFICATIONS AVEC LE MESH/APPARENCE DE L'HÉLICO***//   
        GetComponent<MeshRenderer>().material.color = new Color (0.389937f, 0.040465f, 0.2214171f, 1); //(R,G,B,Alpha) 
        GetComponent<MeshFilter>().mesh = helicoAccidente;

        //Puis on appelLe après 8 secondes la fonction pour relancer la partie
        Invoke("Relancer", 8f); 
    }


    //Fonction pour la gestion de l'essence de l'hélico
    void GestionEssence(){
        //On fait descendre le niveau d'essence
        quantiteEssence -= 0.05f;

        //On s'assure que le niveau d'essence ne dépasse pas le niveau maximal établit
        if (quantiteEssence > essenceMax){
            quantiteEssence = essenceMax;
        }

        //GESTION DE L'IMAGE DU NIVEAU D'ESSENCE / UI
        float pourcentage = quantiteEssence/essenceMax;  //Variable locale pour le pourcentage d'essence restant 
        
        //On diminue proportionnelement l'affichage de la barre d'essence avec le pourcentage restant
        niveauEssenceIMG.fillAmount = pourcentage;   

        //Si le niveau d'essence est à 0, on arrête le moteur
        if(quantiteEssence <= 0){
            heliceAvant.GetComponent<TournerHelice>().moteurEnMarche = false;
            heliceArriere.GetComponent<TournerHelice>().moteurEnMarche = false;
            //On désactive la possibilité de démarrer le moteur en cliquant sur Entrer
            heliceAvant.GetComponent<TournerHelice>().finJeu = true;
            heliceArriere.GetComponent<TournerHelice>().finJeu = true;
        }
    }

    //Fonction pour le clignotement du message d'avertissement
    void ClignotementAvertissement()
    {
        if (texteAvertissement.gameObject.activeSelf) //Verification de l'état actif du gameObject du texte
        {
            texteAvertissement.gameObject.SetActive(false);
        }
        else
        {
            texteAvertissement.gameObject.SetActive(true);
        }
    }


    //Fonction pour relancer la partie
    void Relancer(){
        Scene laScene = SceneManager.GetActiveScene(); //Variable locale qui represente la scène actuelle
        SceneManager.LoadScene(laScene.name); //On fait rejouer la scène actuelle
    }
}
