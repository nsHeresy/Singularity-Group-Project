using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject player;
    public float healthPercent = 1f;
   

    private Player playerTargetable;
    private float healthFullWidth;

	// Use this for initialization
	void Start () {
        playerTargetable = player.GetComponent<Player>();
        healthPercent = playerTargetable.CurHealth / playerTargetable.MaxHealth;
        var healthBarRect = transform as RectTransform;
        healthFullWidth = healthBarRect.sizeDelta.x;
	}
	
	// After HP is updated
	void LateUpdate ()
    {
        //reset the width of the health bar
        var healthBarRect = transform as RectTransform;
        healthBarRect.sizeDelta = new Vector2(healthFullWidth, healthBarRect.sizeDelta.y);

        // calculate % width
        healthPercent = playerTargetable.CurHealth / playerTargetable.MaxHealth;

        //calculate new width and apply
        var curWidth = healthBarRect.rect.width;
        curWidth *= healthPercent;
        healthBarRect.sizeDelta = new Vector2(curWidth, healthBarRect.sizeDelta.y);
    }
}
