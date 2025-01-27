using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

public class MapDisplay : MonoBehaviour
{
    private string apiKey;
    public string mapCenter = "Enschede"; // The location you want to center the map on
    public int zoomLevel = 15; // Zoom level for the map
    public int mapSize = 2048; // Size of the map image (2048x2048 for higher quality)
    // public int maxSize = 6400; // Max size for high-resolution maps (Google's limit)

    private Renderer mapRenderer;

    private string customMapStyle = "[{\"featureType\":\"administrative\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"administrative\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"administrative.international_border\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"administrative.international_border\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"administrative.reservation\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"land\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"land\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency.fire\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency.hospital\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency.hospital\",\"elementType\":\"geometry.fill\",\"stylers\":[{\"color\":\"#250e0e\"}]},{\"featureType\":\"poi.emergency.hospital\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency.pharmacy\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.emergency.police\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.amusement\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.arts\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.casino\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.cinema\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.historic\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.museum\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.entertainment.tourist\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.food_and_drink\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.food_and_drink.bar\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.food_and_drink.cafe\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.food_and_drink.restaurant\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.food_and_drink.winery\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.iconic_icon_poi\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.lodging\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.other_poi\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.outdoor_area_or_point\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.retail\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.services\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"poi.transit_poi\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"on\"}]},{\"featureType\":\"transportation\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation.all_buildings\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation.all_buildings\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation.all_buildings.commercial_buildings\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation.all_buildings.commercial_buildings\",\"elementType\":\"geometry.fill\",\"stylers\":[{\"color\":\"#ffffff\"}]},{\"featureType\":\"transportation.all_buildings.commercial_buildings\",\"elementType\":\"geometry.stroke\",\"stylers\":[{\"color\":\"#ffffff\"},{\"weight\":0}]},{\"featureType\":\"transportation.built_up_area\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"on\"}]},{\"featureType\":\"transportation.corridor\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"off\"}]},{\"featureType\":\"transportation.road\",\"elementType\":\"geometry\",\"stylers\":[{\"visibility\":\"on\"}]},{\"featureType\":\"transportation.road\",\"elementType\":\"labels\",\"stylers\":[{\"visibility\":\"off\"}]}]";

    void Start()
    {
        // Load API key from .env file
        apiKey = LoadApiKeyFromEnv();

        if (string.IsNullOrEmpty(apiKey))
        {
            Debug.LogError($"API key is missing or invalid: {apiKey}");
            return;
        }

        // TODO: return this when building for phone
        // if (GPSManager.Instance)
        if (false)
        {
            float latitude = GPSManager.Instance.Latitude;
            float longitude = GPSManager.Instance.Longitude;

            // Request map with player's location
            string location = $"{latitude},{longitude}";
            StartCoroutine(DownloadMap(location));
        }
        else
        {
            Debug.LogError("GPSManager instance is not available. Location is set to Enschede center");
            StartCoroutine(DownloadMap(mapCenter));
        }

        mapRenderer = GetComponent<Renderer>();
    }

    // Load the API key from the .env file
    private string LoadApiKeyFromEnv()
    {
        var envFilePath = Path.Combine(Application.dataPath, "../.env");
        if (File.Exists(envFilePath))
        {
            string[] lines = File.ReadAllLines(envFilePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("GOOGLE_MAPS_API_KEY"))
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim();
                    }
                }
            }
        }

        return string.Empty;
    }

    // Download the map image from Google Static Maps API
    private IEnumerator DownloadMap(string center)
    {
        var url = $"https://maps.googleapis.com/maps/api/staticmap?center={center}&zoom={zoomLevel}&size={mapSize}x{mapSize}&maptype=roadmap&style={UnityWebRequest.EscapeURL(customMapStyle)}&key={apiKey}&map_id=fc16fcc5b49a1b83";

        using (WWW www = new WWW(url))
        {
            yield return www;

            if (www.error == null)
            {
                Texture2D texture = new Texture2D(1, 1);
                www.LoadImageIntoTexture(texture);
                mapRenderer.material.mainTexture = texture;
            }
            else
            {
                Debug.LogError("Error downloading map image: " + www.error);
            }
        }
    }
}