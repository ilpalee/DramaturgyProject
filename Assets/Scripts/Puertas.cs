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
    public Player_1_Controller PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = FindObjectOfType<Player_1_Controller>();
        PlayerTP_Script = FindObjectOfType<PlayerTP>();
        
        playerCollider = GameObject.FindGameObjectWithTag("Personaje1").GetComponent<Collider2D>();
    }
    

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EnPuerta == true)
        {
           PlayerControllerScript.Puerta.PlayOneShot(PlayerControllerScript.Puerta.clip);
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
