using UnityEngine;

public class AranaTipo1Controller3 : MonoBehaviour
{
    private Transform Objetivo;
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento
        CuboController2.OnCuboCercaObjetivo += OnCuboCercaObjetivo;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CuboController2.OnCuboCercaObjetivo -= OnCuboCercaObjetivo;
    }

    private void OnCuboCercaObjetivo(Transform objetivo)
    {
        Objetivo = objetivo;
    }



    private void Update()
    {
        if (Objetivo != null)
        {
            // teletransportar araña 1 hacia el objetivo
            rb.position = Objetivo.position;
        }
    }
}
