﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class Objecto : Interactivo
{
    public Item item;
    private SpriteRenderer spriteRenderer;
    public int cantidad = 1;

    // Start is called before the first frame update
    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.name = item.nombre;
        spriteRenderer.sprite = item.sprite;
    }

    private void Start()
    {
        micolisionador = GetComponent<BoxCollider2D>();
        player = GameManager.instance.jugador.GetComponent<PlayerController>();
        spriteRenderer.sortingLayerName = "Drop";
        micolisionador.isTrigger = true;
        micolisionador.size = new Vector2(1, 1);
        gameObject.layer = 13;
    }

    public override void Interaccion()
    {
        Debug.Log("interactuando con" + item.name);
        if (Inventario.instance.AgregarObjeto(item, cantidad))
        {
            Destroy(gameObject);
        }
    }
}
