using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatosGuardadosEntreEscenas : MonoBehaviour
{


    public static DatosGuardadosEntreEscenas Instancia;

    private bool destruirEnSiguienteCarga = false;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instancia != this)
            {
                Destroy(gameObject);
            }
        }
    }

    
   // Llamar a esta funcion para destruir el objeto en la escena del menu principal
    public void DestruirEnMenuPrincipal()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
        destruirEnSiguienteCarga = true;
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (destruirEnSiguienteCarga && scene.name == "MenuPrincipal" || scene.name == "Final") // test -------------------------------------
        {
            SceneManager.sceneLoaded -= HandleSceneLoaded;
            Destroy(gameObject);
        }
    }
}
