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
        // Aqu� podr�as agregar l�gica de da�o o interacci�n
    }

    public void SalirEstado()
    {
        controlador.ActivarAnimacion("persecusion");
    }
}
