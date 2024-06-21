using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_1_Controller : MonoBehaviour
{
    public DatosGuardadosEntreEscenas DatosGuardadosScript;

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
    
    public int VidaMaxima;
    public int Vida;

    public Image[] Corazon;
    public Sprite C_Lleno;
    public Sprite C_Vacio;
    

    private bool FlagSonidoVida = false;
    private float TiempoSonidoVida = 2f;
    private int VidaAnterior;
    public AudioSource PerdidaVida;
    
    private bool Damage = false; //TEST-----------------------------
    
      private enum MovementAxis
      {
         Vertical, Horizontal
      }

      private void Start()
      {
         movement = Vector3.zero;
         SceneManager.sceneLoaded += OnSceneLoaded;
         DatosGuardadosScript = FindObjectOfType<DatosGuardadosEntreEscenas>();
      }

      private void Update()
      {
        CorazonesLogica();
        
            
        if (MovementInput == true && !Inventario.Activar_inv && !MenuDePausa.EnPausa && !Inventario.EnAnimacionSombrero && !Inventario.EnAnimacionChimenea && !AnimacionFinal.EnAnimacionFinal && !Dialogos.Dialogando && Damage == false)
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

      private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
      {
        if (scene.name == "Casa2")
        {
            if (Ambiente != null)
            {
                Ambiente.Stop();
            }
            else
            {
                Ambiente = null;
            }
            
        }
      }




      public void CorazonesLogica()
      {


        if (Vida < VidaAnterior && !FlagSonidoVida)
        {
            anim.Play("Anim_Daño"); //reemplazar por animacion de damage
            Damage = true;
            PerdidaVida.Play();
            FlagSonidoVida = true;
            StartCoroutine(ReactivarBoolSonidoVidaYMovimiento());
        }

        VidaAnterior = Vida;

        if (Vida <= 0)
        {
            Time.timeScale = 1f;
            MenuDePausa.EnPausa = false;
            //Reinicio bool consejos temporales
            Inventario.DesactivarBloqueoEscalera = false;
            //Reinicio bool puzzle libreria y vestidor completos
            Inventario.Libreria_Completo = false; 
            Inventario.Vestidor_Completo = false;
            //Reinicio bool llave
            Inventario.LlaveUsada = false;
            Puerta_a_Puzzles.EnPuertaLlave = false;

            SceneManager.LoadScene("GameOver");

            if (DatosGuardadosScript != null)
            {
                DatosGuardadosScript.DestruirEnMenuPrincipal();
            }
        }

        if (Vida > VidaMaxima)
        {
            Vida = VidaMaxima;
        }

        for (int i = 0; i < Corazon.Length; i ++)
        {
            if (i < Vida)
            {
                Corazon[i].sprite = C_Lleno;
            }
            else
            {
                Corazon[i].sprite = C_Vacio;
            }

            if (i < VidaMaxima)
            {
                Corazon[i].enabled = true;
            }
            else
            {
                Corazon[i].enabled = false;
            }
        }
      }


      IEnumerator ReactivarBoolSonidoVidaYMovimiento()
    {
        yield return new WaitForSeconds(TiempoSonidoVida);

        Damage = false;
        FlagSonidoVida = false;
    }

      
}


