using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuDePausa : MonoBehaviour
{
    public DatosGuardadosEntreEscenas DatosGuardadosScript;

    public GameObject PanelPausa;
    public static bool EnPausa;

    public AudioSource Audio1;
    public AudioSource Audio2;
    public AudioSource Audio3;

    public Player_1_Controller Player_1_Controller_Script;

    public GameObject PanelControles;
    public GameObject botonASeleccionar;

    void Start()
    {
        DatosGuardadosScript = FindObjectOfType<DatosGuardadosEntreEscenas>();
        PanelPausa.SetActive(false);
        Player_1_Controller_Script = FindObjectOfType<Player_1_Controller>();
    }


    void Update()
    {
        if (!Dialogos.Dialogando)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                if(EnPausa)
                {
                    ReanudarJuego();
                }
                else
                {
                    PausarJuego();
                }

                if (PanelControles.activeSelf)
                {
                    PanelControles.SetActive(false);
                    EventSystem.current.SetSelectedGameObject(botonASeleccionar);
                }
            }
        }
        
    }

    public void PausarJuego()
    {
        Audio1.Pause();
        Audio2.Pause();
        Audio3.Pause();
        PanelPausa.SetActive(true);
        Time.timeScale = 0f;
        EnPausa = true;
    }

    public void ReanudarJuego()
    {
        Audio1.UnPause();
        Audio2.UnPause();
        Audio3.UnPause();
        PanelPausa.SetActive(false);
        Time.timeScale = 1f;
        EnPausa = false;
    }

    public void VolverAlMenu()
    {
        if (DatosGuardadosScript != null)
        {
            DatosGuardadosScript.DestruirEnMenuPrincipal();
        }
        Time.timeScale = 1f;
        EnPausa = false;
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
}
