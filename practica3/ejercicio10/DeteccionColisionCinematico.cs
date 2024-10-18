using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColisionCinematico : MonoBehaviour
{
    // Se llama cuando otro objeto colisiona con el cilindro
    void OnCollisionEnter(Collision colision)
    {
        // Verifica si el objeto que colisiona tiene un tag
        if (colision.gameObject.CompareTag("Cubo") || colision.gameObject.CompareTag("Esfera"))
        {
            // Muestra un mensaje en la consola con la etiqueta del objeto que colisiona
            Debug.Log("Colisión detectada con: " + colision.gameObject.tag);
        }
    }
}
