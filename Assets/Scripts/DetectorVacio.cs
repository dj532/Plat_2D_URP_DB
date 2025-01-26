using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorVacio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitBox")) 
        {
            Debug.Log("Jugador cayó al vacío. Game Over.");
            ActivarGameOver();
        }
    }

    private void ActivarGameOver()
    {
        // Llama al controlador de Game Over
        ControlGameOver.Instance.MostrarGameOver();
    }
}
