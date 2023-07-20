using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEscenas : MonoBehaviour
{

     private bool EnPuerta = false;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EnPuerta == true)
        {
           ChangeScene();
           SceneManager.LoadScene("Mapa_5");
           EnPuerta = false;
        }
    }

   
   public void OnTriggerEnter2D(Collider2D collision)
   {
     if (collision.gameObject.CompareTag("Puerta"))
     {    
          EnPuerta = true;
     }
   }
   public void OnTriggerExit2D(Collider2D collision)
   {
     if (collision.gameObject.CompareTag("Puerta"))
     {    
          EnPuerta = false;
     }
   }  

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("HaciaMapa1"))
        {
             
             ChangeScene();
             SceneManager.LoadScene("Mapa_1");
        }

        if (collision.gameObject.CompareTag("HaciaMapa2"))
        {
             
             ChangeScene();
             SceneManager.LoadScene("Mapa_2");
        }

        if (collision.gameObject.CompareTag("HaciaMapa3"))
        {
             ChangeScene();
             SceneManager.LoadScene("Mapa_3");
        }

        if (collision.gameObject.CompareTag("HaciaMapa4"))
        {
             ChangeScene();
             SceneManager.LoadScene("Mapa_4");
        }

    }

     

     public void ChangeScene()
     {
        StartCoroutine(ChangeSceneWithPause());
     }

     IEnumerator ChangeSceneWithPause()
     {
        yield return new WaitForSecondsRealtime(0.1f);
        
        // Pausa el juego
        Time.timeScale = 0f;

        // Espera la duracion de la pausa
        yield return new WaitForSecondsRealtime(0.2f);

        // Reanuda el juego
        Time.timeScale = 1f;

     }


}
