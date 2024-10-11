using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // El tiempo de espera en frames antes de cambiar el color
    public int framesToWait = 120; // Valor inicial, puede cambiarse desde el inspector
    
    private Renderer objectRenderer;
    private Color currentColor;
    private int frameCounter = 0;
    
    // Inicialización
    void Start()
    {
        // Obtiene el Renderer del objeto para modificar el material
        objectRenderer = GetComponent<Renderer>();

        // Inicializa el vector de color con valores aleatorios entre 0.0 y 1.0
        currentColor = new Color(Random.value, Random.value, Random.value);
        
        // Aplica el color inicial al objeto
        objectRenderer.material.color = currentColor;
    }

    // Update es llamada una vez por frame
    void Update()
    {
        // Incrementa el contador de frames
        frameCounter++;
        
        // Si ha pasado el número de frames necesarios, cambiar el color
        if (frameCounter >= framesToWait)
        {
            // Resetea el contador de frames
            frameCounter = 0;
            
            // Cambia uno de los componentes del color aleatoriamente
            int randomIndex = Random.Range(0, 3); // Índice aleatorio entre 0 y 2

            // Modifica el valor en la posición seleccionada
            if (randomIndex == 0)
                currentColor.r = Random.value;
            else if (randomIndex == 1)
                currentColor.g = Random.value;
            else
                currentColor.b = Random.value;

            // Asigna el nuevo color al objeto
            objectRenderer.material.color = currentColor;
        }
    }
}
