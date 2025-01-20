using UnityEngine;
using UnityEngine.UI; // For Unity UI
using TMPro; // For TextMeshPro
using System.Collections;

public class GPSManager : MonoBehaviour
{
    // References to TextMeshPro UI objects
    public TMP_Text latitudeText;
    public TMP_Text longitudeText;
    public TMP_Text altitudeText;
    public TMP_Text accuracyText;

    IEnumerator Start()
    {
        // Check if the device supports location services
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services are not enabled by the user.");
            UpdateUIText("Location services are not enabled.", null, null, null);
            yield break;
        }

        // Start the location service
        Input.location.Start(desiredAccuracyInMeters: 1, updateDistanceInMeters: 1f);

        // Wait until the service initializes
        var maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            UpdateUIText("Initializing location...", null, null, null);
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service failed to start
        if (maxWait <= 0 || Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Failed to initialize location services.");
            UpdateUIText("Failed to initialize location.", null, null, null);
            yield break;
        }

        // Successfully started location service
        Debug.Log("Location service started!");
        UpdateUIText("Location service started!", null, null, null);

        // Continuously update GPS data in the UI
        while (true)
        {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;
            float altitude = Input.location.lastData.altitude;
            float accuracy = Input.location.lastData.horizontalAccuracy;

            // Update the TextMeshPro UI
            UpdateUIText(latitude.ToString("F6"), longitude.ToString("F6"), altitude.ToString("F2"), accuracy.ToString("F2"));

            // Debug logs (optional)
            Debug.Log($"Latitude: {latitude}, Longitude: {longitude}, Altitude: {altitude}, Accuracy: {accuracy}");

            yield return new WaitForSeconds(1); // Update every second
        }
    }

    private void OnDisable()
    {
        // Stop the location service when the script is disabled
        if (Input.location.isEnabledByUser)
        {
            Input.location.Stop();
        }
    }

    // Method to update the TextMeshPro UI
    private void UpdateUIText(string latitude, string longitude, string altitude, string accuracy)
    {
        if (latitudeText != null) latitudeText.text = "Latitude: " + (latitude ?? "N/A");
        if (longitudeText != null) longitudeText.text = "Longitude: " + (longitude ?? "N/A");
        if (altitudeText != null) altitudeText.text = "Altitude: " + (altitude ?? "N/A");
        if (accuracyText != null) accuracyText.text = "Accuracy: " + (accuracy ?? "N/A");
    }
}
