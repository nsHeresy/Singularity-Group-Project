﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class Player : Targetable
{
    public float curHealth;
    public float maxHealth;

    public float healFactor;

	public static Vector3 PlayerPosition;

	private void Start () {
        curHealth = 50;
        maxHealth = 100;

        healFactor = 2;
}
	
	private void Update ()
	{
		PlayerPosition = transform.position;

        RegenHealth();
	}

    void RegenHealth() {
        curHealth += Time.deltaTime * healFactor;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }
	
}
