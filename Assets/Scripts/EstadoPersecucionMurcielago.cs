using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MaquinaEstadoMurcielago;

public class EstadoPersecucionMurcielago : MaquinaEstadoMurcielago.IEstadoMurcielago
{
    private ControladorMurcielago controlador;
    private Transform jugador;

    public EstadoPersecucionMurcielago(ControladorMurcielago controlador)
    {
        this.controlador = controlador;
    }

    public void EntrarEstado()
    {
        jugador = GameObject.FindGameObjectWithTag("PlayerHitBox").transform;
        controlador.ActivarAnimacion("persecucion");
    }

    public void ActualizarEstado()
    {
        if (jugador != null)
        {
            controlador.transform.position = Vector2.MoveTowards(
                controlador.transform.position,
                jugador.position,
                controlador.ObtenerVelocidadPatrulla() * Time.deltaTime
            );
        }
    }

    public void SalirEstado()
    {
        controlador.ActivarAnimacion("Volar");
    }
}
