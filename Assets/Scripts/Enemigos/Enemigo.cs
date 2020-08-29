using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Atributos atributos;
    public string nombre;
    public int experiencia;
    public GameObject puff;
    
    protected void DecirNombre() //Protected permite acceder swasw clases derivadas pero no desde "fuera"
    {
        Debug.Log("soy " + nombre);
    }

    public void EntregarExperiencia()
    {
        GameManager.instance.jugador.GetComponent<NivelDeExperiencia>().experiencia += experiencia;
    }
}
