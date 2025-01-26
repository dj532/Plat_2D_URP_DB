using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaquinaEstadoMurcielago 
{
    private IEstadoMurcielago estadoActual;

    public interface IEstadoMurcielago
    {
        void EntrarEstado();

        void ActualizarEstado();

        void SalirEstado();
    }

    public void CambiarEstado(IEstadoMurcielago nuevoEstado)
    {
        if (estadoActual != null)
        {
            estadoActual.SalirEstado();
        }

        estadoActual = nuevoEstado;

        if (estadoActual != null)
        {
            estadoActual.EntrarEstado();
        }
    }

    public void Actualizar()
    {
        if (estadoActual != null)
        {
            estadoActual.ActualizarEstado();
        }
    }
}