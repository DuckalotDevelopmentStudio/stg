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
        nameText.text = planet.GetPlanetInfo().GetName();
        descText.text = planet.GetPlanetInfo().GetDescription();
        planetPanel.SetActive(false);
        planet.OnVisit += OpenUI;
    }

	public void OpenUI(){
		planetPanel.SetActive(true);
	}

    void OnDisable()
    {
        planet.OnVisit -= OpenUI; 
    }

}
