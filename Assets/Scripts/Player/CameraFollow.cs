using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float yOffset;
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        transform.position += new Vector3(0, yOffset);
	}
}
