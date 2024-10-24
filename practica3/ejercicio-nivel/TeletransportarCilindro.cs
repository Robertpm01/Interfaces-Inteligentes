using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportarCilindro : MonoBehaviour
{
    public Vector3 puntoDestino; // Fija este punto en el inspector o en el código
    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            rb.MovePosition(puntoDestino);
        }
    }
}
