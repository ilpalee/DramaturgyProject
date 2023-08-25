using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{
    public GameObject PanelDialogo;
    public TextMeshProUGUI TextoDialogo;
    public string[] Dialogo;
    private int index;
    public float VelocidadTexto;

    public float Espaciado;
    public bool EnRango;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && EnRango)
        {
            if (PanelDialogo.activeInHierarchy)
            {
                LimpiarTexto();
            }
            else
            {
                PanelDialogo.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && EnRango)
        {
            SiguienteLinea();
        }
    }


    public void LimpiarTexto()
    {
        TextoDialogo.text = "";
        index = 0;
        PanelDialogo.SetActive(false);
    }


    IEnumerator Typing()
    {
        foreach (char letter in Dialogo[index].ToCharArray())

        {
            TextoDialogo.text += letter;
            yield return new WaitForSeconds(VelocidadTexto);
        }
    }


    public void SiguienteLinea()

    {
        if (index < Dialogo.Length - 1)
        {
            index++;
            TextoDialogo.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            LimpiarTexto();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            EnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            EnRango = false;
            LimpiarTexto();
        }
    }
}
