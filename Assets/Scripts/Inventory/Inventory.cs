using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField]
    int maxWeight;
    int currentWeight = 0;
    [SerializeField]
    List<Item> inventory = new List<Item>();

    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.weight+currentWeight <= maxWeight) {
            inventory.Add(itemToAdd);
            currentWeight += itemToAdd.weight;
        } 
    }
    public void RemoveItem(Item itemToRemove)
    {
        if (inventory.Contains(itemToRemove))
        {
            int index = inventory.IndexOf(itemToRemove);
            Item item = inventory[index];
            inventory.Remove(item);
            currentWeight -= item.weight;
        }
            
    }
    public List<Item> GetInventory()
    {
        return inventory;
    }
    
}
