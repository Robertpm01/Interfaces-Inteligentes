using UnityEngine;

public class AranaTipo1Controller2 : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private Transform Objetivo;
    private Rigidbody rb; // Referencia al Rigidbody
    public Material color;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("huevo_tipo2"))
        {
            Debug.Log("Colisión con huevo tipo 2 detectada.");

            // Obtener el Renderer del objeto y cambiar el material
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = color;
                Debug.Log("Color cambiado correctamente.");
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente Renderer.");
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento de colisión
        CuboController.OnCuboAranaTipo2Collision += MoverHaciaObjetivoSeleccionado;
        CuboController.OnCuboAranaTipo1Collision += MoverHaciaObjetivoHuevoTipo2;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CuboController.OnCuboAranaTipo2Collision -= MoverHaciaObjetivoSeleccionado;
        CuboController.OnCuboAranaTipo1Collision -= MoverHaciaObjetivoHuevoTipo2;
    }

    private void MoverHaciaObjetivoSeleccionado(Transform objetivo)
    {
        Objetivo = objetivo;
    }

    private void MoverHaciaObjetivoHuevoTipo2(Transform objetivo)
    {
        Objetivo = objetivo;
    }

    private void Update()
    {
        if (Objetivo != null)
        {
            // Mover la esfera tipo 2 hacia el objetivo
            Vector3 direccion = (Objetivo.position - transform.position).normalized;
            rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);
        }

        if (Objetivo != null)
        {
            // Mover la esfera tipo 2 hacia el objetivo
            Vector3 direccion = (Objetivo.position - transform.position).normalized;
            rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);
        }
    }
}
