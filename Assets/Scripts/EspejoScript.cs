using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspejoScript : MonoBehaviour
{

    public static bool EnEspejo;
    public BoxCollider2D BoxCollider_Espejo;

    public Sprite spriteEnEspejo;

    void Start()
    {
        
    }



    void Update()
    {
        if (Inventario.Activar_inv == true)
        {
            BoxCollider_Espejo.enabled = false;
        }
        else
        {
            BoxCollider_Espejo.enabled = true;
        }
    }


        private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnEspejo = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnEspejo = false;
        }

    }



}
