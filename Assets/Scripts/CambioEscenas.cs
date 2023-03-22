using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("HaciaMapa1"))
        {
             SceneManager.LoadScene("Mapa_1");
        }

        if (collision.gameObject.CompareTag("HaciaMapa2"))
        {
             SceneManager.LoadScene("Mapa_2");
        }

        if (collision.gameObject.CompareTag("HaciaMapa3"))
        {
             SceneManager.LoadScene("Mapa_3");
        }

        if (collision.gameObject.CompareTag("HaciaMapa4"))
        {
             SceneManager.LoadScene("Mapa_4");
        }

    }



}
