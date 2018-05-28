using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public PlayerInventory playerInventory;
    [SerializeField]
    private int maxWeight;
    [SerializeField]
    public float money;
    public string listOfItems;
    [SerializeField]
    private Text itemListText;

	// Use this for initialization
	void Start () {
        playerInventory = new PlayerInventory(maxWeight, money);
        TradeButton.OnBuy += UpdateList;
        TradeButton.OnSell += UpdateList;
	}
	
	void UpdateList(Item item)
    {
        listOfItems = "You Have:";
        foreach(Item playerItem in playerInventory.GetInventoryList())
        {
            listOfItems += "\n";
            listOfItems += playerItem.name;
        }
        itemListText.text = listOfItems;
    }
}
