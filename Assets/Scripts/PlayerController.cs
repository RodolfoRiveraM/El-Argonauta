using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public Proyectil proyectil;
    private Pies pies;
    private InputPlayer inputJugador;
    private float horizontal;
    private float vertical;
    private Rigidbody2D miRigidbody2D; //camelCase
    private Animator animator;
    private SpriteRenderer miSprite;
    int correrHashCode;
    public Atributos atributosJugador;
    public LayerMask layerInteraccion;
    private Atacante atacante;
    private Salud salud;
    private NivelDeExperiencia nivelDeExperiencia;
    private Habilidad habilidad;
    private TrailRenderer trailRenderer;
    private float dashCooldown;
    private bool usandoDash;

    // Start is called before the first frame update
    void Start()
    {
        pies = GetComponentInChildren<Pies>();
        trailRenderer = GetComponent<TrailRenderer>();
        habilidad = GetComponent<Habilidad>();
        nivelDeExperiencia = GetComponent<NivelDeExperiencia>();
        salud = GetComponent<Salud>();
        inputJugador = GetComponent<InputPlayer>();
        miRigidbody2D = GetComponent<Rigidbody2D>(); //El rigidbody2d de este gameObject
        animator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        correrHashCode = Animator.StringToHash("Corriendo");
        atacante = GetComponent<Atacante>();
        PanelAtributos.instance.ActualizarTextosAtributos(atributosJugador, salud, nivelDeExperiencia);
    }

    // Update is called once per frame
    void Update()//Game logic
    {
        horizontal = inputJugador.ejeHorizontal;
        vertical = inputJugador.ejeVertical;

        VoltearSprite();

        if (vertical != 0 || horizontal != 0)
        {
            SetXYAnimator();
            animator.SetBool(correrHashCode, true);
        }
        else
        {
            animator.SetBool(correrHashCode, false);
        }

        if (Input.GetButtonDown("Atacar"))
        {
            
            animator.SetBool("Atacando", true);
        }

        if (inputJugador.inventario)
        {
            PanelMenu.instance.AbrirCerrarPaneles();
        }
        ActualizarDashCoolDown();
    }

    private void ActualizarDashCoolDown()
    {
        if (usandoDash)
        {
            dashCooldown += Time.deltaTime;
            if (dashCooldown > trailRenderer.time)
            {
                ActivarODesactivarTrailRenderer();
                dashCooldown = 0;
                usandoDash = false;
            }
        }
    }

    private void VoltearSprite()
    {
        if (horizontal < 0 )
        {
            miSprite.flipX = true;
        }
        else if (horizontal > 0 ) { 
            miSprite.flipX = false;
        }
    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Atacar"))
        {
            animator.SetBool("Atacando", true);
        }
        if (animator.GetBool("Atacando"))
        {
            miRigidbody2D.velocity = Vector2.zero;
        }
        else if((horizontal !=0 ||vertical !=0) && !usandoDash)
        {
            ///-------Movimiento----///
            Vector2 vectorVelocidad = new Vector2(horizontal, vertical) * atributosJugador.velocidad;
            miRigidbody2D.velocity = vectorVelocidad;
        }

        if (inputJugador.habilidad2)
        {
            usandoDash = true;
            habilidad.Dash(inputJugador.direccionMirada, miRigidbody2D);

            ActivarODesactivarTrailRenderer();
        }

        if (inputJugador.habilidad1)
        {
            habilidad.DispararProyectil(proyectil, 10f, inputJugador.direccionMirada, atributosJugador.ataque);
        }
       
    }


    void ControlAtacar()
    {
        atacante.Atacar(inputJugador.direccionMirada, atributosJugador.ataque);
        animator.SetBool("Atacando", false);
    }
    

    private void ActivarODesactivarTrailRenderer()
    {
        if (trailRenderer.enabled)
        {
            trailRenderer.enabled = false;
        }
        else
        {
            trailRenderer.enabled = true;
        }
    }
    //Llamar a interactuar con alguna tecla o haciendo click
    public RaycastHit2D[] Interactuar()
    {
        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, GetComponent<CapsuleCollider2D>().size.x, inputJugador.direccionMirada.normalized, 2f, layerInteraccion);
        if (circleCast != null)
        {
            return circleCast;
        }
        else
        {
            return null;
        }
    }

    private void Pisar()
    {
        pies.ReproducirSonido();
    }
}
