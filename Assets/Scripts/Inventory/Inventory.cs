using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    protected List<Item> inventory = new List<Item>();
    protected float currentMoneyAmount;

    public void AddMoney(int amount)
    {
        currentMoneyAmount += amount;
    }
    public void RemoveMoney(int amount)
    {
        currentMoneyAmount -= amount;
    }
    public float GetCurrentMoneyAmount()
    {
        return currentMoneyAmount;
    }

    public virtual void AddItem(Item itemToAdd)
    {
        inventory.Add(itemToAdd);
    }
    public virtual void RemoveItem(Item itemToRemove)
    {
        if (inventory.Contains(itemToRemove))
        {
            int index = inventory.IndexOf(itemToRemove);
            Item item = inventory[index];
            inventory.Remove(item);
        }
    }

}
public class PlayerInventory : Inventory {

    private int maxWeight;
    private int currentWeight;

    public PlayerInventory (int newMaxWeight, float moneyAmount)
    {
        maxWeight = newMaxWeight;
        currentMoneyAmount = moneyAmount;
    }
    

    public override void AddItem(Item itemToAdd)
    {
        if (itemToAdd.itemWeight + currentWeight <= maxWeight)
        {
            inventory.Add(itemToAdd);
            currentWeight += itemToAdd.itemWeight;
        }
    }
    public override void RemoveItem(Item itemToRemove)
    {
        if (inventory.Contains(itemToRemove))
        {
            int index = inventory.IndexOf(itemToRemove);
            Item item = inventory[index];
            inventory.Remove(item);
            currentWeight -= item.itemWeight;
        }

    }
    public List<Item> GetInventoryList()
    {
        return inventory;
    }
}
public class PlanetInventory : Inventory
{
    public PlanetInventory(float moneyAmount)
    {
        currentMoneyAmount = moneyAmount;
    }
}

