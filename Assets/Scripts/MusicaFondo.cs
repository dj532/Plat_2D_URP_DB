using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    [SerializeField] private AudioSource musica; // Asignar en el Inspector
    // Start is called before the first frame update
    void Start()
    {
        if (musica != null)
        {
            musica.Play(); // Inicia la música al comienzo del nivel
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DetenerMusica()
    {
        if (musica != null)
        {
            musica.Stop(); // Detiene la música
        }
    }
}
