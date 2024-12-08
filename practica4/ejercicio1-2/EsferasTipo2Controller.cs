using UnityEngine;

public class EsferaTipo2Controller : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private Transform cilindroObjetivo; // Referencia al cilindro objetivo
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento de colisión del cilindro
        CylinderController.OnCuboCollision += MoverHaciaCilindro;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CylinderController.OnCuboCollision -= MoverHaciaCilindro;
    }

    private void MoverHaciaCilindro(Transform cilindro)
    {
        // Establecer el cilindro objetivo como el cilindro que colisionó
        cilindroObjetivo = cilindro;
    }

    private void Update()
    {
        if (cilindroObjetivo != null)
        {
            // Mover la esfera tipo 2 hacia el cilindro objetivo
            Vector3 direccion = (cilindroObjetivo.position - transform.position).normalized;
            Vector3 nuevaPosicion = rb.position + direccion * velocidad * Time.deltaTime;
            rb.MovePosition(nuevaPosicion);
        }
    }
}
