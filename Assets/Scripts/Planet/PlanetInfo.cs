using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo {
	private TextAsset planetInfo;
	string name;
	string desc;
    PlanetInventory inventory;

	public void GetInfoFromFile(){
		string planetText = planetInfo.text;
		int seperator = planetText.IndexOf('\n');

		if(seperator > -1){
			name = planetText.Substring(0, seperator);
			desc = planetText.Substring(seperator+1);
		}
	}

    public PlanetInfo(TextAsset newPlanetInfo, float money)
    {
        planetInfo = newPlanetInfo;
        GetInfoFromFile();
        inventory = new PlanetInventory(money);
    }
    public string GetName()
    {
        return name;
    }
    public string GetDescription()
    {
        return desc;
    }
    public PlanetInventory GetInventory()
    {
        return inventory;
    }
}
