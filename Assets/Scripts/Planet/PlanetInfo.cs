using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo
{
    //private TextAsset planetInfo;
    private string planetName;
    private string planetDescription;
    PlanetInventory planetInventory;
    public string buy;
    public string sell;

    public PlanetInfo(TextAsset planetInfoTextFile, float moneyAmount)
    {
        GetInfoFromFile(planetInfoTextFile);
        planetInventory = new PlanetInventory(moneyAmount);
    }

    public void GetInfoFromFile(TextAsset planetInfoTextFile)
    {
        string planetText = planetInfoTextFile.text;
        int seperator = planetText.IndexOf('\n');

        if (seperator > -1)
        {
            planetName = planetText.Substring(0, seperator);
            planetDescription = planetText.Substring(seperator + 1);
        }
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
}
