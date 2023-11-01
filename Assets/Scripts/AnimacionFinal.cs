using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class AnimacionFinal : MonoBehaviour
{

    public PlayableDirector DirectorAnimFinal;
    public BoxCollider2D BoxCollider_final;
    public static bool EnAnimacionFinal;
    public Player_1_Controller playerControllerScript;
    private float TiempoAnimacionFinal = 13.3333f;


    void Start()
    {
        playerControllerScript = FindObjectOfType<Player_1_Controller>();
    }

    
    void Update()
    {
        
    }

    IEnumerator ReactivarBoolMovimiento_Final()
    {
        yield return new WaitForSeconds(TiempoAnimacionFinal);
    
        EnAnimacionFinal = false;
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            
            playerControllerScript.movement.y = 0;
            EnAnimacionFinal = true;
            StartCoroutine(ReactivarBoolMovimiento_Final());
            BoxCollider_final.enabled = false;
            GameObject directorObjectFinal = GameObject.FindGameObjectWithTag("TimeLine_Final");
            DirectorAnimFinal = directorObjectFinal.GetComponent<PlayableDirector>();
            DirectorAnimFinal.Play();
        }
    }
}
