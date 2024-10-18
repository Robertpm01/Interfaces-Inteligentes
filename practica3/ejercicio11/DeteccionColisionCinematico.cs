using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionTriggerCilindro : MonoBehaviour
{
    // Este método se ejecuta cuando otro objeto entra en el Trigger del cilindro
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene la etiqueta "Cubo" o "Esfera"
        if (other.CompareTag("Cubo") || other.CompareTag("Esfera"))
        {
            // Muestra un mensaje en la consola con la etiqueta del objeto que colisiona
            Debug.Log("El objeto que entró en el Trigger es: " + other.gameObject.tag);
        }
    }
}
