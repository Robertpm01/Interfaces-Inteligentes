using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCuboHaciaEsfera : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject cubo;
    // Update is called once per frame
    void Update()
    {
        MoverObjeto();
        MoverCuboHaciaEsfera();
        GirarCuboHaciaEsfera();
    }

    void MoverObjeto()
    {
        // Movimiento de la esfera con las teclas W-S (eje vertical) y A-D (eje horizontal)
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f; // Tecla W (arriba)
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f; // Tecla S (abajo)
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f; // Tecla A (izquierda)
        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f; // Tecla D (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, movimientoVertical, 0); // Movimiento en los ejes X y Y
        transform.Translate(direccion * speed * Time.deltaTime, Space.World);
    }

    void MoverCuboHaciaEsfera()
    {
        // Calcula la dirección desde el cubo hacia la esfera
        Vector3 direccion = (esfera.position - cubo.position).normalized;

        // Mantén la altura (eje Y) del cubo constante
        direccion.y = 0;

        // Mueve el cubo en la dirección hacia la esfera, a una velocidad constante
        cubo.Translate(direccion * speed * Time.deltaTime, Space.World);
    }

    void GirarCuboHaciaEsfera()
    {
        // Ajusta la posición de la esfera para que tenga la misma altura que el cubo
        Vector3 posicionObjetivo = new Vector3(position.x, cubo.position.y, position.z);

        // Hace que el cubo gire hacia la posición de la esfera
        cubo.LookAt(posicionObjetivo);
    }
}
