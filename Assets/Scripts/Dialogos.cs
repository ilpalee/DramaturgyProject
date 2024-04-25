using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{

    [SerializeField] private GameObject PanelDialogo;
    [SerializeField] private TMP_Text TextoDialogo;
    [SerializeField, TextArea(4, 6)] private string [] LineasDialogo;

    [SerializeField] private Sprite imagenDialogo;
    [SerializeField] private string NombreSpeaker;

    private bool EnRango;
    public static bool Dialogando;
    private int lineIndex;
    public float TiempoTipeo; 
    
    public Canvas canvasmain;

    void Start()
    {
        canvasmain = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        if (canvasmain != null)
        {
            PanelDialogo = canvasmain.transform.Find("PanelDialogo").gameObject;
            TextoDialogo = PanelDialogo.transform.Find("TextoDialogo").GetComponent<TMP_Text>();
        }
    }


    void Update()
    {
        if (EnRango && Input.GetKeyDown(KeyCode.Space))
        {
            if(!Dialogando)
            {
                IniciarDialogo();
            }
            else if (TextoDialogo.text == LineasDialogo[lineIndex])
            {
                SiguienteLinea();
            }
        }
    }

    private void IniciarDialogo()
    {
        Dialogando = true;
        PanelDialogo.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0;

        Transform childText = PanelDialogo.transform.Find("NombreSpeaker");

        if (childText != null)
        {
            
            TMP_Text textoComponent = childText.GetComponent<TMP_Text>();

            if (textoComponent != null)
            {
                
                textoComponent.text = NombreSpeaker;
            }
        }


        Transform childImage = PanelDialogo.transform.Find("Retrato");

        if (childImage != null)
        {
        
        Image imageComponent = childImage.GetComponent<Image>();
        
        if (imageComponent != null)
        {
            
            imageComponent.sprite = imagenDialogo;
        }
        }
        StartCoroutine(ShowLine());
    }

    private void SiguienteLinea()
    {
        lineIndex++;
        if(lineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            Dialogando = false;
            PanelDialogo.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private IEnumerator ShowLine()
    {
        TextoDialogo.text = string.Empty;
        
        foreach(char ch in LineasDialogo [lineIndex])
        {
            TextoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(TiempoTipeo);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            EnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Personaje1"))
        {
            EnRango = false;
        }
    }

}
