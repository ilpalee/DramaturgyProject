using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chimenea : MonoBehaviour
{

    public static bool EnChimenea;
    public BoxCollider2D BoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            EnChimenea = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnChimenea = false;
        }

    }
}
