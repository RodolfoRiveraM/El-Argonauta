using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicas;
    public static MusicManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); //de esta forma nos aseguramos de que exista solo un musicmanager
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        ReproducirMusica(0);
    }

    public void ReproducirMusica(int indice)
    {
        audioSource.clip = musicas[indice];
        audioSource.Play();
    }


}
