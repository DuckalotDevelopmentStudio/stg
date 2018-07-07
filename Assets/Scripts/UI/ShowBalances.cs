using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBalances : MonoBehaviour {
    
    [SerializeField]
	private Player player;
    [SerializeField]
	private PlayerMovement playerMovement;
    [SerializeField]
	private Text moneyText;
    [SerializeField]
	private Slider fuelSlider;

	void Start() {
		if(!player)
			player = GameObject.FindObjectOfType<Player>();
		if(!playerMovement)
			playerMovement = player.GetComponent<PlayerMovement>();
	}

	void LateUpdate () {
		moneyText.text = "" + player.money;
		// Gets the current percentage of fuel left to keep the values from 0-100
		fuelSlider.value = (playerMovement.fuel / playerMovement.maxFuel) * 100;
	}
}
