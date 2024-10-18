using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceTenUnits : MonoBehaviour
{
    private GameObject cubo;
    private GameObject cilindro;
    private GameObject esfera;
    public float desplazamiento = 10;
    public int framesToWait = 120;
    private int frameCounter = 0;

    void Update() 
    {
        frameCounter++;

        if (frameCounter >= framesToWait) {

            cubo = GameObject.FindWithTag("Cube");
            cilindro = GameObject.FindWithTag("Cylinder");
            esfera = GameObject.FindWithTag("Sphere");

            // Verificamos si los objetos han sido encontrados
            if (cubo != null && cilindro != null && esfera != null)
            {
                // Calcular y mostrar la distancia a ambos objetos en la consola
                float distanciaCubo = Vector3.Distance(transform.position, cubo.transform.position);
                float distanciaCilindro = Vector3.Distance(transform.position, cilindro.transform.position);
                float distanciaEsfera = Vector3.Distance(transform.position, esfera.transform.position);

                Debug.Log("Distancia a Cubo: " + distanciaCubo);
                Debug.Log("Distancia a Cilindro: " + distanciaCilindro);
                Debug.Log("Distancia a Esfera: " + distanciaEsfera);
                
                esfera.transform.localScale = new Vector3(esfera.transform.x - transform.x + desplazamiento, 0, esfera.transform.z - transform.z + desplazamiento);
                cubo.transform.localScale = new Vector3(cubo.transform.x - transform.x + desplazamiento, 0, cubo.transform.z - transform.z + desplazamiento);
                cilindro.transform.localScale = new Vector3(cilindro.transform.x - transform.x + desplazamiento, 0, cilindro.transform.z - transform.z + desplazamiento);

                float distanciaCuboMod = Vector3.Distance(transform.position, cubo.transform.position);
                float distanciaCilindroMod = Vector3.Distance(transform.position, cilindro.transform.position);
                float distanciaEsferaMod = Vector3.Distance(transform.position, esfera.transform.position);

                Debug.Log("Distancia a Cubo modificada: " + distanciaCubo);
                Debug.Log("Distancia a Cilindro modificada: " + distanciaCilindro);
                Debug.Log("Distancia a Esfera modificada: " + distanciaEsfera);

                // Resetea el contador de frames
                frameCounter = 0;
                
                // Cambia uno de los componentes del color aleatoriamente
                int randomIndex = Random.Range(0, 3); // Índice aleatorio entre 0 y 2

                // Modifica el valor en la posición seleccionada
                if (randomIndex == 0)
                    esfera.currentColor.r = Random.value;
                    cubo.currentColor.r = Random.value;
                    cilindro.currentColor.r = Random.value;
                else if (randomIndex == 1)
                    esfera.currentColor.g = Random.value;
                    cubo.currentColor.g = Random.value;
                    cilindro.currentColor.g = Random.value;
                else
                    esfera.currentColor.b = Random.value;
                    cubo.currentColor.b = Random.value;
                    cilindro.currentColor.b = Random.value;

                // Asigna el nuevo color al objeto
                esfera.objectRenderer.material.color = currentColor;
                cubo.objectRenderer.material.color = currentColor;
                cilindro.objectRenderer.material.color = currentColor;
            }
            else
            {
                // Mostrar un mensaje de error si no se encuentran los objetos
                Debug.LogError("No se encontraron el cubo o el cilindro con las etiquetas especificadas.");
            }
        }
    }
}
