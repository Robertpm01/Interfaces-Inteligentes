using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorFarther : MonoBehaviour
{
    // Variables públicas para seleccionar los colores desde el Inspector
    public Color colorEsfera;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) {
        // Encuentra todos los objetos en la escena
        GameObject[] esferas = GameObject.FindGameObjectsWithTag("type2");
        GameObject esferaMasLejana = null;
        float distanciaMasLejana = 0;

        foreach (GameObject obj in esferas)
        { 
          if (distanciaMasLejana < Vector3.Distance(transform.position, obj.transform.position)) 
          {
            distanciaMasLejana = Vector3.Distance(transform.position, obj.transform.position);
            esferaMasLejana = obj;
          }
        }
        // Obtener el componente Renderer de la esfera y cambiar el color al seleccionado
        Renderer EsferaRenderer = esferaMasLejana.GetComponent<Renderer>();
        EsferaRenderer.material.color = colorEsfera;
        Debug.Log("Color de la esfera cambiado.");
      }
    }
}