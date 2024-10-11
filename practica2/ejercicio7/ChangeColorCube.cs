using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : MonoBehaviour
{
    // Variables públicas para seleccionar los colores desde el Inspector
    public Color colorCubo;
    //public Color colorCubo = Color.blue;

    void Update()
    {
        // Detectar si se pulsa la tecla flecha arriba para cambiar el color del cubo
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Obtener el componente Renderer del cubo y cambiar el color al seleccionado
            Renderer cuboRenderer = GetComponent<Renderer>();
            cuboRenderer.material.color = colorCubo;
            Debug.Log("Color del cubo cambiado.");
        }
    }
}