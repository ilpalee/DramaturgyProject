using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    public DatosGuardadosEntreEscenas DatosGuardadosScript;

    public GameObject PanelPausa;
    public bool EnPausa;

    void Start()
    {
        DatosGuardadosScript = FindObjectOfType<DatosGuardadosEntreEscenas>();
        PanelPausa.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        PanelPausa.SetActive(true);
        Time.timeScale = 0f;
        EnPausa = true;
    }

    public void ReanudarJuego()
    {
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
