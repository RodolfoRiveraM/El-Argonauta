using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField]
    [Range(-3, 3)]
    private float pitchMinimo;
    [SerializeField]
    [Range(-3, 3)]
    private float pitchMaximo;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void ReproducirSonido()
    {
        audioSource.pitch = Random.Range(pitchMinimo, pitchMaximo);
        audioSource.Play();
    }
}
