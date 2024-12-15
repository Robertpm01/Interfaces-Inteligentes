using UnityEngine;
using UnityEngine.UI;

public class SamuraiController : MonoBehaviour
{
    // UI Elements
    public Text angularSpeedText;
    public Text accelerationText;
    public Text altitudeGravityText;
    public Text locationText;

    // Samurai Movement Parameters
    public float accelerationMultiplier = 5f;
    public float maxDistance = 15f; // Maximum distance the Samurai can move
    public Vector2 latitudeRange = new Vector2(-90, 90);
    public Vector2 longitudeRange = new Vector2(-180, 180);

    private Vector3 initialPosition;
    private Vector3 currentVelocity;
    private bool withinRange = true;

    void Start()
    { 
        // Enable gyroscope and location services
        Input.gyro.enabled = true;
        Input.location.Start();
        Input.compass.enabled = true;

        // Record the initial position of the Samurai
        initialPosition = transform.position;

        // Ensure the Samurai starts above the plane
        if (initialPosition.y < 0.5f)
        {
            initialPosition.y = 0.5f;
            transform.position = initialPosition;
        }
    }

    void Update()
    {
        UpdateSensorUI();
        SamuraiMovement();
    }

    private void UpdateSensorUI()
    {
        // Display Angular Speed
        Vector3 angularSpeed = Input.gyro.rotationRate;
        if (angularSpeedText != null)
            angularSpeedText.text = $"Vel. Angular: {angularSpeed}";

        // Display Acceleration
        Vector3 acceleration = Input.gyro.userAcceleration;
        if (accelerationText != null)
            accelerationText.text = $"Aceleración: {acceleration}";

        // Display Altitude and Gravity
        float altitude = Input.location.status == LocationServiceStatus.Running ? Input.location.lastData.altitude : 0f;
        float gravity = Physics.gravity.y;
        if (altitudeGravityText != null)
            altitudeGravityText.text = $"Altitud: {altitude}, Gravedad: {gravity}";

        // Display Location
        if (locationText != null)
        {
            if (Input.location.status == LocationServiceStatus.Running)
            {
                float latitude = Input.location.lastData.latitude;
                float longitude = Input.location.lastData.longitude;
                locationText.text = $"Lat: {latitude}, Lon: {longitude}";

                withinRange = latitude >= latitudeRange.x && latitude <= latitudeRange.y &&
                              longitude >= longitudeRange.x && longitude <= longitudeRange.y;
            }
            else
            {
                locationText.text = "Localización: No disponible";
                withinRange = false;
            }
        }
    }

    private void SamuraiMovement()
    {
        if (!withinRange)
        {
            currentVelocity = Vector3.zero; // Stop movement if out of range
            return;
        }

        // Calculate movement based on acceleration
        Vector3 acceleration = Input.acceleration;
        acceleration.z = -acceleration.z; // Invert Z-axis for forward/backward movement

        currentVelocity = acceleration * accelerationMultiplier;

        // Limit movement to the maximum distance
        Vector3 nextPosition = transform.position + currentVelocity * Time.deltaTime;
        float distanceFromStart = Vector3.Distance(initialPosition, nextPosition);

        if (distanceFromStart <= maxDistance)
        {
            nextPosition.y = Mathf.Max(nextPosition.y, 0.5f); // Prevent falling below the plane
            transform.position = nextPosition;
        }
        else
        {
            currentVelocity = Vector3.zero; // Stop moving if the maximum distance is exceeded
        }

        // Orient the Samurai to point northward
        if (Input.compass.enabled)
        {
            float heading = Input.compass.trueHeading;
            transform.rotation = Quaternion.Euler(0, heading, 0);
        }
    }

    private void OnDisable()
    {
        Input.location.Stop();
    }
}
