using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SonidoCuadro : MonoBehaviour
{

    public AudioSource PasosCuadro;
    public GameObject CuadroAntagonista;
    public GameObject CuadroAntagonistaVacio;
  

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            PasosCuadro.Play();
            CuadroAntagonista.SetActive(false);
            CuadroAntagonistaVacio.SetActive(true);
        }
        
    }
}
