﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Salud))]
[RequireComponent (typeof(Salud))]
public class EnemigoIA : Enemigo
{
    protected Habilidad habilidad;

    protected InputEnemigo input;
    private Atacante atacante;
    protected SpriteRenderer spriteRenderer;
    private bool muerto;
    private bool atacando;
    private bool enCombate;
    private int correrHash;
    private int atacarHash;
    private Animator animator;
    private Vector2 direccionAtaque;
    private int muerteHash;


    [SerializeField] private float distanciaDeteccion;
    [SerializeField] private float distanciaAtaque;


    private void Start()
    {
        habilidad = GetComponent<Habilidad>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();

        correrHash = Animator.StringToHash("Corriendo");
        atacarHash = Animator.StringToHash("Atacar");
        muerteHash = Animator.StringToHash("Muerto");
        Instantiate(puff, transform);
    }

    private void Update()
    {

        Comportamiento();
    }


    protected void Comportamiento()
    {
        if (!muerto)
        {
            if (!atacando && input.distanciaJugador < distanciaAtaque)
            {
                RealizarAtaque();
            }
            else if (!atacando && (enCombate || input.distanciaJugador < distanciaDeteccion))
            {
                MoverHaciaJugador();
            }
        }
    }

    private void RealizarAtaque()
    {
        int probabilidadDeAtaque = Random.Range(0, 100);
        animator.SetBool(correrHash, false);
        if (probabilidadDeAtaque > 50)
        {
            direccionAtaque = input.direccionHaciaJugador;
            enCombate = true;
            atacando = true;
            animator.SetBool(correrHash, false);
            animator.SetTrigger(atacarHash);
        }

    }

    private void MoverHaciaJugador()
    {
        animator.SetBool(correrHash, true);
        VoltearSprite();
        transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
    }

    public virtual void EnemigoAtacar()
    {
        atacante.Atacar(direccionAtaque, atributos.ataque);

    }

    protected virtual void VoltearSprite()
    {
        if (input.horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void SetAtacandoFalse()
    {
        atacando = false;
    }

    public void Morir()
    {
        muerto = true;
        animator.SetBool(muerteHash, true);
    }
}
