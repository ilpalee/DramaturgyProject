using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerEntreEscenas : MonoBehaviour
{  
    


    private void Awake()
    {
        var Mantener = FindObjectsOfType<MantenerEntreEscenas>();
        
        if(Mantener.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }
    
    void Start()
    {
        
    }

    

    void Update()
    {
        
    }


}
