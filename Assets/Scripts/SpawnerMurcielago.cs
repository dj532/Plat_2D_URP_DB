using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMurcielago : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Waypoints para los murciélagos
    [SerializeField] private GameObject murcielagoPrefab;
    [SerializeField] private int cantidadMurcielagos = 10;
    [SerializeField] private float intervaloSpawn = 1f;

    private void Start()
    {
        StartCoroutine(SpawnearMurcielago());
    }

    IEnumerator SpawnearMurcielago()
    {
        for (int i = 0; i < cantidadMurcielagos; i++)
        {
            GameObject murcielago = Instantiate(murcielagoPrefab, transform.position, Quaternion.identity);
            var controlador = murcielago.GetComponent<ControladorMurcielago>();
            if (controlador != null)
            {
                controlador.ConfigurarWaypoints(waypoints); // Pasar los waypoints al murciélago
            }
            yield return new WaitForSeconds(intervaloSpawn);
        }
    }
}