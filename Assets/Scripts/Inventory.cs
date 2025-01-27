using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();  // List of items in the inventory

    // Function to add an item to the inventory (stacking if the item already exists)
    public void AddItem(Item newItem)
    {
        // Check if the item already exists in the inventory
        var existingItem = items.Find(item => item.itemName == newItem.itemName);

        if (existingItem != null)
        {
            // If item exists, stack the quantity
            existingItem.quantity += newItem.quantity;  // Increase the quantity in the inventory
            Debug.Log("Stacked " + newItem.quantity + " of " + existingItem.itemName);
        }
        else
        {
            // If item does not exist, add it as a new entry to the inventory
            items.Add(new InventoryItem(newItem.itemName, newItem.quantity));
            Debug.Log("Added new item: " + newItem.itemName);
        }
    }

    // Function to remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        var itemToRemove = items.Find(item => item.itemName == itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            Debug.Log("Item Removed: " + itemName);
        }
    }

    // Function to check if the player has a specific item
    public bool HasItem(string itemName)
    {
        var item = items.Find(i => i.itemName == itemName);
        return item != null;
    }
}