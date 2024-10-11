using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeight2Sooner : MonoBehaviour
{
    // Variables públicas para ajustar el incremento de altura desde el Inspector
    public float incrementoAltura = 1.0f;

    void Start()
    {
        // Encuentra todas las esferas con la etiqueta "type2"
        GameObject[] esferas = GameObject.FindGameObjectsWithTag("type2");

        if (esferas.Length < 2)
        {
            Debug.LogError("No hay suficientes esferas con la etiqueta 'type2' para encontrar las dos más cercanas.");
            return;
        }

        GameObject esferaMasCercana1 = null;
        GameObject esferaMasCercana2 = null;

        float distanciaMasCercana1 = Mathf.Infinity;
        float distanciaMasCercana2 = Mathf.Infinity;

        // Recorrer todas las esferas y encontrar las dos más cercanas
        foreach (GameObject obj in esferas)
        {
            float distanciaActual = Vector3.Distance(transform.position, obj.transform.position);

            if (distanciaActual < distanciaMasCercana1)
            {
                // Actualizar la segunda esfera más cercana con la antigua primera
                distanciaMasCercana2 = distanciaMasCercana1;
                esferaMasCercana2 = esferaMasCercana1;

                // Actualizar la primera esfera más cercana
                distanciaMasCercana1 = distanciaActual;
                esferaMasCercana1 = obj;
            }
            else if (distanciaActual < distanciaMasCercana2)
            {
                // Actualizar la segunda esfera más cercana si es más cercana que la actual segunda
                distanciaMasCercana2 = distanciaActual;
                esferaMasCercana2 = obj;
            }
        }

        // Aumentar la altura (escala en Y) de las dos esferas más cercanas
        if (esferaMasCercana1 != null)
        {
            esferaMasCercana1.transform.localScale = new Vector3(
                esferaMasCercana1.transform.localScale.x,
                esferaMasCercana1.transform.localScale.y + incrementoAltura,
                esferaMasCercana1.transform.localScale.z
            );
        }

        if (esferaMasCercana2 != null)
        {
            esferaMasCercana2.transform.localScale = new Vector3(
                esferaMasCercana2.transform.localScale.x,
                esferaMasCercana2.transform.localScale.y + incrementoAltura,
                esferaMasCercana2.transform.localScale.z
            );
        }
    }
}
