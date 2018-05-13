﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour {

	public TextAsset planetInfo;
	public string name;
	public string description;

	[Header("UI")]
	public GameObject planetPanel;
	public Text nameText;
	public Text descText;

	void Awake(){
		SetUIText();
	}

	public void Visit(){
		Debug.Log("Visiting " + name);
		OpenUI();
	}

	private void OpenUI(){
		planetPanel.SetActive(true);
	}

	private void SetUIText(){
		// Reads the info about the planet from the txt file
		string planetText = planetInfo.text;
		int seperator = planetText.IndexOf('\n');

		if(seperator > -1){
			name = planetText.Substring(0, seperator);
			description = planetText.Substring(seperator+1);
		}

		nameText.text = name;
		descText.text = description;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Visit();
		}
	}

}
