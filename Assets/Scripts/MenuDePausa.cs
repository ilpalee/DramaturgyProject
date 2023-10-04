using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    public DatosGuardadosEntreEscenas DatosGuardadosScript;

    public GameObject PanelPausa;
    public static bool EnPausa;

    public AudioSource Audio1;
    public AudioSource Audio2;
    public AudioSource Audio3;

    void Start()
    {
        DatosGuardadosScript = FindObjectOfType<DatosGuardadosEntreEscenas>();
        PanelPausa.SetActive(false);
    }


    void Update()
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
        SceneManager.LoadScene("MenuPrincipal");
    }
}
