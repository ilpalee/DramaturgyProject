using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;

    private GameObject itemToPickUp; // Almacena el objeto que este dentro del rango de colision.

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            Activar_inv = !Activar_inv;
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
                break;
            }
        }
    }


}
