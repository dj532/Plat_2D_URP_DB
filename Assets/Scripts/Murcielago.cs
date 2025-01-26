using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadPatrulla; // Velocidad de movimiento
    [SerializeField] private float rangoMovimiento; // Rango de movimiento en un eje
    private Vector3 posicionInicial;
    private bool moviendoHorizontal = true;

    [Header("Detección")]
    [SerializeField] private float danhoAtaque;
    [SerializeField] private float rangoDeteccion; // Rango para detectar al jugador
    [SerializeField] private LayerMask capaJugador;

    private Transform jugador;

    private void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(Patrullar());
    }

    private IEnumerator Patrullar()
    {
        while (true)
        {
            if (jugador == null) // Patrullar solo si no hay jugador detectado
            {
                float nuevaPosicionX = moviendoHorizontal
                    ? posicionInicial.x + rangoMovimiento
                    : posicionInicial.x - rangoMovimiento;

                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(nuevaPosicionX, transform.position.y),
                    velocidadPatrulla * Time.deltaTime);

                EnfocarDestino(nuevaPosicionX);

                if (Vector2.Distance(transform.position, new Vector2(nuevaPosicionX, transform.position.y)) < 0.1f)
                {
                    moviendoHorizontal = !moviendoHorizontal; // Cambiar dirección de derecha a izquierda
                }
            }

            yield return null;
        }
    }

    private void EnfocarDestino(float destinoX)
    {
        // Orientar el murciélago hacia la dirección del movimiento
        transform.localScale = destinoX > transform.position.x ? Vector3.one : new Vector3(-1, 1, 1);
    }

    private void Update()
    {
        // Detectar al jugador dentro del rango
        Collider2D jugadorDetectado = Physics2D.OverlapCircle(transform.position, rangoDeteccion, capaJugador);

        if (jugadorDetectado != null)
        {
            jugador = jugadorDetectado.transform;
            PerseguirJugador();
        }
        else
        {
            jugador = null;
        }
    }

    private void PerseguirJugador()
    {
        if (jugador != null)
        {
            Vector3 posicionAnterior = transform.position;
            transform.position = Vector2.MoveTowards(transform.position,
                jugador.position,
                velocidadPatrulla * Time.deltaTime);

            // Orientar el murciélago hacia el jugador
            EnfocarDestino(jugador.position.x);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar rango de detección en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}

/*[Header("Patrullaje")]
[SerializeField] private Transform[] wayPoints;
[SerializeField] private float velocidadPatrulla;

[Header("Detección")]
[SerializeField] private float danhoAtaque;
[SerializeField] private LayerMask capaJugador;

private Vector3 destinoActual;
private int indiceActual = 0;

public delegate void JugadorDetectadoEventHandler(Transform jugador);
public event JugadorDetectadoEventHandler OnJugadorDetectado;

private void Start()
{
    destinoActual = wayPoints[indiceActual].position;
    StartCoroutine(Patrulla());
}

private IEnumerator Patrulla()
{
    while (true)
    {
        while (Vector3.Distance(transform.position, destinoActual) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadPatrulla * Time.deltaTime);
            yield return null;
        }

        DefinirNuevoDestino();
    }
}

private void DefinirNuevoDestino()
{
    indiceActual = (indiceActual + 1) % wayPoints.Length;
    destinoActual = wayPoints[indiceActual].position; 
    EnfocarDestino();
}

private void EnfocarDestino()
{
    transform.localScale = destinoActual.x > transform.position.x ? Vector3.one : new Vector3(-1, 1, 1);
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("DeteccionPlayer"))
    {
        Debug.Log("Jugador detectado por Murciélago");
        OnJugadorDetectado?.Invoke(other.transform);
    }
}

}*/