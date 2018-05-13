using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public TextAsset planetInfo;
	public string name;
	public string description;

	void Awake(){


		string planetText = planetInfo.text;
		int seperator = planetText.IndexOf('\n');

		if(seperator > -1){
			name = planetText.Substring(0, seperator);
			description = planetText.Substring(seperator+1);
		}
		
		Debug.Log(name);
		Debug.Log(description);
	}

	public void visit(){

	}

}
