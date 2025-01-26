using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRellenoVida : MonoBehaviour
{
    [SerializeField] private Image barraVida;

    public void ActualizarBarra(float vidaActual, float vidaMaxima)
    {
        barraVida.fillAmount = vidaActual / vidaMaxima;
    }
}