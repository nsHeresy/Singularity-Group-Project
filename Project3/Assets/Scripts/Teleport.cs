using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {

    public GameObject sisterWormhole;   //the paired wormhole to move the player to, on collision
    public GameObject player;           //the player object to move around

    public float teleportCooldown = 3f;     //how long before the same wormhole can teleport you again
    public float timeSinceLastTeleport = 3f;        //cooldown enforcing
    


    // Update is called once per frame
    void Update () {
        //lower the cooldown every frame
        if (timeSinceLastTeleport > 0)
            timeSinceLastTeleport -= Time.deltaTime;

        //ensure the cooldown doesn't go too far below 0
        if (timeSinceLastTeleport < 0)
            timeSinceLastTeleport = 0;

        //if the cooldown is off and player is in range, teleport them
        if (isPlayerInDistance() && timeSinceLastTeleport <= 0) {
            TeleportPlayer();
        }
	}

    /// <summary>
    /// Flashes the screen, then moves the player to the position of the sister wormhole.
    /// Starts the cooldown of both wormholes, so that the player isn't immediately teleported back.
    /// Player keeps their velocity, takes direction and location of wormhole.
    /// </summary>
    void TeleportPlayer() {

        timeSinceLastTeleport = teleportCooldown;

        Vector3 thisPosition = sisterWormhole.transform.position;
        Vector3 direction = sisterWormhole.transform.forward;

        sisterWormhole.GetComponent<Teleport>().timeSinceLastTeleport = teleportCooldown;

        player.transform.position = thisPosition;
        player.transform.forward = direction;
        

    }

    /// <summary>
    /// Checks if the player is within range to be teleported
    /// </summary>
    /// <returns>True if the player is in range of the wormhole, False if they're not</returns>
    bool isPlayerInDistance()
    {
        if (player != null)
        {
            var result =  (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 50);
            return result;
        }
        return false;
    }
}
