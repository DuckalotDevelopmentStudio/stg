using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{

    public delegate void VisitPlanet(GameObject planetToVisit);
    public static event VisitPlanet OnVisit;
    [SerializeField]
    private TradeLoader TradeLoader;
    [SerializeField]
    private ItemStats ItemStats;
    [SerializeField]
    private string planetInfoFilePath = null;

    private PlanetInfo planetInfo;
    private PlanetUI planetUI;

    void Awake()
    {
        SetPlanetInfo(planetInfoFilePath);
    }

    void OnMouseOver()

    {
        if (Input.GetMouseButtonDown(0))
        {
            Visit();
        }
    }

    public void Visit()
    {
        if (OnVisit != null)
        {
            OnVisit(gameObject);
        }
    }

    void SetPlanetInfo(string path)
    {
        if (path != null)
        {
            TextAsset planetInfoTextFile = Resources.Load(path) as TextAsset;
            planetInfo = new PlanetInfo(planetInfoTextFile, 10f);
        }
        Debug.Log("Hell");
        foreach (Trade tradeItem in TradeLoader.tradeList.Trade)
        {
            if(tradeItem.name == planetInfo.GetPlanetName())
            {
                planetInfo.buy = tradeItem.buy;
                planetInfo.sell = tradeItem.sell;
                Debug.Log(planetInfo.buy);
                Debug.Log(planetInfo.sell);
            }
            Debug.Log(tradeItem.name);
        }
    }
    public PlanetInfo GetPlanetInfo()
    {
        return planetInfo;
    }
}
