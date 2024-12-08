using UnityEngine;

public class HuevoController : MonoBehaviour
{
    private Rigidbody rb; // Referencia al Rigidbody
    public static event System.Action<Transform> OnAranaTipo1ColisionHuevo;
    public static event System.Action<Transform> OnAranaTipo2ColisionHuevo;

    // Límites de las posiciones permitidas
    private float xMin = -14f;
    private float xMax = 14f;
    private float zMin = -14f;
    private float zMax = 14f;
    private float y = 1.5f; // Altura fija

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tipo1"))
        {
            OnAranaTipo1ColisionHuevo?.Invoke(collision.transform);
            // Mover a una posición aleatoria dentro del rango permitido
            rb.position = ObtenerPosicionAleatoria();
        }
        else if (collision.gameObject.CompareTag("tipo2"))
        {
            OnAranaTipo2ColisionHuevo?.Invoke(collision.transform);
            // Mover a una posición aleatoria dentro del rango permitido
            rb.position = ObtenerPosicionAleatoria();
        }
    }

    private Vector3 ObtenerPosicionAleatoria()
    {
        // Calcular una posición aleatoria dentro de los límites
        float x = Random.Range(xMin, xMax);
        float z = Random.Range(zMin, zMax);

        return new Vector3(x, y, z);
    }
}
