using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour {
	[HideInInspector]
	public PlanetInfo info;
	private PlanetUI ui;

	void Awake(){
		info.GetInfoFromFile();
	}

	public void Visit(){
		ui.OpenUI();
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Visit();
		}
	}

}
