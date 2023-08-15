using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardadosEntreEscenas : MonoBehaviour
{


    public static DatosGuardadosEntreEscenas Instancia;

    // GameObject que conserva los datos (dentro de este) entre las escenas, eliminando duplicados.

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

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
