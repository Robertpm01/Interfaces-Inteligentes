using UnityEngine;

public class CylinderController : MonoBehaviour
{
    // Evento para enviar el mensaje a las esferas
    public static event System.Action<Transform> OnCuboCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cubo"))
        {
            Debug.Log("El cubo ha colisionado con el cilindro");
            
            // Llamar al evento enviando la referencia de este cilindro
            if (OnCuboCollision != null)
            {
                OnCuboCollision.Invoke(transform);
            }
        }
    }
}
