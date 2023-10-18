using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estanteria : MonoBehaviour
{

    
    public static bool EnEstanteria;
    public BoxCollider2D BoxCollider;
    
    public Sprite spriteEnEstanteria;

    void Start()
    {
        
    }



    
    void Update()
    {
        if (Inventario.Activar_inv == true)
        {
            BoxCollider.enabled = false;
        }
        else
        {
            BoxCollider.enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnEstanteria = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnEstanteria = false;
        }

    }



}
