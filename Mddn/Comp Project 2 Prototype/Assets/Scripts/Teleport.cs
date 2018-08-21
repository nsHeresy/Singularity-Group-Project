using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {

    public GameObject sisterWormhole;
    public GameObject player;
    public Image panel;

    public float teleportCooldown = 3f;
    public float timeSinceLastTeleport = 3f;
    


    // Update is called once per frame
    void Update () {
        if (timeSinceLastTeleport > 0)
            timeSinceLastTeleport -= Time.deltaTime;

        if (timeSinceLastTeleport < 0)
            timeSinceLastTeleport = 0;

        if (isPlayerInDistance() && timeSinceLastTeleport <= 0) {
            TeleportPlayer();
        }
	}

    void TeleportPlayer() {

        Color whiteFlash = new Color(255f, 255f, 255f, 255f);
        Color transparent = new Color(1f, 1f, 1f, 0f);
        panel.GetComponent<FadeIn>().PanelFade(whiteFlash,.5f,false);
        panel.GetComponent<FadeIn>().PanelFade(transparent, 0.5f, false);

        timeSinceLastTeleport = teleportCooldown;

        Vector3 thisPosition = sisterWormhole.transform.position;
        Vector3 direction = sisterWormhole.transform.forward;

        sisterWormhole.GetComponent<Teleport>().timeSinceLastTeleport = teleportCooldown;

        player.transform.position = thisPosition;
        player.transform.forward = direction;
        

    }

    bool isPlayerInDistance()
    {
        if(player != null)
            return (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 30);
        return false;
    }
}
