using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour {

    public GameObject player;
    public PlayerFlightControl control;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isPlayerInDistance()) {
            control.driverSelfDestruct();
        }
	}

    bool isPlayerInDistance() {
        return (Vector3.Distance(gameObject.transform.position, player.transform.position)<= 75);
    }
}
