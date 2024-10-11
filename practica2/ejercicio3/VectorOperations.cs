using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorOperations : MonoBehaviour
{
    // Declaramos dos variables públicas de tipo Vector3 para ser configuradas desde el inspector
    public Vector3 vector1;
    public Vector3 vector2;

    // Variables para mostrar los resultados en el Inspector
    public float magnitudVector1;
    public float magnitudVector2;
    public float anguloEntreVectores;
    public float distanciaEntreVectores;
    public string vectorMayorAltura;

    // Start es llamado antes de la primera actualización de frame
    void Start()
    {
        // Calculamos la magnitud de los vectores
        magnitudVector1 = vector1.magnitude;
        magnitudVector2 = vector2.magnitude;

        // Mostramos las magnitudes en la consola
        Debug.Log("Magnitud de Vector1: " + magnitudVector1);
        Debug.Log("Magnitud de Vector2: " + magnitudVector2);

        // Calculamos el ángulo entre los dos vectores usando el producto punto
        anguloEntreVectores = Vector3.Angle(vector1, vector2);
        Debug.Log("Ángulo entre Vector1 y Vector2: " + anguloEntreVectores + " grados");

        // Calculamos la distancia entre los dos vectores
        distanciaEntreVectores = Vector3.Distance(vector1, vector2);
        Debug.Log("Distancia entre Vector1 y Vector2: " + distanciaEntreVectores);

        // Determinamos cuál de los vectores está a mayor altura (comparando el valor de y)
        if (vector1.y > vector2.y)
        {
            vectorMayorAltura = "Vector1 está a mayor altura.";
        }
        else if (vector1.y < vector2.y)
        {
            vectorMayorAltura = "Vector2 está a mayor altura.";
        }
        else
        {
            vectorMayorAltura = "Ambos vectores están a la misma altura.";
        }
        
        // Mostramos en la consola cuál vector está a mayor altura
        Debug.Log(vectorMayorAltura);
    }
}
