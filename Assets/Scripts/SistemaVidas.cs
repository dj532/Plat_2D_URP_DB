using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private float vidaMaxima;
    private float vidaActual;

    public event Action OnMuerteEvent;
    public event Action<float, float> OnCambioVidaEvent;

    private void Start()
    {
        vidaActual = vidaMaxima;
        OnCambioVidaEvent?.Invoke(vidaActual, vidaMaxima);
    }

    public void RecibirDanho(float danho)
    {
        vidaActual -= danho;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        OnCambioVidaEvent?.Invoke(vidaActual, vidaMaxima);

        if (vidaActual <= 0)
        {
            Debug.Log("Jugador muerto, evento OnMuerteEvent invocado.");
            OnMuerteEvent?.Invoke();
            StartCoroutine(DestruirDespuesDeTiempo()); // Inicia una corrutina para destruir al jugador
        }
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        yield return new WaitForSeconds(0.1f); // Retrasa la destrucción 1 segundo
        Destroy(gameObject);
    }

    public float GetVidaActual() => vidaActual;
    public float GetVidaMaxima() => vidaMaxima;
}
