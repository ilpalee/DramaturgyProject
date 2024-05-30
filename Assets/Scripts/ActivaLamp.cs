using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaLamp : MonoBehaviour
{

    public GameObject Lamp;
    public GameObject LuzPj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lamp == null)
        {
            LuzPj.SetActive(true);
        }
    }
}
