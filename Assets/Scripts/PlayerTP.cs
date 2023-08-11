using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{

    public GameObject FadeEffect;
    public Vector3 PlayerMove;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            CorrutinaPausa();
            FadeEffect.SetActive(true);
            PlayerMovimiento(other);
        }
    }

    private void PlayerMovimiento(Collider2D other)
    {
        other.transform.position += PlayerMove;
    }

    public void CorrutinaPausa()
    {
        StartCoroutine(PausaEnTransicionDeArea());
    }

    IEnumerator PausaEnTransicionDeArea()
    {
        // Luego de este tiempo, pausa el juego
        yield return new WaitForSecondsRealtime(0.3f);
        
        // Pausa el juego
        Time.timeScale = 0f;

        // Espera la duracion de la pausa
        yield return new WaitForSecondsRealtime(0.5f);

        // Reanuda el juego
        Time.timeScale = 1f;

    }

}
