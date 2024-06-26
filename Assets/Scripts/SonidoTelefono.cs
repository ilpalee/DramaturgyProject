using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoTelefono : MonoBehaviour
{

    public GameObject Llave;
    private bool LlaveEnInventario = false;
    private bool FlagLlave = false;

    private bool FlagTelefonoSound = false;

    public GameObject PlayerObject;
    public Transform PlayerTransform;
    public AudioSource audioSource;
    public AudioSource AudioRisa;

    public float maxDistance = 10f; 
    public float minVolume = 0f; 
    public float maxVolume = 1f; 

    public GameObject TextoPuerta;

    private bool TriggerTelefono = false;
    private bool InteraccionUnica = false;

    public Player_1_Controller Pj_Script;
    
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Personaje1");
        PlayerTransform = PlayerObject.GetComponent<Transform>();
        Pj_Script = FindObjectOfType<Player_1_Controller>();
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && TriggerTelefono == true && LlaveEnInventario == true && InteraccionUnica == false)
        {
            AudioRisa.Play();
            Pj_Script.Vida--;
            audioSource.Stop();
            InteraccionUnica = true;
        }

        if (!FlagLlave && Llave == null)
        {
            LlaveEnInventario = true;
            TextoPuerta.SetActive(false);
            FlagLlave = true;
        }

        if (LlaveEnInventario && !FlagTelefonoSound) 
        {
            audioSource.Play();
            FlagTelefonoSound = true;
        }

        

        if (PlayerTransform != null && audioSource != null)
        {
            // Calcula la distancia en 2D entre el objeto y el jugador
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                                              new Vector2(PlayerTransform.position.x, PlayerTransform.position.y));

            // Limita la distancia entre 0 y maxDistance
            float clampedDistance = Mathf.Clamp(distance, 0f, maxDistance);

            // Calcula el volumen en función de la distancia
            float volume = 1 - (clampedDistance / maxDistance);

            // Ajusta el volumen dentro del rango definido
            float finalVolume = Mathf.Clamp(volume, minVolume, maxVolume);

            // Establece el volumen del AudioSource
            audioSource.volume = finalVolume;
        }
        
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            TriggerTelefono = true;
        }

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            TriggerTelefono = false;
        }

    }
}
