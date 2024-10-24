using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{
    // codigo del ejercicio 5
    public float speed = 5f;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoverEsfera();
    }

    void MoverEsfera()
    {
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;
        
        if (Input.GetKey(KeyCode.I)) movimientoVertical = 1f; // Tecla I (arriba)
        if (Input.GetKey(KeyCode.K)) movimientoVertical = -1f; // Tecla K (abajo)
        if (Input.GetKey(KeyCode.J)) movimientoHorizontal = -1f; // Tecla J (izquierda)
        if (Input.GetKey(KeyCode.L)) movimientoHorizontal = 1f; // Tecla L (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;
        rb.MovePosition(transform.position + direccion * speed * Time.deltaTime);
    }
}
