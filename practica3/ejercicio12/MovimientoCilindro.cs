using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCilindro : MonoBehaviour
{
    public Transform goal; // Asigna la esfera como el objetivo
    public float speed = 5f;
    public float rotSpeed = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoverCilindro();
    }

    void MoverCilindro()
    {
        // Dirección hacia la esfera (goal)
        Vector3 direction = (goal.position - transform.position).normalized;

        // Mantener la rotación solo en el plano X-Z (ignorar Y)
        Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);

        // Rotar gradualmente hacia la esfera
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        // Aplicar fuerza para mover el cilindro hacia la esfera
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
}
