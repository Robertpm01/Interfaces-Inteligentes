using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarChoquePared : MonoBehaviour
{
    // codigo ejercicio 11
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            Debug.Log("La esfera ha chocado con la pared: " + other.gameObject.name);
        }
    }
}
