using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCuadro : MonoBehaviour
{

     public Animator anim;

     public float TiempoEjecucion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            anim.SetBool("BoolAnimCuadro", true);
            Invoke("DespuesDelTiempo", TiempoEjecucion);
        }
    }

    private void DespuesDelTiempo()
    {
        SceneManager.LoadScene("Casa2");
    }
    

}
