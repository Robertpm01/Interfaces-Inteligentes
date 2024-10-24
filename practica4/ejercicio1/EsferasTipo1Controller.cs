using UnityEngine;

public class EsferaTipo1Controller : MonoBehaviour
{
    public Transform objetivoEsferaTipo2; // Asigna una esfera de tipo 2 desde el inspector
    public float velocidad = 5f;

    private void OnEnable()
    {
        // Suscribirse al evento de colisión del cilindro
        CylinderController.OnCuboCollision += MoverHaciaEsferaTipo2;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se destruye el objeto o se desactiva
        CylinderController.OnCuboCollision -= MoverHaciaEsferaTipo2;
    }

    private void MoverHaciaEsferaTipo2(Transform cilindro)
    {
        // Mover la esfera tipo 1 hacia la esfera de tipo 2
        Vector3 direccion = (objetivoEsferaTipo2.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}
