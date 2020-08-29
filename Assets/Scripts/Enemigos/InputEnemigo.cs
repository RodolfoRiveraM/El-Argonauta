using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemigo : MonoBehaviour
{

    public Transform jugador;
    public float vertical
    {
        get
        {
            return direccionHaciaJugador.y;
        }
    }
    public float horizontal

    {
        get
        {
            return direccionHaciaJugador.x;
        }
    }
    public float distanciaJugador {  get { return direccionHaciaJugador.magnitude; } }
    public Vector2 direccionHaciaJugador { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        //jugador = GameManager.instance.jugador.transform;
        DefinirDireccionHaciaJugador();

    }

    // Update is called once per frame
    void Update()
    {
        DefinirDireccionHaciaJugador();

    }

    private void DefinirDireccionHaciaJugador()
    {
        direccionHaciaJugador = jugador.position - transform.position ;
    }

  
}
