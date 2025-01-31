using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem
{
    public string itemName; // Name of the item
    public int quantity;    // Quantity of this item in the inventory

    // Constructor to initialize a new inventory item
    public InventoryItem(string name, int qty)
    {
        itemName = name;
        quantity = qty;
    }
}

public class Item : MonoBehaviour
{
    public bool isCollected = false;  // Track if the item is collected
    public float pickupRadius = 2f;   // Radius within which the player can interact with the item
    public int quantity = 1;  
    public bool isCollectible = true;
    public string itemName;
    public bool isVisible = false;
    public String sceneToLoad;

    private Transform playerTransform; // Reference to the player's transform
    public GameObject pickupUI;        // The UI panel that will show the "Pick Up" button
    public Button pickupButton;        // The "Pick Up" button
    private Inventory inventory;        // Reference to the player’s inventory
    private Renderer itemRenderer;

    void Start()
    {
        // Find the player object and get its transform
        playerTransform = GameObject.FindWithTag("Player").transform;
        
        inventory = playerTransform.GetComponent<Inventory>(); 
        
        // Initially hide the "Pick Up" UI
        pickupUI.SetActive(false);
        
        itemRenderer = GetComponent<Renderer>();
        
        if (itemRenderer)
        {
            itemRenderer.enabled = false;  // Hide the item at the start
        }

        // Set up the button to call PickUpItem when clicked
        pickupButton.onClick.AddListener(PickUpItem);
    }

    void Update()
    {
        // Check if the player is close enough to the item
        if (!isCollected && Vector3.Distance(transform.position, playerTransform.position) <= pickupRadius)
        {
            if (itemRenderer)
            {
                itemRenderer.enabled = true;  // Make the item visible
            }
            
            pickupUI.SetActive(true);  // Show the "Pick Up" UI
            //
            // if (Input.GetMouseButtonDown(0))
            // {
            //     if (IsClickOnItem())
            //     {
            //         pickupUI.SetActive(true);  // Show the "Pick Up" UI
            //     }
            // }
        }
        else
        {
            // Hide the "Pick Up" UI when the player moves away from the item
            pickupUI.SetActive(false);
            
            // Hide the item when the player is too far
            if (itemRenderer)
            {
                itemRenderer.enabled = false;  // Hide the item
            }
        }
    }

    // Function to pick up the item
    void PickUpItem()
    {
        // // Add the item to the inventory (stacks if already present)
        // inventory?.AddItem(this);
        //
        // // Mark the item as collected
        // isCollected = true;
        //
        // // Hide the UI and destroy the item in the scene
        // pickupUI.SetActive(false);
        // if (itemRenderer)
        // {
        //     itemRenderer.enabled = false;  // Hide the item when picked up
        // }
        // Destroy(gameObject);  // Remove the item from the world after pickup
        SceneManager.LoadScene(sceneToLoad);
    }
 
    private static bool IsClickOnItem()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Create a ray from the camera to the mouse position

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit an object with the "Item" tag
            if (hit.collider.CompareTag("Item"))
            {
                // If it's the item, return true
                return true;
            }
        }

        return false;  // No hit or not an item
    }
}
