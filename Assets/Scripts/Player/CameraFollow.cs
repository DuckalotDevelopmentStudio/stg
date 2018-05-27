using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float smoothAmount = 0.5f;
    private Vector3 velocity;
	
    void Start() {
        if(!player)
            player = GameObject.FindObjectOfType<Player>().gameObject.transform;
    }
	void LateUpdate () {
        transform.position = Vector3.SmoothDamp(transform.position, 
                                                new Vector3(player.position.x, player.position.y + yOffset, player.position.z), 
                                                ref velocity, 
                                                smoothAmount);
	}
}
