﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GeneradorTextHit))]
public class NivelDeExperiencia : MonoBehaviour
{
    private PlayerController jugador;
    private Salud salud;
    public BotonAtributo[] botonesAtributos;
    public Image barraDeExp;
    private GeneradorTextHit generadorText;
    private Rango rangoTextoLevelUp = new Rango() { min = 0, max = 0 };
    private int experienciaActual;
    private int expSiguienteNivel; //experiencia necesaria para subir al siguiente nivel
    public int puntosDeAtributos;
    public int nivel { get; set; }
    private float razonExpNivelActual; //sera el % de experiencia para subir de nivel


    public int experiencia
    {
        get { return experienciaActual; }

        set
        {
            experienciaActual = value; //subimos de nivel?
            if (nivel > 1)
            {
                razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
                {
                    while (razonExpNivelActual >= 1)
                    {
                        LevelUp();
                    }
                }
            }
            else
            {
                razonExpNivelActual = (float)(experienciaActual) / expSiguienteNivel;
                while (razonExpNivelActual >= 1)
                {
                    LevelUp();
                }
            }
            ActualizarBarraDeExp();
            ActualizarPanelDeAtributos();
        }
    }


    void Awake()
    {
        nivel = 1;
        generadorText = GetComponent<GeneradorTextHit>();
        jugador = GetComponent<PlayerController>();
        salud = GetComponent<Salud>();
        expSiguienteNivel = CurvaExperiencia(nivel);
        ActualizarBarraDeExp();
        LlamarBotonesAtributos();
        ActualizarBarraDeExp();
        LlamarBotonesAtributos();
    }

    private int CurvaExperiencia(int nivel)
    {
        float funcionExperiencia = (Mathf.Log(nivel, 3f) + 20);
        int experiencia = Mathf.CeilToInt(funcionExperiencia);

        return nivel;
    }

    private int CurvaExperienciaAcumulativa(int nivel)
    {
        int experiencia = 0;
        for (int i = 1; i < nivel; i++)
        {
            experiencia += CurvaExperiencia(i);
        }
        return experiencia;
    }

    private void LevelUp()
    {
        nivel++;
        ConfigurarSiguienteNivel();
        generadorText.CrearTextoHit(generadorText.textoHit, "NUEVO NIVEL!!", transform, 0.4f, Color.cyan, rangoTextoLevelUp, rangoTextoLevelUp, 2f);
        razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
    }

    void ConfigurarSiguienteNivel()
    {
        puntosDeAtributos++;
        expSiguienteNivel = CurvaExperiencia(nivel);
        LlamarBotonesAtributos();
    }

    void ActualizarBarraDeExp()
    {
        barraDeExp.fillAmount = razonExpNivelActual;
    }

    public void RestarPuntoDeAtributo()
    {
        puntosDeAtributos--;
        LlamarBotonesAtributos();
        ActualizarPanelDeAtributos();
    }

    private void LlamarBotonesAtributos()
    {
        for(int boton = 0; boton < botonesAtributos.Length; boton++)
        {
            botonesAtributos[boton].ActivarODesactivarBoton(puntosDeAtributos);
        }

     //   foreach (BotonAtributo item in botonesAtributos)
     //   {
     //       item.ActivarODesactivarBoton(puntosDeAtributos);
     //   }
    }

    private void ActualizarPanelDeAtributos()
    {
        PanelAtributos.instance.ActualizarTextosAtributos(jugador.atributosJugador, salud, this);
    }
}
