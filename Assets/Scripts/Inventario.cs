using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    
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

    private GameObject itemToPickUp; // Almacena el objeto que este dentro del rango de colision.

    void Start()
    {
        
    }

    
    void Update()
    {
        Navegar();

        if (Input.GetKeyDown(KeyCode.I) && !playerController.EstaCaminando)
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
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Item"))
        {
            itemToPickUp = null; // Borra la referencia al objeto cuando sale del rango de colision.
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

                        if (Input.GetKeyDown(KeyCode.Space)) 
                        {
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
