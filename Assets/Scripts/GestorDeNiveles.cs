using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeNiveles : MonoBehaviour
{
    public void Castillo()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndice = 2;
        SceneManager.LoadScene(siguienteEscenaIndice);
        MusicManager.instance.ReproducirMusica(4);
    }

    public void Playa()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndice = 3;
        SceneManager.LoadScene(siguienteEscenaIndice);
        MusicManager.instance.ReproducirMusica(2);
    }

    public void Inicio()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndice = 1;
        SceneManager.LoadScene(siguienteEscenaIndice);

    }

    public void Calabozo()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndice = 4;
        SceneManager.LoadScene(siguienteEscenaIndice);
        MusicManager.instance.ReproducirMusica(3);
    }


    public void Invierno()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndice = 5;
        SceneManager.LoadScene(siguienteEscenaIndice);
        MusicManager.instance.ReproducirMusica(1);
    }
}
