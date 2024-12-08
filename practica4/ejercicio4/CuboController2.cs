using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboController2 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public Transform objetivoSeleccionado;
    public float distanciaDeteccion = 5f;
    public static event System.Action<Transform> OnCuboCercaObjetivo;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoverCubo();

        // Verificar distancia entre el cubo y el objetivo
        if (Vector3.Distance(transform.position, objetivoSeleccionado.position) <= distanciaDeteccion)
        {
            // Activar el evento para notificar a otros
            OnCuboCercaObjetivo?.Invoke(objetivoSeleccionado);
        }
    }

    void MoverCubo()
    {
        // Movimiento de la esfera con las teclas W-S (eje vertical) y A-D (eje horizontal)
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f; // Tecla W (arriba)
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f; // Tecla S (abajo)
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f; // Tecla A (izquierda)
        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f; // Tecla D (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, 0, movimientoVertical); // Movimiento en los ejes X y Y
        rb.MovePosition(rb.position + direccion * speed * Time.deltaTime);
    }
}
