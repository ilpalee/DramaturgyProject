using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzPj : MonoBehaviour
{

    public Transform Personaje;
    public GameObject Personaje1;
    
    void Start()
    {
        Personaje1 = GameObject.FindGameObjectWithTag("Personaje1");
        Personaje = Personaje1.GetComponent<Transform>();
        transform.parent = Personaje;
        transform.position = Personaje1.transform.position;
    }


    void Update()
    {
        
    }
}
