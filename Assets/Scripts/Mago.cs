using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : MonoBehaviour
{
    [SerializeField] private GameObject bolaFuego; // prefab
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaque;
    [SerializeField] private float danhoAtaque;
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
        Instantiate(bolaFuego, puntoSpawn.position, transform.rotation);
    }
}
