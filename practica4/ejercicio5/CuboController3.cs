using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importar para trabajar con UI

public class CuboController3 : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del cubo
    private Rigidbody rb; // Referencia al Rigidbody
    public float distanciaDeteccion = 5f; // Distancia para detectar arañas
    public static event System.Action<Transform> OnCuboCercaAranaTipo1;
    public static event System.Action<Transform> OnCuboCercaAranaTipo2;
    public List<GameObject> aranas; // Lista de arañas en la escena
    private int puntuacion = 0;
    public Text puntuacionText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ActualizarPuntuacion();
    }

    void Update()
    {
        MoverCubo();

        foreach (GameObject arana in aranas)
        {
            // Verificar distancia entre el cubo y la araña
            float distancia = Vector3.Distance(transform.position, arana.transform.position);

            if (distancia <= distanciaDeteccion)
            {
                if (arana.CompareTag("tipo1"))
                {
                    // Notificar que el cubo está cerca de una araña tipo 1
                    OnCuboCercaAranaTipo1?.Invoke(arana.transform);
                }
                else if (arana.CompareTag("tipo2"))
                {
                    // Notificar que el cubo está cerca de una araña tipo 2
                    OnCuboCercaAranaTipo2?.Invoke(arana.transform);
                }
            }
        }
    }

    void MoverCubo()
    {
        // Movimiento del cubo con las teclas W-S (eje vertical) y A-D (eje horizontal)
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f; // Tecla W (arriba)
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f; // Tecla S (abajo)
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f; // Tecla A (izquierda)
        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f; // Tecla D (derecha)

        Vector3 direccion = new Vector3(movimientoHorizontal, 0, movimientoVertical); // Movimiento en los ejes X y Z
        rb.MovePosition(rb.position + direccion * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        HuevoController.OnAranaTipo1ColisionHuevo += OnAranaTipo1ColisionHuevo;
        HuevoController.OnAranaTipo2ColisionHuevo += OnAranaTipo2ColisionHuevo;
    }

    private void OnDisable()
    {
        HuevoController.OnAranaTipo1ColisionHuevo -= OnAranaTipo1ColisionHuevo;
        HuevoController.OnAranaTipo2ColisionHuevo -= OnAranaTipo2ColisionHuevo;
    }

    private void OnAranaTipo1ColisionHuevo(Transform arana)
    {
        //sumar 5 puntos
        puntuacion = puntuacion + 5;
        ActualizarPuntuacion();
    }

    private void OnAranaTipo2ColisionHuevo(Transform arana)
    {
        //sumar 10 puntos
        puntuacion = puntuacion + 10;
        ActualizarPuntuacion();
    }

    void ActualizarPuntuacion()
    {
        // Actualizar el texto de la puntuación
        if (puntuacionText != null)
        {
            if (puntuacion >= 100) {
                puntuacionText.text = "felicidades por los 100 puntos!";

            } else {
                puntuacionText.text = "Puntuación: " + puntuacion;
            }
            
        }
    }

}
