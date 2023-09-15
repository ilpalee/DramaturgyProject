using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_1_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 movement;
    public Animator anim;
    public bool MovementInput = true;
    public bool EstaCaminando = false;
    string LastDirection = "";

    public AudioClip clipLluviaInterior;
    
    
    public AudioSource Pasos;
    public AudioSource Ambiente;
    public AudioSource Puerta;

    private MovementAxis axis = MovementAxis.Horizontal;


      private enum MovementAxis
      {
         Vertical, Horizontal
      }

      private void Start()
      {
         movement = Vector3.zero;
      }

      private void Update()
      {
            // CONFIGURACION DE MOVIMIENTO BASE, HORIZONTAL Y VERTICAL, TECLAS: W,A,S,D / FLECHAS
        if (MovementInput == true)
        {

         if (Input.GetButtonDown("Horizontal")) axis = MovementAxis.Horizontal;
         if (Input.GetButtonDown("Vertical")) axis = MovementAxis.Vertical;

         if (Input.GetButtonUp("Horizontal") && Input.GetButton("Vertical")) axis = MovementAxis.Vertical;
         if (Input.GetButtonUp("Vertical") && Input.GetButton("Horizontal")) axis = MovementAxis.Horizontal;

         var x = Input.GetAxisRaw("Horizontal");
         var y = Input.GetAxisRaw("Vertical");

         movement = new Vector2(x, y);
         EstaCaminando = movement != Vector2.zero;

         if (ReturnEstaCaminando())
         {
             if (!Pasos.isPlaying)
            {
                Pasos.Play();
            }
         }
         else
         {
            Pasos.Stop();
         }

             // SE EVITA EL MOVIMIENTO DIAGONAL Y SE ESTABLECEN LAS ANIMACIONES PARA CADA MOVIMIENTO

         if (axis == MovementAxis.Horizontal)
         {
            movement.y = 0;

            if (x == 1)
            {
                  anim.Play("PJ1_Walk_Right");
                  LastDirection = "Derecha";
            }

            if (LastDirection == "Derecha" && x == 0)
            {
                  anim.Play("PJ1_Idle_Right");
            }

            if (x == -1)
            {
                  anim.Play("PJ1_Walk_Left");
                  LastDirection = "Izquierda";
            }

            if (LastDirection == "Izquierda" && x == 0)
            {
                  anim.Play("PJ1_Idle_Left");
            }
         }
         else if (axis == MovementAxis.Vertical)
         {
            movement.x = 0;

            if (y == 1)
            {
                  anim.Play("PJ1_Walk_Back");
                  LastDirection = "Arriba";
            }

            if (LastDirection == "Arriba" && y == 0)
            {
                  anim.Play("PJ1_Idle_Back");
            }

            if (y == -1)
            {
                  anim.Play("PJ1_Walk_Front");
                  LastDirection = "Abajo";
            }

            if (LastDirection == "Abajo" && y == 0)
            {
                  anim.Play("PJ1_Idle_Front");
            }
         }     
        }
      }

      public bool ReturnEstaCaminando()
      {
            return EstaCaminando;
      }

      public void FixedUpdate()
      {     
             // MOVIMIENTO DEL RIGIDBODY, LO QUE PERMITE MOVER AL PJ
         if (MovementInput == true)
         {
            rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
         }
         else if (MovementInput == false)
         {
            movement.y = 0;
            movement.x = 0;
            anim.enabled = false;
         }
         
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
        if(other.tag == "TriggerLluvia")
        {
            Ambiente.Play();
        }

        if(other.tag == "TriggerLluviaInterior")
        {
            Ambiente.clip = clipLluviaInterior;
            Ambiente.Play();
        }

        
      }

      
      



      
}


