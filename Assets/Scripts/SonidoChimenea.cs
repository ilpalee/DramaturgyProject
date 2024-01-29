using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoChimenea : MonoBehaviour
{

    public SpriteRenderer SpriteRender;
    private bool FlagChimeneaSound = false;

    public GameObject PlayerObject;
    public Transform PlayerTransform;
    public AudioSource audioSource;

    public float maxDistance = 10f; 
    public float minVolume = 0.1f; 
    public float maxVolume = 1f; 
    
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Personaje1");
        PlayerTransform = PlayerObject.GetComponent<Transform>();
    }

    
    void Update()
    {
        if (SpriteRender.enabled && FlagChimeneaSound == false) 
        {
            audioSource.Play();
            FlagChimeneaSound = true;
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
}
