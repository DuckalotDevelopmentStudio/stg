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
        if (((itemToAdd.size)+currentWeight) <= maxWeight) {
            inventory.Add(itemToAdd);
            currentWeight += itemToAdd.size;
        } 
    }
    public void RemoveItem(Goods itemToRemove)
    {
            foreach (Goods item in inventory)
            {
                if (item == itemToRemove)
                {
                    inventory.Remove(item);
                    currentWeight -= item.size;
                }
            }
    }
    public List<Goods> GetInventory()
    {
        return inventory;
    }

}
