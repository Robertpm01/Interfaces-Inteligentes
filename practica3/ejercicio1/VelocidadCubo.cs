using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad = 1f;
    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
          Debug.Log("Flecha izquierda" + (movimientoHorizontal * velocidad));

        } else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
          Debug.Log("Flecha derecha" + (movimientoHorizontal * velocidad));

        } else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
          Debug.Log("Flecha arriba" + (movimientoVertical * velocidad));

        } else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
          Debug.Log("Flecha abajo" + (movimientoVertical * velocidad));
        }
    }
}