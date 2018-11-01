using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundTeleport : MonoBehaviour {

    public GameObject player;           //the player object to move around
    public Image panel;                 //the UI panel which can be darkened during this movement.

    //watches for when there is a collision
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;
        
        Transform T = other.gameObject.GetComponent<Transform>();

        Vector3 pos = T.position;
        Vector3 newPos = pos * -1;

        player.transform.position = newPos;

        //Color whiteFlash = new Color(255f, 255f, 255f, 255f);
        // Color transparent = new Color(0f, 0f, 0f, 0f);
        //panel.GetComponent<FadeIn>().PanelFade(whiteFlash, 1f, false);
        //panel.GetComponent<FadeIn>().PanelFade(transparent, 20f, false);
        panel.GetComponent<FadeIn>().Flash();

    }
}
