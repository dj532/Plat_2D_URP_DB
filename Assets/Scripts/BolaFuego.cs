using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float impulsoDisparo; // Aseg�rate de tener un valor predeterminado
    [SerializeField] private float danhoAtaque;

    public void SetDireccion(Vector3 direccion)
    {
        // Inicializa el Rigidbody2D si a�n no se ha hecho
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();

        }

        // Aseg�rate de que el Rigidbody2D existe antes de aplicar la fuerza
        if (rb != null)
        {
            rb.AddForce(direccion * impulsoDisparo, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("El Rigidbody2D no est� asignado en BolaFuego.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidas sistemaVidas = col.GetComponent<SistemaVidas>();
            if (sistemaVidas != null)
            {
                sistemaVidas.RecibirDanho(danhoAtaque);
            }
        }
    }
}
