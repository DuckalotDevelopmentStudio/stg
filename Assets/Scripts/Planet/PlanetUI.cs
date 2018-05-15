using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject planetPanel;
    [SerializeField]
    private Text planetNameText;
    [SerializeField]
    private Text planetDescText;

    void Awake()
    {
        Planet.OnVisit += OpenUI;
        DisableUI();
    }

    public void OpenUI(GameObject planetVisited)
    {
        Planet planet = planetVisited.GetComponent<Planet>();
        planetNameText.text = planet.GetPlanetInfo().GetPlanetName();
        planetDescText.text = planet.GetPlanetInfo().GetPlanetDescription();
        if (!planetPanel.activeSelf)
            planetPanel.SetActive(true);
    }
    
    public void DisableUI()
    {
        planetPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        Planet.OnVisit -= OpenUI;
    }

}
