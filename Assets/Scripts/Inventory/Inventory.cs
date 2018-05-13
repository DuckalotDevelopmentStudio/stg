using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    protected List<Item> inventory = new List<Item>();
    protected float money;

    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
    public float GetMoney()
    {
        return money;
    }
    
}
public class PlayerInventory : Inventory {

    int maxWeight;
    int currentWeight;

    public PlayerInventory (int newMaxWeight, float newMoney)
    {
        maxWeight = newMaxWeight;
        money = newMoney;
    }
    

    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.weight + currentWeight <= maxWeight)
        {
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
public class PlanetInventory : Inventory
{
    public PlanetInventory(float newMoney)
    {
        money = newMoney;
    }
}

