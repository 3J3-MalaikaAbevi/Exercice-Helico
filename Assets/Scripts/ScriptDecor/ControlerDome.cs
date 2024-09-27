using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerDome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            GetComponent<Animator>().SetBool("ouvertureDome", true);
        }  

        if(Input.GetKeyDown(KeyCode.F)){
            GetComponent<Animator>().SetBool("ouvertureDome", false);           
        }       
    }

    void joueSon(AudioClip sonDome){
        GetComponent<AudioSource>().PlayOneShot(sonDome);
    }
}
