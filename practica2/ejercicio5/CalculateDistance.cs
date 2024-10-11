using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    // Referencias a los objetos cubo y cilindro
    private GameObject cubo;
    private GameObject cilindro;

    // Start es llamado antes de la primera actualización de frame
    void Start()
    {
        // Encontrar el objeto cubo por su etiqueta
        cubo = GameObject.FindWithTag("Cube");
        
        // Encontrar el objeto cilindro por su etiqueta
        cilindro = GameObject.FindWithTag("Cylinder");

        // Verificamos si ambos objetos han sido encontrados
        if (cubo != null && cilindro != null)
        {
            // Calcular y mostrar la distancia a ambos objetos en la consola
            float distanciaCubo = Vector3.Distance(transform.position, cubo.transform.position);
            float distanciaCilindro = Vector3.Distance(transform.position, cilindro.transform.position);

            Debug.Log("Distancia a Cubo: " + distanciaCubo);
            Debug.Log("Distancia a Cilindro: " + distanciaCilindro);
        }
        else
        {
            // Mostrar un mensaje de error si no se encuentran los objetos
            Debug.LogError("No se encontraron el cubo o el cilindro con las etiquetas especificadas.");
        }
    }
}
