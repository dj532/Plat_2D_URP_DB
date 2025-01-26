using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlMonedas : MonoBehaviour
{
    public static ControlMonedas Instance;

    [SerializeField] private int monedasTotales; // Total de monedas en el nivel
    private int monedasRecolectadas = 0; // Contador de monedas recolectadas

    [Header("UI Elements")]
    [SerializeField] private TMP_Text textoMonedas; // Texto para mostrar monedas recolectadas
    [SerializeField] private Slider barraProgreso; // Barra de progreso

    private void Awake()
    {
        // Configuración del Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void RecolectarMoneda()
    {
        // Incrementa el contador de monedas recolectadas
        monedasRecolectadas++;

        // Actualiza la UI
        ActualizarUI();

        // Comprueba si todas las monedas han sido recolectadas
        if (monedasRecolectadas >= monedasTotales)
        {
            Debug.Log("¡Nivel completado! Todas las monedas recolectadas.");
            ControlGameOver.Instance.MostrarVictoria(); // Llama al método para mostrar victoria
        }
    }

    private void ActualizarUI()
    {
        // Actualiza el texto del contador
        if (textoMonedas != null)
        {
            textoMonedas.text = $"Monedas: {monedasRecolectadas}/{monedasTotales}";
        }

        // Actualiza la barra de progreso
        if (barraProgreso != null)
        {
            barraProgreso.value = (float)monedasRecolectadas / monedasTotales;
        }
    }
}
