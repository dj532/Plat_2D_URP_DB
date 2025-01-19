using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
    // Se ejecuta desde evento de animacion
    private void Ataque()
    {
        // Lanzar trigger instantaneo
        Collider2D[] collidersTocados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, queEsDanhable);
        foreach(var item in collidersTocados)
        {
            SistemaVidas sistemaVidas = item.gameObject.GetComponent<SistemaVidas>();
            sistemaVidas.RecibirDanho(danhoAtaque);
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
        bool tocado = Physics2D.Raycast(pies.position, Vector3.down, distanciaDeteccionSuelo, queEsSaltable);
        return tocado;
    }
    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * velocidadMovimiento, rb.velocity.y);
        if (inputH != 0)
        {
            anim.SetBool("Running", true);
            if(inputH > 0) // mov a Derecha
            {
                transform.eulerAngles = Vector3.zero;
            }
            else // Mov a Izq
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else // InputH = 0.
        {
            anim.SetBool("Running", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoAtaque.position, radioAtaque);
    }
}
