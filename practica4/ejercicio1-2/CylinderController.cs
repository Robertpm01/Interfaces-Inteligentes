using UnityEngine;

public class CylinderController : MonoBehaviour
{
    // Evento para enviar un mensaje a las esferas cuando el cubo colisiona con el cilindro
    public static event System.Action<Transform> OnCuboCollision;

    // Detectar colisión entre el cubo y el cilindro
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            Debug.Log("Cubo ha colisionado con el cilindro");
            
            // Disparar el evento para notificar a las esferas
            if (OnCuboCollision != null)
            {
                OnCuboCollision.Invoke(transform); // Enviar la referencia del cilindro
            }
        }
    }
}
