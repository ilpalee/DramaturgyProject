using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardadosEntreEscenas : MonoBehaviour
{


    public static DatosGuardadosEntreEscenas Instancia;


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
