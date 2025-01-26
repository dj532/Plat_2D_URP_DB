using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float velocidadPatrulla;
    private Vector3 destinoActual;
    private int indiceActual = 0;

    [SerializeField] private float danhoAtaque;
    private SistemaVidas sistemaVidas;

    private void Start()
    {
        destinoActual = wayPoints[indiceActual].position;
        StartCoroutine(Patrulla());
    }

    private IEnumerator Patrulla()
    {
        while (true)
        {
            while (transform.position != destinoActual)
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
