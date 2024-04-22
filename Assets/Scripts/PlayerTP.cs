using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{

    public GameObject FadeEffect;
    public Vector3 PlayerMove;

    public Player_1_Controller Player_1_Controller_Script;
    
    // Referencias de Gameobjects y Scripts para controlarlos en este Script

    void Start()
    {
        FadeEffect = GameObject.FindGameObjectWithTag("FadeObject");
        Player_1_Controller_Script = FindObjectOfType<Player_1_Controller>();
    }

    // Si el gameobject "FadeEffect" esta activo, se desactiva el input de movimiento, de lo contrario, se vuelve a activar ademas de las animaciones.

    void Update()
    {

        if(FadeEffect.activeSelf)
        {
            Player_1_Controller_Script.MovementInput = false;
        }
        else
        {
            Player_1_Controller_Script.MovementInput = true;
            Player_1_Controller_Script.anim.enabled = true;
        }
    }

    // Si el gameobject de este script entra en trigger con el personaje, se ejecuta la corrutina de pausa, se activa el gameobject "fadeeffect" y se ejecuta la funcion "PlayerMovimiento".

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            CorrutinaPausa();
            FadeEffect.SetActive(true);
            PlayerMovimiento(other);
        }
    }

    // Se mueve al personaje el valor indicado en "PlayerMove" desde el inspector.

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
