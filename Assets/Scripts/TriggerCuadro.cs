using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCuadro : MonoBehaviour
{

     public Animator anim;

     public float TiempoEjecucion;

     public AudioSource SonidoCuadro;

     private BoxCollider2D boxCollider;  

    // Start is called before the first frame update


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            SonidoCuadro.Play();
            anim.SetBool("BoolAnimCuadro", true);
            Invoke("DespuesDelTiempo", TiempoEjecucion);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            boxCollider.enabled = false;
        }
    }

    private void DespuesDelTiempo()
    {
        boxCollider.enabled = false;
        SceneManager.LoadScene("Casa2");
    }
    

}
