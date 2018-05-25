using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnableOrDisable()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }
}
