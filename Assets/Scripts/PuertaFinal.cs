using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaFinal : MonoBehaviour
{

    public bool EnPuertaFinal;
    public DatosGuardadosEntreEscenas DatosGuardadosScript;
    
    void Start()
    {
        DatosGuardadosScript = FindObjectOfType<DatosGuardadosEntreEscenas>();
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EnPuertaFinal == true)
        {
           Time.timeScale = 1f;
           MenuDePausa.EnPausa = false;
           //Reinicio bool consejos temporales
           Inventario.DesactivarBloqueoEscalera = false;
           //Reinicio bool puzzle libreria y vestidor completos
           Inventario.Libreria_Completo = false; 
           Inventario.Vestidor_Completo = false;
           
           SceneManager.LoadScene("Final");
           EnPuertaFinal = false;

            if (DatosGuardadosScript != null)
            {
                DatosGuardadosScript.DestruirEnMenuPrincipal();
            }
           
        }
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            EnPuertaFinal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            EnPuertaFinal = false;
        }
    }



}
