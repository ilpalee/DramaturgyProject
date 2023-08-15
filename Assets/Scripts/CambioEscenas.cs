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
           SceneManager.LoadScene("EntradaCasa");
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
