using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour {
	[SerializeField]
	private TextAsset planetInfo;
	public string planetName;
	public string planetDescription;

	[Header("UI")]
	[SerializeField]
	private GameObject planetPanel;
	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Text descText;

	void Awake(){
		SetUIText();
		planetPanel.SetActive(false);
	}

	public void Visit(){
		Debug.Log("Visiting " + planetName);
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
			planetName = planetText.Substring(0, seperator);
			planetDescription = planetText.Substring(seperator+1);
		}

		nameText.text = planetName;
		descText.text = planetDescription;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Visit();
		}
	}

}
