using UnityEngine;

public class AranaTipo2Controller4 : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private Transform Objetivo;
    public Transform huevoObjetivo;
    private Rigidbody rb; // Referencia al Rigidbody
    public float velocidadRotacion = 10f; // Velocidad de rotación hacia el objetivo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento
        CuboController3.OnCuboCercaAranaTipo2 += OnCuboCercaArana;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CuboController3.OnCuboCercaAranaTipo2 -= OnCuboCercaArana;
    }

    private void OnCuboCercaArana(Transform objetivo)
    {
        Objetivo = huevoObjetivo;
    }

    private void Update()
    {
        if (Objetivo != null)
        {
            Vector3 direccion = (Objetivo.position - rb.position).normalized;
            rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);
            Objetivo = null;
        }
    }
}
