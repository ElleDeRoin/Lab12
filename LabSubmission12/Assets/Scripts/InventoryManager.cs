using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public string searchName = "Axe";
    private List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        GenerateInventory();
        // PrintInventory();

        InventoryItem found = LinearSearchByName(searchName);

        if(found != null) {
            Debug.Log($"Found '{found.Name}' (ID: {found.ID}, Value: {found.Value})");
        }
        else {
            Debug.Log($"'{searchName}' not found in inventory");
        }
    }

    void GenerateInventory() {
        string[] names = { "Sword", "Axe", "Hammer", "Mace", "Polearm", "Shield", "Bow", "Arrow"};

        HashSet<int> usedIDs = new HashSet<int>();

        foreach (string n in names) {
            int id;
            do { id = UnityEngine.Random.Range(1,1000); } while (!usedIDs.Add(id));

            inventory.Add(new InventoryItem(id, n, Random.Range(5,300)));
        }
    }

    public InventoryItem LinearSearchByName(string itemName) {
        for (int i = 0; i < inventory.Count; i++) {
            if (string.Equals(inventory[i].Name, itemName, System.StringComparison.OrdinalIgnoreCase)) {
                return inventory[i];
            }
        }
        return null;
    }
    
    // prints items to console to check if setup worked
    void PrintInventory() {
        foreach (InventoryItem item in inventory) {
            Debug.Log($"ID: {item.ID} | Name: {item.Name} | Value: {item.Value}");
        }
    }
}
