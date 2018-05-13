using System.Collections.Generic;
using UnityEngine;

public class GoodsStats : MonoBehaviour {
    
    public static GoodsList goodsList = new GoodsList();

	void Awake () {
        LoadGoods();
	}

    #region Functions
    void LoadGoods()
    {
        TextAsset asset = Resources.Load("Goods") as TextAsset;
        if (asset != null)
        {
            goodsList = JsonUtility.FromJson<GoodsList>(asset.text);
            
        }
    }
    public static Goods GetGoodsByName(string name)
    {
        foreach(Goods goods in goodsList.Goods)
        {
            if(goods.name == name)
            {
                return goods;
            }
        }
        return null;
    } 
    #endregion
}
