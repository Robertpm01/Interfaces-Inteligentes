using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        Debug.Log(name + " - Posicion: " + position.ToString());
    }
}
