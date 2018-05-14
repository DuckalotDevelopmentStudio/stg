using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
	[SerializeField]
	private TextAsset planetInfo;

	public string name;
	public string desc;

	public void GetInfoFromFile(){
		string planetText = planetInfo.text;
		int seperator = planetText.IndexOf('\n');

		if(seperator > -1){
			name = planetText.Substring(0, seperator);
			desc = planetText.Substring(seperator+1);
		}
	}
}
