using UnityEngine;

public class EsferaTipo2Controller : MonoBehaviour
{
    public float velocidad = 5f;
    private Transform cilindroObjetivo;

    private void OnEnable()
    {
        // Suscribirse al evento de colisión del cilindro
        CylinderController.OnCuboCollision += MoverHaciaCilindro;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se destruye el objeto o se desactiva
        CylinderController.OnCuboCollision -= MoverHaciaCilindro;
    }

    private void MoverHaciaCilindro(Transform cilindro)
    {
        // Establecer el cilindro como el objetivo
        cilindroObjetivo = cilindro;
    }

    private void Update()
    {
        if (cilindroObjetivo != null)
        {
            // Mover la esfera tipo 2 hacia el cilindro objetivo
            Vector3 direccion = (cilindroObjetivo.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
}
