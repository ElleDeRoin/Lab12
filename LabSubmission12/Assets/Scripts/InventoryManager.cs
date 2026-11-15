using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public string searchName = "Axe";
    private List<InventoryItem> inventory = new List<InventoryItem>();

    public int searchId = 10; // random number to search for in binary search

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

        // for testing binary search
        searchId = found.ID;

        // Binary search - sort inventory by ID first, then search by ID
        Sort(inventory);
            // PrintInventory(); // print sorted inventory to check if sorting worked

        int searchedIndex = BinarySearch(inventory, searchId);
        if (searchedIndex != -1)
        {
            found = inventory[searchedIndex];
            Debug.Log($"Item '{found.Name}' with ID {searchId} found in inventory.");
        }
        else
        {
            Debug.Log($"Item with ID {searchId} not found in inventory.");
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

    // sorts inventory in ascending order by ID
    public void Sort(List<InventoryItem> items)
    {
        items.Sort((a, b) => a.ID.CompareTo(b.ID));
    }

    // Binary search by ID
    public int BinarySearch(List<InventoryItem> items, int ID)
    {

        int left = 0;
        int right = items.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (items[mid].ID == ID)
            {
                return mid;
            }
            else if (items[mid].ID < ID)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1; // Not found
    }
    
    // prints items to console to check if setup worked
    void PrintInventory() {
        foreach (InventoryItem item in inventory) {
            Debug.Log($"ID: {item.ID} | Name: {item.Name} | Value: {item.Value}");
        }
    }
}
