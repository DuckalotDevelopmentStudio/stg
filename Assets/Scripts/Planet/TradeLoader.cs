using System.Collections.Generic;
using UnityEngine;

public class TradeLoader : MonoBehaviour
{

    public TradeList tradeList = new TradeList();

    void Start()
    {
        LoadItem();
    }

    #region Functions
    void LoadItem()
    {
        TextAsset asset = Resources.Load("Trade") as TextAsset;
        if (asset != null)
        {
            tradeList = JsonUtility.FromJson<TradeList>(asset.text);

        }
    }
    public Trade GetTradeInfoByPlanetName(string name)
    {
        foreach (Trade tradeItem in tradeList.Trade)
        {
            if (tradeItem.name.Equals(name))
            {
                return tradeItem;
            }
        }
        return null;
    }
    #endregion
}
