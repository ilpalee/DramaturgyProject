using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Inventario : MonoBehaviour
{
    public Player_1_Controller P1_Controller;
    public Animator anim;
    
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public static bool Activar_inv;

    public GameObject Selector;
    public int ID;
    public int Fases_inv;
    public Player_1_Controller playerController;

    public GameObject Opciones;
    public Image [] Seleccion;
    public Sprite [] Seleccion_Sprite;
    public int ID_Select;

    public GameObject Panel_Recoger;
    public float Tiempo_Panel_Recoger;
    private float Tiempo_Anim_Sombrero = 9f;
    private float Tiempo_Anim_Chimenea = 10f;
    public GameObject Panel_LibroIncorrecto;
    public GameObject Panel_RopaIncorrecta;

    private GameObject itemToPickUp; // Almacena el objeto que este dentro del rango de colision.

    private Sprite spriteSeleccionado; 

    private Estanteria estanteriaActual;

    private EspejoScript Script_Espejo; // test------------

    private Maniqui_Script Script_Maniqui; // test -------------------

    private Chimenea Script_Chimenea;
    public GameObject AnimacionChimenea;

    public AudioSource LibroCorrecto;

    private int ContadorLibros;

    private bool Flag = false;

    private bool Flag_2 = false;

    public static bool Libreria_Completo;

    public static bool Vestidor_Completo;

    public PlayableDirector DirectorAnimEspejo;

    public PlayableDirector DirectorChimenea; 

    public static bool EnAnimacionSombrero;

    public static bool EnAnimacionChimenea;

    private bool RopaSupCorrecta;
    private bool RopaInfCorrecta;
    private bool SombreroUsado;

    void Start()
    {
        
    }

    
    void Update()
    {
        Navegar();


        if (!Flag && ContadorLibros == 5)
        {
            Libreria_Completo = true;
            Flag = true;
        }

        if (!Flag_2 && RopaSupCorrecta == true && RopaInfCorrecta == true && SombreroUsado == true)
        {
            Vestidor_Completo = true;
            Flag_2 = true;
        }

        if (Input.GetKeyDown(KeyCode.I) && !playerController.EstaCaminando || Input.GetKeyDown(KeyCode.Space) && Estanteria.EnEstanteria == true && !playerController.EstaCaminando || Input.GetKeyDown(KeyCode.Space) && Maniqui_Script.EnManiqui == true && !playerController.EstaCaminando || Input.GetKeyDown(KeyCode.Space) && EspejoScript.EnEspejo == true && !playerController.EstaCaminando || Input.GetKeyDown(KeyCode.Space) && Chimenea.EnChimenea == true && !playerController.EstaCaminando)
        {
            Activar_inv = !Activar_inv;
            
            if (Activar_inv)
            {
                Fases_inv = 1; 
            }
            else
            {
                Fases_inv = 0;
            }
            
            ID = 0;

        }

        if (Input.GetKeyDown(KeyCode.Space) && itemToPickUp != null)
        {
            RecogerObjeto(itemToPickUp);
        }

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Item"))
        {
            itemToPickUp = coll.gameObject; // Almacena el objeto dentro del rango de colision.
        }

        if (coll.CompareTag("Estanteria"))
        {
            estanteriaActual = coll.GetComponent<Estanteria>(); 
        }

        if (coll.CompareTag("Espejo"))
        {
            Script_Espejo = coll.GetComponent<EspejoScript>(); 
        }

        if (coll.CompareTag("Maniqui"))  // test ------------------------------
        {
            Script_Maniqui = coll.GetComponent<Maniqui_Script>(); 
        }

        if (coll.CompareTag("ChimeneaColl"))
        {
            Script_Chimenea = coll.GetComponent<Chimenea>(); 
        }

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Item"))
        {
            itemToPickUp = null; // Borra la referencia al objeto cuando sale del rango de colision.
        }

        if (coll.CompareTag("Referencia"))
        {
            estanteriaActual = null;
        }

        if (coll.CompareTag("Referencia_Maniqui")) // test ------------------------
        {
            Script_Maniqui = null;
        }

        if (coll.CompareTag("Referencia_Espejo")) // test ------------------------
        {
            Script_Espejo = null;
        }

        if (coll.CompareTag("ReferenciaChimenea")) 
        {
            Script_Chimenea = null;
        }


    }

    // Metodo para recoger un objeto y agregarlo al inventario.
    private void RecogerObjeto(GameObject item)
    {
        for (int i = 0; i < Bag.Count; i++)
        {
            if (Bag[i].GetComponent<Image>().enabled == false)
            {
                Bag[i].GetComponent<Image>().enabled = true;
                Bag[i].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                Destroy(item); // Destruye el objeto en el mundo una vez que se recoge.

                Panel_Recoger.SetActive(true);
                StartCoroutine(DesactivarPanelRecoger());

                break;
            }
        }
    }

    private IEnumerator DesactivarPanelRecoger()
    {
        yield return new WaitForSeconds(Tiempo_Panel_Recoger);
        Panel_Recoger.SetActive(false);
        Panel_LibroIncorrecto.SetActive(false);
        Panel_RopaIncorrecta.SetActive(false);
    }

    IEnumerator ReactivarBoolMovimiento()
    {
        yield return new WaitForSeconds(Tiempo_Anim_Sombrero);
    
        EnAnimacionSombrero = false;
    }

    IEnumerator ReactivarBoolMovimiento_2()
    {
        yield return new WaitForSeconds(Tiempo_Anim_Chimenea);
    
        EnAnimacionChimenea = false;
    }

    public void Navegar()
    {

        switch (Fases_inv)
        {
            case 0:

                inv.SetActive(false);
                Opciones.SetActive(false);
                Activar_inv = false;
                

                break;
            
            case 1:

                inv.SetActive(true);
                Opciones.SetActive(false);
                Selector.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space) && Bag[ID].GetComponent<Image>().enabled == true)
                {
                    spriteSeleccionado = Bag[ID].GetComponent<Image>().sprite;
                    Fases_inv = 2;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && ID < Bag.Count-1)
                {
                    ID++;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) && ID > 0)
                {
                    ID--;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && ID > 4)
                {
                    ID -= 5;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && ID < 5)
                {
                    ID += 5;
                }

                Selector.transform.position = Bag[ID].transform.position;

                break;
            
            case 2:

                Opciones.SetActive(true);
                Opciones.transform.position = Bag[ID].transform.position;

                Selector.SetActive(false);

                if (Input.GetKeyDown(KeyCode.UpArrow) && ID_Select > 0)
                {
                    ID_Select--;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && ID_Select < Seleccion.Length -1)
                {
                    ID_Select++;
                }

                switch (ID_Select)
                {
                    case 0: // Boton Usar

                        Seleccion[0].sprite = Seleccion_Sprite[1];
                        Seleccion[1].sprite = Seleccion_Sprite[0];

                        if (Input.GetKeyDown(KeyCode.Space) && estanteriaActual != null && spriteSeleccionado == estanteriaActual.spriteEnEstanteria)
                        {
                            Bag[ID].GetComponent<Image>().enabled = false;
                            LibroCorrecto.Play();
                            ContadorLibros ++;
                            Fases_inv = 0;
                        }
                        else if (Input.GetKeyDown(KeyCode.Space) && estanteriaActual != null && spriteSeleccionado != estanteriaActual.spriteEnEstanteria)
                        {
                            P1_Controller.Vida--;
                            Panel_LibroIncorrecto.SetActive(true);
                            StartCoroutine(DesactivarPanelRecoger());
                            Fases_inv = 0;
                        }

                        if (Input.GetKeyDown(KeyCode.Space) && Script_Maniqui != null && spriteSeleccionado == Script_Maniqui.spriteManiqui_1) // test -------------------
                        {
                            RopaSupCorrecta = true;
                            Script_Maniqui.ActivarRopaSuperior();
                            Bag[ID].GetComponent<Image>().enabled = false;
                            Fases_inv = 0;

                        }

                        if (Input.GetKeyDown(KeyCode.Space) && Script_Maniqui != null && spriteSeleccionado == Script_Maniqui.spriteManiqui_2) // test ---------------
                        {
                            RopaInfCorrecta = true;
                            Script_Maniqui.ActivarRopaInferior();
                            Bag[ID].GetComponent<Image>().enabled = false;
                            Fases_inv = 0;

                        }

                        if (Input.GetKeyDown(KeyCode.Space) && Script_Maniqui != null && spriteSeleccionado != Script_Maniqui.spriteManiqui_1 && spriteSeleccionado != Script_Maniqui.spriteManiqui_2) // test -----------
                        {
                            P1_Controller.Vida--;
                            Panel_RopaIncorrecta.SetActive(true);
                            StartCoroutine(DesactivarPanelRecoger());
                            Fases_inv = 0;
                        }

                        if (Input.GetKeyDown(KeyCode.Space) && Script_Espejo != null && spriteSeleccionado == Script_Espejo.spriteEnEspejo) // test -------------------
                        {
                            SombreroUsado = true;
                            EnAnimacionSombrero = true;
                            StartCoroutine(ReactivarBoolMovimiento());
                            Bag[ID].GetComponent<Image>().enabled = false;
                            Fases_inv = 0;
                            GameObject directorObject = GameObject.FindGameObjectWithTag("TimeLine_2");
                            DirectorAnimEspejo = directorObject.GetComponent<PlayableDirector>();
                            DirectorAnimEspejo.Play();
                        }

                        if (Input.GetKeyDown(KeyCode.Space) && Script_Chimenea != null && spriteSeleccionado == Script_Chimenea.spriteEnChimenea)
                        {
                            Bag[ID].GetComponent<Image>().enabled = false;
                            AnimacionChimenea = GameObject.FindGameObjectWithTag("AnimacionFuego");
                            if (AnimacionChimenea != null)
                            {
                                SpriteRenderer spriteAnimacionFuego = AnimacionChimenea.GetComponent<SpriteRenderer>();
                                if(spriteAnimacionFuego != null)
                                {
                                    spriteAnimacionFuego.enabled = true;
                                    GameObject DirectorChimeneaFind = GameObject.FindGameObjectWithTag("TimeLine_Chimenea");
                                    DirectorChimenea = DirectorChimeneaFind.GetComponent<PlayableDirector>();
                                    DirectorChimenea.Play();
                                    EnAnimacionChimenea = true;
                                    StartCoroutine(ReactivarBoolMovimiento_2());
                                    // corrutina desabilitar movimiento en animacion
                                }
                            }
                            Fases_inv = 0;

                        }


                        
                        break;

                    case 1: // Boton Volver

                        Seleccion[0].sprite = Seleccion_Sprite[0];
                        Seleccion[1].sprite = Seleccion_Sprite[1];

                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Fases_inv = 1;
                        }

                        break;
                }

                break;

        }

        

    }


}
