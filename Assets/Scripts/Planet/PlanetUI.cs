using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour {

	public Planet planet;

	[Header("UI")]
	[SerializeField]
	private GameObject planetPanel;
	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Text descText;

	void Awake(){
		planetPanel.SetActive(false);
	}

	public void OpenUI(){
		nameText.text = planet.info.name;
		descText.text = planet.info.desc;
		planetPanel.SetActive(true);
	}

}
