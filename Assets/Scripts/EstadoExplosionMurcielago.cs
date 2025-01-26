using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoExplosionMurcielago : MaquinaEstadoMurcielago.IEstadoMurcielago
{
    private ControladorMurcielago controlador;

    public EstadoExplosionMurcielago(ControladorMurcielago controlador)
    {
        this.controlador = controlador;
    }

    public void EntrarEstado()
    {
        controlador.ActivarAnimacion("explosion");
        Debug.Log("Entrando en Explosión");
    }

    public void ActualizarEstado()
    {
        // Aquí puede haber lógica para destruir o desactivar el murciélago.
        Object.Destroy(controlador.gameObject);
    }

    public void SalirEstado()
    {
        Debug.Log("Saliendo de Explosión");
    }
}
