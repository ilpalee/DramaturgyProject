using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maniqui_Script : MonoBehaviour
{

    public static bool EnManiqui;
    public BoxCollider2D BoxCollider_Maniqui;

    public Sprite spriteManiqui_1;
    public Sprite spriteManiqui_2;

    public GameObject RopaSuperiorManiqui; // test --------------
    public GameObject RopaInferiorManiqui; // test --------------
    
    
    void Start()
    {
        
    }

    public void ActivarRopaSuperior()
    {
        RopaSuperiorManiqui.SetActive(true);
    }

    public void ActivarRopaInferior()
    {
        RopaInferiorManiqui.SetActive(true);
    }


    
    void Update()
    {
        if (Inventario.Activar_inv == true)
        {
            BoxCollider_Maniqui.enabled = false;
        }
        else
        {
            BoxCollider_Maniqui.enabled = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnManiqui = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Personaje1")
        {
            EnManiqui = false;
        }

    }


}
