using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        MenuDePausa.EnPausa = false;
        //Reinicio bool consejos temporales
        Inventario.DesactivarBloqueoEscalera = false;
        //Reinicio bool puzzle libreria y vestidor completos
        Inventario.Libreria_Completo = false; 
        Inventario.Vestidor_Completo = false;
        //Reinicio bool llave
        Inventario.LlaveUsada = false;
        Puerta_a_Puzzles.EnPuertaLlave = false;
        
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Salir()
    {
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }
}
