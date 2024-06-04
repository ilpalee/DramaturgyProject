using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta_a_Puzzles : MonoBehaviour
{

    public static bool EnPuertaLlave;
    public BoxCollider2D BoxCollider;
    
    public Sprite spriteEnPuertaLlave;

    public GameObject TpTrigger;

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

        if (Inventario.LlaveUsada == true)
        {
            TpTrigger.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnPuertaLlave = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnPuertaLlave = false;
        }

    }



}
