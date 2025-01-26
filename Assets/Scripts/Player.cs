using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;

    [Header("Sistema de movimiento")]
    [SerializeField] private Transform pies;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float distanciaDeteccionSuelo;
    [SerializeField] private LayerMask queEsSaltable;

    [Header("Sistema de combate")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    [Header("Componentes")]
    [SerializeField] private ControlRellenoVida controlVida;
    [SerializeField] private ScoreManager controlScore;
    private SistemaVidas sistemaVidas;

    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sistemaVidas = GetComponent<SistemaVidas>();

        sistemaVidas.OnMuerteEvent += ActivarGameOver;
        sistemaVidas.OnCambioVidaEvent += ActualizarBarraVida;

        controlVida.ActualizarBarra(sistemaVidas.GetVidaActual(), sistemaVidas.GetVidaMaxima());
    }


    void Update()
    {
        Movimiento();

        Saltar();

        LanzarAtaque();

    }

    private void LanzarAtaque()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }

    private void Ataque()
    {

        Collider2D[] collidersTocados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, queEsDanhable);
        foreach (var item in collidersTocados)
        {
            SistemaVidas sistemaVidasEnemigo = item.gameObject.GetComponent<SistemaVidas>();
            if (sistemaVidasEnemigo != null)
            {
                sistemaVidasEnemigo.RecibirDanho(danhoAtaque);
                controlScore.AgregarPuntos(10); // Añade 10 puntos al eliminar un enemigo
            }

        }
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstoyEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetTrigger("Saltar");
        }
    }

    private bool EstoyEnSuelo()
    {
        return Physics2D.Raycast(pies.position, Vector3.down, distanciaDeteccionSuelo, queEsSaltable);
    }

    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * velocidadMovimiento, rb.velocity.y);

        if (inputH != 0)
        {
            anim.SetBool("Running", true);
            transform.eulerAngles = inputH > 0 ? Vector3.zero : new Vector3(0, 180, 0);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    private void ActualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        controlVida.ActualizarBarra(vidaActual, vidaMaxima);
    }

    private void ActivarGameOver()
    {
        if (ControlGameOver.Instance != null)
        {
            Debug.Log("Llamando a MostrarGameOver...");
            ControlGameOver.Instance.MostrarGameOver();
        }
        else
        {
            Debug.LogError("ControlGameOver.Instance es null. Revisa si el script está asignado correctamente.");
        }
    }
    /*private void ActivarGameOver()
    {
        Debug.Log("Llamando a MostrarGameOver...");
        ControlGameOver.Instance.MostrarGameOver();
    }*/

    private void OnDestroy()
    {
        if (sistemaVidas != null)
        {
            sistemaVidas.OnMuerteEvent -= ActivarGameOver;
            sistemaVidas.OnCambioVidaEvent -= ActualizarBarraVida;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);
    }

}