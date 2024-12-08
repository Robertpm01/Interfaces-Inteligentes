using UnityEngine;

public class EsferaTipo1Controller : MonoBehaviour
{
    public Transform objetivoEsferaTipo2; // Esfera de tipo 2 objetivo
    public float velocidad = 5f; // Velocidad de movimiento
    private Rigidbody rb; // Referencia al Rigidbody
    private bool collision = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento de colisión del cilindro
        CylinderController.OnCuboCollision += MoverHaciaEsferaTipo2;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CylinderController.OnCuboCollision -= MoverHaciaEsferaTipo2;
    }

    private void MoverHaciaEsferaTipo2(Transform cilindro)
    {   
        collision = true;
    }

    private void Update()
    {
        if (objetivoEsferaTipo2 != null && collision == true)
        {
            // Mover la esfera tipo 1 hacia su objetivo de tipo 2
            Vector3 direccion = (objetivoEsferaTipo2.position - transform.position).normalized;
            Vector3 nuevaPosicion = rb.position + direccion * velocidad * Time.deltaTime;
            rb.MovePosition(nuevaPosicion);
        }
    }

}
