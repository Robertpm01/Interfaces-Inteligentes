using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{

    public Vector3 moveDirection = new Vector3(1, 0, 0);
    public float speed = 2f;

    void Update()
    {
        // Trasladar el cubo según la dirección y la velocidad ajustada por frame.
        //transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        transform.Translate(moveDirection * speed, Space.World);

        // transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self); // Movimiento relativo al cubo
    }
}