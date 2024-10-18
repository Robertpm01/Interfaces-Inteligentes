using UnityEngine;

public class ejercicioNivel : MonoBehaviour
{
    public GameObject object1; // Arrastra tu primer objeto desde el inspector
    public GameObject object2; // Arrastra tu segundo objeto desde el inspector
    public GameObject object3; // Arrastra tu tercer objeto desde el inspector

    public Camera mainCamera; // Arrastra la cámara desde el inspector
    private int iterationCount = 0;
    private const int interval = 100; // Intervalo de iteraciones para cambiar posiciones y colores

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Si no se asignó una cámara, usa la cámara principal
        }
    }

    void Update()
    {
        iterationCount++;

        // Cada 100 iteraciones desplazamos los objetos
        if (iterationCount % interval == 0)
        {
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 newPosition = new Vector3(cameraPosition.x + 10f, 0f, cameraPosition.z + 10f); // A nivel del suelo (y = 0)

            // Asignamos las nuevas posiciones a los objetos
            object1.transform.position = newPosition;
            object2.transform.position = newPosition + new Vector3(5f, 0f, 0f); // Pequeño desplazamiento entre objetos
            object3.transform.position = newPosition + new Vector3(-5f, 0f, 5f);

            // Asignamos colores aleatorios a los objetos
            object1.GetComponent<Renderer>().material.color = GetRandomColor();
            object2.GetComponent<Renderer>().material.color = GetRandomColor();
            object3.GetComponent<Renderer>().material.color = GetRandomColor();
        }
    }

    // Función para generar un color aleatorio
    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}