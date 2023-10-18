using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInfoLibros : MonoBehaviour
{

    private bool Trigger_Info;
    public GameObject Panel_Info_Libros;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Trigger_Info == true)
        {
            Panel_Info_Libros.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            Trigger_Info = true;
        }

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            Trigger_Info = false;
            Panel_Info_Libros.SetActive(false);
        }

    }
}
