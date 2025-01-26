using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtaqueMurcielago : MaquinaEstadoMurcielago.IEstadoMurcielago
{
    private ControladorMurcielago controlador;

    public EstadoAtaqueMurcielago(ControladorMurcielago controlador)
    {
        this.controlador = controlador;
    }

    public void EntrarEstado()
    {
        controlador.ActivarAnimacion("atacar");
    }

    public void ActualizarEstado()
    {
        // Aquí podrías agregar lógica de daño o interacción
    }

    public void SalirEstado()
    {
        controlador.ActivarAnimacion("persecusion");
    }
}
