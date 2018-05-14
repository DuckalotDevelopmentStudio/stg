using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour {

    public delegate void VisitPlanet();
    public event VisitPlanet OnVisit;

    PlanetInfo info;
	private PlanetUI ui;
    TextAsset textFile;

	void Awake(){
        CreatePlanet();
	}

	public void Visit(){
        OnVisit();
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Visit();
		}
	}

    void CreatePlanet()
    {
        textFile = Resources.Load("Planets/Planet_Hubble") as TextAsset;
        info = new PlanetInfo(textFile, 10f);
    }
    //Returns Info on Planet
    public PlanetInfo GetPlanetInfo()
    {
        return info;
    }

}
