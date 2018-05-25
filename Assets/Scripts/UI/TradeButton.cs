using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeButton : MonoBehaviour {

    private CurrentPlanet currentPlanet;
    private PlanetInfo planet;
    private PlayerInventory playerInventory;
    private ItemStats itemStats;
    public delegate void TradeItem (Item itemTraded);
    public static event TradeItem OnBuy;
    public static event TradeItem OnSell;
    // Use this for initialization
    void Start () {
        currentPlanet = GameObject.Find("Planets").GetComponent<CurrentPlanet>();
        itemStats = GameObject.Find("Planets").GetComponent<ItemStats>();
        playerInventory = GameObject.Find("Player").GetComponent<Player>().playerInventory;
	}

    public void OnButtonClick()
    {
        if(transform.GetChild(0).GetComponent<Text>().text.Equals("Buy"))
        {
            Buy();
        } else
        {
            Sell();
        }
    }
	
	void Buy()
    {
        string itemName = transform.parent.GetChild(1).GetComponent<Text>().text;
        Item item = itemStats.GetGoodsByName(itemName);
        Debug.Log(item);
        planet = currentPlanet.GetCurrentPlanet();
        playerInventory.AddItem(item);
        playerInventory.RemoveMoney(item.price);
        if(OnBuy != null)
        {
            OnBuy(item);
        }
    }

    void Sell()
    {
        string itemName = transform.parent.GetChild(1).GetComponent<Text>().text;
        Item item = itemStats.GetGoodsByName(itemName);
        planet = currentPlanet.GetCurrentPlanet();
        playerInventory.RemoveItem(item);
        playerInventory.AddMoney(item.price);
        if (OnSell != null)
        {
            OnSell(item);
        }

    }
}
