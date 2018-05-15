using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{

    public delegate void VisitPlanet(GameObject planetToVisit);
    public static event VisitPlanet OnVisit;

    [SerializeField]
    private string planetInfoFilePath = null;

    private PlanetInfo planetInfo;
    private PlanetUI planetUI;

    void Awake()
    {
        SetPlanetInfo(planetInfoFilePath);
    }

    public void Visit()
    {
        if (OnVisit != null)
        {
            OnVisit(gameObject);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Visit();
        }
    }

    void SetPlanetInfo(string path)
    {
        TextAsset planetInfoTextFile = Resources.Load(path) as TextAsset;
        planetInfo = new PlanetInfo(planetInfoTextFile, 10f);
    }
    public PlanetInfo GetPlanetInfo()
    {
        return planetInfo;
    }
}
