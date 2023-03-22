using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class test : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;
    public GameObject Personaje;
    
    
    void Start()
    {
        Personaje = GameObject.FindWithTag("Personaje1");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            virtualCamera.Follow = Personaje.transform;
        }
    }



}





    

    