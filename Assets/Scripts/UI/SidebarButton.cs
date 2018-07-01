using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidebarButton : MonoBehaviour {
    
    private int outDistance = 0;
    private float inDistance;
    bool isOut = false;

    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        inDistance = -rectTransform.rect.width + transform.GetChild(0).GetComponent<RectTransform>().rect.width;
    }

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
