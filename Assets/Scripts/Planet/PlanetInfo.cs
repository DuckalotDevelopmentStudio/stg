using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlanetInfo
{
    //private TextAsset planetInfo;
    private string planetName;
    private string planetDescription;
    PlanetInventory planetInventory;
    private string buy;
    private string sell;

    public PlanetInfo(TextAsset planetInfoTextFile, float moneyAmount)
    {
        GetInfoFromFile(planetInfoTextFile);
        planetInventory = new PlanetInventory(moneyAmount);
    }

    public void GetInfoFromFile(TextAsset planetInfoTextFile)
    {
        string[] lines = File.ReadAllLines(UnityEditor.AssetDatabase.GetAssetPath(planetInfoTextFile));
        planetName = lines[0];
        planetDescription = lines[1];
        buy = lines[2];
        sell = lines[3];
    }
    public string GetPlanetName()
    {
        return planetName;
    }
    public string GetPlanetDescription()
    {
        return planetDescription;
    }
    public PlanetInventory GetPlanetInventory()
    {
        return planetInventory;
    }
    public string GetBuy()
    {
        return buy;
    }
    public string GetSell()
    {
        return sell;
    }
}
