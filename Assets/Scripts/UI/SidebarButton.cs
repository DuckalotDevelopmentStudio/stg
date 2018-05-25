using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidebarButton : MonoBehaviour {

    [SerializeField]
    private int outDistance;
    [SerializeField]
    private int inDistance;
    bool isOut = false;

    public void Click()
    {
        if(!isOut)
        {
            transform.position = new Vector3(outDistance, transform.position.y);
            isOut = true;
        } else
        {
            transform.position = new Vector3(inDistance, transform.position.y);
            isOut = false;
        }
    }
	
}
