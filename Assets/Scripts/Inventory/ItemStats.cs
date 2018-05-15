using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour
{

    public ItemsList itemList = new ItemsList();

    void Awake()
    {
        LoadItem();
    }

    #region Functions
    void LoadItem()
    {
        TextAsset asset = Resources.Load("Item") as TextAsset;
        if (asset != null)
        {
            itemList = JsonUtility.FromJson<ItemsList>(asset.text);

        }
    }
    public Item GetGoodsByName(string name)
    {
        foreach (Item goods in itemList.Item)
        {
            if (goods.itemName.Equals(name))
            {
                return goods;
            }
        }
        return null;
    }
    public List<Item> GetGoodsByName(string[] names)
    {
        List<Item> listOfGoods = new List<Item>();

        foreach (string name in names)
        {
            foreach (Item goods in itemList.Item)
            {
                if (goods.itemName.Equals(name))
                {
                    listOfGoods.Add(goods);
                }
            }
        }

        if(listOfGoods != null)
            return listOfGoods;
        
        return null;
    }
    #endregion
}
