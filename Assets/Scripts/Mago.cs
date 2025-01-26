using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : MonoBehaviour
{
    [SerializeField] private GameObject bolaFuego; // prefab
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaque;
    [SerializeField] private float danhoAtaque = 10f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RutinaAtaque());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator RutinaAtaque()
    {
        while (true)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoAtaque);
        }
    }
    private void LanzarBola()
    {
        if (GameObject.FindWithTag("PlayerHitBox") == null) return;

        // Calcula la direcci�n hacia el jugador
        Vector3 direccionJugador = (GameObject.FindWithTag("PlayerHitBox").transform.position - puntoSpawn.position).normalized;

        // Instancia la bola de fuego
        GameObject bola = Instantiate(bolaFuego, puntoSpawn.position, Quaternion.identity);

        // Asigna la direcci�n al script de la bola de fuego
        BolaFuego scriptBola = bola.GetComponent<BolaFuego>();
        if (scriptBola != null)
        {
            scriptBola.SetDireccion(direccionJugador);
        }
        else
        {
            Debug.LogError("No se encontr� el script BolaFuego en el objeto instanciado.");
        }
    }
}

