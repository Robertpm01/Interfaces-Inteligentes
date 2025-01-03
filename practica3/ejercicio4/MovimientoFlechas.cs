using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFlechas : MonoBehaviour
{
    public float speed = 1.5f;
    // Update is called once per frame
    void Update()
    {
        MoverObjeto();
    }

    void MoverObjeto()
    {
        // Movimiento de la esfera con las teclas W-S (eje vertical) y A-D (eje horizontal)
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) movimientoVertical = 1f; // Tecla W (arriba)
        if (Input.GetKey(KeyCode.DownArrow)) movimientoVertical = -1f; // Tecla S (abajo)
        if (Input.GetKey(KeyCode.LeftArrow)) movimientoHorizontal = -1f; // Tecla A (izquierda)
        if (Input.GetKey(KeyCode.RightArrow)) movimientoHorizontal = 1f; // Tecla D (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, movimientoVertical, 0); // Movimiento en los ejes X y Y
        //transform.Translate(direccion * speed * Time.deltaTime, Space.World);
        transform.Translate(direccion * speed, Space.World);
    }
}
