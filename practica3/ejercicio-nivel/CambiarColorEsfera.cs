using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColorEsfera : MonoBehaviour
{
    private Renderer rendererEsfera;

    void Start()
    {
        rendererEsfera = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Capsula"))
        {
            rendererEsfera.material.color = Color.green;
        }
    }
}
