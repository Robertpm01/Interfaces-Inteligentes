using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    void Update()
    {
       Disparar();
    }

    void Disparar()
    {   
        if (Input.GetButtonDown("Fire1"))
       {
            Debug.Log("Disparo realizado");
       } 
    }
}
