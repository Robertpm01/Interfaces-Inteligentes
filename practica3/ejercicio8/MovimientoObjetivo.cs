using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetivo : MonoBehaviour
{
    public float velocidadAvance = 5f; // Velocidad de avance del objeto
    public float velocidadGiro = 100f; // Velocidad de giro del objeto

    // Update is called once per frame
    void Update()
    {
        GirarObjetivo();
        AvanzarHaciaAdelante();
        DibujarRayoDepuracion();
    }

    void GirarObjetivo()
    {
        // Captura la entrada del eje Horizontal (teclas izquierda/derecha o A/D)
        float giroHorizontal = Input.GetAxis("Horizontal");

        // Aplica una rotación sobre el eje Y (gira a la izquierda o derecha)
        transform.Rotate(0, giroHorizontal * velocidadGiro * Time.deltaTime, 0);
    }

    void AvanzarHaciaAdelante()
    {
        // Mueve el objeto hacia adelante en la dirección que está mirando
        transform.Translate(transform.forward * velocidadAvance * Time.deltaTime, Space.World);
    }

    void DibujarRayoDepuracion()
    {
        // Dibuja un rayo desde la posición del objeto hacia adelante para visualizar la dirección
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }
}
