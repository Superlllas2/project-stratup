using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startingCanvas;  // Reference to the starting UI canvas
    public GameObject mainCanvas;
    public string sceneToLoad;         // The scene to load after the delay (in the build settings)

    void Start()
    {
        // Show the starting canvas initially
        startingCanvas.SetActive(true);
        mainCanvas.SetActive(false);

        // Start the scene transition after a delay
        Invoke("LoadGameUI", 3f);  // 2 seconds delay before loading the next scene
    }

    // Function to load the next scene
    private void LoadNextScene()
    {
        // Optionally, you can hide or disable the starting canvas before loading the scene
        startingCanvas.SetActive(false);

        // Load the next scene (make sure the scene is added to the build settings)
        SceneManager.LoadScene(sceneToLoad);
    }

    private void LoadGameUI()
    {
        startingCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}