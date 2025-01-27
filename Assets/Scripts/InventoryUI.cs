using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;  // Inventory UI panel
    public Transform itemListParent;   // Parent container to hold item buttons
    public GameObject itemButtonPrefab; // Prefab for item buttons
    public Inventory inventory;

    void Start()
    {
        inventoryPanel.SetActive(false); // Hide inventory at start
    }

    // Function to show the inventory UI
    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
        UpdateInventoryUI();
    }

    // Update the inventory UI by adding buttons for each item
    private void UpdateInventoryUI()
    {
        // Clear previous UI elements
        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        // Add buttons for each item in the inventory
        foreach (Item item in inventory.items)
        {
            GameObject itemButton = Instantiate(itemButtonPrefab, itemListParent);
            itemButton.GetComponentInChildren<Text>().text = $"{item.itemName} x{item.quantity}";  // Display item name and quantity
            itemButton.GetComponent<Button>().onClick.AddListener(() => UseItem(item)); // Add functionality to use the item
        }
    }

    // Function to use an item from the inventory
    private void UseItem(Item item)
    {
        Debug.Log($"Used: {item.itemName}");
        // Implement the item usage functionality here (e.g., healing the player)
        inventory.RemoveItem(item);  // Optionally remove the item after use
        UpdateInventoryUI(); // Update UI after usage
    }
}