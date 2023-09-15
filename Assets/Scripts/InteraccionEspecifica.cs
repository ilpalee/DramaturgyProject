using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionEspecifica : MonoBehaviour
{

    private bool EnRango;

    public bool CondicionActiva = false;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (EnRango && Input.GetKeyDown(KeyCode.Space))
        {
            CondicionActiva = true;
        }
        
    }






      private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            EnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            EnRango = false;
        }
    }
}
