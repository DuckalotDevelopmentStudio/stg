using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBalances : MonoBehaviour {
    
    public Player player;
    public PlayerMovement playerMovement;
    public Text moneyText;
    public Slider fuelSlider;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "" + player.money;
		fuelSlider.value = playerMovement.fuel;
	}
}
