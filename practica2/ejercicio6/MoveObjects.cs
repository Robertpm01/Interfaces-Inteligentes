using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    // Referencias a los tres objetos que se moverán
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;

    // Desplazamientos configurables para cada objeto
    public Vector3 desplazamiento1;
    public Vector3 desplazamiento2;
    public Vector3 desplazamiento3;

    // Variable para controlar si ya se ha realizado el desplazamiento
    private bool desplazados = false;

    void Update()
    {
        // Detecta si se pulsa la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space) && !desplazados)
        {
            // Mover el objeto 1
            objeto1.transform.position = desplazamiento1;

            // Mover el objeto 2
            objeto2.transform.position = desplazamiento2;

            // Mover el objeto 3
            objeto3.transform.position = desplazamiento3;

            // Marcar que los objetos ya han sido desplazados
            desplazados = true;

            // Mostrar en la consola las nuevas posiciones
            Debug.Log("Nueva posición del objeto 1: " + objeto1.transform.position);
            Debug.Log("Nueva posición del objeto 2: " + objeto2.transform.position);
            Debug.Log("Nueva posición del objeto 3: " + objeto3.transform.position);
        }
    }
}
