using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{

    public GameObject FadeEffect;
    public bool EnPuerta = false; 
    public Transform puntoTeleportacion;
    public PlayerTP PlayerTP_Script; 
    private Collider2D playerCollider;

    void Start()
    {
        PlayerTP_Script = FindObjectOfType<PlayerTP>();
        FadeEffect = GameObject.FindGameObjectWithTag("FadeObject");
        playerCollider = GameObject.FindGameObjectWithTag("Personaje1").GetComponent<Collider2D>();
    }
    

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EnPuerta == true)
        {
           PlayerTP_Script.CorrutinaPausa();
           FadeEffect.SetActive(true);
           playerCollider.transform.position = puntoTeleportacion.position;
           EnPuerta = false;
        }
    }


     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            EnPuerta = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            EnPuerta = false;
        }
    }







}
