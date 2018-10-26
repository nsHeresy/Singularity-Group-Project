using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundTeleport : MonoBehaviour {

    public GameObject player;           //the player object to move around


    //watches for when there is a collision
    private void OnTriggerExit(Collider other)
    {

        Transform T = other.gameObject.GetComponent<Transform>();

        Vector3 pos = T.position;
        Vector3 newPos = pos * -1;

        player.transform.position = newPos;

    }
}
