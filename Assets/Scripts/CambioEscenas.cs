using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEscenas : MonoBehaviour
{

     private bool EnPuertaExterior = false;
     public Player_1_Controller PlayerControllerScript;
     public AudioClip clipPuertaExterior;
     
    void Start()
    {
        PlayerControllerScript = FindObjectOfType<Player_1_Controller>();
    }

    // Si el personaje se encuentra en el collider de la puerta (bool) y presiona la tecla determinada, se carga la escena e inica la funcion de la corrutina (pausa del juego).
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EnPuertaExterior == true)
        {
           PlayerControllerScript.Puerta.PlayOneShot(clipPuertaExterior);
           ChangeScene();
           SceneManager.LoadScene("EntradaCasa");
           EnPuertaExterior = false;
        }
    }

   
   public void OnTriggerEnter2D(Collider2D collision)
   {
     if (collision.gameObject.CompareTag("PuertaExterior"))
     {    
          EnPuertaExterior = true;
     }
   }
   public void OnTriggerExit2D(Collider2D collision)
   {
     if (collision.gameObject.CompareTag("PuertaExterior"))
     {    
          EnPuertaExterior = false;
     }
   }  

     

     public void ChangeScene()
     {
        StartCoroutine(ChangeSceneWithPause());
     }

     IEnumerator ChangeSceneWithPause()
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
