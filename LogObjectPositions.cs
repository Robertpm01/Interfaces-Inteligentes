using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogObjectPositions : MonoBehaviour
{ 
  void Start()
  {
    // Encuentra todos los objetos en la escena
    GameObject[] allObjects = FindObjectsOfType<GameObject>();

    foreach (GameObject obj in allObjects)
    {
      // Verificar si el objeto tiene un componente Transform
      if (obj.GetComponent<Transform>() != null)
      {
        // Obtener la posición del objeto
        Vector3 position = obj.transform.position;
          
        // Imprimir la posición del objeto en la consola
        Debug.Log(obj.name + " - Position: " + position.ToString());
      }
    }
  }
}