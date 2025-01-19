using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float implulsoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * implulsoDisparo, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
