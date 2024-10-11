using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCylinder : MonoBehaviour
{
    // Variables públicas para seleccionar los colores desde el Inspector
    public Color colorCilindro;
    //public Color colorCilindro = Color.blue;

    void Update()
    {
        // Detectar si se pulsa la tecla 'C' para cambiar el color del cilindro
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Obtener el componente Renderer del cilindro y cambiar el color al seleccionado
            Renderer cilindroRenderer = GetComponent<Renderer>();
            cilindroRenderer.material.color = colorCilindro;
            Debug.Log("Color del cilindro cambiado.");
        }
    }
}