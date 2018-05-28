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
    [SerializeField]
    private GameObject spaceship;
    [SerializeField]
    private float money = 0;
    private PlanetInfo planetInfo;
    [SerializeField]
    private PlanetUI planetUI;

    public float visitDistance = 3f;
    public float timer = 1f;

    void Start()
    {
        planetInfo = new PlanetInfo(Resources.Load(planetInfoFilePath) as TextAsset, money);
    }

    void OnMouseOver()

    {
        if (Input.GetMouseButtonDown(0))
        {
            Visit();
        }
    }

    private void Update()
    {
        //Debug.Log(Vector3.Distance(GetComponent<Transform>().position, spaceship.transform.position));
        if(Vector3.Distance(gameObject.transform.position, spaceship.transform.position) < visitDistance)
        {
            planetUI.OpenVisitUI(gameObject);
            //Debug.Log("Player is near: " + planetInfo.GetPlanetName());
        }
        else
        {
            planetUI.CloseVisitUI(gameObject);
        }
        
    }

    public void Visit()
    {
        if (OnVisit != null)
        {
            OnVisit(gameObject);
        }
        else
        {
            //Debug.Log("Onvisit == null");
        }
    }
    
    public PlanetInfo GetPlanetInfo()
    {
        return planetInfo;
    }
}
