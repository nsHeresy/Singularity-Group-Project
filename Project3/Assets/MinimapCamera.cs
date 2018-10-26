using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    public GameObject player;
    
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y + 100, playerPos.z);
	}
}
