using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public Transform objetivoSeleccionado;
    private Transform objetivoHuevoTipo2;
    public static event System.Action<Transform> OnCuboAranaTipo2Collision;
    public static event System.Action<Transform> OnCuboAranaTipo1Collision;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tipo2"))
        {   
            // colision araña gris
            
            if (OnCuboAranaTipo2Collision != null)
            {
                OnCuboAranaTipo2Collision.Invoke(objetivoSeleccionado); // Enviar la referencia de la arana
            }
        }

        if (collision.gameObject.CompareTag("tipo1"))
        {   
            // colision araña roja
            
            if (OnCuboAranaTipo1Collision != null)
            {
                GameObject huevo = GameObject.FindGameObjectWithTag("huevo_tipo2");
                if (huevo != null)
                {
                    objetivoHuevoTipo2 = huevo.transform;
                    OnCuboAranaTipo1Collision.Invoke(objetivoHuevoTipo2); // Enviar la referencia de la arana
                }
                else
                {
                    Debug.LogWarning("No se encontró ningún objeto con el tag 'huevo_tipo2'");
                }
            }
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoverCubo();
    }

    void MoverCubo()
    {
        // Movimiento de la esfera con las teclas W-S (eje vertical) y A-D (eje horizontal)
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f; // Tecla W (arriba)
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f; // Tecla S (abajo)
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f; // Tecla A (izquierda)
        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f; // Tecla D (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, 0, movimientoVertical); // Movimiento en los ejes X y Y
        rb.MovePosition(rb.position + direccion * speed * Time.deltaTime);
    }
}
