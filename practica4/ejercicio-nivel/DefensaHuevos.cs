using UnityEngine;
using System.Collections.Generic;

public class DefensaHuevos : MonoBehaviour
{
    public Transform jugador; // Asigna el jugador en el Inspector
    public float distanciaDeteccion = 10f; // Distancia a la que las arañas detectan al jugador cerca del huevo
    public List<Transform> aranasDefensoras; // Lista de arañas que defenderán este huevo
    public Transform puntoDeDescanso; // Punto de descanso asignado en la escena
    public float velocidadAranas = 5f; // Velocidad de movimiento de las arañas
    public float velocidadHuevos = 3f; // Velocidad de alejamiento de los huevos

    // Evento que notifica cuando el jugador se acerca a un huevo
    public static event System.Action<Transform> OnJugadorCercaHuevo;

    private Rigidbody rbHuevo; // Referencia al Rigidbody del huevo

    void Start()
    {
        rbHuevo = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar distancia entre el jugador y el huevo
        if (Vector3.Distance(transform.position, jugador.position) <= distanciaDeteccion)
        {
            // Activar el evento para notificar a otros huevos
            OnJugadorCercaHuevo?.Invoke(transform);

            // Las arañas de este huevo se mueven hacia el huevo
            foreach (Transform arana in aranasDefensoras)
            {
                MoverAranaHacia(arana, transform.position);
            }
        }
        else
        {
            // Las arañas de este huevo se mueven al punto de descanso
            foreach (Transform arana in aranasDefensoras)
            {
                MoverAranaHacia(arana, puntoDeDescanso.position);
            }
        }
    }

    private void MoverAranaHacia(Transform arana, Vector3 destino)
    {
        Vector3 direccion = (destino - arana.position).normalized;
        arana.position += direccion * velocidadAranas * Time.deltaTime;
    }

    private void OnEnable()
    {
        // Suscribirse al evento para alejarse cuando otro huevo detecte al jugador
        OnJugadorCercaHuevo += AlejarseDelJugador;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento
        OnJugadorCercaHuevo -= AlejarseDelJugador;
    }

    private void AlejarseDelJugador(Transform huevoQueDetecta)
    {
        // Si este huevo es el que detectó al jugador, no debe alejarse
        if (huevoQueDetecta == transform)
            return;

        // Calcular la dirección opuesta al jugador para alejarse
        Vector3 direccionAlejamiento = (transform.position - jugador.position).normalized;
        rbHuevo.MovePosition(transform.position + direccionAlejamiento * velocidadHuevos * Time.deltaTime);
    }
}
