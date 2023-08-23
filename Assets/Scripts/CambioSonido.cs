using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioSonido : MonoBehaviour
{
   
    public AudioClip clipPasosEnter;
    public AudioClip clipPasosExit;
    public GameObject Personaje;


    void Start()
    {
        Personaje = GameObject.FindGameObjectWithTag("Personaje1");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            
            Personaje.GetComponent<AudioSource>().clip = clipPasosEnter;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            
            Personaje.GetComponent<AudioSource>().clip = clipPasosExit;
        }
    }

}
