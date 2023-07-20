using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEscenas : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

   
   public void OnTriggerEnter2D(Collider2D collision)
   {
     if (collision.gameObject.CompareTag("Test"))
     {
          Debug.Log("asd");
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
