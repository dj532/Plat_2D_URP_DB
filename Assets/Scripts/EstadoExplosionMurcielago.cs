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
        Debug.Log("Entrando en Explosi�n");
    }

    public void ActualizarEstado()
    {
        // Aqu� puede haber l�gica para destruir o desactivar el murci�lago.
        Object.Destroy(controlador.gameObject);
    }

    public void SalirEstado()
    {
        Debug.Log("Saliendo de Explosi�n");
    }
}
