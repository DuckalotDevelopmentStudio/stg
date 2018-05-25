using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlanet : MonoBehaviour {

    public static PlanetInfo currentPlanet;

    private void Start()
    {
        Planet.OnVisit += ChangeCurrentPlanet;
    }

    void ChangeCurrentPlanet(GameObject planetVisited)
    {
        currentPlanet = planetVisited.GetComponent<Planet>().GetPlanetInfo();
    }

    public PlanetInfo GetCurrentPlanet()
    {
        return currentPlanet;
    }
}
