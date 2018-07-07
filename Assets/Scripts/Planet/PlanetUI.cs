using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{
    [Header("Planet UI")]
    [SerializeField]
    private Canvas playerCanvas;
    [SerializeField]
    private GameObject planetPanel;
    [SerializeField]
    private Text planetNameText;
    [SerializeField]
    private Text planetDescText;
    [SerializeField]
    private Text playerBuyText;
    [SerializeField]
    private Text planetSellText;
    private GameObject currentPlanet;

    [Header("Visiting Menu")]
    [SerializeField]
    private GameObject visitingPanel;
    [SerializeField]
    private Text visitingPlanetNameText;
    [SerializeField]
    private Button visitButton;


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
        currentPlanet = planetVisited;
        SetupTradeButtons();
        if (!planetPanel.activeSelf)
            planetPanel.SetActive(true);

        playerCanvas.gameObject.SetActive(false);
    }

    public void OpenVisitUI(GameObject planetVisiting)
    {
        if (!planetPanel.activeSelf)
        {
            Planet planet = planetVisiting.GetComponent<Planet>();
            visitingPlanetNameText.text = planet.GetPlanetInfo().GetPlanetName();
            
            visitButton.onClick.AddListener(() =>
            {
                planet.Visit();
                visitingPanel.SetActive(false);
            });
            visitingPanel.transform.position = Camera.main.WorldToScreenPoint(planetVisiting.transform.position);

            if (!visitingPanel.activeSelf)
                visitingPanel.SetActive(true);
        }
    }
    public void CloseVisitUI(GameObject planetVisiting)
    {

        Planet planet = planetVisiting.GetComponent<Planet>();

        if (visitingPlanetNameText.text.Equals(planet.GetPlanetInfo().GetPlanetName()))
        {
            //Debug.Log("Closing VisitUI");
            visitingPanel.SetActive(false);
            visitButton.onClick.RemoveAllListeners();
            visitingPlanetNameText.text = "";
        }

    }

    public void DisableUI()
    {
        Debug.Log("closing");
        planetPanel.SetActive(false);
        visitingPanel.SetActive(false);
        playerCanvas.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Planet.OnVisit -= OpenUI;
    }

    void SetupTradeButtons()
    {
        playerBuyText.text = currentPlanet.GetComponent<Planet>().GetPlanetInfo().GetBuy();
        planetSellText.text = currentPlanet.GetComponent<Planet>().GetPlanetInfo().GetSell();
        Debug.Log(currentPlanet.GetComponent<Planet>().GetPlanetInfo().GetBuy());
    }

}
