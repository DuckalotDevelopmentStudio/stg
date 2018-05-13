using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField]
    int maxWeight;
    int currentWeight = 0;
    [SerializeField]
    List<Goods> inventory = new List<Goods>();

    public void AddItem(Goods itemToAdd)
    {
        if (itemToAdd.weight+currentWeight <= maxWeight) {
            inventory.Add(itemToAdd);
            currentWeight += itemToAdd.weight;
        } 
    }
    public void RemoveItem(Goods itemToRemove)
    {
        if (inventory.Contains(itemToRemove))
        {
            int index = inventory.IndexOf(itemToRemove);
            Goods item = inventory[index];
            inventory.Remove(item);
            currentWeight -= item.weight;
        }
            
    }
    public List<Goods> GetInventory()
    {
        return inventory;
    }
    
}
