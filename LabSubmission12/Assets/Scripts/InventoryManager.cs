using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        GenerateInventory();
        PrintInventory();
    }

    void GenerateInventory() {
        string[] names = { "Sword", "Axe", "Hammer", "Mace", "Polearm", "Shield", "Bow", "Arrow"};

        HashSet<int> usedIDs = new HashSet<int>();

        foreach (string n in names) {
            int id;
            do { id = Random.Range(1,1000); } while (!usedIDs.Add(id));

            inventory.Add(new InventoryItem(id, n, Random.Range(5,300)));
        }
    }
    
    // prints items to console to check if setup worked
    void PrintInventory() {
        foreach (InventoryItem item in inventory) {
            Debug.Log($"ID: {item.ID} | Name: {item.Name} | Value: {item.Value}");
        }
    }
}
