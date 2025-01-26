using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MaquinaEstadoMurcielago;

public class ControladorMurcielago : MonoBehaviour
{
    [Header("Configuración de Patrulla")]
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float velocidadPatrulla;

    [Header("Configuración de Combate")]
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Transform puntoDeteccionJugador;
    [SerializeField] private float rangoDeteccionJugador;
    [SerializeField] private LayerMask capaJugador;

    [Header("Animaciones")]
    [SerializeField] private Animator animator;

    private MaquinaEstadoMurcielago maquinaEstados;

    public EstadoPersecucionMurcielago estadoPersecucion;
    public EstadoAtaqueMurcielago estadoAtaque;
    public EstadoExplosionMurcielago estadoExplosion;

    private void Awake()
    {
        maquinaEstados = new MaquinaEstadoMurcielago();

        estadoPersecucion = new EstadoPersecucionMurcielago(this);
        estadoAtaque = new EstadoAtaqueMurcielago(this);
        estadoExplosion = new EstadoExplosionMurcielago(this);

        maquinaEstados.CambiarEstado(null); // Inicia sin estado.
    }

    private void Update()
    {
        maquinaEstados.Actualizar();
    }

    public void CambiarEstado(MaquinaEstadoMurcielago.IEstadoMurcielago nuevoEstado)
    {
        maquinaEstados.CambiarEstado(nuevoEstado);
    }

    public void ActivarAnimacion(string nombreAnimacion)
    {
        if (animator != null)
        {
            animator.SetTrigger(nombreAnimacion);
        }
    }
    public void ConfigurarWaypoints(Transform[] nuevosWaypoints)
    {
        wayPoints = nuevosWaypoints;
    }

    public Transform ObtenerPuntoDeteccionJugador() => puntoDeteccionJugador;
    public float ObtenerRangoDeteccionJugador() => rangoDeteccionJugador;
    public LayerMask ObtenerCapaJugador() => capaJugador;
    public float ObtenerDanhoAtaque() => danhoAtaque;
    public float ObtenerVelocidadPatrulla() => velocidadPatrulla;
}