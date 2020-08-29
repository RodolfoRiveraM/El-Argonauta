using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionTitulo : MonoBehaviour
{
    public Sprite animacionInicializada;
    public Sprite animacionFinalizada;
    private Image image;
    public bool anima;
 
    void Start()
    {
        image = GetComponent<Image>();
        Screen.SetResolution(1920, 1080, true);
    }

    
    public void AnimarOCerrarAnimacion()
    {
        if (anima)
        {
            image.sprite = animacionInicializada;
            anima = false;
        }
        else
        {
            image.sprite = animacionFinalizada;
            anima = true;
        }
    }
}
