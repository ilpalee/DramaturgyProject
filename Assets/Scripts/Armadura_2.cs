using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura_2 : MonoBehaviour
{

    public GameObject Armadura_Fase_1;
    public SpriteRenderer Armadura_Fase_2;
    
    public AudioClip sonido;
    private AudioSource audioSource;

    private bool sonidoReproducido = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (!sonidoReproducido && Inventario.Vestidor_Completo == true)
        {
            Armadura_Fase_1.SetActive(false);
            Armadura_Fase_2.enabled = true;

            audioSource.clip = sonido;
            audioSource.Play();
            sonidoReproducido = true;
        }

    }


}
