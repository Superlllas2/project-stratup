using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button settingsButton;
    
    
    
    public Button craftButton;
    public Button craft;
    public Button leaveCraft;
    public Image craftFail;
    
    public Button inventoryButton;
    public Button inventoryBackButton;
    
    
    public Button charButton;
    
    
    public GameObject registrationCanvas;
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
        
        settingsButton.onClick.AddListener(ShowSettingsScreen);
        craftButton.onClick.AddListener(ShowCrafting);
        inventoryButton.onClick.AddListener(ShowInventory);
        charButton.onClick.AddListener(ShowCharacterCustomization);
        craft.onClick.AddListener(CraftButton);
        leaveCraft.onClick.AddListener(LeaveCraft);
        inventoryBackButton.onClick.AddListener(InventoryBackButton);
        
        

        // Start the scene transition after a delay
        Invoke("LoadGameUI", 1f);  // 2 seconds delay before loading the next scene
    }
    
    public void ShowMainMenu()
    {
        mainCanvas.SetActive(true);
        startingCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        characterScreen?.SetActive(false);
        settingsScreen.SetActive(false);
    }
    
    public void ShowInventory()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(true);
        craftingScreen.SetActive(false);
        characterScreen?.SetActive(false);
        settingsScreen.SetActive(false);
    }

    // Show the crafting screen and hide others
    public void ShowCrafting()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(true);
        characterScreen?.SetActive(false);
        settingsScreen.SetActive(false);
    }

    // Show the character customization screen and hide others
    public void ShowCharacterCustomization()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        characterScreen?.SetActive(true);
        settingsScreen.SetActive(false);
    }    
    
    // Show the character customization screen and hide others
    public void ShowSettingsScreen()
    {
        mainCanvas.SetActive(false);
        inventoryScreen.SetActive(false);
        craftingScreen.SetActive(false);
        characterScreen?.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void CraftButton()
    {
        craftFail.gameObject.SetActive(true);
    }

    public void InventoryBackButton()
    {
        inventoryBackButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

    public void LeaveCraft()
    {
        craftingScreen.SetActive(false);
        mainCanvas.SetActive(true);
    }
    
    // Function to load the next scene
    private void LoadNextScene()
    {
        startingCanvas.SetActive(false);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void LoadGameUI()
    {
        ShowMainMenu();
    }
}