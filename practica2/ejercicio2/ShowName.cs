using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Imprimir el nombre del objeto al que está asociado este script
        Debug.Log(gameObject.name);
    }
}