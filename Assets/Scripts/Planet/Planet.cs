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
    [SerializeField]
    private GameObject spaceship;

    private PlanetInfo planetInfo;
    [SerializeField]
    private PlanetUI planetUI;

    public float visitDistance = 3f;

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

    private void Update()
    {
        //Debug.Log(Vector3.Distance(GetComponent<Transform>().position, spaceship.transform.position));
        if(Vector3.Distance(gameObject.transform.position, spaceship.transform.position) < visitDistance)
        {
            planetUI.OpenVisitUI(gameObject);
            Debug.Log("Player is near: " + planetInfo.GetPlanetName());
        }
        else
        {
            planetUI.CloseVisitUI(gameObject);
        }
    }

    public void Visit()
    {
        if (OnVisit != null)
        {
            OnVisit(gameObject);
        }
        else
        {
            Debug.Log("Onvisit == null");
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
