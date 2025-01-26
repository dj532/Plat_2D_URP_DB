using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour
{
    [SerializeField] private SistemaVidas sistemaVidas;

    private void Start()
    {
        if (sistemaVidas != null)
        {
            sistemaVidas.OnMuerteEvent += AlMorir;
        }
    }

    private void AlMorir()
    {
        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (sistemaVidas != null)
        {
            sistemaVidas.OnMuerteEvent -= AlMorir;
        }
    }
}