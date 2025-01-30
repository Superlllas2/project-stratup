using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button settingsButton;
    public Button craftButton;
    public Button inventoryButton;
    public Button charButton;
    
    public GameObject startingCanvas;  // Reference to the starting UI canvas
    public GameObject mainCanvas;
    public GameObject inventoryScreen; // Inventory panel
    public GameObject craftingScreen;  // Crafting panel
    public GameObject characterScreen;
    public GameObject settingsScreen;
    public string sceneToLoad;         // The scene to load after the delay (in the build settings)

    void Start()
    {
        // Show the starting canvas initially
        startingCanvas.SetActive(true);
        mainCanvas.SetActive(false);

        // Start the scene transition after a delay
        Invoke("LoadGameUI", 1f);  // 2 seconds delay before loading the next scene
    }
    
    public void ShowMainMenu()
    {
        mainCanvas.SetActive(true);
        startingCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        // characterScreen?.SetActive(false);
        // settingsScreen.SetActive(false);
    }

    public void ShowInventory()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(true);
        craftingScreen.SetActive(false);
        // characterScreen?.SetActive(false);
        // settingsScreen.SetActive(false);
    }

    // Show the crafting screen and hide others
    public void ShowCrafting()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(true);
        // characterScreen?.SetActive(false);
        // settingsScreen.SetActive(false);
    }

    // Show the character customization screen and hide others
    public void ShowCharacterCustomization()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        // characterScreen?.SetActive(true);
        // settingsScreen.SetActive(false);
    }    
    
    // Show the character customization screen and hide others
    public void ShowSettingsScreen()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        // characterScreen?.SetActive(false);
        // settingsScreen.SetActive(true);
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
        ShowMainMenu();
    }
}