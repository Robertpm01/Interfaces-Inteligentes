using UnityEngine;

public class AranaTipo2Controller3 : MonoBehaviour
{
    private Transform Objetivo;
    public Transform objetivoAranaTipo2;
    private Rigidbody rb; // Referencia al Rigidbody
    public float velocidadRotacion = 10f; // Velocidad de rotación hacia el objetivo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    private void OnEnable()
    {
        // Suscribirse al evento
        CuboController2.OnCuboCercaObjetivo += OnCuboCercaObjetivo;
    }

    private void OnDisable()
    {
        // Desuscribirse cuando se desactiva o destruye
        CuboController2.OnCuboCercaObjetivo -= OnCuboCercaObjetivo;
    }

    private void OnCuboCercaObjetivo(Transform objetivo)
    {
        Objetivo = objetivoAranaTipo2;
        Debug.Log("arana tipo2 orientacion");
    }



    private void Update()
    {
        if (Objetivo != null)
        {
            // orientar araña 2 hacia el objetivo
            // Calcular la dirección hacia el objetivo
            Vector3 direccionHaciaObjetivo = (Objetivo.position - rb.position).normalized;

            // Calcular la rotación necesaria hacia el objetivo
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionHaciaObjetivo);

            // Interpolar suavemente hacia la rotación deseada
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime));
        }
    }
}
